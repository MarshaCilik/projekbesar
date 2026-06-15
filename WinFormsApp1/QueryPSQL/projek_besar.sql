--
-- PostgreSQL database dump
--

\restrict ygzCfqQ5aRgZVd7aWPozzhvySB0Fft6mfw4SL7iSqqxt8ZG5uTajbilXiFgEpKW

-- Dumped from database version 17.6
-- Dumped by pg_dump version 17.6

-- Started on 2026-06-16 00:56:23

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
-- TOC entry 268 (class 1255 OID 18260)
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
-- TOC entry 271 (class 1255 OID 18261)
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
-- TOC entry 272 (class 1255 OID 18262)
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
-- TOC entry 295 (class 1255 OID 18630)
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
-- TOC entry 286 (class 1255 OID 18264)
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
-- TOC entry 287 (class 1255 OID 18265)
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
-- TOC entry 296 (class 1255 OID 18631)
-- Name: checkout_pesanan(integer); Type: PROCEDURE; Schema: public; Owner: postgres
--

CREATE PROCEDURE public.checkout_pesanan(IN p_pesanan_id integer)
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
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, metode_pembayaran, status_pembayaran)
    VALUES (NOW(), 'Checkout pesanan ID ' || p_pesanan_id, v_users_id, 'Diproses', v_distribusi_id, 'Cash', 'belum lunas') RETURNING transaksi_id INTO v_transaksi_id;
    FOR r_detail_pembelian IN SELECT quantity, harga_per_item, barang_id FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id) VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;
    FOR r_detail_sewa IN SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id, opsi_pengembalian_id FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, r_detail_sewa.opsi_pengembalian_id);
    END LOOP;
END; $$;


ALTER PROCEDURE public.checkout_pesanan(IN p_pesanan_id integer) OWNER TO postgres;

--
-- TOC entry 267 (class 1255 OID 18267)
-- Name: f_get_dashboard_stats(date); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.f_get_dashboard_stats(p_tanggal date) RETURNS TABLE(total_transaksi bigint, barang_dikirim bigint)
    LANGUAGE plpgsql
    AS $$
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
$$;


ALTER FUNCTION public.f_get_dashboard_stats(p_tanggal date) OWNER TO postgres;

--
-- TOC entry 269 (class 1255 OID 18268)
-- Name: f_get_dashboard_stats(timestamp without time zone); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.f_get_dashboard_stats(p_tanggal timestamp without time zone) RETURNS TABLE(total_transaksi bigint, barang_dikirim bigint)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY SELECT * FROM f_get_dashboard_stats(p_tanggal::date);
END;
$$;


ALTER FUNCTION public.f_get_dashboard_stats(p_tanggal timestamp without time zone) OWNER TO postgres;

--
-- TOC entry 270 (class 1255 OID 18269)
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
-- TOC entry 298 (class 1255 OID 18633)
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
-- TOC entry 297 (class 1255 OID 18632)
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
-- TOC entry 301 (class 1255 OID 18636)
-- Name: get_tagihan_denda_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_tagihan_denda_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        t.transaksi_id,
        t.created_at,
        t.status_transaksi,
        t.metode_pembayaran,
        t.status_pembayaran,
        t.catatan,
        a.nama_alat,
        dts.quantity,
        dts.harga_sewa_perhari,
        dts.denda,
        dts.status_sewa,
        dts.tgl_sewa,
        dts.tgl_pengembalian,
        op.opsi_pengembalian
    FROM transaksi t
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
-- TOC entry 300 (class 1255 OID 18635)
-- Name: get_transaksi_berlangsung_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_transaksi_berlangsung_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        t.transaksi_id,
        t.created_at,
        t.status_transaksi,
        t.metode_pembayaran,
        t.status_pembayaran,
        t.catatan,
        a.nama_alat,
        dts.quantity,
        dts.harga_sewa_perhari,
        dts.denda,
        dts.status_sewa,
        dts.tgl_sewa,
        dts.tgl_pengembalian,
        op.opsi_pengembalian
    FROM transaksi t
    LEFT JOIN detail_transaksi_sewa dts ON t.transaksi_id = dts.transaksi_id
    LEFT JOIN alat_sewa a ON dts.alat_sewa_id = a.alat_sewa_id
    LEFT JOIN opsi_pengembalian op ON dts.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE t.users_id = p_users_id
      AND t.status_transaksi = 'Diproses'
    ORDER BY t.created_at DESC;
END;
$$;


ALTER FUNCTION public.get_transaksi_berlangsung_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 299 (class 1255 OID 18634)
-- Name: get_transaksi_selesai_by_user(integer); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.get_transaksi_selesai_by_user(p_users_id integer) RETURNS TABLE(transaksi_id integer, created_at timestamp without time zone, status_transaksi character varying, metode_pembayaran character varying, status_pembayaran character varying, catatan text, nama_alat character varying, quantity integer, harga_sewa_perhari numeric, denda numeric, status_sewa character varying, tgl_sewa date, tgl_pengembalian date, opsi_pengembalian character varying)
    LANGUAGE plpgsql
    AS $$
BEGIN
    RETURN QUERY
    SELECT
        t.transaksi_id,
        t.created_at,
        t.status_transaksi,
        t.metode_pembayaran,
        t.status_pembayaran,
        t.catatan,
        a.nama_alat,
        dts.quantity,
        dts.harga_sewa_perhari,
        dts.denda,
        dts.status_sewa,
        dts.tgl_sewa,
        dts.tgl_pengembalian,
        op.opsi_pengembalian
    FROM transaksi t
    LEFT JOIN detail_transaksi_sewa dts ON t.transaksi_id = dts.transaksi_id
    LEFT JOIN alat_sewa a ON dts.alat_sewa_id = a.alat_sewa_id
    LEFT JOIN opsi_pengembalian op ON dts.opsi_pengembalian_id = op.opsi_pengembalian_id
    WHERE t.users_id = p_users_id
      AND t.status_transaksi = 'Selesai'
    ORDER BY t.created_at DESC;
END;
$$;


ALTER FUNCTION public.get_transaksi_selesai_by_user(p_users_id integer) OWNER TO postgres;

--
-- TOC entry 288 (class 1255 OID 18272)
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
-- TOC entry 289 (class 1255 OID 18273)
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
-- TOC entry 290 (class 1255 OID 18274)
-- Name: log_audit_transaksi(); Type: FUNCTION; Schema: public; Owner: postgres
--

CREATE FUNCTION public.log_audit_transaksi() RETURNS trigger
    LANGUAGE plpgsql
    AS $$
DECLARE
    v_user_id int;
BEGIN
    v_user_id := NULLIF(current_setting('myapp.current_user_id', true), '')::int;
    IF v_user_id IS NULL THEN
        v_user_id := NEW.users_id; -- fallback ke user pemilik transaksi
    END IF;

    INSERT INTO audit_transaksi(aksi, waktu_perubahan, kolom_perubahan, value_lama, value_baru, transaksi_id, users_id)
    VALUES (
        'UPDATE', 
        NOW(), 
        'status_pembayaran / status_transaksi', 
        'Pembayaran: ' || OLD.status_pembayaran || ', Transaksi: ' || OLD.status_transaksi, 
        'Pembayaran: ' || NEW.status_pembayaran || ', Transaksi: ' || NEW.status_transaksi,
        NEW.transaksi_id,
        v_user_id
    );
    RETURN NEW;
END;
$$;


ALTER FUNCTION public.log_audit_transaksi() OWNER TO postgres;

--
-- TOC entry 291 (class 1255 OID 18275)
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
-- TOC entry 292 (class 1255 OID 18276)
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

    -- Validasi & Pengurangan Stok Barang
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
        
        UPDATE barang SET stok = stok - r_detail_pembelian.quantity WHERE barang_id = r_detail_pembelian.barang_id;
    END LOOP;

    -- Validasi & Pengurangan Stok Alat
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
        
        UPDATE alat_sewa SET stok = stok - r_detail_sewa.quantity WHERE alat_sewa_id = r_detail_sewa.alat_sewa_id;
    END LOOP;

    -- Update status pesanan
    UPDATE pesanan SET status_pesanan = 'Selesai' WHERE pesanan_id = p_pesanan_id;

    -- Tentukan status distribusi
    IF v_opsi = 'diantar' THEN
        v_distribusi_id := 1;
    ELSE
        v_distribusi_id := NULL;
    END IF;

    -- Buat transaksi
    INSERT INTO transaksi (created_at, catatan, users_id, status_transaksi, status_distribusi_id, metode_pembayaran, status_pembayaran)
    VALUES (NOW(), 'Penerimaan pesanan ID ' || p_pesanan_id || ' oleh ' || p_karyawan_username, v_users_id, 'Diproses', v_distribusi_id, 'Cash', 'belum lunas')
    RETURNING transaksi_id INTO v_transaksi_id;

    -- Copy detail pembelian
    FOR r_detail_pembelian IN SELECT quantity, harga_per_item, barang_id FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id)
        VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;

    -- Copy detail sewa
    FOR r_detail_sewa IN SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, 1);
    END LOOP;
END;
$$;


ALTER PROCEDURE public.p_terima_pesanan(IN p_pesanan_id integer, IN p_karyawan_username character varying) OWNER TO postgres;

--
-- TOC entry 293 (class 1255 OID 18277)
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
-- TOC entry 273 (class 1255 OID 18278)
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
-- TOC entry 274 (class 1255 OID 18279)
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
-- TOC entry 294 (class 1255 OID 18280)
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
-- TOC entry 217 (class 1259 OID 18281)
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
-- TOC entry 218 (class 1259 OID 18284)
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
-- TOC entry 5100 (class 0 OID 0)
-- Dependencies: 218
-- Name: alat_sewa_alat_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.alat_sewa_alat_sewa_id_seq OWNED BY public.alat_sewa.alat_sewa_id;


--
-- TOC entry 219 (class 1259 OID 18285)
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
-- TOC entry 220 (class 1259 OID 18291)
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
-- TOC entry 5101 (class 0 OID 0)
-- Dependencies: 220
-- Name: audit_stok_barang_alat_audit_stok_barang_alat_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq OWNED BY public.audit_stok_barang_alat.audit_stok_barang_alat_id;


--
-- TOC entry 221 (class 1259 OID 18292)
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
-- TOC entry 222 (class 1259 OID 18298)
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
-- TOC entry 5102 (class 0 OID 0)
-- Dependencies: 222
-- Name: audit_transaksi_audit_transaksi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.audit_transaksi_audit_transaksi_id_seq OWNED BY public.audit_transaksi.audit_transaksi_id;


--
-- TOC entry 223 (class 1259 OID 18299)
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
-- TOC entry 224 (class 1259 OID 18302)
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
-- TOC entry 5103 (class 0 OID 0)
-- Dependencies: 224
-- Name: barang_barang_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.barang_barang_id_seq OWNED BY public.barang.barang_id;


--
-- TOC entry 225 (class 1259 OID 18303)
-- Name: desa; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.desa (
    desa_id integer NOT NULL,
    nama_desa character varying(255) NOT NULL,
    kecamatan_id integer NOT NULL
);


ALTER TABLE public.desa OWNER TO postgres;

--
-- TOC entry 226 (class 1259 OID 18306)
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
-- TOC entry 5104 (class 0 OID 0)
-- Dependencies: 226
-- Name: desa_desa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.desa_desa_id_seq OWNED BY public.desa.desa_id;


--
-- TOC entry 227 (class 1259 OID 18307)
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
-- TOC entry 228 (class 1259 OID 18310)
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
-- TOC entry 5105 (class 0 OID 0)
-- Dependencies: 228
-- Name: detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq OWNED BY public.detail_pesanan_pembelian.detail_pesanan_pembelian_id;


--
-- TOC entry 229 (class 1259 OID 18311)
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
-- TOC entry 230 (class 1259 OID 18314)
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
-- TOC entry 5106 (class 0 OID 0)
-- Dependencies: 230
-- Name: detail_pesanan_sewa_detail_pesanan_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq OWNED BY public.detail_pesanan_sewa.detail_pesanan_sewa_id;


--
-- TOC entry 231 (class 1259 OID 18315)
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
-- TOC entry 232 (class 1259 OID 18318)
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
-- TOC entry 5107 (class 0 OID 0)
-- Dependencies: 232
-- Name: detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq OWNED BY public.detail_transaksi_pembelian.detail_transaksi_pembelian_id;


--
-- TOC entry 233 (class 1259 OID 18319)
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
-- TOC entry 234 (class 1259 OID 18325)
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
-- TOC entry 5108 (class 0 OID 0)
-- Dependencies: 234
-- Name: detail_transaksi_sewa_detail_transaksi_sewa_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq OWNED BY public.detail_transaksi_sewa.detail_transaksi_sewa_id;


--
-- TOC entry 235 (class 1259 OID 18326)
-- Name: kategori; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kategori (
    kategori_id integer NOT NULL,
    kategori character varying(255) NOT NULL,
    deskripsi text
);


ALTER TABLE public.kategori OWNER TO postgres;

--
-- TOC entry 236 (class 1259 OID 18331)
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
-- TOC entry 5109 (class 0 OID 0)
-- Dependencies: 236
-- Name: kategori_kategori_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kategori_kategori_id_seq OWNED BY public.kategori.kategori_id;


--
-- TOC entry 237 (class 1259 OID 18332)
-- Name: kecamatan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kecamatan (
    kecamatan_id integer NOT NULL,
    nama_kecamatan character varying(255) NOT NULL
);


ALTER TABLE public.kecamatan OWNER TO postgres;

--
-- TOC entry 238 (class 1259 OID 18335)
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
-- TOC entry 5110 (class 0 OID 0)
-- Dependencies: 238
-- Name: kecamatan_kecamatan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kecamatan_kecamatan_id_seq OWNED BY public.kecamatan.kecamatan_id;


--
-- TOC entry 239 (class 1259 OID 18336)
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
-- TOC entry 240 (class 1259 OID 18341)
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
-- TOC entry 5111 (class 0 OID 0)
-- Dependencies: 240
-- Name: kurir_kurir_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.kurir_kurir_id_seq OWNED BY public.kurir.kurir_id;


--
-- TOC entry 241 (class 1259 OID 18342)
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
-- TOC entry 242 (class 1259 OID 18346)
-- Name: lihat_barang_petani; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.lihat_barang_petani AS
 SELECT b.barang_id,
    b.nama_barang AS "nama barang",
    b.stok,
    b.harga_per_item AS "harga per unit",
    k.kategori
   FROM (public.barang b
     JOIN public.kategori k USING (kategori_id));


ALTER VIEW public.lihat_barang_petani OWNER TO postgres;

--
-- TOC entry 243 (class 1259 OID 18350)
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
-- TOC entry 244 (class 1259 OID 18354)
-- Name: opsi_pengembalian; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.opsi_pengembalian (
    opsi_pengembalian_id integer NOT NULL,
    opsi_pengembalian character varying(255) NOT NULL
);


ALTER TABLE public.opsi_pengembalian OWNER TO postgres;

--
-- TOC entry 245 (class 1259 OID 18357)
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
-- TOC entry 5112 (class 0 OID 0)
-- Dependencies: 245
-- Name: opsi_pengembalian_opsi_pengembalian_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.opsi_pengembalian_opsi_pengembalian_id_seq OWNED BY public.opsi_pengembalian.opsi_pengembalian_id;


--
-- TOC entry 246 (class 1259 OID 18358)
-- Name: pesanan; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.pesanan (
    pesanan_id integer NOT NULL,
    tanggal_pesanan timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    users_id integer NOT NULL,
    status_pesanan character varying NOT NULL,
    opsi_pengiriman character varying
);


ALTER TABLE public.pesanan OWNER TO postgres;

--
-- TOC entry 247 (class 1259 OID 18364)
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
-- TOC entry 5113 (class 0 OID 0)
-- Dependencies: 247
-- Name: pesanan_pesanan_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.pesanan_pesanan_id_seq OWNED BY public.pesanan.pesanan_id;


--
-- TOC entry 248 (class 1259 OID 18365)
-- Name: roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.roles (
    roles_id integer NOT NULL,
    roles character varying(100) NOT NULL
);


ALTER TABLE public.roles OWNER TO postgres;

--
-- TOC entry 249 (class 1259 OID 18368)
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
-- TOC entry 5114 (class 0 OID 0)
-- Dependencies: 249
-- Name: roles_roles_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.roles_roles_id_seq OWNED BY public.roles.roles_id;


--
-- TOC entry 250 (class 1259 OID 18369)
-- Name: status_distribusi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.status_distribusi (
    status_distribusi_id integer NOT NULL,
    status_distribusi character varying(100) NOT NULL
);


ALTER TABLE public.status_distribusi OWNER TO postgres;

--
-- TOC entry 251 (class 1259 OID 18372)
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
-- TOC entry 5115 (class 0 OID 0)
-- Dependencies: 251
-- Name: status_distribusi_status_distribusi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.status_distribusi_status_distribusi_id_seq OWNED BY public.status_distribusi.status_distribusi_id;


--
-- TOC entry 252 (class 1259 OID 18373)
-- Name: transaksi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.transaksi (
    transaksi_id integer NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP NOT NULL,
    catatan text,
    ongkos_kirim numeric(15,2),
    users_id integer NOT NULL,
    kurir_id integer,
    status_transaksi character varying NOT NULL,
    status_distribusi_id integer NOT NULL,
    metode_pembayaran character varying NOT NULL,
    status_pembayaran character varying NOT NULL
);


ALTER TABLE public.transaksi OWNER TO postgres;

--
-- TOC entry 253 (class 1259 OID 18379)
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
-- TOC entry 5116 (class 0 OID 0)
-- Dependencies: 253
-- Name: transaksi_transaksi_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.transaksi_transaksi_id_seq OWNED BY public.transaksi.transaksi_id;


--
-- TOC entry 254 (class 1259 OID 18380)
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
-- TOC entry 255 (class 1259 OID 18387)
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
-- TOC entry 5117 (class 0 OID 0)
-- Dependencies: 255
-- Name: users_users_id_seq; Type: SEQUENCE OWNED BY; Schema: public; Owner: postgres
--

ALTER SEQUENCE public.users_users_id_seq OWNED BY public.users.users_id;


--
-- TOC entry 256 (class 1259 OID 18388)
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
    t.metode_pembayaran,
    t.status_pembayaran
   FROM (((((((((public.transaksi t
     LEFT JOIN public.users u ON ((t.users_id = u.users_id)))
     LEFT JOIN public.pesanan p ON (((t.users_id = p.users_id) AND ((p.status_pesanan)::text = 'Sudah Checkout'::text))))
     LEFT JOIN public.kurir k ON ((t.kurir_id = k.kurir_id)))
     LEFT JOIN public.status_distribusi sd ON ((t.status_distribusi_id = sd.status_distribusi_id)))
     LEFT JOIN public.detail_transaksi_pembelian dp ON ((t.transaksi_id = dp.transaksi_id)))
     LEFT JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
     LEFT JOIN public.detail_transaksi_sewa ds ON ((t.transaksi_id = ds.transaksi_id)))
     LEFT JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
     LEFT JOIN public.opsi_pengembalian op ON ((ds.opsi_pengembalian_id = op.opsi_pengembalian_id)));


ALTER VIEW public.v_karyawan_dashboard_transaksi OWNER TO postgres;

--
-- TOC entry 257 (class 1259 OID 18393)
-- Name: v_karyawan_keuangan; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_karyawan_keuangan AS
 SELECT 'Penjualan'::character varying AS tipe,
    b.nama_barang AS keterangan,
    ((dp.quantity)::numeric * dp.harga_per_item) AS jumlah,
    t.created_at,
    u.nama AS oleh
   FROM (((public.detail_transaksi_pembelian dp
     JOIN public.transaksi t ON ((dp.transaksi_id = t.transaksi_id)))
     JOIN public.barang b ON ((dp.barang_id = b.barang_id)))
     JOIN public.users u ON ((t.users_id = u.users_id)))
  WHERE ((t.status_pembayaran)::text = 'lunas'::text)
UNION ALL
 SELECT 'Sewa Alat'::character varying AS tipe,
    a.nama_alat AS keterangan,
    (((ds.quantity)::numeric * ds.harga_sewa_perhari) * ((ds.tgl_pengembalian - ds.tgl_sewa))::numeric) AS jumlah,
    t.created_at,
    u.nama AS oleh
   FROM (((public.detail_transaksi_sewa ds
     JOIN public.transaksi t ON ((ds.transaksi_id = t.transaksi_id)))
     JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
     JOIN public.users u ON ((t.users_id = u.users_id)))
  WHERE ((t.status_pembayaran)::text = 'lunas'::text)
UNION ALL
 SELECT 'Denda'::character varying AS tipe,
    ('Denda keterlambatan '::text || (a.nama_alat)::text) AS keterangan,
    ds.denda AS jumlah,
    t.created_at,
    u.nama AS oleh
   FROM (((public.detail_transaksi_sewa ds
     JOIN public.transaksi t ON ((ds.transaksi_id = t.transaksi_id)))
     JOIN public.alat_sewa a ON ((ds.alat_sewa_id = a.alat_sewa_id)))
     JOIN public.users u ON ((t.users_id = u.users_id)))
  WHERE ((ds.denda > (0)::numeric) AND ((ds.status_sewa)::text = 'Lunas'::text));


ALTER VIEW public.v_karyawan_keuangan OWNER TO postgres;

--
-- TOC entry 258 (class 1259 OID 18398)
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
-- TOC entry 259 (class 1259 OID 18403)
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
-- TOC entry 260 (class 1259 OID 18408)
-- Name: v_manajemen_distribusi; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_manajemen_distribusi AS
 SELECT t.transaksi_id,
    u.nama AS nama_user,
    COALESCE(b.nama_barang, a.nama_alat) AS nama_barang_alat,
    COALESCE(dp.quantity, ds.quantity) AS jumlah,
    ((COALESCE(dp.quantity, ds.quantity))::numeric * COALESCE(dp.harga_per_item, ds.harga_sewa_perhari)) AS total,
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
-- TOC entry 261 (class 1259 OID 18413)
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
-- TOC entry 262 (class 1259 OID 18418)
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
-- TOC entry 263 (class 1259 OID 18423)
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
-- TOC entry 264 (class 1259 OID 18428)
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
-- TOC entry 265 (class 1259 OID 18433)
-- Name: v_update_stok_alat; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_update_stok_alat AS
 SELECT alat_sewa_id AS id,
    nama_alat AS nama,
    harga_sewa_perhari AS harga,
    stok
   FROM public.alat_sewa;


ALTER VIEW public.v_update_stok_alat OWNER TO postgres;

--
-- TOC entry 266 (class 1259 OID 18437)
-- Name: v_update_stok_barang; Type: VIEW; Schema: public; Owner: postgres
--

CREATE VIEW public.v_update_stok_barang AS
 SELECT barang_id AS id,
    nama_barang AS nama,
    harga_per_item AS harga,
    stok
   FROM public.barang;


ALTER VIEW public.v_update_stok_barang OWNER TO postgres;

--
-- TOC entry 4806 (class 2604 OID 18441)
-- Name: alat_sewa alat_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa ALTER COLUMN alat_sewa_id SET DEFAULT nextval('public.alat_sewa_alat_sewa_id_seq'::regclass);


--
-- TOC entry 4807 (class 2604 OID 18442)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat ALTER COLUMN audit_stok_barang_alat_id SET DEFAULT nextval('public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq'::regclass);


--
-- TOC entry 4809 (class 2604 OID 18443)
-- Name: audit_transaksi audit_transaksi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi ALTER COLUMN audit_transaksi_id SET DEFAULT nextval('public.audit_transaksi_audit_transaksi_id_seq'::regclass);


--
-- TOC entry 4811 (class 2604 OID 18444)
-- Name: barang barang_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang ALTER COLUMN barang_id SET DEFAULT nextval('public.barang_barang_id_seq'::regclass);


--
-- TOC entry 4812 (class 2604 OID 18445)
-- Name: desa desa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa ALTER COLUMN desa_id SET DEFAULT nextval('public.desa_desa_id_seq'::regclass);


--
-- TOC entry 4813 (class 2604 OID 18446)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian ALTER COLUMN detail_pesanan_pembelian_id SET DEFAULT nextval('public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq'::regclass);


--
-- TOC entry 4814 (class 2604 OID 18447)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa ALTER COLUMN detail_pesanan_sewa_id SET DEFAULT nextval('public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq'::regclass);


--
-- TOC entry 4815 (class 2604 OID 18448)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian ALTER COLUMN detail_transaksi_pembelian_id SET DEFAULT nextval('public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq'::regclass);


--
-- TOC entry 4816 (class 2604 OID 18449)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa ALTER COLUMN detail_transaksi_sewa_id SET DEFAULT nextval('public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq'::regclass);


--
-- TOC entry 4818 (class 2604 OID 18450)
-- Name: kategori kategori_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategori ALTER COLUMN kategori_id SET DEFAULT nextval('public.kategori_kategori_id_seq'::regclass);


--
-- TOC entry 4819 (class 2604 OID 18451)
-- Name: kecamatan kecamatan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kecamatan ALTER COLUMN kecamatan_id SET DEFAULT nextval('public.kecamatan_kecamatan_id_seq'::regclass);


--
-- TOC entry 4820 (class 2604 OID 18452)
-- Name: kurir kurir_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kurir ALTER COLUMN kurir_id SET DEFAULT nextval('public.kurir_kurir_id_seq'::regclass);


--
-- TOC entry 4821 (class 2604 OID 18453)
-- Name: opsi_pengembalian opsi_pengembalian_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.opsi_pengembalian ALTER COLUMN opsi_pengembalian_id SET DEFAULT nextval('public.opsi_pengembalian_opsi_pengembalian_id_seq'::regclass);


--
-- TOC entry 4822 (class 2604 OID 18454)
-- Name: pesanan pesanan_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan ALTER COLUMN pesanan_id SET DEFAULT nextval('public.pesanan_pesanan_id_seq'::regclass);


--
-- TOC entry 4824 (class 2604 OID 18455)
-- Name: roles roles_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles ALTER COLUMN roles_id SET DEFAULT nextval('public.roles_roles_id_seq'::regclass);


--
-- TOC entry 4825 (class 2604 OID 18456)
-- Name: status_distribusi status_distribusi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status_distribusi ALTER COLUMN status_distribusi_id SET DEFAULT nextval('public.status_distribusi_status_distribusi_id_seq'::regclass);


--
-- TOC entry 4826 (class 2604 OID 18457)
-- Name: transaksi transaksi_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi ALTER COLUMN transaksi_id SET DEFAULT nextval('public.transaksi_transaksi_id_seq'::regclass);


--
-- TOC entry 4828 (class 2604 OID 18458)
-- Name: users users_id; Type: DEFAULT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users ALTER COLUMN users_id SET DEFAULT nextval('public.users_users_id_seq'::regclass);


--
-- TOC entry 5059 (class 0 OID 18281)
-- Dependencies: 217
-- Data for Name: alat_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.alat_sewa VALUES (3, 'Sekop', 3, 3500.00, 2000.00, 4, '2026-06-12 03:45:13.926722');


--
-- TOC entry 5061 (class 0 OID 18285)
-- Dependencies: 219
-- Data for Name: audit_stok_barang_alat; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5063 (class 0 OID 18292)
-- Dependencies: 221
-- Data for Name: audit_transaksi; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5065 (class 0 OID 18299)
-- Dependencies: 223
-- Data for Name: barang; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.barang VALUES (1, 'biji wortel', 10, 2000.00, 2, '2026-06-02 13:48:38.315861');
INSERT INTO public.barang VALUES (2, 'biji apel', 9, 10000.00, 3, '2026-06-02 13:49:12.44456');


--
-- TOC entry 5067 (class 0 OID 18303)
-- Dependencies: 225
-- Data for Name: desa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.desa VALUES (4, 'kencong', 2);
INSERT INTO public.desa VALUES (5, 'ambulu', 2);


--
-- TOC entry 5069 (class 0 OID 18307)
-- Dependencies: 227
-- Data for Name: detail_pesanan_pembelian; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.detail_pesanan_pembelian VALUES (2, 8, 2000.00, 2, 1);


--
-- TOC entry 5071 (class 0 OID 18311)
-- Dependencies: 229
-- Data for Name: detail_pesanan_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.detail_pesanan_sewa VALUES (1, 9, 3500.00, '2026-06-13', '2026-06-15', 2, 3, NULL);
INSERT INTO public.detail_pesanan_sewa VALUES (2, 7, 3500.00, '2026-06-15', '2026-06-20', 3, 3, 2);


--
-- TOC entry 5073 (class 0 OID 18315)
-- Dependencies: 231
-- Data for Name: detail_transaksi_pembelian; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5075 (class 0 OID 18319)
-- Dependencies: 233
-- Data for Name: detail_transaksi_sewa; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5077 (class 0 OID 18326)
-- Dependencies: 235
-- Data for Name: kategori; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kategori VALUES (2, 'Sayur', NULL);
INSERT INTO public.kategori VALUES (3, 'buah', NULL);
INSERT INTO public.kategori VALUES (4, 'alat', NULL);


--
-- TOC entry 5079 (class 0 OID 18332)
-- Dependencies: 237
-- Data for Name: kecamatan; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.kecamatan VALUES (2, 'sumbersari');


--
-- TOC entry 5081 (class 0 OID 18336)
-- Dependencies: 239
-- Data for Name: kurir; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5083 (class 0 OID 18354)
-- Dependencies: 244
-- Data for Name: opsi_pengembalian; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.opsi_pengembalian VALUES (1, 'Diambil kurir');
INSERT INTO public.opsi_pengembalian VALUES (2, 'Antar sendiri');


--
-- TOC entry 5085 (class 0 OID 18358)
-- Dependencies: 246
-- Data for Name: pesanan; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.pesanan VALUES (2, '2026-06-13 00:00:00', 3, 'Sudah Checkout', 'Ambil sendiri');
INSERT INTO public.pesanan VALUES (3, '2026-06-15 00:00:00', 3, 'Belum Checkout', 'Diantar kurir');


--
-- TOC entry 5087 (class 0 OID 18365)
-- Dependencies: 248
-- Data for Name: roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.roles VALUES (1, 'petani');
INSERT INTO public.roles VALUES (2, 'karyawan');
INSERT INTO public.roles VALUES (3, 'admin');


--
-- TOC entry 5089 (class 0 OID 18369)
-- Dependencies: 250
-- Data for Name: status_distribusi; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.status_distribusi VALUES (1, 'Diproses');
INSERT INTO public.status_distribusi VALUES (2, 'Dikirim');
INSERT INTO public.status_distribusi VALUES (3, 'Diterima');
INSERT INTO public.status_distribusi VALUES (4, 'Ambil Sendiri');


--
-- TOC entry 5091 (class 0 OID 18373)
-- Dependencies: 252
-- Data for Name: transaksi; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 5093 (class 0 OID 18380)
-- Dependencies: 254
-- Data for Name: users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.users VALUES (4, 'tiwi', '0845678786754', 'tiwi@gmailcom', 'tiwi', '123', true, 'mastrip', '2026-06-08 22:56:32.806906', NULL, 1, 5);
INSERT INTO public.users VALUES (1, 'Marsha Jahat', '0857462735', 'marshaadmin@gmail.com', 'adminmar', '321', true, 'jawa', '2026-06-10 16:28:20.083858', NULL, 3, 5);
INSERT INTO public.users VALUES (5, 'YunitaRamadhani', '098767890', 'YuniJember@gmail.com', 'Yuni', '999', true, 'jln.Sumatera', '2026-06-14 17:25:39.637669', NULL, 2, 4);
INSERT INTO public.users VALUES (3, 'Marsha Devara', '0832435464535', 'marsha@gmail.com', 'marsha', '123', true, 'raung', '2026-06-04 23:29:45.548503', '2026-06-15 19:32:45.327612', 1, 4);


--
-- TOC entry 5118 (class 0 OID 0)
-- Dependencies: 218
-- Name: alat_sewa_alat_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.alat_sewa_alat_sewa_id_seq', 3, true);


--
-- TOC entry 5119 (class 0 OID 0)
-- Dependencies: 220
-- Name: audit_stok_barang_alat_audit_stok_barang_alat_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.audit_stok_barang_alat_audit_stok_barang_alat_id_seq', 1, false);


--
-- TOC entry 5120 (class 0 OID 0)
-- Dependencies: 222
-- Name: audit_transaksi_audit_transaksi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.audit_transaksi_audit_transaksi_id_seq', 1, false);


--
-- TOC entry 5121 (class 0 OID 0)
-- Dependencies: 224
-- Name: barang_barang_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.barang_barang_id_seq', 2, true);


--
-- TOC entry 5122 (class 0 OID 0)
-- Dependencies: 226
-- Name: desa_desa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.desa_desa_id_seq', 5, true);


--
-- TOC entry 5123 (class 0 OID 0)
-- Dependencies: 228
-- Name: detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_pesanan_pembelian_detail_pesanan_pembelian_id_seq', 2, true);


--
-- TOC entry 5124 (class 0 OID 0)
-- Dependencies: 230
-- Name: detail_pesanan_sewa_detail_pesanan_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_pesanan_sewa_detail_pesanan_sewa_id_seq', 2, true);


--
-- TOC entry 5125 (class 0 OID 0)
-- Dependencies: 232
-- Name: detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_transaksi_pembelian_detail_transaksi_pembelian_id_seq', 1, false);


--
-- TOC entry 5126 (class 0 OID 0)
-- Dependencies: 234
-- Name: detail_transaksi_sewa_detail_transaksi_sewa_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.detail_transaksi_sewa_detail_transaksi_sewa_id_seq', 1, false);


--
-- TOC entry 5127 (class 0 OID 0)
-- Dependencies: 236
-- Name: kategori_kategori_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kategori_kategori_id_seq', 4, true);


--
-- TOC entry 5128 (class 0 OID 0)
-- Dependencies: 238
-- Name: kecamatan_kecamatan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kecamatan_kecamatan_id_seq', 2, true);


--
-- TOC entry 5129 (class 0 OID 0)
-- Dependencies: 240
-- Name: kurir_kurir_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.kurir_kurir_id_seq', 1, false);


--
-- TOC entry 5130 (class 0 OID 0)
-- Dependencies: 245
-- Name: opsi_pengembalian_opsi_pengembalian_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.opsi_pengembalian_opsi_pengembalian_id_seq', 2, true);


--
-- TOC entry 5131 (class 0 OID 0)
-- Dependencies: 247
-- Name: pesanan_pesanan_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.pesanan_pesanan_id_seq', 3, true);


--
-- TOC entry 5132 (class 0 OID 0)
-- Dependencies: 249
-- Name: roles_roles_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.roles_roles_id_seq', 3, true);


--
-- TOC entry 5133 (class 0 OID 0)
-- Dependencies: 251
-- Name: status_distribusi_status_distribusi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.status_distribusi_status_distribusi_id_seq', 1, false);


--
-- TOC entry 5134 (class 0 OID 0)
-- Dependencies: 253
-- Name: transaksi_transaksi_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.transaksi_transaksi_id_seq', 1, false);


--
-- TOC entry 5135 (class 0 OID 0)
-- Dependencies: 255
-- Name: users_users_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_users_id_seq', 5, true);


--
-- TOC entry 4832 (class 2606 OID 18460)
-- Name: alat_sewa alat_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa
    ADD CONSTRAINT alat_sewa_pkey PRIMARY KEY (alat_sewa_id);


--
-- TOC entry 4834 (class 2606 OID 18462)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_pkey PRIMARY KEY (audit_stok_barang_alat_id);


--
-- TOC entry 4836 (class 2606 OID 18464)
-- Name: audit_transaksi audit_transaksi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_pkey PRIMARY KEY (audit_transaksi_id);


--
-- TOC entry 4838 (class 2606 OID 18466)
-- Name: barang barang_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_pkey PRIMARY KEY (barang_id);


--
-- TOC entry 4840 (class 2606 OID 18468)
-- Name: desa desa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa
    ADD CONSTRAINT desa_pkey PRIMARY KEY (desa_id);


--
-- TOC entry 4842 (class 2606 OID 18470)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_pkey PRIMARY KEY (detail_pesanan_pembelian_id);


--
-- TOC entry 4844 (class 2606 OID 18472)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_pkey PRIMARY KEY (detail_pesanan_sewa_id);


--
-- TOC entry 4846 (class 2606 OID 18474)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_pkey PRIMARY KEY (detail_transaksi_pembelian_id);


--
-- TOC entry 4848 (class 2606 OID 18476)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_pkey PRIMARY KEY (detail_transaksi_sewa_id);


--
-- TOC entry 4850 (class 2606 OID 18478)
-- Name: kategori kategori_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kategori
    ADD CONSTRAINT kategori_pkey PRIMARY KEY (kategori_id);


--
-- TOC entry 4852 (class 2606 OID 18480)
-- Name: kecamatan kecamatan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kecamatan
    ADD CONSTRAINT kecamatan_pkey PRIMARY KEY (kecamatan_id);


--
-- TOC entry 4854 (class 2606 OID 18482)
-- Name: kurir kurir_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kurir
    ADD CONSTRAINT kurir_pkey PRIMARY KEY (kurir_id);


--
-- TOC entry 4856 (class 2606 OID 18484)
-- Name: opsi_pengembalian opsi_pengembalian_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.opsi_pengembalian
    ADD CONSTRAINT opsi_pengembalian_pkey PRIMARY KEY (opsi_pengembalian_id);


--
-- TOC entry 4858 (class 2606 OID 18486)
-- Name: pesanan pesanan_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan
    ADD CONSTRAINT pesanan_pkey PRIMARY KEY (pesanan_id);


--
-- TOC entry 4860 (class 2606 OID 18488)
-- Name: roles roles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (roles_id);


--
-- TOC entry 4862 (class 2606 OID 18490)
-- Name: status_distribusi status_distribusi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.status_distribusi
    ADD CONSTRAINT status_distribusi_pkey PRIMARY KEY (status_distribusi_id);


--
-- TOC entry 4864 (class 2606 OID 18492)
-- Name: transaksi transaksi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_pkey PRIMARY KEY (transaksi_id);


--
-- TOC entry 4866 (class 2606 OID 18494)
-- Name: users users_email_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_email_key UNIQUE (email);


--
-- TOC entry 4868 (class 2606 OID 18496)
-- Name: users users_no_telp_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_no_telp_key UNIQUE (no_telp);


--
-- TOC entry 4870 (class 2606 OID 18498)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (users_id);


--
-- TOC entry 4872 (class 2606 OID 18500)
-- Name: users users_username_key; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_username_key UNIQUE (username);


--
-- TOC entry 4897 (class 2620 OID 18501)
-- Name: alat_sewa t_audit_stok_alat; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER t_audit_stok_alat AFTER UPDATE OF stok ON public.alat_sewa FOR EACH ROW EXECUTE FUNCTION public.log_audit_stok_alat();


--
-- TOC entry 4898 (class 2620 OID 18502)
-- Name: barang t_audit_stok_barang; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER t_audit_stok_barang AFTER UPDATE OF stok ON public.barang FOR EACH ROW EXECUTE FUNCTION public.log_audit_stok_barang();


--
-- TOC entry 4899 (class 2620 OID 18503)
-- Name: transaksi t_audit_transaksi; Type: TRIGGER; Schema: public; Owner: postgres
--

CREATE TRIGGER t_audit_transaksi AFTER UPDATE OF status_pembayaran, status_transaksi ON public.transaksi FOR EACH ROW EXECUTE FUNCTION public.log_audit_transaksi();


--
-- TOC entry 4873 (class 2606 OID 18504)
-- Name: alat_sewa alat_sewa_kategori_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.alat_sewa
    ADD CONSTRAINT alat_sewa_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id) ON DELETE RESTRICT;


--
-- TOC entry 4874 (class 2606 OID 18509)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4875 (class 2606 OID 18514)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4876 (class 2606 OID 18519)
-- Name: audit_stok_barang_alat audit_stok_barang_alat_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_stok_barang_alat
    ADD CONSTRAINT audit_stok_barang_alat_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4877 (class 2606 OID 18524)
-- Name: audit_transaksi audit_transaksi_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4878 (class 2606 OID 18529)
-- Name: audit_transaksi audit_transaksi_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.audit_transaksi
    ADD CONSTRAINT audit_transaksi_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4879 (class 2606 OID 18534)
-- Name: barang barang_kategori_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.barang
    ADD CONSTRAINT barang_kategori_id_fkey FOREIGN KEY (kategori_id) REFERENCES public.kategori(kategori_id) ON DELETE RESTRICT;


--
-- TOC entry 4881 (class 2606 OID 18539)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4882 (class 2606 OID 18544)
-- Name: detail_pesanan_pembelian detail_pesanan_pembelian_pesanan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_pembelian
    ADD CONSTRAINT detail_pesanan_pembelian_pesanan_id_fkey FOREIGN KEY (pesanan_id) REFERENCES public.pesanan(pesanan_id) ON DELETE CASCADE;


--
-- TOC entry 4883 (class 2606 OID 18549)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4884 (class 2606 OID 18554)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_opsi_pengembalian_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_opsi_pengembalian_id_fkey FOREIGN KEY (opsi_pengembalian_id) REFERENCES public.opsi_pengembalian(opsi_pengembalian_id) ON DELETE SET NULL;


--
-- TOC entry 4885 (class 2606 OID 18559)
-- Name: detail_pesanan_sewa detail_pesanan_sewa_pesanan_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_pesanan_sewa
    ADD CONSTRAINT detail_pesanan_sewa_pesanan_id_fkey FOREIGN KEY (pesanan_id) REFERENCES public.pesanan(pesanan_id) ON DELETE CASCADE;


--
-- TOC entry 4886 (class 2606 OID 18564)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_barang_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_barang_id_fkey FOREIGN KEY (barang_id) REFERENCES public.barang(barang_id) ON DELETE CASCADE;


--
-- TOC entry 4887 (class 2606 OID 18569)
-- Name: detail_transaksi_pembelian detail_transaksi_pembelian_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_pembelian
    ADD CONSTRAINT detail_transaksi_pembelian_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4888 (class 2606 OID 18574)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_alat_sewa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_alat_sewa_id_fkey FOREIGN KEY (alat_sewa_id) REFERENCES public.alat_sewa(alat_sewa_id) ON DELETE CASCADE;


--
-- TOC entry 4889 (class 2606 OID 18579)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_opsi_pengembalian_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_opsi_pengembalian_id_fkey FOREIGN KEY (opsi_pengembalian_id) REFERENCES public.opsi_pengembalian(opsi_pengembalian_id) ON DELETE RESTRICT;


--
-- TOC entry 4890 (class 2606 OID 18584)
-- Name: detail_transaksi_sewa detail_transaksi_sewa_transaksi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.detail_transaksi_sewa
    ADD CONSTRAINT detail_transaksi_sewa_transaksi_id_fkey FOREIGN KEY (transaksi_id) REFERENCES public.transaksi(transaksi_id) ON DELETE CASCADE;


--
-- TOC entry 4880 (class 2606 OID 18589)
-- Name: desa fk_desa_kecamatan; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.desa
    ADD CONSTRAINT fk_desa_kecamatan FOREIGN KEY (kecamatan_id) REFERENCES public.kecamatan(kecamatan_id);


--
-- TOC entry 4891 (class 2606 OID 18594)
-- Name: pesanan pesanan_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.pesanan
    ADD CONSTRAINT pesanan_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4892 (class 2606 OID 18599)
-- Name: transaksi transaksi_kurir_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_kurir_id_fkey FOREIGN KEY (kurir_id) REFERENCES public.kurir(kurir_id) ON DELETE SET NULL;


--
-- TOC entry 4893 (class 2606 OID 18604)
-- Name: transaksi transaksi_status_distribusi_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_status_distribusi_id_fkey FOREIGN KEY (status_distribusi_id) REFERENCES public.status_distribusi(status_distribusi_id) ON DELETE RESTRICT;


--
-- TOC entry 4894 (class 2606 OID 18609)
-- Name: transaksi transaksi_users_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.transaksi
    ADD CONSTRAINT transaksi_users_id_fkey FOREIGN KEY (users_id) REFERENCES public.users(users_id) ON DELETE CASCADE;


--
-- TOC entry 4895 (class 2606 OID 18614)
-- Name: users users_desa_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_desa_id_fkey FOREIGN KEY (desa_id) REFERENCES public.desa(desa_id) ON DELETE SET NULL;


--
-- TOC entry 4896 (class 2606 OID 18619)
-- Name: users users_roles_id_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_roles_id_fkey FOREIGN KEY (roles_id) REFERENCES public.roles(roles_id) ON DELETE SET NULL;


-- Completed on 2026-06-16 00:56:23

--
-- PostgreSQL database dump complete
--

\unrestrict ygzCfqQ5aRgZVd7aWPozzhvySB0Fft6mfw4SL7iSqqxt8ZG5uTajbilXiFgEpKW

