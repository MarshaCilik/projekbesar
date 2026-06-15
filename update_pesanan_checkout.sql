-- =========================================================================
-- SCRIPT UPDATE: MANAJEMEN TRANSAKSI CHECKOUT & VALIDASI STOK
-- =========================================================================
-- Hubungkan ke database "projek_semester2" di pgAdmin dan jalankan skrip ini (F5)
-- =========================================================================

BEGIN;

-- 1. VIEW untuk Menampilkan Pesanan yang Sudah Checkout beserta Stok Saat Ini
CREATE OR REPLACE VIEW public.v_pesanan_checkout AS
SELECT 
    p.pesanan_id AS "ID Pesanan",
    u.nama AS "Nama Petani",
    p.tanggal_pesanan::date AS "Tanggal Pesanan",
    p.opsi_pengiriman AS "Pengiriman",
    b.nama_barang AS "Nama Item",
    dp.quantity AS "Jumlah",
    b.stok AS "Stok Sekarang",
    'Pembelian'::text AS "Jenis",
    b.barang_id AS "Item ID",
    p.status_pesanan AS "Status"
FROM pesanan p
JOIN users u ON p.users_id = u.users_id
JOIN detail_pesanan_pembelian dp ON p.pesanan_id = dp.pesanan_id
JOIN barang b ON dp.barang_id = b.barang_id
WHERE p.status_pesanan = 'Sudah Checkout'

UNION ALL

SELECT 
    p.pesanan_id AS "ID Pesanan",
    u.nama AS "Nama Petani",
    p.tanggal_pesanan::date AS "Tanggal Pesanan",
    p.opsi_pengiriman AS "Pengiriman",
    a.nama_alat AS "Nama Item",
    ds.quantity AS "Jumlah",
    a.stok AS "Stok Sekarang",
    'Penyewaan'::text AS "Jenis",
    a.alat_sewa_id AS "Item ID",
    p.status_pesanan AS "Status"
FROM pesanan p
JOIN users u ON p.users_id = u.users_id
JOIN detail_pesanan_sewa ds ON p.pesanan_id = ds.pesanan_id
JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
WHERE p.status_pesanan = 'Sudah Checkout';

ALTER TABLE public.v_pesanan_checkout OWNER TO postgres;


-- 2. PROSEDUR untuk Menerima Pesanan (Validasi & Kurangi Stok Otomatis, Kirim ke Transaksi)
CREATE OR REPLACE PROCEDURE public.p_terima_pesanan(IN p_pesanan_id integer, IN p_karyawan_username varchar)
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
    -- 1. Ambil info pesanan yang berstatus 'Sudah Checkout'
    SELECT users_id, opsi_pengiriman
    INTO v_users_id, v_opsi
    FROM pesanan
    WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Sudah Checkout';

    IF v_users_id IS NULL THEN
        RAISE EXCEPTION 'Pesanan dengan ID % tidak ditemukan atau statusnya bukan Sudah Checkout.', p_pesanan_id;
    END IF;

    -- 2. VALIDASI STOK BARANG & KURANGI STOK
    FOR r_detail_pembelian IN 
        SELECT dp.barang_id, dp.quantity, b.nama_barang, b.stok 
        FROM detail_pesanan_pembelian dp
        JOIN barang b ON dp.barang_id = b.barang_id
        WHERE dp.pesanan_id = p_pesanan_id
    LOOP
        IF r_detail_pembelian.stok < r_detail_pembelian.quantity THEN
            RAISE EXCEPTION 'Stok barang % tidak mencukupi! Stok saat ini: %, dipesan: %', 
                r_detail_pembelian.nama_barang, r_detail_pembelian.stok, r_detail_pembelian.quantity;
        END IF;
        
        -- Kurangi stok
        UPDATE barang 
        SET stok = stok - r_detail_pembelian.quantity 
        WHERE barang_id = r_detail_pembelian.barang_id;
    END LOOP;

    -- VALIDASI STOK ALAT SEWA & KURANGI STOK
    FOR r_detail_sewa IN 
        SELECT ds.alat_sewa_id, ds.quantity, a.nama_alat, a.stok 
        FROM detail_pesanan_sewa ds
        JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
        WHERE ds.pesanan_id = p_pesanan_id
    LOOP
        IF r_detail_sewa.stok < r_detail_sewa.quantity THEN
            RAISE EXCEPTION 'Stok alat sewa % tidak mencukupi! Stok saat ini: %, dipesan: %', 
                r_detail_sewa.nama_alat, r_detail_sewa.stok, r_detail_sewa.quantity;
        END IF;
        
        -- Kurangi stok
        UPDATE alat_sewa 
        SET stok = stok - r_detail_sewa.quantity 
        WHERE alat_sewa_id = r_detail_sewa.alat_sewa_id;
    END LOOP;

    -- 3. Update status pesanan menjadi 'Selesai'
    UPDATE pesanan
    SET status_pesanan = 'Selesai'
    WHERE pesanan_id = p_pesanan_id;

    -- 4. Tentukan status distribusi awal
    IF v_opsi = 'diantar' THEN
        v_distribusi_id := 1; -- Diproses
    ELSE
        v_distribusi_id := NULL; -- Ambil sendiri (tidak dikirim)
    END IF;

    -- 5. Buat record transaksi utama
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, metode_pembayaran, status_pembayaran)
    VALUES (NOW(), 'Penerimaan pesanan ID ' || p_pesanan_id || ' oleh ' || p_karyawan_username, v_users_id, 'Diproses', v_distribusi_id, 'Cash', 'belum lunas')
    RETURNING transaksi_id INTO v_transaksi_id;

    -- 6. Salin detail pembelian ke transaksi
    FOR r_detail_pembelian IN 
        SELECT quantity, harga_per_item, barang_id 
        FROM detail_pesanan_pembelian 
        WHERE pesanan_id = p_pesanan_id
    LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id)
        VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;

    -- 7. Salin detail sewa ke transaksi
    FOR r_detail_sewa IN 
        SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id 
        FROM detail_pesanan_sewa 
        WHERE pesanan_id = p_pesanan_id
    LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, 1);
    END LOOP;

END;
$$;

ALTER PROCEDURE public.p_terima_pesanan(IN p_pesanan_id integer, IN p_karyawan_username varchar) OWNER TO postgres;


-- 3. PROSEDUR untuk Membatalkan Pesanan dengan Alasan Tertentu
CREATE OR REPLACE PROCEDURE public.p_batal_pesanan(IN p_pesanan_id integer, IN p_alasan text)
LANGUAGE 'plpgsql'
AS $$
BEGIN
    UPDATE pesanan
    SET status_pesanan = 'Dibatalkan',
        opsi_pengiriman = COALESCE(opsi_pengiriman, '') || ' (Batal: ' || p_alasan || ')'
    WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Sudah Checkout';
END;
$$;

ALTER PROCEDURE public.p_batal_pesanan(IN p_pesanan_id integer, IN p_alasan text) OWNER TO postgres;

COMMIT;
