using System;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            UpdateDbSchema();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new LoginForm());
        }

        private static void UpdateDbSchema()
        {
            try
            {
                using (var conn = WinFormsApp1.Helpers.connectDB.GetConnection())
                {
                    // Drop old 2-parameter signature if it exists
                    string dropSql = @"
                        DROP PROCEDURE IF EXISTS public.p_terima_pesanan(integer, character varying);
                    ";
                    using (var cmd = new NpgsqlCommand(dropSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }

                    // Create or replace the 3-parameter signature
                    string createSql = @"
CREATE OR REPLACE PROCEDURE public.p_terima_pesanan(
	IN p_pesanan_id integer,
	IN p_karyawan_username character varying,
	IN p_kurir_id integer DEFAULT NULL)
LANGUAGE 'plpgsql'
AS $BODY$
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
    -- Validasi & Pengurangan Stok Barang Pembelian
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
    -- Validasi & Pengurangan Stok Alat Sewa
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
    -- Update status keranjang pesanan utama
    UPDATE pesanan SET status_pesanan = 'Selesai' WHERE pesanan_id = p_pesanan_id;
    -- Tentukan status distribusi untuk diteruskan ke logistik
    IF v_opsi = 'diantar' THEN
        v_distribusi_id := 1;
    ELSE
        v_distribusi_id := NULL;
    END IF;
    -- Buat baris transaksi baru
    INSERT INTO transaksi (created_at, catatan, users_id, kurir_id, status_transaksi, status_distribusi_id, metode_pembayaran, status_pembayaran)
    VALUES (NOW(), 'Penerimaan pesanan ID ' || p_pesanan_id || ' oleh ' || p_karyawan_username, v_users_id, p_kurir_id, 'Diproses', v_distribusi_id, 'Cash', 'belum lunas')
    RETURNING transaksi_id INTO v_transaksi_id;
    -- Migrasi detail pembelian
    FOR r_detail_pembelian IN SELECT quantity, harga_per_item, barang_id FROM detail_pesanan_pembelian WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_pembelian (quantity, harga_per_item, transaksi_id, barang_id)
        VALUES (r_detail_pembelian.quantity, r_detail_pembelian.harga_per_item, v_transaksi_id, r_detail_pembelian.barang_id);
    END LOOP;
    -- Migrasi detail sewa
    FOR r_detail_sewa IN SELECT quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, alat_sewa_id FROM detail_pesanan_sewa WHERE pesanan_id = p_pesanan_id LOOP
        INSERT INTO detail_transaksi_sewa (quantity, tgl_sewa, tgl_pengembalian, harga_sewa_perhari, denda, status_sewa, transaksi_id, alat_sewa_id, opsi_pengembalian_id)
        VALUES (r_detail_sewa.quantity, r_detail_sewa.tgl_sewa, r_detail_sewa.tgl_pengembalian, r_detail_sewa.harga_sewa_perhari, 0, 'Belum Kembali', v_transaksi_id, r_detail_sewa.alat_sewa_id, 1);
    END LOOP;
END;
$BODY$;";
                    using (var cmd = new NpgsqlCommand(createSql, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Print to diagnostic output, do not block app start
                System.Diagnostics.Debug.WriteLine("Database update failed: " + ex.Message);
            }
        }
    }
}