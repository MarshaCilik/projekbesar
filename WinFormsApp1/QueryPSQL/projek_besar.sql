--
-- PostgreSQL database dump
--

\restrict gDbhnHq5Qo9jIycmyxV4QhperdFlesqkA3zyWypUfKIWOpLt68WDwQAdNBvadGj

-- Dumped from database version 17.6
-- Dumped by pg_dump version 17.6

-- Started on 2026-06-17 07:50:38

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- TOC entry 266 (class 1255 OID 82808)
-- Name: add_alat_sewa(character varying, integer, numeric, numeric, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_alat_sewa(IN p_nama_alat character varying, IN p_stok integer, IN p_harga_sewa_perhari numeric, IN p_harga_denda_perhari numeric, IN p_nama_kategori character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_kategori_id INTEGER;
BEGIN
    -- 1. Cari tahu apakah kategori tersebut sudah terdaftar (gunakan LOWER/ILIKE agar tidak sensitif huruf besar/kecil)
    SELECT kategori_id 
    INTO v_kategori_id
    FROM kategori
    WHERE LOWER(kategori) = LOWER(p_nama_kategori)
    LIMIT 1;

    -- 2. JIKA KATEGORI BELUM ADA (v_kategori_id IS NULL), maka buat baru secara otomatis
    IF v_kategori_id IS NULL THEN
        INSERT INTO kategori (kategori, deskripsi)
        VALUES (p_nama_kategori, 'Kategori otomatis dibuat saat menambahkan alat ' || p_nama_alat)
        RETURNING kategori_id INTO v_kategori_id; -- Langsung ambil ID baru yang terbuat
    END IF;

    -- 3. Masukkan data alat sewa baru menggunakan v_kategori_id yang sudah didapatkan
    INSERT INTO alat_sewa (nama_alat, stok, harga_sewa_perhari, harga_denda_perhari, kategori_id, added_at)
    VALUES (p_nama_alat, p_stok, p_harga_sewa_perhari, p_harga_denda_perhari, v_kategori_id, CURRENT_TIMESTAMP);

END;
$$;


ALTER PROCEDURE public.add_alat_sewa(IN p_nama_alat character varying, IN p_stok integer, IN p_harga_sewa_perhari numeric, IN p_harga_denda_perhari numeric, IN p_nama_kategori character varying) OWNER TO postgres;

--
-- TOC entry 267 (class 1255 OID 82809)
-- Name: add_new_barang(character varying, integer, numeric, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_new_barang(IN p_nama_barang character varying, IN p_stok integer, IN p_harga_per_item numeric, IN p_kategori character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
	v_kategori_id int;
BEGIN
	SELECT kategori_id 
	INTO v_kategori_id
	FROM kategori
	WHERE kategori ILIKE p_kategori;

	IF v_kategori_id IS NULL THEN
		INSERT INTO kategori (kategori) VALUES (p_kategori) 
		RETURNING kategori_id INTO v_kategori_id;
	END IF;

	INSERT INTO barang (nama_barang, stok, harga_per_item, kategori_id, added_at)
	VALUES (p_nama_barang, p_stok, p_harga_per_item, v_kategori_id, now());
END;
$$;


ALTER PROCEDURE public.add_new_barang(IN p_nama_barang character varying, IN p_stok integer, IN p_harga_per_item numeric, IN p_kategori character varying) OWNER TO postgres;

--
-- TOC entry 269 (class 1255 OID 82810)
-- Name: add_new_users_petani(character varying, character varying, character varying, character varying, character varying, character varying, character varying, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_new_users_petani(IN p_nama character varying, IN p_email character varying, IN p_no_telp character varying, IN p_username character varying, IN p_password character varying, IN p_alamat character varying, IN p_kecamatan character varying, IN p_desa character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
	v_kecamatan_id INT;
	v_desa_id INT;
BEGIN
	SELECT kecamatan_id 
	INTO v_kecamatan_id
	FROM kecamatan WHERE nama_kecamatan ilike p_kecamatan;

	SELECT desa_id
	INTO v_desa_id
	FROM desa WHERE nama_desa ilike p_desa;

	IF v_kecamatan_id IS NULL THEN
		INSERT INTO kecamatan (nama_kecamatan)
		VALUES (p_kecamatan)
		RETURNING kecamatan_id INTO v_kecamatan_id;
	END IF;

	IF v_desa_Id IS NULL THEN
		INSERT INTO desa (nama_desa, kecamatan_id) 
		VALUES (p_desa, v_kecamatan_id)
		RETURNING desa_id INTO v_desa_id;
	END IF;

    INSERT INTO users (nama, no_telp, email, username, passwords, isActive, alamat, created_at, roles_id, desa_id)
    VALUES (p_nama, p_no_telp, p_email, p_username, p_password, true, p_alamat, now(), 1, v_desa_id);
END;
$$;


ALTER PROCEDURE public.add_new_users_petani(IN p_nama character varying, IN p_email character varying, IN p_no_telp character varying, IN p_username character varying, IN p_password character varying, IN p_alamat character varying, IN p_kecamatan character varying, IN p_desa character varying) OWNER TO postgres;

--
-- TOC entry 285 (class 1255 OID 82811)
-- Name: add_pesanan_alat_sewa(integer, character varying, integer, integer, date, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_pesanan_alat_sewa(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_alat_sewa_id integer, IN p_quantity integer, IN p_tanggal_pengembalian date, IN p_opsi_pengembalian_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_pesanan_id INT; v_status_pesanan VARCHAR; v_harga_sewa_perhari NUMERIC;
BEGIN
    SELECT harga_sewa_perhari INTO v_harga_sewa_perhari FROM alat_sewa WHERE alat_sewa_id = p_alat_sewa_id;
    IF v_harga_sewa_perhari IS NULL THEN RAISE EXCEPTION 'Alat sewa dengan ID % tidak ditemukan.', p_alat_sewa_id; END IF;
    SELECT status_pesanan, pesanan_id INTO v_status_pesanan, v_pesanan_id FROM pesanan WHERE users_id = p_users_id AND status_pesanan = 'Belum Checkout' LIMIT 1;
    IF v_pesanan_id IS NULL THEN
        INSERT INTO pesanan(tanggal_pesanan, users_id, status_pesanan, opsi_pengiriman) VALUES (CURRENT_DATE, p_users_id, 'Belum Checkout', p_opsi_pengiriman) RETURNING pesanan_id INTO v_pesanan_id;
    END IF;
    INSERT INTO detail_pesanan_sewa(quantity, harga_sewa_perhari, tgl_sewa, tgl_pengembalian, pesanan_id, alat_sewa_id, opsi_pengembalian_id)
    VALUES (p_quantity, v_harga_sewa_perhari, CURRENT_DATE, p_tanggal_pengembalian, v_pesanan_id, p_alat_sewa_id, p_opsi_pengembalian_id);
END; $$;


ALTER PROCEDURE public.add_pesanan_alat_sewa(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_alat_sewa_id integer, IN p_quantity integer, IN p_tanggal_pengembalian date, IN p_opsi_pengembalian_id integer) OWNER TO postgres;

--
-- TOC entry 300 (class 1255 OID 83189)
-- Name: add_pesanan_alat_sewa(integer, character varying, character varying, integer, integer, date, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_pesanan_alat_sewa(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_metode_pembayaran character varying, IN p_alat_sewa_id integer, IN p_quantity integer, IN p_tanggal_pengembalian date, IN p_opsi_pengembalian_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_pesanan_id int;
    v_harga numeric;
BEGIN
    SELECT pesanan_id INTO v_pesanan_id
    FROM pesanan
    WHERE users_id = p_users_id AND status_pesanan = 'Belum Checkout';

    IF v_pesanan_id IS NULL THEN
        INSERT INTO pesanan (users_id, status_pesanan, opsi_pengiriman, metode_pembayaran)
        VALUES (p_users_id, 'Belum Checkout', p_opsi_pengiriman, p_metode_pembayaran)
        RETURNING pesanan_id INTO v_pesanan_id;
    END IF;

    SELECT harga_sewa_perhari INTO v_harga FROM alat_sewa WHERE alat_sewa_id = p_alat_sewa_id;

    INSERT INTO detail_pesanan_sewa (pesanan_id, alat_sewa_id, quantity, harga_sewa_perhari, tgl_sewa, tgl_pengembalian, opsi_pengembalian_id)
    VALUES (v_pesanan_id, p_alat_sewa_id, p_quantity, v_harga, CURRENT_DATE, p_tanggal_pengembalian, p_opsi_pengembalian_id);
END;
$$;


ALTER PROCEDURE public.add_pesanan_alat_sewa(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_metode_pembayaran character varying, IN p_alat_sewa_id integer, IN p_quantity integer, IN p_tanggal_pengembalian date, IN p_opsi_pengembalian_id integer) OWNER TO postgres;

--
-- TOC entry 286 (class 1255 OID 82812)
-- Name: add_pesanan_barang(integer, character varying, integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_pesanan_barang(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_barang_id integer, IN p_quantity integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_pesanan_id int;
    v_harga_per_item numeric;
BEGIN   
    -- 1. Ambil harga per item dari tabel barang
    SELECT harga_per_item 
    INTO v_harga_per_item
    FROM barang
    WHERE barang_id = p_barang_id;

    -- Validasi jika barang ternyata tidak ditemukan di database
    IF v_harga_per_item IS NULL THEN
        RAISE EXCEPTION 'Barang dengan ID % tidak ditemukan.', p_barang_id;
    END IF;

    -- 2. KUNCI UTAMA: Cari apakah user punya keranjang aktif ('Belum Checkout')
    SELECT pesanan_id
    INTO v_pesanan_id
    FROM pesanan
    WHERE users_id = p_users_id AND status_pesanan = 'Belum Checkout'
    LIMIT 1;

    -- 3. JIKA TIDAK ADA keranjang aktif, buatkan NOTA PESANAN baru terlebih dahulu
    IF v_pesanan_id IS NULL THEN
        INSERT INTO pesanan(tanggal_pesanan, users_id, status_pesanan, opsi_pengiriman)
        VALUES (CURRENT_DATE, p_users_id, 'Belum Checkout', p_opsi_pengiriman) 
        RETURNING pesanan_id INTO v_pesanan_id;
    END IF;

    -- 4. Masukkan item barang ke detail pesanan (Cukup tulis 1 kali di sini)
    INSERT INTO detail_pesanan_pembelian(quantity, harga_per_item, pesanan_id, barang_id)
    VALUES (p_quantity, v_harga_per_item, v_pesanan_id, p_barang_id);

END;
$$;


ALTER PROCEDURE public.add_pesanan_barang(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_barang_id integer, IN p_quantity integer) OWNER TO postgres;

--
-- TOC entry 299 (class 1255 OID 83188)
-- Name: add_pesanan_barang(integer, character varying, character varying, integer, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.add_pesanan_barang(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_metode_pembayaran character varying, IN p_barang_id integer, IN p_quantity integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_pesanan_id int;
    v_harga numeric;
BEGIN
    -- Cek pesanan 'Belum Checkout'
    SELECT pesanan_id INTO v_pesanan_id
    FROM pesanan
    WHERE users_id = p_users_id AND status_pesanan = 'Belum Checkout';

    IF v_pesanan_id IS NULL THEN
        -- Buat pesanan baru dengan metode_pembayaran
        INSERT INTO pesanan (users_id, status_pesanan, opsi_pengiriman, metode_pembayaran)
        VALUES (p_users_id, 'Belum Checkout', p_opsi_pengiriman, p_metode_pembayaran)
        RETURNING pesanan_id INTO v_pesanan_id;
    END IF;

    -- Ambil harga
    SELECT harga_per_item INTO v_harga FROM barang WHERE barang_id = p_barang_id;

    -- Insert ke detail pesanan
    INSERT INTO detail_pesanan_pembelian (pesanan_id, barang_id, quantity, harga_per_item)
    VALUES (v_pesanan_id, p_barang_id, p_quantity, v_harga);
END;
$$;


ALTER PROCEDURE public.add_pesanan_barang(IN p_users_id integer, IN p_opsi_pengiriman character varying, IN p_metode_pembayaran character varying, IN p_barang_id integer, IN p_quantity integer) OWNER TO postgres;

--
-- TOC entry 298 (class 1255 OID 83237)
-- Name: audit_transaksi_trigger_func(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.audit_transaksi_trigger_func() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
BEGIN
    IF (TG_OP = 'INSERT') THEN
        INSERT INTO audit_transaksi(transaksi_id, aksi, kolom_perubahan, waktu_perubahan, users_id)
        VALUES (NEW.transaksi_id, 'INSERT', 'Semua (Data Baru)', NOW(), NEW.users_id);
        RETURN NEW;
        
    ELSIF (TG_OP = 'UPDATE') THEN
        -- Cek perubahan pada status_transaksi
        IF (OLD.status_transaksi IS DISTINCT FROM NEW.status_transaksi) THEN
            INSERT INTO audit_transaksi(transaksi_id, aksi, kolom_perubahan, waktu_perubahan, users_id)
            VALUES (NEW.transaksi_id, 'UPDATE', 'status_transaksi', NOW(), NEW.users_id);
        END IF;

        -- Cek perubahan pada status_pembayaran
        IF (OLD.status_pembayaran IS DISTINCT FROM NEW.status_pembayaran) THEN
            INSERT INTO audit_transaksi(transaksi_id, aksi, kolom_perubahan, waktu_perubahan, users_id)
            VALUES (NEW.transaksi_id, 'UPDATE', 'status_pembayaran', NOW(), NEW.users_id);
        END IF;

        -- Cek perubahan pada status_distribusi_id
        IF (OLD.status_distribusi_id IS DISTINCT FROM NEW.status_distribusi_id) THEN
            INSERT INTO audit_transaksi(transaksi_id, aksi, kolom_perubahan, waktu_perubahan, users_id)
            VALUES (NEW.transaksi_id, 'UPDATE', 'status_distribusi', NOW(), NEW.users_id);
        END IF;

        RETURN NEW;
    END IF;
    
    RETURN NULL;
END;
$$;


ALTER FUNCTION public.audit_transaksi_trigger_func() OWNER TO postgres;

--
-- TOC entry 287 (class 1255 OID 82813)
-- Name: batal_pesanan_item(integer, text, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.batal_pesanan_item(IN p_pesanan_id integer, IN p_jenis_pesanan text, IN p_nama_item character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_total_item integer;
BEGIN
    -- 1. HAPUS DARI TABEL DETAIL BERDASARKAN JENISNYA
    IF p_jenis_pesanan = 'Pembelian' THEN
        DELETE FROM detail_pesanan_pembelian
        WHERE pesanan_id = p_pesanan_id 
          AND barang_id = (SELECT barang_id FROM barang WHERE nama_barang = p_nama_item LIMIT 1);
          
    ELSIF p_jenis_pesanan = 'Penyewaan' THEN
        DELETE FROM detail_pesanan_sewa
        WHERE pesanan_id = p_pesanan_id 
          AND alat_sewa_id = (SELECT alat_sewa_id FROM alat_sewa WHERE nama_alat = p_nama_item LIMIT 1);
    END IF;

    -- 2. HITUNG SISA ITEM DI NOTA TERSEBUT
    SELECT 
        (SELECT COUNT(*) FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id) +
        (SELECT COUNT(*) FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id)
    INTO v_total_item;

    -- 3. JIKA NOTA SUDAH KOSONG (TIDAK ADA ITEM LAGI), HAPUS NOTA INDUKNYA
    IF v_total_item = 0 THEN
        DELETE FROM pesanan WHERE pesanan_id = p_pesanan_id;
    END IF;
END;
$$;


ALTER PROCEDURE public.batal_pesanan_item(IN p_pesanan_id integer, IN p_jenis_pesanan text, IN p_nama_item character varying) OWNER TO postgres;

--
-- TOC entry 288 (class 1255 OID 82814)
-- Name: petani_checkout_pesanan(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.petani_checkout_pesanan(IN p_pesanan_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_transaksi_id int; v_users_id int; v_opsi varchar; v_distribusi_id int;
    r_detail_pembelian RECORD; r_detail_sewa RECORD;
BEGIN
    SELECT users_id, opsi_pengiriman INTO v_users_id, v_opsi FROM pesanan WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Belum Checkout';
    IF v_users_id IS NULL THEN RAISE EXCEPTION 'Pesanan tidak ditemukan atau sudah di-checkout.'; END IF;
    UPDATE pesanan SET status_pesanan = 'Sudah Checkout' WHERE pesanan_id = p_pesanan_id;
    IF v_opsi = 'diantar' THEN v_distribusi_id := 1; ELSE v_distribusi_id := 4; END IF;
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, status_pembayaran, pesanan_id)
    VALUES (NOW(), 'Checkout pesanan ID ' || p_pesanan_id, v_users_id, 'Diproses', v_distribusi_id, 'belum lunas', p_pesanan_id) RETURNING transaksi_id INTO v_transaksi_id;
    FOR r_detail_pembelian IN SELECT quantity, harga_per_item, barang_id FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id) VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;
    FOR r_detail_sewa IN SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id, opsi_pengembalian_id FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, r_detail_sewa.opsi_pengembalian_id);
    END LOOP;
END; $$;


ALTER PROCEDURE public.petani_checkout_pesanan(IN p_pesanan_id integer) OWNER TO postgres;

--
-- TOC entry 272 (class 1255 OID 83222)
-- Name: checkout_petani(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.checkout_petani(IN p_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Mengubah status pesanan dari 'Belum Checkout' menjadi 'Sudah Checkout'
    UPDATE pesanan 
    SET status_pesanan = 'Sudah Checkout'
    WHERE pesanan_id = p_id;
    
END;
$$;


ALTER PROCEDURE public.checkout_petani(IN p_id integer) OWNER TO postgres;

--
-- TOC entry 296 (class 1255 OID 83180)
-- Name: f_get_dashboard_stats(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.f_get_dashboard_stats() RETURNS TABLE(total_transaksi_diproses bigint, total_transaksi_diantar bigint, total_pesanan_masuk bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT 
        (SELECT COUNT(transaksi_id) FROM transaksi WHERE status_transaksi = 'Diproses')::bigint AS total_transaksi_diproses,
        (SELECT COUNT(t.transaksi_id) FROM transaksi t WHERE t.status_transaksi = 'Diproses' AND t.status_distribusi_id IN (1, 2))::bigint AS total_transaksi_diantar,
        (SELECT COUNT(pesanan_id) FROM pesanan WHERE status_pesanan = 'Sudah Checkout')::bigint AS total_pesanan_masuk;
END;
$$;


ALTER FUNCTION public.f_get_dashboard_stats() OWNER TO postgres;

--
-- TOC entry 265 (class 1255 OID 82817)
-- Name: get_password_by_username(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_password_by_username(p_username character varying) RETURNS TABLE(db_password character varying, db_role integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
	return query
	select passwords, roles_id
	from users
	where username = p_username;
END;
$$;


ALTER FUNCTION public.get_password_by_username(p_username character varying) OWNER TO postgres;

--
-- TOC entry 289 (class 1255 OID 82818)
-- Name: get_pesanan_already_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_pesanan_already_by_user(p_users_id integer) RETURNS TABLE("ID" integer, "Jenis Pesanan" text, "Nama Item" character varying, "Harga Satuan" numeric, "Jumlah" integer, "Lama Sewa (Hari)" integer, "Tanggal Pemesanan" date, "Tanggal Pengembalian" date, "Opsi Pengembalian" character varying, "Status" character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT p.pesanan_id, 'Pembelian'::text, b.nama_barang, dpb.harga_per_item,
        dpb.quantity, 0::integer, p.tanggal_pesanan::date, NULL::date,
        NULL::character varying, p.status_pesanan
    FROM pesanan p
    JOIN detail_pesanan_pembelian dpb USING (pesanan_id) JOIN barang b USING (barang_id)
    WHERE p.users_id = p_users_id AND p.status_pesanan = 'Sudah Checkout'
    UNION ALL
    SELECT p.pesanan_id, 'Penyewaan'::text, a.nama_alat, dps.harga_sewa_perhari,
        dps.quantity, (dps.tgl_pengembalian - dps.tgl_sewa)::integer,
        p.tanggal_pesanan::date, dps.tgl_pengembalian::date,
        op.opsi_pengembalian, p.status_pesanan
    FROM pesanan p
    JOIN detail_pesanan_sewa dps USING (pesanan_id) JOIN alat_sewa a USING (alat_sewa_id)
    LEFT JOIN opsi_pengembalian op ON dps.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE p.users_id = p_users_id AND p.status_pesanan = 'Sudah Checkout';
END; $$;


ALTER FUNCTION public.get_pesanan_already_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 290 (class 1255 OID 82819)
-- Name: get_pesanan_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_pesanan_by_user(p_users_id integer) RETURNS TABLE("ID" integer, "Jenis Pesanan" text, "Nama Item" character varying, "Harga Satuan" numeric, "Jumlah" integer, "Lama Sewa (Hari)" integer, "Tanggal Pemesanan" date, "Tanggal Pengembalian" date, "Opsi Pengembalian" character varying, "Status" character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT p.pesanan_id, 'Pembelian'::text, b.nama_barang, dpb.harga_per_item,
        dpb.quantity, 0::integer, p.tanggal_pesanan::date, NULL::date,
        NULL::character varying, p.status_pesanan
    FROM pesanan p
    JOIN detail_pesanan_pembelian dpb USING (pesanan_id) JOIN barang b USING (barang_id)
    WHERE p.users_id = p_users_id AND p.status_pesanan = 'Belum Checkout'
    UNION ALL
    SELECT p.pesanan_id, 'Penyewaan'::text, a.nama_alat, dps.harga_sewa_perhari,
        dps.quantity, (dps.tgl_pengembalian - dps.tgl_sewa)::integer,
        p.tanggal_pesanan::date, dps.tgl_pengembalian::date,
        op.opsi_pengembalian, p.status_pesanan
    FROM pesanan p
    JOIN detail_pesanan_sewa dps USING (pesanan_id) JOIN alat_sewa a USING (alat_sewa_id)
    LEFT JOIN opsi_pengembalian op ON dps.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE p.users_id = p_users_id AND p.status_pesanan = 'Belum Checkout';
END; $$;


ALTER FUNCTION public.get_pesanan_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 303 (class 1255 OID 83213)
-- Name: get_tagihan_denda_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_tagihan_denda_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT t.transaksi_id, t.created_at, t.status_transaksi,
           p.metode_pembayaran, t.status_pembayaran, t.catatan,
           a.nama_alat, dts.quantity, dts.harga_sewa_perhari, dts.denda,
           dts.status_sewa, dts.tgl_sewa, dts.tgl_pengembalian, op.opsi_pengembalian
    FROM transaksi t
    INNER JOIN pesanan p ON t.pesanan_id = p.pesanan_id
    INNER JOIN detail_transaksi_sewa dts ON t.transaksi_id = dts.transaksi_id
    INNER JOIN alat_sewa a ON dts.alat_sewa_id = a.alat_sewa_id
    LEFT JOIN opsi_pengembalian op ON dts.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE t.users_id = p_users_id
      AND t.status_transaksi = 'Diproses'
      AND dts.denda <> 0
      AND dts.status_sewa = 'Sedang disewa'
    ORDER BY t.created_at DESC;
END;
$$;


ALTER FUNCTION public.get_tagihan_denda_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 302 (class 1255 OID 83212)
-- Name: get_transaksi_berlangsung_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_transaksi_berlangsung_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT t.transaksi_id, t.created_at, t.status_transaksi,
           p.metode_pembayaran, t.status_pembayaran, t.catatan,
           a.nama_alat, dts.quantity, dts.harga_sewa_perhari, dts.denda,
           dts.status_sewa, dts.tgl_sewa, dts.tgl_pengembalian, op.opsi_pengembalian
    FROM transaksi t
    LEFT JOIN pesanan p ON t.pesanan_id = p.pesanan_id
    LEFT JOIN detail_transaksi_sewa dts ON t.transaksi_id = dts.transaksi_id
    LEFT JOIN alat_sewa a ON dts.alat_sewa_id = a.alat_sewa_id
    LEFT JOIN opsi_pengembalian op ON dts.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE t.users_id = p_users_id AND t.status_transaksi = 'Diproses'
    ORDER BY t.created_at DESC;
END;
$$;


ALTER FUNCTION public.get_transaksi_berlangsung_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 301 (class 1255 OID 83211)
-- Name: get_transaksi_selesai_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_transaksi_selesai_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT t.transaksi_id, t.created_at, t.status_transaksi,
           p.metode_pembayaran, t.status_pembayaran, t.catatan,
           a.nama_alat, dts.quantity, dts.harga_sewa_perhari, dts.denda,
           dts.status_sewa, dts.tgl_sewa, dts.tgl_pengembalian, op.opsi_pengembalian
    FROM transaksi t
    LEFT JOIN pesanan p ON t.pesanan_id = p.pesanan_id
    LEFT JOIN detail_transaksi_sewa dts ON t.transaksi_id = dts.transaksi_id
    LEFT JOIN alat_sewa a ON dts.alat_sewa_id = a.alat_sewa_id
    LEFT JOIN opsi_pengembalian op ON dts.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE t.users_id = p_users_id AND t.status_transaksi = 'Selesai'
    ORDER BY t.created_at DESC;
END;
$$;


ALTER FUNCTION public.get_transaksi_selesai_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 270 (class 1255 OID 83176)
-- Name: log_audit_stok_alat(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.log_audit_stok_alat() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_user_id int;
BEGIN
    v_user_id := NULLIF(current_setting('myapp.current_user_id', true), '')::int;
    IF v_user_id IS NULL THEN
        SELECT users_id INTO v_user_id FROM users LIMIT 1;
    END IF;

    INSERT INTO audit_stok_barang_alat(stok_awal, stok_akhir, keterangan, waktu_perubahan, users_id, barang_id, alat_sewa_id)
    VALUES (OLD.stok, NEW.stok, 'Update stok alat ' || NEW.nama_alat, NOW(), v_user_id, NULL, NEW.alat_sewa_id);
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.log_audit_stok_alat() OWNER TO postgres;

--
-- TOC entry 271 (class 1255 OID 83178)
-- Name: log_audit_stok_barang(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.log_audit_stok_barang() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_user_id int;
BEGIN
    v_user_id := NULLIF(current_setting('myapp.current_user_id', true), '')::int;
    IF v_user_id IS NULL THEN
        SELECT users_id INTO v_user_id FROM users LIMIT 1;
    END IF;

    INSERT INTO audit_stok_barang_alat(stok_awal, stok_akhir, keterangan, waktu_perubahan, users_id, barang_id, alat_sewa_id)
    VALUES (OLD.stok, NEW.stok, 'Update stok barang ' || NEW.nama_barang, NOW(), v_user_id, NEW.barang_id, NULL);
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.log_audit_stok_barang() OWNER TO postgres;

--
-- TOC entry 268 (class 1255 OID 82826)
-- Name: p_batal_pesanan(integer, text); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.p_batal_pesanan(IN p_pesanan_id integer, IN p_alasan text)
    LANGUAGE plpgsql
    AS $$
BEGIN
    UPDATE pesanan
    SET status_pesanan = 'Dibatalkan',
        opsi_pengiriman = COALESCE(opsi_pengiriman, '') || ' (Batal: ' || p_alasan || ')'
    WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Sudah Checkout';
END;
$$;


ALTER PROCEDURE public.p_batal_pesanan(IN p_pesanan_id integer, IN p_alasan text) OWNER TO postgres;

--
-- TOC entry 295 (class 1255 OID 82827)
-- Name: p_terima_pesanan(integer, character varying); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.p_terima_pesanan(IN p_pesanan_id integer, IN p_karyawan_username character varying)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_transaksi_id int;
    v_users_id int;
    v_opsi varchar;
    v_distribusi_id int;
    r_detail_pembelian RECORD;
    r_detail_sewa RECORD;
BEGIN
    SELECT users_id, opsi_pengiriman
    INTO v_users_id, v_opsi
    FROM pesanan
    WHERE pesanan_id = p_pesanan_id AND status_pesanan = 'Sudah Checkout';

    IF v_users_id IS NULL THEN
        RAISE EXCEPTION 'Pesanan dengan ID % tidak ditemukan atau statusnya bukan Sudah Checkout.', p_pesanan_id;
    END IF;

    -- Validasi Stok Barang
    FOR r_detail_pembelian IN 
        SELECT dp.quantity, b.stok, b.nama_barang 
        FROM detail_pesanan_pembelian dp
        JOIN barang b ON dp.barang_id = b.barang_id
        WHERE dp.pesanan_id = p_pesanan_id
    LOOP
        IF r_detail_pembelian.stok < r_detail_pembelian.quantity THEN
            RAISE EXCEPTION 'Stok barang % tidak mencukupi.', r_detail_pembelian.nama_barang;
        END IF;
    END LOOP;

    -- Validasi Stok Alat Sewa
    FOR r_detail_sewa IN 
        SELECT ds.quantity, a.stok, a.nama_alat 
        FROM detail_pesanan_sewa ds
        JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
        WHERE ds.pesanan_id = p_pesanan_id
    LOOP
        IF r_detail_sewa.stok < r_detail_sewa.quantity THEN
            RAISE EXCEPTION 'Stok alat % tidak mencukupi.', r_detail_sewa.nama_alat;
        END IF;
    END LOOP;

    -- Update status pesanan
    UPDATE pesanan SET status_pesanan = 'Selesai' WHERE pesanan_id = p_pesanan_id;

    -- Tentukan status distribusi
    IF v_opsi = 'Diambil Sendiri' THEN
        v_distribusi_id := 1; 
    ELSIF v_opsi = 'Diantar' THEN
        v_distribusi_id := 2; 
    ELSE
        v_distribusi_id := 1; 
    END IF;

    -- Bikin transaksi (metode_pembayaran dihapus dari sini)
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, status_pembayaran, pesanan_id)
    VALUES (NOW(), 'Penerimaan pesanan ID ' || p_pesanan_id || ' oleh ' || p_karyawan_username, v_users_id, 'Diproses', v_distribusi_id, 'belum lunas', p_pesanan_id)
    RETURNING transaksi_id INTO v_transaksi_id;

    -- Salin ke detail transaksi pembelian
    FOR r_detail_pembelian IN SELECT quantity, harga_per_item, barang_id FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id)
        VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;

    -- Salin ke detail transaksi sewa
    FOR r_detail_sewa IN SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, 1);
    END LOOP;
END;
$$;


ALTER PROCEDURE public.p_terima_pesanan(IN p_pesanan_id integer, IN p_karyawan_username character varying) OWNER TO postgres;

--
-- TOC entry 291 (class 1255 OID 82828)
-- Name: p_update_status_pembayaran(integer, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.p_update_status_pembayaran(IN p_transaksi_id integer, IN p_status character varying, IN p_karyawan_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    PERFORM set_config('myapp.current_user_id', p_karyawan_id::varchar, true);
    UPDATE transaksi SET status_pembayaran = p_status WHERE transaksi_id = p_transaksi_id;
END;
$$;


ALTER PROCEDURE public.p_update_status_pembayaran(IN p_transaksi_id integer, IN p_status character varying, IN p_karyawan_id integer) OWNER TO postgres;

--
-- TOC entry 292 (class 1255 OID 82829)
-- Name: p_update_status_transaksi(integer, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.p_update_status_transaksi(IN p_transaksi_id integer, IN p_status character varying, IN p_karyawan_id integer)
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_pembayaran varchar;
    v_distribusi varchar;
    v_distribusi_id int;
BEGIN
    PERFORM set_config('myapp.current_user_id', p_karyawan_id::varchar, true);

    SELECT t.status_pembayaran, sd.status_distribusi, t.status_distribusi_id
    INTO v_pembayaran, v_distribusi, v_distribusi_id
    FROM transaksi t
    LEFT JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id
    WHERE t.transaksi_id = p_transaksi_id;

    -- Validasi status_distribusi_id 4 ('Ambil Sendiri') diabaikan agar langsung diselesaikan
    IF v_distribusi_id IS NOT NULL AND v_distribusi_id != 4 AND (v_pembayaran != 'lunas' OR v_distribusi != 'Diterima') THEN
        RAISE EXCEPTION 'Transaksi opsi diantar hanya bisa diselesaikan jika pembayaran lunas dan distribusi Diterima!';
    END IF;

    UPDATE transaksi SET status_transaksi = p_status WHERE transaksi_id = p_transaksi_id;
END;
$$;


ALTER PROCEDURE public.p_update_status_transaksi(IN p_transaksi_id integer, IN p_status character varying, IN p_karyawan_id integer) OWNER TO postgres;

--
-- TOC entry 293 (class 1255 OID 82830)
-- Name: p_update_stok(integer, integer, character varying, integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.p_update_stok(IN p_id integer, IN p_stok_baru integer, IN p_jenis character varying, IN p_karyawan_id integer)
    LANGUAGE plpgsql
    AS $$
BEGIN
    -- Set local session parameter agar bisa dibaca trigger audit
    PERFORM set_config('myapp.current_user_id', p_karyawan_id::varchar, true);

    IF p_jenis = 'barang' THEN
        UPDATE barang SET stok = p_stok_baru WHERE barang_id = p_id;
    ELSE
        UPDATE alat_sewa SET stok = p_stok_baru WHERE alat_sewa_id = p_id;
    END IF;
END;
$$;


ALTER PROCEDURE public.p_update_stok(IN p_id integer, IN p_stok_baru integer, IN p_jenis character varying, IN p_karyawan_id integer) OWNER TO postgres;

--
-- TOC entry 297 (class 1255 OID 83236)
-- Name: search_alat_sewa(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.search_alat_sewa(search_keyword character varying) RETURNS TABLE(alat_sewa_id integer, nama_alat character varying, stok integer, harga_sewa_perhari numeric, harga_denda_perhari numeric, kategori character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT a.alat_sewa_id, a.nama_alat::VARCHAR, a.stok, a.harga_sewa_perhari, a.harga_denda_perhari, k.kategori::VARCHAR
    FROM alat_sewa a
    JOIN kategori k ON a.kategori_id = k.kategori_id
    WHERE a.nama_alat ILIKE '%' || search_keyword || '%';
END;
$$;


ALTER FUNCTION public.search_alat_sewa(search_keyword character varying) OWNER TO postgres;

--
-- TOC entry 273 (class 1255 OID 83235)
-- Name: search_barang_petani(character varying); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.search_barang_petani(search_keyword character varying) RETURNS TABLE(barang_id integer, "nama barang" character varying, stok integer, "harga per unit" numeric, kategori character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT b.barang_id, b.nama_barang::VARCHAR, b.stok, b.harga_per_item, k.kategori::VARCHAR
    FROM barang b
    JOIN kategori k ON b.kategori_id = k.kategori_id
    WHERE b.nama_barang ILIKE '%' || search_keyword || '%';
END;
$$;


ALTER FUNCTION public.search_barang_petani(search_keyword character varying) OWNER TO postgres;

--
-- TOC entry 294 (class 1255 OID 82831)
-- Name: update_users(text, text, text, text, text, boolean, text, text, text, text); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.update_users(IN p_nama text, IN p_no_telp text, IN p_email text, IN p_username_baru text, IN p_password text, IN p_isactive boolean, IN p_alamat text, IN p_desa text, IN p_kecamatan text, IN p_username_lama text)
    LANGUAGE plpgsql
    AS $$
DECLARE
	v_desa_id int;
	v_kecamatan_id int;
BEGIN
	-- 1. Cari ID Desa berdasarkan nama teks
	SELECT desa_id 
	INTO v_desa_id
	FROM desa
	WHERE nama_desa ILIKE p_desa;

	-- 2. Cari ID Kecamatan berdasarkan nama teks
	SELECT kecamatan_id
	INTO v_kecamatan_id
	FROM kecamatan
	WHERE nama_kecamatan ILIKE p_kecamatan;

	-- 3. LOGIKA VALIDASI RELASI WILAYAH (DIPERBAIKI)
	IF v_kecamatan_id IS NULL THEN
		-- Wajib sebutkan nama kolom target (nama_kecamatan) agar tidak salah lempar parameter
		INSERT INTO kecamatan (nama_kecamatan)
		VALUES (p_kecamatan) 
		RETURNING kecamatan_id INTO v_kecamatan_id;
	END IF;

	IF v_desa_id IS NULL THEN
		-- Wajib sebutkan nama kolom target (nama_desa, kecamatan_id)
		INSERT INTO desa (nama_desa, kecamatan_id)
		VALUES (p_desa, v_kecamatan_id) 
		RETURNING desa_id INTO v_desa_id;
	END IF;

	-- 4. PROSES UPDATE DATA USER UTAMA
UPDATE users 
	SET 
		nama = p_nama, 
		no_telp = p_no_telp, 
		email = p_email, 
		username = p_username_baru, -- <--- Set ke yang baru
		passwords = p_password, 
		alamat = p_alamat, 
		isactive = p_isactive,
		desa_id = v_desa_id, 
		update_at = NOW()
	WHERE username = p_username_lama; -- <--- Cari berdasarkan username yang LAMA!
END;
$$;


ALTER PROCEDURE public.update_users(IN p_nama text, IN p_no_telp text, IN p_email text, IN p_username_baru text, IN p_password text, IN p_isactive boolean, IN p_alamat text, IN p_desa text, IN p_kecamatan text, IN p_username_lama text) OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 217 (class 1259 OID 82832)
-- Name: alat_sewa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.alat_sewa (
    alat_sewa_id integer NOT NULL,
    nama_alat character varying(255) NOT NULL,
    stok integer NOT NULL,
    harga_sewa_perhari numeric(15,2) NOT NULL,
    harga_denda_perhari numeric(15,2) NOT NULL,
    kategori_id integer,
    added_at timestamp without time zone NOT NULL
);


ALTER TABLE public.alat_sewa OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 82835)
-- Name: alat_sewa_alat_sewa_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.alat_sewa_alat_sewa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.alat_sewa_alat_sewa_id_seq OWNER TO postgres;

--
-- TOC entry 5198 (class 0 OID 0)
-- Dependencies: 218
-- Name: alat_sewa_alat_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.alat_sewa_alat_sewa_id_seq OWNED BY public.alat_sewa.alat_sewa_id;


--
-- TOC entry 219 (class 1259 OID 82836)
-- Name: audit_stok_barang_alat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.audit_stok_barang_alat (
    audit_stok_barang_alat_id integer NOT NULL,
    stok_awal integer NOT NULL,
    stok_akhir integer NOT NULL,
    keterangan text NOT NULL,
    waktu_perubahan timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    users_id integer NOT NULL,
    barang_id integer,
    alat_sewa_id integer
);


ALTER TABLE public.audit_stok_barang_alat OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 82842)
-- Name: audit_stok_barang_alat_audit_stok_barang_alat_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq OWNER TO postgres;

--
-- TOC entry 5199 (class 0 OID 0)
-- Dependencies: 220
-- Name: audit_stok_barang_alat_audit_stok_barang_alat_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq OWNED BY public.audit_stok_barang_alat.audit_stok_barang_alat_id;


--
-- TOC entry 221 (class 1259 OID 82843)
-- Name: audit_transaksi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.audit_transaksi (
    audit_transaksi_id integer NOT NULL,
    aksi character varying(100) NOT NULL,
    waktu_perubahan timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    kolom_perubahan character varying(255),
    value_lama text,
    value_baru text,
    transaksi_id integer NOT NULL,
    users_id integer NOT NULL
);


ALTER TABLE public.audit_transaksi OWNER TO postgres;

--
-- TOC entry 222 (class 1259 OID 82849)
-- Name: audit_transaksi_audit_transaksi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.audit_transaksi_audit_transaksi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.audit_transaksi_audit_transaksi_id_seq OWNER TO postgres;

--
-- TOC entry 5200 (class 0 OID 0)
-- Dependencies: 222
-- Name: audit_transaksi_audit_transaksi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.audit_transaksi_audit_transaksi_id_seq OWNED BY public.audit_transaksi.audit_transaksi_id;


--
-- TOC entry 223 (class 1259 OID 82850)
-- Name: barang; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.barang (
    barang_id integer NOT NULL,
    nama_barang character varying(255) NOT NULL,
    stok integer NOT NULL,
    harga_per_item numeric(15,2) NOT NULL,
    kategori_id integer,
    added_at timestamp without time zone
);


ALTER TABLE public.barang OWNER TO postgres;

--
-- TOC entry 224 (class 1259 OID 82853)
-- Name: barang_barang_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.barang_barang_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.barang_barang_id_seq OWNER TO postgres;

--
-- TOC entry 5201 (class 0 OID 0)
-- Dependencies: 224
-- Name: barang_barang_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.barang_barang_id_seq OWNED BY public.barang.barang_id;


--
-- TOC entry 225 (class 1259 OID 82854)
-- Name: desa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.desa (
    desa_id integer NOT NULL,
    nama_desa character varying(255) NOT NULL,
    kecamatan_id integer NOT NULL
);


ALTER TABLE public.desa OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 82857)
-- Name: desa_desa_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.desa_desa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.desa_desa_id_seq OWNER TO postgres;

--
-- TOC entry 5202 (class 0 OID 0)
-- Dependencies: 226
-- Name: desa_desa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.desa_desa_id_seq OWNED BY public.desa.desa_id;


--
-- TOC entry 227 (class 1259 OID 82858)
-- Name: detail_pesanan_pembelian; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.detail_pesanan_pembelian (
    detail_pesanan_pembelian_id integer NOT NULL,
    quantity integer NOT NULL,
    harga_per_item numeric(15,2) NOT NULL,
    pesanan_id integer NOT NULL,
    barang_id integer NOT NULL
);


ALTER TABLE public.detail_pesanan_pembelian OWNER TO postgres;

--
-- TOC entry 228 (class 1259 OID 82861)
-- Name: detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq OWNER TO postgres;

--
-- TOC entry 5203 (class 0 OID 0)
-- Dependencies: 228
-- Name: detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq OWNED BY public.detail_pesanan_pembelian.detail_pesanan_pembelian_id;


--
-- TOC entry 229 (class 1259 OID 82862)
-- Name: detail_pesanan_sewa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.detail_pesanan_sewa (
    detail_pesanan_sewa_id integer NOT NULL,
    quantity integer NOT NULL,
    harga_sewa_perhari numeric(15,2) NOT NULL,
    tgl_sewa date NOT NULL,
    tgl_pengembalian date NOT NULL,
    pesanan_id integer NOT NULL,
    alat_sewa_id integer NOT NULL,
    opsi_pengembalian_id integer
);


ALTER TABLE public.detail_pesanan_sewa OWNER TO postgres;

--
-- TOC entry 230 (class 1259 OID 82865)
-- Name: detail_pesanan_sewa_detail_pesanan_sewa_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq OWNER TO postgres;

--
-- TOC entry 5204 (class 0 OID 0)
-- Dependencies: 230
-- Name: detail_pesanan_sewa_detail_pesanan_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq OWNED BY public.detail_pesanan_sewa.detail_pesanan_sewa_id;


--
-- TOC entry 231 (class 1259 OID 82866)
-- Name: detail_transaksi_pembelian; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.detail_transaksi_pembelian (
    detail_transaksi_pembelian_id integer NOT NULL,
    quantity integer NOT NULL,
    harga_per_item numeric(15,2) NOT NULL,
    transaksi_id integer NOT NULL,
    barang_id integer NOT NULL
);


ALTER TABLE public.detail_transaksi_pembelian OWNER TO postgres;

--
-- TOC entry 232 (class 1259 OID 82869)
-- Name: detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq OWNER TO postgres;

--
-- TOC entry 5205 (class 0 OID 0)
-- Dependencies: 232
-- Name: detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq OWNED BY public.detail_transaksi_pembelian.detail_transaksi_pembelian_id;


--
-- TOC entry 233 (class 1259 OID 82870)
-- Name: detail_transaksi_sewa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.detail_transaksi_sewa (
    detail_transaksi_sewa_id integer NOT NULL,
    quantity integer NOT NULL,
    tgl_sewa date NOT NULL,
    tgl_pengembalian date NOT NULL,
    harga_sewa_perhari numeric(15,2) NOT NULL,
    denda numeric(15,2) DEFAULT 0 NOT NULL,
    transaksi_id integer NOT NULL,
    alat_sewa_id integer NOT NULL,
    status_sewa character varying NOT NULL,
    opsi_pengembalian_id integer NOT NULL
);


ALTER TABLE public.detail_transaksi_sewa OWNER TO postgres;

--
-- TOC entry 234 (class 1259 OID 82876)
-- Name: detail_transaksi_sewa_detail_transaksi_sewa_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq OWNER TO postgres;

--
-- TOC entry 5206 (class 0 OID 0)
-- Dependencies: 234
-- Name: detail_transaksi_sewa_detail_transaksi_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq OWNED BY public.detail_transaksi_sewa.detail_transaksi_sewa_id;


--
-- TOC entry 235 (class 1259 OID 82877)
-- Name: kategori; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kategori (
    kategori_id integer NOT NULL,
    kategori character varying(255) NOT NULL,
    deskripsi text
);


ALTER TABLE public.kategori OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 82882)
-- Name: kategori_kategori_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kategori_kategori_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kategori_kategori_id_seq OWNER TO postgres;

--
-- TOC entry 5207 (class 0 OID 0)
-- Dependencies: 236
-- Name: kategori_kategori_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kategori_kategori_id_seq OWNED BY public.kategori.kategori_id;


--
-- TOC entry 237 (class 1259 OID 82883)
-- Name: kecamatan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kecamatan (
    kecamatan_id integer NOT NULL,
    nama_kecamatan character varying(255) NOT NULL
);


ALTER TABLE public.kecamatan OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 82886)
-- Name: kecamatan_kecamatan_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kecamatan_kecamatan_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kecamatan_kecamatan_id_seq OWNER TO postgres;

--
-- TOC entry 5208 (class 0 OID 0)
-- Dependencies: 238
-- Name: kecamatan_kecamatan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kecamatan_kecamatan_id_seq OWNED BY public.kecamatan.kecamatan_id;


--
-- TOC entry 239 (class 1259 OID 82887)
-- Name: kurir; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kurir (
    kurir_id integer NOT NULL,
    nama_kurir character varying(255) NOT NULL,
    no_telp character varying(50) NOT NULL,
    alamat text NOT NULL
);


ALTER TABLE public.kurir OWNER TO postgres;

--
-- TOC entry 240 (class 1259 OID 82892)
-- Name: kurir_kurir_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.kurir_kurir_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.kurir_kurir_id_seq OWNER TO postgres;

--
-- TOC entry 5209 (class 0 OID 0)
-- Dependencies: 240
-- Name: kurir_kurir_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kurir_kurir_id_seq OWNED BY public.kurir.kurir_id;


--
-- TOC entry 241 (class 1259 OID 82893)
-- Name: lihat_alat; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.lihat_alat AS
 SELECT a.alat_sewa_id,
    a.nama_alat,
    a.stok,
    a.harga_sewa_perhari,
    a.harga_denda_perhari,
    k.kategori,
    a.added_at
   FROM (public.alat_sewa a
     JOIN public.kategori k USING (kategori_id));


ALTER VIEW public.lihat_alat OWNER TO postgres;

--
-- TOC entry 242 (class 1259 OID 82897)
-- Name: lihat_barang_petani; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.lihat_barang_petani AS
 SELECT b.barang_id,
    b.nama_barang AS "nama barang",
    b.stok,
    b.harga_per_item AS "harga per unit",
    k.kategori,
    b.added_at
   FROM (public.barang b
     JOIN public.kategori k USING (kategori_id))
  ORDER BY b.barang_id;


ALTER VIEW public.lihat_barang_petani OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 82901)
-- Name: lihatbarangpetani; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.lihatbarangpetani AS
 SELECT b.nama_barang AS "naam barang",
    b.stok,
    b.harga_per_item AS "harga per unit",
    k.kategori
   FROM (public.barang b
     JOIN public.kategori k USING (kategori_id));


ALTER VIEW public.lihatbarangpetani OWNER TO postgres;

--
-- TOC entry 244 (class 1259 OID 82905)
-- Name: opsi_pengembalian; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.opsi_pengembalian (
    opsi_pengembalian_id integer NOT NULL,
    opsi_pengembalian character varying(255) NOT NULL
);


ALTER TABLE public.opsi_pengembalian OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 82908)
-- Name: opsi_pengembalian_opsi_pengembalian_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.opsi_pengembalian_opsi_pengembalian_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.opsi_pengembalian_opsi_pengembalian_id_seq OWNER TO postgres;

--
-- TOC entry 5210 (class 0 OID 0)
-- Dependencies: 245
-- Name: opsi_pengembalian_opsi_pengembalian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.opsi_pengembalian_opsi_pengembalian_id_seq OWNED BY public.opsi_pengembalian.opsi_pengembalian_id;


--
-- TOC entry 246 (class 1259 OID 82909)
-- Name: pesanan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pesanan (
    pesanan_id integer NOT NULL,
    tanggal_pesanan timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    users_id integer NOT NULL,
    status_pesanan character varying NOT NULL,
    opsi_pengiriman character varying,
    metode_pembayaran character varying
);


ALTER TABLE public.pesanan OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 82915)
-- Name: pesanan_pesanan_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.pesanan_pesanan_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.pesanan_pesanan_id_seq OWNER TO postgres;

--
-- TOC entry 5211 (class 0 OID 0)
-- Dependencies: 247
-- Name: pesanan_pesanan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.pesanan_pesanan_id_seq OWNED BY public.pesanan.pesanan_id;


--
-- TOC entry 248 (class 1259 OID 82916)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    roles_id integer NOT NULL,
    roles character varying(100) NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 82919)
-- Name: roles_roles_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.roles_roles_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.roles_roles_id_seq OWNER TO postgres;

--
-- TOC entry 5212 (class 0 OID 0)
-- Dependencies: 249
-- Name: roles_roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_roles_id_seq OWNED BY public.roles.roles_id;


--
-- TOC entry 250 (class 1259 OID 82920)
-- Name: status_distribusi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.status_distribusi (
    status_distribusi_id integer NOT NULL,
    status_distribusi character varying(100) NOT NULL
);


ALTER TABLE public.status_distribusi OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 82923)
-- Name: status_distribusi_status_distribusi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.status_distribusi_status_distribusi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.status_distribusi_status_distribusi_id_seq OWNER TO postgres;

--
-- TOC entry 5213 (class 0 OID 0)
-- Dependencies: 251
-- Name: status_distribusi_status_distribusi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.status_distribusi_status_distribusi_id_seq OWNED BY public.status_distribusi.status_distribusi_id;


--
-- TOC entry 252 (class 1259 OID 82924)
-- Name: transaksi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transaksi (
    transaksi_id integer NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    catatan text,
    users_id integer NOT NULL,
    kurir_id integer,
    status_transaksi character varying NOT NULL,
    status_distribusi_id integer NOT NULL,
    status_pembayaran character varying NOT NULL,
    pesanan_id integer
);


ALTER TABLE public.transaksi OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 82930)
-- Name: transaksi_transaksi_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.transaksi_transaksi_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.transaksi_transaksi_id_seq OWNER TO postgres;

--
-- TOC entry 5214 (class 0 OID 0)
-- Dependencies: 253
-- Name: transaksi_transaksi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transaksi_transaksi_id_seq OWNED BY public.transaksi.transaksi_id;


--
-- TOC entry 254 (class 1259 OID 82931)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    users_id integer NOT NULL,
    nama character varying(255) NOT NULL,
    no_telp character varying(50) NOT NULL,
    email character varying(255) NOT NULL,
    username character varying(100) NOT NULL,
    passwords character varying(255) NOT NULL,
    isactive boolean DEFAULT true NOT NULL,
    alamat text NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    update_at timestamp without time zone,
    roles_id integer,
    desa_id integer
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 255 (class 1259 OID 82938)
-- Name: users_users_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_users_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;


ALTER SEQUENCE public.users_users_id_seq OWNER TO postgres;

--
-- TOC entry 5215 (class 0 OID 0)
-- Dependencies: 255
-- Name: users_users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_users_id_seq OWNED BY public.users.users_id;


--
-- TOC entry 263 (class 1259 OID 83206)
-- Name: v_karyawan_dashboard_transaksi; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_karyawan_dashboard_transaksi AS
 SELECT t.transaksi_id,
    t.created_at,
    t.catatan,
    u.nama AS nama_user,
    COALESCE(b.nama_barang, a.nama_alat) AS barang_atau_alat,
    COALESCE(dp.quantity, ds.quantity) AS jumlah,
    ((COALESCE(dp.quantity, ds.quantity))::numeric * COALESCE(dp.harga_per_item, ds.harga_sewa_perhari)) AS total,
        CASE
            WHEN ((p.opsi_pengiriman)::text = 'diantar'::text) THEN COALESCE(k.nama_kurir, '-'::character varying)
            ELSE '-'::character varying
        END AS nama_kurir,
    t.status_transaksi,
    COALESCE(sd.status_distribusi, '-'::character varying) AS status_distribusi,
        CASE
            WHEN (ds.detail_transaksi_sewa_id IS NOT NULL) THEN op.opsi_pengembalian
            ELSE '-'::character varying
        END AS opsi_pengembalian,
    p.metode_pembayaran,
    t.status_pembayaran
   FROM (((((((((public.transaksi t
     LEFT JOIN public.users u ON ((t.users_id = u.users_id)))
     LEFT JOIN public.pesanan p ON ((t.pesanan_id = p.pesanan_id)))
     LEFT JOIN public.kurir k ON ((t.kurir_id = k.kurir_id)))
     LEFT JOIN public.status_distribusi sd ON ((t.status_distribusi_id = sd.status_distribusi_id)))
     LEFT JOIN public.detail_transaksi_pembelian dp ON ((t.transaksi_id = dp.transaksi_id)))
     LEFT JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
     LEFT JOIN public.detail_transaksi_sewa ds ON ((t.transaksi_id = ds.transaksi_id)))
     LEFT JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
     LEFT JOIN public.opsi_pengembalian op ON ((ds.opsi_pengembalian_id = op.opsi_pengembalian_id)));


ALTER VIEW public.v_karyawan_dashboard_transaksi OWNER TO postgres;

--
-- TOC entry 264 (class 1259 OID 83223)
-- Name: v_karyawan_dashboard_transaksi_detail; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_karyawan_dashboard_transaksi_detail AS
 SELECT t.transaksi_id,
    t.created_at,
    u.nama AS nama_user,
    'Pembelian'::text AS jenis_pesanan,
    b.nama_barang AS nama_item,
    dp.quantity,
    dp.harga_per_item AS harga,
    ((dp.quantity)::numeric * dp.harga_per_item) AS total,
    NULL::date AS tgl_sewa,
    NULL::date AS tgl_pengembalian,
    (0)::numeric AS denda,
    '-'::character varying AS status_sewa,
    '-'::character varying AS opsi_pengembalian,
    p.metode_pembayaran,
    t.status_pembayaran,
    t.status_transaksi
   FROM ((((public.transaksi t
     JOIN public.users u ON ((t.users_id = u.users_id)))
     JOIN public.pesanan p ON ((t.pesanan_id = p.pesanan_id)))
     JOIN public.detail_transaksi_pembelian dp ON ((t.transaksi_id = dp.transaksi_id)))
     JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
UNION ALL
 SELECT t.transaksi_id,
    t.created_at,
    u.nama AS nama_user,
    'Penyewaan'::text AS jenis_pesanan,
    a.nama_alat AS nama_item,
    ds.quantity,
    ds.harga_sewa_perhari AS harga,
    ((ds.quantity)::numeric * ds.harga_sewa_perhari) AS total,
    ds.tgl_sewa,
    ds.tgl_pengembalian,
    ds.denda,
    ds.status_sewa,
    COALESCE(op.opsi_pengembalian, '-'::character varying) AS opsi_pengembalian,
    p.metode_pembayaran,
    t.status_pembayaran,
    t.status_transaksi
   FROM (((((public.transaksi t
     JOIN public.users u ON ((t.users_id = u.users_id)))
     JOIN public.pesanan p ON ((t.pesanan_id = p.pesanan_id)))
     JOIN public.detail_transaksi_sewa ds ON ((t.transaksi_id = ds.transaksi_id)))
     JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
     LEFT JOIN public.opsi_pengembalian op ON ((ds.opsi_pengembalian_id = op.opsi_pengembalian_id)));


ALTER VIEW public.v_karyawan_dashboard_transaksi_detail OWNER TO postgres;

--
-- TOC entry 256 (class 1259 OID 82949)
-- Name: v_karyawandatauser; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_karyawandatauser AS
 SELECT u.users_id,
    u.nama,
    u.no_telp,
    u.email,
    u.username,
    u.passwords,
    u.alamat,
    u.created_at,
    u.update_at,
    r.roles,
    d.nama_desa,
    k.nama_kecamatan,
    u.isactive
   FROM (((public.users u
     JOIN public.roles r USING (roles_id))
     JOIN public.desa d USING (desa_id))
     JOIN public.kecamatan k USING (kecamatan_id))
  WHERE (u.roles_id = 2);


ALTER VIEW public.v_karyawandatauser OWNER TO postgres;

--
-- TOC entry 257 (class 1259 OID 82954)
-- Name: v_laporan_denda; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_laporan_denda AS
 SELECT ds.detail_transaksi_sewa_id AS denda_id,
    u.nama AS nama_petani,
    a.nama_alat,
    ds.tgl_pengembalian AS tgl_seharusnya_kembali,
    CURRENT_DATE AS tgl_sekarang,
        CASE
            WHEN (CURRENT_DATE > ds.tgl_pengembalian) THEN (CURRENT_DATE - ds.tgl_pengembalian)
            ELSE 0
        END AS hari_keterlambatan,
    a.harga_denda_perhari,
        CASE
            WHEN (CURRENT_DATE > ds.tgl_pengembalian) THEN (((CURRENT_DATE - ds.tgl_pengembalian))::numeric * a.harga_denda_perhari)
            ELSE (0)::numeric
        END AS total_denda,
    ds.status_sewa AS status_pembayaran
   FROM (((public.detail_transaksi_sewa ds
     JOIN public.transaksi t ON ((ds.transaksi_id = t.transaksi_id)))
     JOIN public.users u ON ((t.users_id = u.users_id)))
     JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)));


ALTER VIEW public.v_laporan_denda OWNER TO postgres;

--
-- TOC entry 258 (class 1259 OID 82959)
-- Name: v_manajemen_distribusi; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_manajemen_distribusi AS
 SELECT t.transaksi_id,
    u.nama AS nama_user,
    COALESCE(b.nama_barang, a.nama_alat) AS nama_barang_alat,
    COALESCE(dp.quantity, ds.quantity) AS jumlah,
        CASE
            WHEN (dp.detail_transaksi_pembelian_id IS NOT NULL) THEN ((dp.quantity)::numeric * dp.harga_per_item)
            WHEN (ds.detail_transaksi_sewa_id IS NOT NULL) THEN (((ds.quantity)::numeric * ds.harga_sewa_perhari) * ((ds.tgl_pengembalian - ds.tgl_sewa))::numeric)
            ELSE (0)::numeric
        END AS total,
    t.status_pembayaran,
    COALESCE(sd.status_distribusi, '-'::character varying) AS status_distribusi,
    COALESCE(k.nama_kurir, '-'::character varying) AS nama_kurir,
    t.status_transaksi
   FROM (((((((public.transaksi t
     JOIN public.users u ON ((t.users_id = u.users_id)))
     LEFT JOIN public.kurir k ON ((t.kurir_id = k.kurir_id)))
     LEFT JOIN public.status_distribusi sd ON ((t.status_distribusi_id = sd.status_distribusi_id)))
     LEFT JOIN public.detail_transaksi_pembelian dp ON ((t.transaksi_id = dp.transaksi_id)))
     LEFT JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
     LEFT JOIN public.detail_transaksi_sewa ds ON ((t.transaksi_id = ds.transaksi_id)))
     LEFT JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
  WHERE (t.status_distribusi_id = ANY (ARRAY[1, 2, 3]));


ALTER VIEW public.v_manajemen_distribusi OWNER TO postgres;

--
-- TOC entry 262 (class 1259 OID 83181)
-- Name: v_pesanan_checkout; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_pesanan_checkout AS
 SELECT p.pesanan_id AS "ID Pesanan",
    u.nama AS "Nama Petani",
    (p.tanggal_pesanan)::date AS "Tanggal Pesanan",
    p.opsi_pengiriman AS "Pengiriman",
    b.nama_barang AS "Nama Item",
    dp.quantity AS "Jumlah",
    b.stok AS "Stok Sekarang",
    ((dp.quantity)::numeric * dp.harga_per_item) AS "Total Harga",
    'Pembelian'::text AS "Jenis",
    b.barang_id AS "Item ID",
    p.status_pesanan AS "Status"
   FROM (((public.pesanan p
     JOIN public.users u ON ((p.users_id = u.users_id)))
     JOIN public.detail_pesanan_pembelian dp ON ((p.pesanan_id = dp.pesanan_id)))
     JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
  WHERE ((p.status_pesanan)::text = 'Sudah Checkout'::text)
UNION ALL
 SELECT p.pesanan_id AS "ID Pesanan",
    u.nama AS "Nama Petani",
    (p.tanggal_pesanan)::date AS "Tanggal Pesanan",
    p.opsi_pengiriman AS "Pengiriman",
    a.nama_alat AS "Nama Item",
    ds.quantity AS "Jumlah",
    a.stok AS "Stok Sekarang",
    (((ds.quantity)::numeric * ds.harga_sewa_perhari) * ((ds.tgl_pengembalian - ds.tgl_sewa))::numeric) AS "Total Harga",
    'Penyewaan'::text AS "Jenis",
    a.alat_sewa_id AS "Item ID",
    p.status_pesanan AS "Status"
   FROM (((public.pesanan p
     JOIN public.users u ON ((p.users_id = u.users_id)))
     JOIN public.detail_pesanan_sewa ds ON ((p.pesanan_id = ds.pesanan_id)))
     JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
  WHERE ((p.status_pesanan)::text = 'Sudah Checkout'::text);


ALTER VIEW public.v_pesanan_checkout OWNER TO postgres;

--
-- TOC entry 259 (class 1259 OID 82969)
-- Name: v_pesanan_for_user; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_pesanan_for_user AS
 SELECT p.pesanan_id AS "ID",
    'Pembelian'::text AS "Jenis Pesanan",
    b.nama_barang AS "Nama Item",
    dpb.harga_per_item AS "Harga Satuan",
    dpb.quantity AS "Jumlah",
    NULL::integer AS "Lama Sewa (Hari)",
    p.tanggal_pesanan AS "Tanggal Pemesanan",
    p.status_pesanan AS "Status"
   FROM ((public.pesanan p
     JOIN public.detail_pesanan_pembelian dpb USING (pesanan_id))
     JOIN public.barang b USING (barang_id))
UNION ALL
 SELECT p.pesanan_id AS "ID",
    'Penyewaan'::text AS "Jenis Pesanan",
    a.nama_alat AS "Nama Item",
    dps.harga_sewa_perhari AS "Harga Satuan",
    dps.quantity AS "Jumlah",
    (dps.tgl_pengembalian - dps.tgl_sewa) AS "Lama Sewa (Hari)",
    p.tanggal_pesanan AS "Tanggal Pemesanan",
    p.status_pesanan AS "Status"
   FROM ((public.pesanan p
     JOIN public.detail_pesanan_sewa dps USING (pesanan_id))
     JOIN public.alat_sewa a USING (alat_sewa_id));


ALTER VIEW public.v_pesanan_for_user OWNER TO postgres;

--
-- TOC entry 260 (class 1259 OID 82974)
-- Name: v_petanidatauser; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_petanidatauser AS
 SELECT u.users_id,
    u.nama,
    u.no_telp,
    u.email,
    u.username,
    u.passwords,
    u.alamat,
    u.created_at,
    u.update_at,
    r.roles,
    d.nama_desa,
    k.nama_kecamatan,
    u.isactive
   FROM (((public.users u
     JOIN public.roles r USING (roles_id))
     JOIN public.desa d USING (desa_id))
     JOIN public.kecamatan k USING (kecamatan_id))
  WHERE (u.roles_id = 1);


ALTER VIEW public.v_petanidatauser OWNER TO postgres;

--
-- TOC entry 261 (class 1259 OID 82979)
-- Name: v_semuadatauser; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_semuadatauser AS
 SELECT u.users_id,
    u.nama,
    u.no_telp,
    u.email,
    u.username,
    u.passwords,
    u.alamat,
    u.created_at,
    u.update_at,
    r.roles,
    d.nama_desa,
    k.nama_kecamatan,
    u.isactive
   FROM (((public.users u
     JOIN public.roles r USING (roles_id))
     JOIN public.desa d USING (desa_id))
     JOIN public.kecamatan k USING (kecamatan_id));


ALTER VIEW public.v_semuadatauser OWNER TO postgres;

--
-- TOC entry 4903 (class 2604 OID 82992)
-- Name: alat_sewa alat_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa ALTER COLUMN alat_sewa_id SET DEFAULT nextval('public.alat_sewa_alat_sewa_id_seq'::regclass);


--
-- TOC entry 4904 (class 2604 OID 82993)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat ALTER COLUMN audit_stok_barang_alat_id SET DEFAULT nextval('public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq'::regclass);


--
-- TOC entry 4906 (class 2604 OID 82994)
-- Name: audit_transaksi audit_transaksi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi ALTER COLUMN audit_transaksi_id SET DEFAULT nextval('public.audit_transaksi_audit_transaksi_id_seq'::regclass);


--
-- TOC entry 4908 (class 2604 OID 82995)
-- Name: barang barang_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang ALTER COLUMN barang_id SET DEFAULT nextval('public.barang_barang_id_seq'::regclass);


--
-- TOC entry 4909 (class 2604 OID 82996)
-- Name: desa desa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa ALTER COLUMN desa_id SET DEFAULT nextval('public.desa_desa_id_seq'::regclass);


--
-- TOC entry 4910 (class 2604 OID 82997)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian ALTER COLUMN detail_pesanan_pembelian_id SET DEFAULT nextval('public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq'::regclass);


--
-- TOC entry 4911 (class 2604 OID 82998)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa ALTER COLUMN detail_pesanan_sewa_id SET DEFAULT nextval('public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq'::regclass);


--
-- TOC entry 4912 (class 2604 OID 82999)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian ALTER COLUMN detail_transaksi_pembelian_id SET DEFAULT nextval('public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq'::regclass);


--
-- TOC entry 4913 (class 2604 OID 83000)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa ALTER COLUMN detail_transaksi_sewa_id SET DEFAULT nextval('public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq'::regclass);


--
-- TOC entry 4915 (class 2604 OID 83001)
-- Name: kategori kategori_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategori ALTER COLUMN kategori_id SET DEFAULT nextval('public.kategori_kategori_id_seq'::regclass);


--
-- TOC entry 4916 (class 2604 OID 83002)
-- Name: kecamatan kecamatan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kecamatan ALTER COLUMN kecamatan_id SET DEFAULT nextval('public.kecamatan_kecamatan_id_seq'::regclass);


--
-- TOC entry 4917 (class 2604 OID 83003)
-- Name: kurir kurir_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kurir ALTER COLUMN kurir_id SET DEFAULT nextval('public.kurir_kurir_id_seq'::regclass);


--
-- TOC entry 4918 (class 2604 OID 83004)
-- Name: opsi_pengembalian opsi_pengembalian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.opsi_pengembalian ALTER COLUMN opsi_pengembalian_id SET DEFAULT nextval('public.opsi_pengembalian_opsi_pengembalian_id_seq'::regclass);


--
-- TOC entry 4919 (class 2604 OID 83005)
-- Name: pesanan pesanan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan ALTER COLUMN pesanan_id SET DEFAULT nextval('public.pesanan_pesanan_id_seq'::regclass);


--
-- TOC entry 4921 (class 2604 OID 83006)
-- Name: roles roles_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN roles_id SET DEFAULT nextval('public.roles_roles_id_seq'::regclass);


--
-- TOC entry 4922 (class 2604 OID 83007)
-- Name: status_distribusi status_distribusi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status_distribusi ALTER COLUMN status_distribusi_id SET DEFAULT nextval('public.status_distribusi_status_distribusi_id_seq'::regclass);


--
-- TOC entry 4923 (class 2604 OID 83008)
-- Name: transaksi transaksi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi ALTER COLUMN transaksi_id SET DEFAULT nextval('public.transaksi_transaksi_id_seq'::regclass);


--
-- TOC entry 4925 (class 2604 OID 83009)
-- Name: users users_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN users_id SET DEFAULT nextval('public.users_users_id_seq'::regclass);


--
-- TOC entry 5157 (class 0 OID 82832)
-- Dependencies: 217
-- Data for Name: alat_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.alat_sewa VALUES (3, 'Sekop', 5, 6000.00, 2000.00, 4, '2026-06-12 03:45:13.926722');
INSERT INTO public.alat_sewa VALUES (9, 'Cangkul', 3, 10000.00, 5000.00, 4, '2026-06-17 05:00:56.342384');


--
-- TOC entry 5159 (class 0 OID 82836)
-- Dependencies: 219
-- Data for Name: audit_stok_barang_alat; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.audit_stok_barang_alat VALUES (1, 3, 3, 'Update stok alat Cangkul', '2026-06-17 02:53:26.181829', 4, NULL, 3);
INSERT INTO public.audit_stok_barang_alat VALUES (2, 3, 3, 'Update stok alat Sekop', '2026-06-17 04:01:00.057514', 4, NULL, 3);
INSERT INTO public.audit_stok_barang_alat VALUES (3, 10, 10, 'Update stok barang biji mengkudu', '2026-06-17 04:24:51.767264', 4, 1, NULL);
INSERT INTO public.audit_stok_barang_alat VALUES (5, 3, 5, 'Update stok alat Sekop', '2026-06-17 04:50:42.62909', 4, NULL, 3);
INSERT INTO public.audit_stok_barang_alat VALUES (7, 10, 10, 'Update stok barang biji nanas', '2026-06-17 05:01:28.959767', 4, 1, NULL);


--
-- TOC entry 5161 (class 0 OID 82843)
-- Dependencies: 221
-- Data for Name: audit_transaksi; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5163 (class 0 OID 82850)
-- Dependencies: 223
-- Data for Name: barang; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.barang VALUES (2, 'biji apel', 9, 10000.00, 3, '2026-06-02 13:49:12.44456');
INSERT INTO public.barang VALUES (3, 'biji semangka', 44, 1000.00, NULL, NULL);
INSERT INTO public.barang VALUES (4, 'biji mangga', 5, 3000.00, NULL, NULL);
INSERT INTO public.barang VALUES (5, 'biji nangka', 3, 3000.00, NULL, NULL);
INSERT INTO public.barang VALUES (6, 'apel', 4, 5000.00, 3, '2026-06-17 04:00:26.045732');
INSERT INTO public.barang VALUES (7, 'benih kol', 9, 7000.00, 2, '2026-06-17 04:25:27.589644');
INSERT INTO public.barang VALUES (1, 'biji nanas', 10, 2000.00, 2, '2026-06-02 13:48:38.315861');
INSERT INTO public.barang VALUES (8, 'benih cabe', 3, 3000.00, 2, '2026-06-17 05:02:02.85675');


--
-- TOC entry 5165 (class 0 OID 82854)
-- Dependencies: 225
-- Data for Name: desa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.desa VALUES (4, 'kencong', 2);
INSERT INTO public.desa VALUES (5, 'ambulu', 2);


--
-- TOC entry 5167 (class 0 OID 82858)
-- Dependencies: 227
-- Data for Name: detail_pesanan_pembelian; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.detail_pesanan_pembelian VALUES (4, 4, 2000.00, 5, 1);


--
-- TOC entry 5169 (class 0 OID 82862)
-- Dependencies: 229
-- Data for Name: detail_pesanan_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.detail_pesanan_sewa VALUES (3, 1, 3500.00, '2026-06-16', '2026-06-23', 5, 3, 1);


--
-- TOC entry 5171 (class 0 OID 82866)
-- Dependencies: 231
-- Data for Name: detail_transaksi_pembelian; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5173 (class 0 OID 82870)
-- Dependencies: 233
-- Data for Name: detail_transaksi_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5175 (class 0 OID 82877)
-- Dependencies: 235
-- Data for Name: kategori; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kategori VALUES (2, 'Sayur', NULL);
INSERT INTO public.kategori VALUES (3, 'buah', NULL);
INSERT INTO public.kategori VALUES (4, 'alat', NULL);
INSERT INTO public.kategori VALUES (5, 'Kendaraan', 'Kategori otomatis dibuat');
INSERT INTO public.kategori VALUES (6, 'Perawatan', 'Kategori otomatis dibuat');


--
-- TOC entry 5177 (class 0 OID 82883)
-- Dependencies: 237
-- Data for Name: kecamatan; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kecamatan VALUES (2, 'sumbersari');


--
-- TOC entry 5179 (class 0 OID 82887)
-- Dependencies: 239
-- Data for Name: kurir; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kurir VALUES (1, 'fajril maulana hidayat', '089394991393', 'jl halmahera');
INSERT INTO public.kurir VALUES (2, 'Farel Pratama', '0834455624', 'Jl Krawu');


--
-- TOC entry 5181 (class 0 OID 82905)
-- Dependencies: 244
-- Data for Name: opsi_pengembalian; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.opsi_pengembalian VALUES (1, 'Diambil kurir');
INSERT INTO public.opsi_pengembalian VALUES (2, 'Antar sendiri');


--
-- TOC entry 5183 (class 0 OID 82909)
-- Dependencies: 246
-- Data for Name: pesanan; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.pesanan VALUES (5, '2026-06-16 19:26:35.739536', 3, 'Sudah Checkout', 'Ambil sendiri', 'Transfer Bank');


--
-- TOC entry 5185 (class 0 OID 82916)
-- Dependencies: 248
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.roles VALUES (1, 'petani');
INSERT INTO public.roles VALUES (2, 'karyawan');
INSERT INTO public.roles VALUES (3, 'admin');


--
-- TOC entry 5187 (class 0 OID 82920)
-- Dependencies: 250
-- Data for Name: status_distribusi; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.status_distribusi VALUES (1, 'Diproses');
INSERT INTO public.status_distribusi VALUES (2, 'Dikirim');
INSERT INTO public.status_distribusi VALUES (3, 'Diterima');
INSERT INTO public.status_distribusi VALUES (4, 'Ambil Sendiri');


--
-- TOC entry 5189 (class 0 OID 82924)
-- Dependencies: 252
-- Data for Name: transaksi; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5191 (class 0 OID 82931)
-- Dependencies: 254
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (4, 'tiwi', '0845678786754', 'tiwi@gmailcom', 'tiwi', '123', true, 'mastrip', '2026-06-08 22:56:32.806906', NULL, 1, 5);
INSERT INTO public.users VALUES (3, 'Marsha Devara', '0832435464535', 'marsha@gmail.com', 'devara', '123', true, 'raung', '2026-06-04 23:29:45.548503', '2026-06-16 11:37:05.575728', 1, 4);
INSERT INTO public.users VALUES (6, 'Mirza Super', '08657454424', 'mirz@gmail.com', 'mirza', '666', true, 'Jl Kalimantan', '2026-06-17 02:35:36.102109', NULL, 2, NULL);
INSERT INTO public.users VALUES (5, 'YunitaRamadhani', '098767890', 'YuniJember@gmail.com', 'yunik', '123', true, 'jln.Sumatera', '2026-06-14 17:25:39.637669', '2026-06-17 02:36:06.575632', 2, 4);
INSERT INTO public.users VALUES (7, 'Ferdiansyah Jubung', '08218418478', 'ferdi@', 'ferdi', '123', true, 'jl kaliurang', '2026-06-17 02:52:22.655575', NULL, 2, 4);
INSERT INTO public.users VALUES (1, 'Marsha Admin', '0857462735', 'marshaadmin@gmail.com', 'mar', '321', true, 'jawa', '2026-06-10 16:28:20.083858', '2026-06-17 04:49:11.758747', 3, 5);


--
-- TOC entry 5216 (class 0 OID 0)
-- Dependencies: 218
-- Name: alat_sewa_alat_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alat_sewa_alat_sewa_id_seq', 9, true);


--
-- TOC entry 5217 (class 0 OID 0)
-- Dependencies: 220
-- Name: audit_stok_barang_alat_audit_stok_barang_alat_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq', 7, true);


--
-- TOC entry 5218 (class 0 OID 0)
-- Dependencies: 222
-- Name: audit_transaksi_audit_transaksi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.audit_transaksi_audit_transaksi_id_seq', 1, false);


--
-- TOC entry 5219 (class 0 OID 0)
-- Dependencies: 224
-- Name: barang_barang_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.barang_barang_id_seq', 8, true);


--
-- TOC entry 5220 (class 0 OID 0)
-- Dependencies: 226
-- Name: desa_desa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.desa_desa_id_seq', 5, true);


--
-- TOC entry 5221 (class 0 OID 0)
-- Dependencies: 228
-- Name: detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq', 6, true);


--
-- TOC entry 5222 (class 0 OID 0)
-- Dependencies: 230
-- Name: detail_pesanan_sewa_detail_pesanan_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq', 3, true);


--
-- TOC entry 5223 (class 0 OID 0)
-- Dependencies: 232
-- Name: detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq', 1, false);


--
-- TOC entry 5224 (class 0 OID 0)
-- Dependencies: 234
-- Name: detail_transaksi_sewa_detail_transaksi_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq', 1, false);


--
-- TOC entry 5225 (class 0 OID 0)
-- Dependencies: 236
-- Name: kategori_kategori_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kategori_kategori_id_seq', 6, true);


--
-- TOC entry 5226 (class 0 OID 0)
-- Dependencies: 238
-- Name: kecamatan_kecamatan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kecamatan_kecamatan_id_seq', 2, true);


--
-- TOC entry 5227 (class 0 OID 0)
-- Dependencies: 240
-- Name: kurir_kurir_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kurir_kurir_id_seq', 2, true);


--
-- TOC entry 5228 (class 0 OID 0)
-- Dependencies: 245
-- Name: opsi_pengembalian_opsi_pengembalian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.opsi_pengembalian_opsi_pengembalian_id_seq', 2, true);


--
-- TOC entry 5229 (class 0 OID 0)
-- Dependencies: 247
-- Name: pesanan_pesanan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.pesanan_pesanan_id_seq', 7, true);


--
-- TOC entry 5230 (class 0 OID 0)
-- Dependencies: 249
-- Name: roles_roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_roles_id_seq', 3, true);


--
-- TOC entry 5231 (class 0 OID 0)
-- Dependencies: 251
-- Name: status_distribusi_status_distribusi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.status_distribusi_status_distribusi_id_seq', 1, false);


--
-- TOC entry 5232 (class 0 OID 0)
-- Dependencies: 253
-- Name: transaksi_transaksi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.transaksi_transaksi_id_seq', 1, false);


--
-- TOC entry 5233 (class 0 OID 0)
-- Dependencies: 255
-- Name: users_users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_users_id_seq', 7, true);


--
-- TOC entry 4929 (class 2606 OID 83011)
-- Name: alat_sewa alat_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa
    ADD CONSTRAINT alat_sewa_pkey PRIMARY KEY (alat_sewa_id);


--
-- TOC entry 4931 (class 2606 OID 83013)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_pkey PRIMARY KEY (audit_stok_barang_alat_id);


--
-- TOC entry 4933 (class 2606 OID 83015)
-- Name: audit_transaksi audit_transaksi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_pkey PRIMARY KEY (audit_transaksi_id);


--
-- TOC entry 4935 (class 2606 OID 83017)
-- Name: barang barang_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_pkey PRIMARY KEY (barang_id);


--
-- TOC entry 4937 (class 2606 OID 83019)
-- Name: desa desa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa
    ADD CONSTRAINT desa_pkey PRIMARY KEY (desa_id);


--
-- TOC entry 4939 (class 2606 OID 83021)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_pkey PRIMARY KEY (detail_pesanan_pembelian_id);


--
-- TOC entry 4941 (class 2606 OID 83023)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_pkey PRIMARY KEY (detail_pesanan_sewa_id);


--
-- TOC entry 4943 (class 2606 OID 83025)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_pkey PRIMARY KEY (detail_transaksi_pembelian_id);


--
-- TOC entry 4945 (class 2606 OID 83027)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_pkey PRIMARY KEY (detail_transaksi_sewa_id);


--
-- TOC entry 4947 (class 2606 OID 83029)
-- Name: kategori kategori_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategori
    ADD CONSTRAINT kategori_pkey PRIMARY KEY (kategori_id);


--
-- TOC entry 4949 (class 2606 OID 83031)
-- Name: kecamatan kecamatan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kecamatan
    ADD CONSTRAINT kecamatan_pkey PRIMARY KEY (kecamatan_id);


--
-- TOC entry 4951 (class 2606 OID 83033)
-- Name: kurir kurir_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kurir
    ADD CONSTRAINT kurir_pkey PRIMARY KEY (kurir_id);


--
-- TOC entry 4953 (class 2606 OID 83035)
-- Name: opsi_pengembalian opsi_pengembalian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.opsi_pengembalian
    ADD CONSTRAINT opsi_pengembalian_pkey PRIMARY KEY (opsi_pengembalian_id);


--
-- TOC entry 4955 (class 2606 OID 83037)
-- Name: pesanan pesanan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan
    ADD CONSTRAINT pesanan_pkey PRIMARY KEY (pesanan_id);


--
-- TOC entry 4957 (class 2606 OID 83039)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (roles_id);


--
-- TOC entry 4959 (class 2606 OID 83041)
-- Name: status_distribusi status_distribusi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status_distribusi
    ADD CONSTRAINT status_distribusi_pkey PRIMARY KEY (status_distribusi_id);


--
-- TOC entry 4961 (class 2606 OID 83234)
-- Name: transaksi transaksi_pesanan_id_unique; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_pesanan_id_unique UNIQUE (pesanan_id);


--
-- TOC entry 4963 (class 2606 OID 83043)
-- Name: transaksi transaksi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_pkey PRIMARY KEY (transaksi_id);


--
-- TOC entry 4965 (class 2606 OID 83045)
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- TOC entry 4967 (class 2606 OID 83047)
-- Name: users users_no_telp_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_no_telp_key UNIQUE (no_telp);


--
-- TOC entry 4969 (class 2606 OID 83049)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (users_id);


--
-- TOC entry 4971 (class 2606 OID 83051)
-- Name: users users_username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- TOC entry 4997 (class 2620 OID 83177)
-- Name: alat_sewa t_audit_stok_alat; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER t_audit_stok_alat AFTER UPDATE OF stok ON public.alat_sewa FOR EACH ROW EXECUTE FUNCTION public.log_audit_stok_alat();


--
-- TOC entry 4998 (class 2620 OID 83179)
-- Name: barang t_audit_stok_barang; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER t_audit_stok_barang AFTER UPDATE OF stok ON public.barang FOR EACH ROW EXECUTE FUNCTION public.log_audit_stok_barang();


--
-- TOC entry 4999 (class 2620 OID 83238)
-- Name: transaksi trg_audit_transaksi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER trg_audit_transaksi AFTER INSERT OR UPDATE ON public.transaksi FOR EACH ROW EXECUTE FUNCTION public.audit_transaksi_trigger_func();


--
-- TOC entry 4972 (class 2606 OID 83055)
-- Name: alat_sewa alat_sewa_kategori_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa
    ADD CONSTRAINT alat_sewa_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id) ON DELETE RESTRICT;


--
-- TOC entry 4973 (class 2606 OID 83060)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4974 (class 2606 OID 83065)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4975 (class 2606 OID 83070)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4976 (class 2606 OID 83075)
-- Name: audit_transaksi audit_transaksi_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4977 (class 2606 OID 83080)
-- Name: audit_transaksi audit_transaksi_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4978 (class 2606 OID 83085)
-- Name: barang barang_kategori_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id) ON DELETE RESTRICT;


--
-- TOC entry 4980 (class 2606 OID 83090)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4981 (class 2606 OID 83095)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_pesanan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_pesanan_id_fkey FOREIGN KEY (pesanan_id) REFERENCES public.pesanan(pesanan_id) ON DELETE CASCADE;


--
-- TOC entry 4982 (class 2606 OID 83100)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4983 (class 2606 OID 83105)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_opsi_pengembalian_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_opsi_pengembalian_id_fkey FOREIGN KEY (opsi_pengembalian_id) REFERENCES public.opsi_pengembalian(opsi_pengembalian_id) ON DELETE SET NULL;


--
-- TOC entry 4984 (class 2606 OID 83110)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_pesanan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_pesanan_id_fkey FOREIGN KEY (pesanan_id) REFERENCES public.pesanan(pesanan_id) ON DELETE CASCADE;


--
-- TOC entry 4985 (class 2606 OID 83115)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4986 (class 2606 OID 83120)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4987 (class 2606 OID 83125)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4988 (class 2606 OID 83130)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_opsi_pengembalian_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_opsi_pengembalian_id_fkey FOREIGN KEY (opsi_pengembalian_id) REFERENCES public.opsi_pengembalian(opsi_pengembalian_id) ON DELETE RESTRICT;


--
-- TOC entry 4989 (class 2606 OID 83135)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4979 (class 2606 OID 83140)
-- Name: desa fk_desa_kecamatan; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa
    ADD CONSTRAINT fk_desa_kecamatan FOREIGN KEY (kecamatan_id) REFERENCES public.kecamatan(kecamatan_id);


--
-- TOC entry 4990 (class 2606 OID 83145)
-- Name: pesanan pesanan_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan
    ADD CONSTRAINT pesanan_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4991 (class 2606 OID 83150)
-- Name: transaksi transaksi_kurir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_kurir_id_fkey FOREIGN KEY (kurir_id) REFERENCES public.kurir(kurir_id) ON DELETE SET NULL;


--
-- TOC entry 4992 (class 2606 OID 83228)
-- Name: transaksi transaksi_pesanan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_pesanan_id_fkey FOREIGN KEY (pesanan_id) REFERENCES public.pesanan(pesanan_id) ON DELETE SET NULL;


--
-- TOC entry 4993 (class 2606 OID 83155)
-- Name: transaksi transaksi_status_distribusi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_status_distribusi_id_fkey FOREIGN KEY (status_distribusi_id) REFERENCES public.status_distribusi(status_distribusi_id) ON DELETE RESTRICT;


--
-- TOC entry 4994 (class 2606 OID 83160)
-- Name: transaksi transaksi_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4995 (class 2606 OID 83165)
-- Name: users users_desa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_desa_id_fkey FOREIGN KEY (desa_id) REFERENCES public.desa(desa_id) ON DELETE SET NULL;


--
-- TOC entry 4996 (class 2606 OID 83170)
-- Name: users users_roles_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_roles_id_fkey FOREIGN KEY (roles_id) REFERENCES public.roles(roles_id) ON DELETE SET NULL;


--
-- TOC entry: View stok tersedikit (UNION barang + alat_sewa, diurutkan dari stok paling sedikit)
--

CREATE VIEW public.view_stok_tersedikit AS
 SELECT 'Barang'::text AS jenis,
    b.barang_id AS id,
    b.nama_barang AS nama,
    b.stok,
    b.harga_per_item AS harga,
    k.kategori
   FROM (public.barang b
     JOIN public.kategori k USING (kategori_id))
UNION ALL
 SELECT 'Alat Sewa'::text AS jenis,
    a.alat_sewa_id AS id,
    a.nama_alat AS nama,
    a.stok,
    a.harga_sewa_perhari AS harga,
    k.kategori
   FROM (public.alat_sewa a
     JOIN public.kategori k USING (kategori_id))
 ORDER BY stok ASC;


ALTER VIEW public.view_stok_tersedikit OWNER TO postgres;

-- Completed on 2026-06-17 07:50:38

--
-- PostgreSQL database dump complete
--

\unrestrict gDbhnHq5Qo9jIycmyxV4QhperdFlesqkA3zyWypUfKIWOpLt68WDwQAdNBvadGj

