using System;
using System.Data;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Controller
{
    public class KaryawanController
    {
        public DataTable GetDashboardTransaksi()
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

        public (long TotalTransaksi, long BarangDikirim) GetDashboardStats(DateTime date)
        {
            long totalTransaksi = 0;
            long barangDikirim = 0;

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT total_transaksi, barang_dikirim FROM f_get_dashboard_stats(@tanggal::date);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("tanggal", date.Date);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            totalTransaksi = dr.IsDBNull(0) ? 0 : dr.GetInt64(0);
                            barangDikirim = dr.IsDBNull(1) ? 0 : dr.GetInt64(1);
                        }
                    }
                }
            }

            return (totalTransaksi, barangDikirim);
        }

        public void UpdatePaymentStatus(int transaksiId, string status, int karyawanId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_update_status_pembayaran(@transaksi_id, @status, @karyawan_id);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("transaksi_id", transaksiId);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("karyawan_id", karyawanId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateTransactionStatus(int transaksiId, string status, int karyawanId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_update_status_transaksi(@transaksi_id, @status, @karyawan_id);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("transaksi_id", transaksiId);
                    cmd.Parameters.AddWithValue("status", status);
                    cmd.Parameters.AddWithValue("karyawan_id", karyawanId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetStokBarang()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_update_stok_barang ORDER BY nama;";
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

        public DataTable GetStokAlat()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_update_stok_alat ORDER BY nama;";
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

        public void UpdateStok(int id, int stokBaru, string jenis, int karyawanId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_update_stok(@id, @stok_baru, @jenis, @karyawan_id);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.Parameters.AddWithValue("stok_baru", stokBaru);
                    cmd.Parameters.AddWithValue("jenis", jenis);
                    cmd.Parameters.AddWithValue("karyawan_id", karyawanId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetManajemenDistribusi()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_pesanan_checkout ORDER BY \"ID Pesanan\" DESC;";
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

        public void TerimaPesanan(int pesananId, string karyawanUsername)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_terima_pesanan(@pesanan_id, @karyawan_username);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("pesanan_id", pesananId);
                    cmd.Parameters.AddWithValue("karyawan_username", karyawanUsername);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void BatalPesanan(int pesananId, string alasan)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_batal_pesanan(@pesanan_id, @alasan);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("pesanan_id", pesananId);
                    cmd.Parameters.AddWithValue("alasan", alasan);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
