using System;
using System.Data;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models.Context
{
    public class KaryawanContext
    {
        public DataTable GetDashboardTransaksi()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_karyawan_dashboard_transaksi_detail ORDER BY created_at DESC;";
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

        public (long TotalTransaksiDiproses, long TotalTransaksiDiantar, long TotalPesananMasuk) GetDashboardStats()
        {
            long totalTransaksiDiproses = 0;
            long totalTransaksiDiantar = 0;
            long totalPesananMasuk = 0;

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT total_transaksi_diproses, total_transaksi_diantar, total_pesanan_masuk FROM f_get_dashboard_stats();";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            totalTransaksiDiproses = dr.IsDBNull(0) ? 0 : dr.GetInt64(0);
                            totalTransaksiDiantar = dr.IsDBNull(1) ? 0 : dr.GetInt64(1);
                            totalPesananMasuk = dr.IsDBNull(2) ? 0 : dr.GetInt64(2);
                        }
                    }
                }
            }

            return (totalTransaksiDiproses, totalTransaksiDiantar, totalPesananMasuk);
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
                string sql = "SELECT barang_id AS id, \"nama barang\" AS nama, \"harga per unit\" AS harga, stok, kategori FROM lihat_barang_petani ORDER BY nama;";
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
                string sql = "SELECT alat_sewa_id AS id, nama_alat AS nama, harga_sewa_perhari AS harga, stok, kategori FROM lihat_alat ORDER BY nama;";
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
                string sql = "SELECT * FROM v_manajemen_distribusi ORDER BY transaksi_id DESC;";
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

        public void UpdateStatusDistribusi(int transaksiId, int statusId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "UPDATE transaksi SET status_distribusi_id = @statusId WHERE transaksi_id = @transaksiId AND status_distribusi_id IS NOT NULL";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("statusId", statusId);
                    cmd.Parameters.AddWithValue("transaksiId", transaksiId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable GetPesananCheckout()
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

        public DataTable GetLaporanStok(string jenis)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "";
                if (jenis == "produk")
                    sql = "SELECT barang_id AS id, \"nama barang\" AS nama, \"harga per unit\" AS harga, stok, kategori FROM lihat_barang_petani ORDER BY stok ASC;";
                else if (jenis == "alat")
                    sql = "SELECT alat_sewa_id AS id, nama_alat AS nama, harga_sewa_perhari AS harga, stok, kategori FROM lihat_alat ORDER BY stok ASC;";
                else if (jenis == "riwayat")
                    sql = "SELECT * FROM audit_stok_barang_alat;";

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

        public DataTable GetLaporanDenda()
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM v_laporan_denda WHERE status_pembayaran != 'Lunas' AND hari_keterlambatan > 0 ORDER BY denda_id DESC;";
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

        public void LunaskanDenda(int detailSewaId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "UPDATE detail_transaksi_sewa SET status_sewa = 'Lunas' WHERE detail_transaksi_sewa_id = @id;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", detailSewaId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool HasUnpaidDenda(int transaksiId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM detail_transaksi_sewa ds JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id WHERE ds.transaksi_id = @id AND ds.status_sewa != 'Lunas' AND CURRENT_DATE > ds.tgl_pengembalian;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", transaksiId);
                    long count = (long)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        public void TerimaPesanan(int pesananId, string karyawanUsername, int? kurirId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL p_terima_pesanan(@pesanan_id, @karyawan_username, @kurir_id);";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("pesanan_id", pesananId);
                    cmd.Parameters.AddWithValue("karyawan_username", karyawanUsername);
                    cmd.Parameters.AddWithValue("kurir_id", (object)kurirId ?? DBNull.Value);
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
