-- =========================================================================
-- SCRIPT SETUP DATABASE PASTANI - FITUR KARYAWAN (VERSI LENGKAP)
-- =========================================================================
-- Cara Penggunaan:
-- 1. Buka pgAdmin dan hubungkan ke server PostgreSQL Anda.
-- 2. Pilih database "projek_semester2".
-- 3. Buka Query Tool (Klik Kanan Database -> Query Tool).
-- 4. Copy seluruh isi file ini, paste ke Query Tool, dan jalankan (F5).
-- =========================================================================

BEGIN;

-- 1. Pembuatan tabel pengeluaran (untuk pencatatan rekap keuangan)
CREATE TABLE IF NOT EXISTS pengeluaran (
    pengeluaran_id SERIAL PRIMARY KEY,
    deskripsi TEXT NOT NULL,
    jumlah NUMERIC NOT NULL,
    created_at TIMESTAMP DEFAULT NOW(),
    created_by INT REFERENCES users(users_id) ON DELETE SET NULL
);

-- 2. Seeding data status_distribusi jika kosong
INSERT INTO status_distribusi (status_distribusi_id, status_distribusi)
VALUES 
    (1, 'Diproses'),
    (2, 'Dikirim'),
    (3, 'Diterima')
ON CONFLICT (status_distribusi_id) DO NOTHING;

-- 3. Prosedur untuk menyelesaikan checkout pesanan secara otomatis
--    (Membuat data transaksi & detail transaksi pembelian/sewa)
CREATE OR REPLACE PROCEDURE public.checkout_pesanan(IN p_pesanan_id integer)
LANGUAGE 'plpgsql'
AS $$
DECLARE
    v_transaksi_id int;
    v_users_id int;
    v_opsi varchar;
    v_distribusi_id int;
    r_detail_pembelian RECORD;
    r_detail_sewa RECORD;
BEGIN
    -- Ambil info pesanan
    SELECT users_id, opsi_pengiriman
    INTO v_users_id, v_opsi
    FROM pesanan
    WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Belum Checkout';

    IF v_users_id IS NULL THEN
        RAISE EXCEPTION 'Pesanan tidak ditemukan atau sudah di-checkout.';
    END IF;

    -- Update status pesanan
    UPDATE pesanan
    SET status_pesanan = 'Sudah Checkout'
    WHERE pesanan_id = p_pesanan_id;

    -- Tentukan status distribusi awal
    IF v_opsi = 'diantar' THEN
        v_distribusi_id := 1; -- Diproses
    ELSE
        v_distribusi_id := NULL; -- Ambil sendiri (tidak dikirim)
    END IF;

    -- Buat record transaksi utama
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, metode_pembayaran, status_pembayaran)
    VALUES (NOW(), 'Checkout pesanan ID ' || p_pesanan_id, v_users_id, 'Diproses', v_distribusi_id, 'Cash', 'belum lunas')
    RETURNING transaksi_id INTO v_transaksi_id;

    -- Salin detail pembelian ke transaksi
    FOR r_detail_pembelian IN 
        SELECT quantity, harga_per_item, barang_id 
        FROM detail_pesanan_pembelian 
        WHERE pesanan_id = p_pesanan_id
    LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id)
        VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;

    -- Salin detail sewa ke transaksi
    FOR r_detail_sewa IN 
        SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id 
        FROM detail_pesanan_sewa 
        WHERE pesanan_id = p_pesanan_id
    LOOP
        INSERT INTO detail_transaksi_sewa (quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, 1);
    END LOOP;
END;
$$;

-- 4. VIEW: Detail Transaksi Dashboard Karyawan
CREATE OR REPLACE VIEW v_karyawan_dashboard_transaksi AS
SELECT 
    t.transaksi_id,
    t.created_at,
    t.catatan,
    u.nama AS nama_user,
    COALESCE(b.nama_barang, a.nama_alat) AS barang_atau_alat,
    COALESCE(dp.quantity, ds.quantity) AS jumlah,
    (COALESCE(dp.quantity, ds.quantity) * COALESCE(dp.harga_per_item, ds.harga_sewa_perhari))::numeric AS total,
    CASE 
        WHEN p.opsi_pengiriman = 'diantar' THEN COALESCE(k.nama_kurir, '-') 
        ELSE '-' 
    END AS nama_kurir,
    t.status_transaksi,
    COALESCE(sd.status_distribusi, '-') AS status_distribusi,
    CASE 
        WHEN ds.detail_transaksi_sewa_id IS NOT NULL THEN op.opsi_pengembalian 
        ELSE '-' 
    END AS opsi_pengembalian,
    t.metode_pembayaran,
    t.status_pembayaran
FROM transaksi t
LEFT JOIN users u ON t.users_id = u.users_id
LEFT JOIN pesanan p ON t.users_id = p.users_id AND p.status_pesanan = 'Sudah Checkout'
LEFT JOIN kurir k ON t.kurir_id = k.kurir_id
LEFT JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id
LEFT JOIN detail_transaksi_pembelian dp ON t.transaksi_id = dp.transaksi_id
LEFT JOIN barang b ON dp.barang_id = b.barang_id
LEFT JOIN detail_transaksi_sewa ds ON t.transaksi_id = ds.transaksi_id
LEFT JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
LEFT JOIN opsi_pengembalian op ON ds.opsi_pengembalian_id = op.opsi_pengembalian_id;

-- 5. VIEW: Fitur Update Stok Barang & Alat (Tanpa kolom update_at/by)
CREATE OR REPLACE VIEW v_update_stok_barang AS
SELECT barang_id AS id, nama_barang AS nama, harga_per_item AS harga, stok FROM barang;

CREATE OR REPLACE VIEW v_update_stok_alat AS
SELECT alat_sewa_id AS id, nama_alat AS nama, harga_sewa_perhari AS harga, stok FROM alat_sewa;

-- 6. VIEW: Manajemen Distribusi (khusus pengiriman 'diantar')
CREATE OR REPLACE VIEW v_manajemen_distribusi AS
SELECT 
    t.transaksi_id,
    u.nama AS nama_user,
    COALESCE(b.nama_barang, a.nama_alat) AS nama_barang_alat,
    COALESCE(dp.quantity, ds.quantity) AS jumlah,
    (COALESCE(dp.quantity, ds.quantity) * COALESCE(dp.harga_per_item, ds.harga_sewa_perhari))::numeric AS total,
    t.status_pembayaran,
    COALESCE(sd.status_distribusi, '-') AS status_distribusi,
    COALESCE(k.nama_kurir, '-') AS nama_kurir,
    t.status_transaksi
FROM transaksi t
JOIN users u ON t.users_id = u.users_id
LEFT JOIN kurir k ON t.kurir_id = k.kurir_id
LEFT JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id
LEFT JOIN detail_transaksi_pembelian dp ON t.transaksi_id = dp.transaksi_id
LEFT JOIN barang b ON dp.barang_id = b.barang_id
LEFT JOIN detail_transaksi_sewa ds ON t.transaksi_id = ds.transaksi_id
LEFT JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
WHERE t.status_distribusi_id IS NOT NULL;

-- 7. VIEW: Rekap Denda Keterlambatan Sewa Alat
CREATE OR REPLACE VIEW v_laporan_denda AS
SELECT 
    ds.detail_transaksi_sewa_id AS denda_id,
    u.nama AS nama_petani,
    a.nama_alat,
    ds.tgl_pengembalian AS tgl_seharusnya_kembali,
    CURRENT_DATE AS tgl_sekarang,
    CASE 
        WHEN CURRENT_DATE > ds.tgl_pengembalian THEN (CURRENT_DATE - ds.tgl_pengembalian)
        ELSE 0 
    END AS hari_keterlambatan,
    a.harga_denda_perhari,
    CASE 
        WHEN CURRENT_DATE > ds.tgl_pengembalian THEN (CURRENT_DATE - ds.tgl_pengembalian) * a.harga_denda_perhari
        ELSE 0::numeric
    END AS total_denda,
    ds.status_sewa AS status_pembayaran
FROM detail_transaksi_sewa ds
JOIN transaksi t ON ds.transaksi_id = t.transaksi_id
JOIN users u ON t.users_id = u.users_id
JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id;

-- 8. VIEW: Laporan Rekap Keuangan (Pemasukan vs Pengeluaran)
CREATE OR REPLACE VIEW v_karyawan_keuangan AS
SELECT 'Penjualan'::varchar AS tipe, b.nama_barang AS keterangan, (dp.quantity * dp.harga_per_item)::numeric AS jumlah, t.created_at, u.nama AS oleh 
FROM detail_transaksi_pembelian dp 
JOIN transaksi t ON dp.transaksi_id = t.transaksi_id 
JOIN barang b ON dp.barang_id = b.barang_id 
JOIN users u ON t.users_id = u.users_id 
WHERE t.status_pembayaran = 'lunas'
UNION ALL
SELECT 'Sewa Alat'::varchar AS tipe, a.nama_alat AS keterangan, (ds.quantity * ds.harga_sewa_perhari * (ds.tgl_pengembalian - ds.tgl_sewa))::numeric AS jumlah, t.created_at, u.nama AS oleh 
FROM detail_transaksi_sewa ds 
JOIN transaksi t ON ds.transaksi_id = t.transaksi_id 
JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id 
JOIN users u ON t.users_id = u.users_id 
WHERE t.status_pembayaran = 'lunas'
UNION ALL
SELECT 'Denda'::varchar AS tipe, 'Denda keterlambatan ' || a.nama_alat AS keterangan, ds.denda AS jumlah, t.created_at, u.nama AS oleh 
FROM detail_transaksi_sewa ds 
JOIN transaksi t ON ds.transaksi_id = t.transaksi_id 
JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id 
JOIN users u ON t.users_id = u.users_id 
WHERE ds.denda > 0 AND ds.status_sewa = 'Lunas'
UNION ALL
SELECT 'Pengeluaran'::varchar AS tipe, p.deskripsi AS keterangan, -p.jumlah AS jumlah, p.created_at, u.nama AS oleh 
FROM pengeluaran p 
LEFT JOIN users u ON p.created_by = u.users_id;

-- 9. FUNCTION: Hitung Statistik Dashboard Harian (Total Transaksi & Jumlah Barang/Alat Dikirim)
CREATE OR REPLACE FUNCTION f_get_dashboard_stats(p_tanggal date)
RETURNS TABLE(total_transaksi bigint, barang_dikirim bigint) AS $$
BEGIN
    RETURN QUERY
    SELECT 
        COUNT(DISTINCT t.transaksi_id)::bigint,
        COALESCE(SUM(dp.quantity), 0)::bigint + COALESCE(SUM(ds.quantity), 0)::bigint
    FROM transaksi t
    LEFT JOIN detail_transaksi_pembelian dp ON t.transaksi_id = dp.transaksi_id
    LEFT JOIN detail_transaksi_sewa ds ON t.transaksi_id = ds.transaksi_id
    WHERE DATE(t.created_at) = p_tanggal;
END;
$$ LANGUAGE plpgsql;

-- 10. PROCEDURE: Update Status Pembayaran (Lunas/belum lunas)
CREATE OR REPLACE PROCEDURE p_update_status_pembayaran(p_transaksi_id int, p_status varchar)
AS $$
BEGIN
    UPDATE transaksi SET status_pembayaran = p_status WHERE transaksi_id = p_transaksi_id;
END;
$$ LANGUAGE plpgsql;

-- 11. PROCEDURE: Update Status Transaksi (Selesai/Diproses/dll.)
-- Aturan: Transaksi yang diantar hanya bisa diselesaikan jika pembayaran lunas dan distribusi 'Diterima'.
CREATE OR REPLACE PROCEDURE p_update_status_transaksi(p_transaksi_id int, p_status varchar)
AS $$
DECLARE
    v_pembayaran varchar;
    v_distribusi varchar;
    v_distribusi_id int;
BEGIN
    SELECT t.status_pembayaran, sd.status_distribusi, t.status_distribusi_id
    INTO v_pembayaran, v_distribusi, v_distribusi_id
    FROM transaksi t
    LEFT JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id
    WHERE t.transaksi_id = p_transaksi_id;

    IF v_distribusi_id IS NOT NULL AND (v_pembayaran != 'lunas' OR v_distribusi != 'Diterima') THEN
        RAISE EXCEPTION 'Transaksi opsi diantar hanya bisa diselesaikan jika pembayaran lunas dan distribusi Diterima!';
    END IF;

    UPDATE transaksi SET status_transaksi = p_status WHERE transaksi_id = p_transaksi_id;
END;
$$ LANGUAGE plpgsql;

-- 12. PROCEDURE: Update Stok Barang atau Alat Sewa
-- Menggunakan set_config() untuk mencatat user sesi saat ini tanpa kolom updated_by/at di tabel utama
CREATE OR REPLACE PROCEDURE p_update_stok(p_id int, p_stok_baru int, p_jenis varchar, p_karyawan_username varchar)
LANGUAGE plpgsql
AS $$
BEGIN
    -- Set local session parameter agar bisa dibaca trigger audit
    PERFORM set_config('myapp.current_user', p_karyawan_username, true);

    IF p_jenis = 'barang' THEN
        UPDATE barang SET stok = p_stok_baru WHERE barang_id = p_id;
    ELSE
        UPDATE alat_sewa SET stok = p_stok_baru WHERE alat_sewa_id = p_id;
    END IF;
END;
$$;

-- 13. PROCEDURE: Tambah Data Pengeluaran Baru
CREATE OR REPLACE PROCEDURE public.p_add_pengeluaran(p_deskripsi text, p_jumlah numeric, p_karyawan_id int)
LANGUAGE plpgsql
AS $$
BEGIN
    INSERT INTO pengeluaran (deskripsi, jumlah, created_at, created_by)
    VALUES (p_deskripsi, p_jumlah, NOW(), p_karyawan_id);
END;
$$;

-- 14. AUDIT LOG TRIGGER: Log Perubahan Stok (Barang & Alat)
-- Membaca config 'myapp.current_user' untuk melacak nama pengubah stok secara dinamis
CREATE OR REPLACE FUNCTION log_audit_stok() RETURNS trigger AS $$
DECLARE
    v_user varchar;
END;
$$ LANGUAGE plpgsql;
-- Note: schema already exists in user's database. We use the trigger defined in the dump.
-- To be safe, we keep the original logic from the dump.
-- Let's define the full audit trigger function properly:
CREATE OR REPLACE FUNCTION log_audit_stok() RETURNS trigger AS $$
DECLARE
    v_user varchar;
BEGIN
    v_user := current_setting('myapp.current_user', true);

    INSERT INTO audit_stok_barang_alat(stok_awal, stok_akhir, keterangan, waktu_perubahan, users_id)
    VALUES (
        OLD.stok, 
        NEW.stok, 
        'Update stok oleh ' || COALESCE(v_user, 'Sistem'), 
        NOW(),
        (SELECT users_id FROM users WHERE username = v_user LIMIT 1)
    );
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_audit_stok_barang ON barang;
CREATE TRIGGER t_audit_stok_barang
AFTER UPDATE OF stok ON barang
FOR EACH ROW EXECUTE FUNCTION log_audit_stok();

DROP TRIGGER IF EXISTS t_audit_stok_alat ON alat_sewa;
CREATE TRIGGER t_audit_stok_alat
AFTER UPDATE OF stok ON alat_sewa
FOR EACH ROW EXECUTE FUNCTION log_audit_stok();

-- 15. AUDIT LOG TRIGGER: Log Perubahan Status Pembayaran / Transaksi
CREATE OR REPLACE FUNCTION log_audit_transaksi() RETURNS trigger AS $$
BEGIN
    INSERT INTO audit_transaksi(aksi, waktu_perubahan, kolom_perubahan, value_lama, value_baru, transaksi_id, users_id)
    VALUES (
        'UPDATE', 
        NOW(), 
        'status_pembayaran / status_transaksi', 
        'Pembayaran: ' || OLD.status_pembayaran || ', Transaksi: ' || OLD.status_transaksi, 
        'Pembayaran: ' || NEW.status_pembayaran || ', Transaksi: ' || NEW.status_transaksi,
        OLD.transaksi_id,
        OLD.users_id
    );
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS t_audit_transaksi ON transaksi;
CREATE TRIGGER t_audit_transaksi
AFTER UPDATE OF status_pembayaran OR status_transaksi ON transaksi
FOR EACH ROW EXECUTE FUNCTION log_audit_transaksi();

COMMIT;
