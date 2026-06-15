-- ==========================================
-- SCRIPT INISIALISASI DATABASE PASTANI
-- ==========================================

-- 1. TABEL KATEGORI
CREATE TABLE IF NOT EXISTS kategori (
    kategori_id SERIAL PRIMARY KEY,
    kategori VARCHAR(100) NOT NULL UNIQUE,
    deskripsi TEXT
);

-- 2. TABEL BARANG
CREATE TABLE IF NOT EXISTS barang (
    barang_id SERIAL PRIMARY KEY,
    nama_barang VARCHAR(150) NOT NULL UNIQUE,
    stok INT NOT NULL DEFAULT 0 CHECK (stok >= 0),
    harga_per_item DECIMAL(12, 2) NOT NULL DEFAULT 0 CHECK (harga_per_item >= 0),
    kategori_id INT REFERENCES kategori(kategori_id) ON DELETE SET NULL,
    created_at TIMESTAMP DEFAULT NOW()
);

-- 3. TABEL ALAT SEWA
CREATE TABLE IF NOT EXISTS alat_sewa (
    alat_sewa_id SERIAL PRIMARY KEY,
    nama_alat VARCHAR(150) NOT NULL UNIQUE,
    stok INT NOT NULL DEFAULT 0 CHECK (stok >= 0),
    harga_sewa_perhari DECIMAL(12, 2) NOT NULL DEFAULT 0 CHECK (harga_sewa_perhari >= 0),
    harga_denda_perhari DECIMAL(12, 2) NOT NULL DEFAULT 0 CHECK (harga_denda_perhari >= 0),
    kategori_id INT REFERENCES kategori(kategori_id) ON DELETE SET NULL,
    added_at TIMESTAMP DEFAULT NOW()
);

-- 4. TABEL AUDIT STOK BARANG & ALAT
CREATE TABLE IF NOT EXISTS audit_stok_barang_alat (
    audit_stok_barang_alat_id SERIAL PRIMARY KEY,
    stok_awal INT,
    stok_akhir INT,
    keterangan TEXT,
    waktu_perubahan TIMESTAMP DEFAULT NOW(),
    barang_id INT REFERENCES barang(barang_id) ON DELETE CASCADE,
    alat_sewa_id INT REFERENCES alat_sewa(alat_sewa_id) ON DELETE CASCADE
);

-- ==========================================
-- SEED DATA AWAL (JIKA KOSONG)
-- ==========================================
INSERT INTO kategori (kategori, deskripsi) VALUES 
('Pupuk', 'Berbagai macam pupuk pertanian'),
('Bibit Tanaman', 'Bibit tanaman pangan dan hias'),
('Alat Berat', 'Peralatan bertani ukuran besar'),
('Alat Ringan', 'Peralatan bertani manual tangan')
ON CONFLICT (kategori) DO NOTHING;

INSERT INTO barang (nama_barang, stok, harga_per_item, kategori_id) VALUES 
('Pupuk Urea 50kg', 100, 150000.00, 1),
('Pupuk NPK Mutiara 1kg', 250, 25000.00, 1),
('Bibit Padi Pandanwangi 5kg', 80, 75000.00, 2),
('Bibit Jagung Manis 1kg', 120, 45000.00, 2)
ON CONFLICT (nama_barang) DO NOTHING;

INSERT INTO alat_sewa (nama_alat, stok, harga_sewa_perhari, harga_denda_perhari, kategori_id) VALUES 
('Traktor Kubota', 5, 250000.00, 50000.00, 3),
('Mesin Rontok Padi', 8, 120000.00, 25000.00, 3),
('Cangkul Baja', 30, 10000.00, 2000.00, 4),
('Sprayer Elektrik', 15, 30000.00, 5000.00, 4)
ON CONFLICT (nama_alat) DO NOTHING;

-- ==========================================
-- VIEW: view_katalog_alat
-- ==========================================
CREATE OR REPLACE VIEW view_katalog_alat AS
SELECT 
    a.alat_sewa_id, 
    a.nama_alat, 
    k.kategori, 
    a.stok, 
    a.harga_sewa_perhari,
    a.harga_denda_perhari
FROM alat_sewa a
LEFT JOIN kategori k ON a.kategori_id = k.kategori_id;

-- ==========================================
-- FUNCTION: hitung_total_denda
-- ==========================================
CREATE OR REPLACE FUNCTION hitung_total_denda(tgl_kembali DATE, harga_denda DECIMAL)
RETURNS DECIMAL AS $$
DECLARE
    hari_telat INT;
    total_denda DECIMAL;
BEGIN
    -- Ngitung selisih hari dari tanggal sekarang (CURRENT_DATE) ke tanggal harusnya balik
    hari_telat := CURRENT_DATE - tgl_kembali;
    
    IF hari_telat > 0 THEN
        total_denda := hari_telat * harga_denda;
    ELSE
        total_denda := 0; -- Kalo nggak telat ya dendanya 0
    END IF;
    
    RETURN total_denda;
END;
$$ LANGUAGE plpgsql;

-- ==========================================
-- TRIGGER & TRIGGER FUNCTION: catat_audit_stok_barang
-- ==========================================
CREATE OR REPLACE FUNCTION catat_audit_stok_barang()
RETURNS TRIGGER AS $$
BEGIN
    -- Cek kalo stoknya beneran berubah
    IF NEW.stok <> OLD.stok THEN
        INSERT INTO audit_stok_barang_alat (stok_awal, stok_akhir, keterangan, waktu_perubahan, barang_id)
        VALUES (OLD.stok, NEW.stok, 'Update stok barang ID: ' || NEW.barang_id || ' (' || NEW.nama_barang || ')', NOW(), NEW.barang_id);
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

-- Drop trigger if exists first
DROP TRIGGER IF EXISTS trg_audit_stok_barang ON barang;

CREATE TRIGGER trg_audit_stok_barang
AFTER UPDATE ON barang
FOR EACH ROW
EXECUTE FUNCTION catat_audit_stok_barang();

-- ==========================================
-- TRIGGER & TRIGGER FUNCTION: catat_audit_stok_alat
-- ==========================================
CREATE OR REPLACE FUNCTION catat_audit_stok_alat()
RETURNS TRIGGER AS $$
BEGIN
    IF NEW.stok <> OLD.stok THEN
        INSERT INTO audit_stok_barang_alat (stok_awal, stok_akhir, keterangan, waktu_perubahan, alat_sewa_id)
        VALUES (OLD.stok, NEW.stok, 'Update stok alat ID: ' || NEW.alat_sewa_id || ' (' || NEW.nama_alat || ')', NOW(), NEW.alat_sewa_id);
    END IF;
    RETURN NEW;
END;
$$ LANGUAGE plpgsql;

DROP TRIGGER IF EXISTS trg_audit_stok_alat ON alat_sewa;

CREATE TRIGGER trg_audit_stok_alat
AFTER UPDATE ON alat_sewa
FOR EACH ROW
EXECUTE FUNCTION catat_audit_stok_alat();

-- ==========================================
-- STORED PROCEDURE: proses_tambah_stok_barang
-- ==========================================
CREATE OR REPLACE PROCEDURE proses_tambah_stok_barang(
    p_barang_id INT,
    p_jumlah_tambah INT
)
LANGUAGE plpgsql AS $$
BEGIN
    -- Nambahin stok barang sesuai inputan admin
    UPDATE barang
    SET stok = stok + p_jumlah_tambah
    WHERE barang_id = p_barang_id;
END; 
$$;
