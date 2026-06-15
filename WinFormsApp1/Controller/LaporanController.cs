using System;
using System.Data;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Controller
{
    public class LaporanController
    {
        public DataTable GetTransaksi(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_karyawan_dashboard_transaksi ORDER BY created_at DESC;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetStok()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    SELECT 'Barang' AS jenis, nama, harga, stok, 
                           CASE WHEN stok = 0 THEN 'Habis' WHEN stok <= 5 THEN 'Menipis' ELSE 'Cukup' END AS status_stok
                    FROM v_update_stok_barang
                    UNION ALL
                    SELECT 'Alat Sewa' AS jenis, nama, harga, stok, 
                           CASE WHEN stok = 0 THEN 'Habis' WHEN stok <= 5 THEN 'Menipis' ELSE 'Cukup' END AS status_stok
                    FROM v_update_stok_alat
                    ORDER BY status_stok DESC, nama;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetDenda()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_laporan_denda ORDER BY tgl_seharusnya_kembali DESC;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public DataTable GetKeuangan()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_karyawan_keuangan ORDER BY created_at DESC;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public void LunasiDenda(int dendaId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    UPDATE detail_transaksi_sewa 
                    SET status_sewa = 'Lunas', 
                        denda = CASE 
                            WHEN CURRENT_DATE > tgl_pengembalian THEN (CURRENT_DATE - tgl_pengembalian) * harga_sewa_perhari
                            ELSE 0::numeric 
                        END
                    WHERE detail_transaksi_sewa_id = @dendaId;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("dendaId", dendaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
