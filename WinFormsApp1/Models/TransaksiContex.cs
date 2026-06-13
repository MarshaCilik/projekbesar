using global::WinFormsApp1.Helpers;
using Npgsql;
using System;
using System.Data;
using WinFormsApp1.Helpers;
namespace WinFormsApp1.Models
{

    public class TransaksiContex
    {
        // 1. Ngitung total transaksi hari ini khusus buat karyawan  yg login
        public int HitungTotalTransaksiHariIni(int userId)
        {
            int total = 0;
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM transaksi WHERE DATE(created_at) = CURRENT_DATE AND users_id = @userId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return total;
        }

        // 2. Ngitung pesanan diantar khusus karyawan tersebut
        public int HitungPesananDiantar(int userId)
        {
            int total = 0;
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM transaksi WHERE status_pengiriman = 'Diantar' AND users_id = @userId";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    total = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return total;
        }

        // 3. Tarik data tabel transaksi buat karyawan tersebut
        public DataTable GetTransaksiByUserId(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "SELECT * FROM transaksi WHERE users_id = @userId ORDER BY created_at DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@userId", userId);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }

        // 4. Ubah status jadi lunas
        public void UpdateStatusLunas(int transaksiId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "UPDATE transaksi SET status_pembayaran = 'Lunas' WHERE transaksi_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", transaksiId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // 5. Ubah status transaksi jadi selesai 
        public void SelesaikanTransaksiDenganValidasi(int transaksiId)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // 1. Kita interogasi dulu data transaksinya dari database
                string cekQuery = "SELECT status_pembayaran, status_distribusi, status_pengiriman, status_pengembalian FROM transaksi WHERE transaksi_id = @id";

                string pPembayaran = "";
                string pDistribusi = "";
                string pPengiriman = "";
                string pPengembalian = "";

                using (NpgsqlCommand cmdCek = new NpgsqlCommand(cekQuery, conn))
                {
                    cmdCek.Parameters.AddWithValue("@id", transaksiId);
                    using (NpgsqlDataReader reader = cmdCek.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Tarik data pakai ToString() dan antisipasi kalau datanya kosong (null)
                            pPembayaran = reader["status_pembayaran"]?.ToString() ?? "";
                            pDistribusi = reader["status_distribusi"]?.ToString() ?? "";
                            pPengiriman = reader["status_pengiriman"]?.ToString() ?? "";
                            pPengembalian = reader["status_pengembalian"]?.ToString() ?? "";
                        }
                    }
                }

                // 2. MULAI PROSES VALIDASI (SATPAM)

                // Aturan 1: Wajib Lunas
                if (pPembayaran != "Lunas")
                {
                    throw new Exception("Gagal! Transaksi belum lunas bro, tagih dulu ke petaninya.");
                }

                // Aturan 2: Kalau minta diantar, barang WAJIB udah Diterima
                if (pPengiriman == "Diantar" && pDistribusi != "Diterima")
                {
                    throw new Exception($"Gagal! Barang belum sampai ke petani. Status distribusinya masih: '{pDistribusi}'.");
                }

                // Aturan 3: Kalau ini alat sewa, WAJIB udah Selesai dikembalikan
                // Asumsi: Kalau bukan sewa, status_pengembalian biasanya kosong. Kalau sewa, ada isinya.
                if (!string.IsNullOrWhiteSpace(pPengembalian) && pPengembalian != "Selesai")
                {
                    throw new Exception($"Gagal! Alat sewa belum beres dikembalikan. Statusnya masih: '{pPengembalian}'.");
                }

                // 3. Kalau lolos semua hadangan di atas, baru deh kita Selesaikan!
                string updateQuery = "UPDATE transaksi SET status_transaksi = 'Selesai' WHERE transaksi_id = @id";
                using (NpgsqlCommand cmdUpdate = new NpgsqlCommand(updateQuery, conn))
                {
                    cmdUpdate.Parameters.AddWithValue("@id", transaksiId);
                    cmdUpdate.ExecuteNonQuery();
                }
            }
        }

    }

}
