using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Models.Context
{
    public class TransaksiContext
    {
        // Helper: baca satu baris Transaksi dari DataReader
        private Transaksi ReadRow(NpgsqlDataReader dr)
        {
            int transaksiId = Convert.ToInt32(dr["transaksi_id"]);
            DateTime createdAt = Convert.ToDateTime(dr["created_at"]);
            string statusTransaksi = dr["status_transaksi"].ToString() ?? "";
            string metodePembayaran = dr["metode_pembayaran"].ToString() ?? "";
            string statusPembayaran = dr["status_pembayaran"].ToString() ?? "";
            string catatan = dr["catatan"] != DBNull.Value ? dr["catatan"].ToString() ?? "" : "";

            // kolom detail sewa (NULL untuk transaksi tanpa sewa)
            string namaAlat = dr["nama_alat"] != DBNull.Value ? dr["nama_alat"].ToString() ?? "-" : "-";
            int quantity = dr["quantity"] != DBNull.Value ? Convert.ToInt32(dr["quantity"]) : 0;
            decimal hargaSewaPerhari = dr["harga_sewa_perhari"] != DBNull.Value ? Convert.ToDecimal(dr["harga_sewa_perhari"]) : 0;
            decimal denda = dr["denda"] != DBNull.Value ? Convert.ToDecimal(dr["denda"]) : 0;
            string statusSewa = dr["status_sewa"] != DBNull.Value ? dr["status_sewa"].ToString() ?? "-" : "-";
            DateOnly tglSewa = dr["tgl_sewa"] != DBNull.Value
                ? DateOnly.FromDateTime(Convert.ToDateTime(dr["tgl_sewa"])) : DateOnly.MinValue;
            DateOnly tglPengembalian = dr["tgl_pengembalian"] != DBNull.Value
                ? DateOnly.FromDateTime(Convert.ToDateTime(dr["tgl_pengembalian"])) : DateOnly.MinValue;
            string opsiPengembalian = dr["opsi_pengembalian"] != DBNull.Value ? dr["opsi_pengembalian"].ToString() ?? "-" : "-";

            return new Transaksi(transaksiId, createdAt, statusTransaksi, metodePembayaran,
                statusPembayaran, catatan, namaAlat, quantity, hargaSewaPerhari, denda,
                statusSewa, tglSewa, tglPengembalian, opsiPengembalian);
        }

        // btn_RiwayatTransaksi: status_transaksi = 'Selesai'
        public List<Transaksi> GetTransaksiSelesai(Users user)
        {
            var list = new List<Transaksi>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_transaksi_selesai_by_user(@p_users_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_users_id", user.UsersId);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            list.Add(ReadRow(dr));
                    }
                }
            }
            return list.Where(t => t.StatusTransaksi == "Selesai").ToList();
        }

        // btn_TransaksiBerlangsung: status_transaksi = 'Diproses' dan status_distribusi 'Diproses' atau 'Dikirim'
        public List<Transaksi> GetTransaksiBerlangsung(Users user)
        {
            var list = new List<Transaksi>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_transaksi_berlangsung_by_user(@p_users_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_users_id", user.UsersId);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            list.Add(ReadRow(dr));
                    }
                }
            }
            return list.Where(t => t.StatusTransaksi == "Diproses" && 
                                   (GetStatusDistribusi(t.TransaksiId) == "Diproses" || GetStatusDistribusi(t.TransaksiId) == "Dikirim")).ToList();
        }

        // btn_TagihanDenda: status_transaksi = 'Diproses' dan denda > 0
        public List<Transaksi> GetTagihanDenda(Users user)
        {
            var list = new List<Transaksi>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_tagihan_denda_by_user(@p_users_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_users_id", user.UsersId);
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            list.Add(ReadRow(dr));
                    }
                }
            }
            return list.Where(t => t.StatusTransaksi == "Diproses" && t.Denda > 0).ToList();
        }

        public string GetStatusDistribusi(int transaksiId)
        {
            using (var conn = connectDB.GetConnection())
            {
                string sql = "SELECT sd.status_distribusi FROM transaksi t JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id WHERE t.transaksi_id = @id";
                using (var cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", transaksiId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
        }

        public bool TerimaPesanan(int transaksiId)
        {
            using (var conn = connectDB.GetConnection())
            {
                try
                {
                    string sql = "UPDATE transaksi SET status_distribusi_id = 3 WHERE transaksi_id = @id";
                    using (var cmd = new NpgsqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("id", transaksiId);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
                catch
                {
                    return false;
                }
            }
        }

        // UNTUK ADMIN: Menampilkan semua transaksi selesai dengan filter tanggal dan (opsional) pencarian ID
        public List<Transaksi> GetAllTransaksiSelesai(DateTime dariTanggal, DateTime keTanggal, string searchId)
        {
            var list = new List<Transaksi>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // Menggunakan query dasar yang me-join tabel-tabel relevan, mirip dengan yang dilakukan di GetTransaksiSelesai
                // tapi tidak difilter per user, melainkan untuk semua.
                // Jika prosedur get_transaksi_selesai_by_user() tidak bisa dikosongkan usernya, 
                // kita bisa mem-build query manual yang equivalent. 
                // Karena kita tidak yakin detail function 'get_transaksi_selesai_by_user', kita bisa query langsung:
                string sql = @"
                    SELECT 
                        t.transaksi_id, 
                        t.created_at, 
                        t.status_transaksi, 
                        p.metode_pembayaran, 
                        t.status_pembayaran, 
                        t.catatan, 
                        a.nama_alat, 
                        ds.quantity, 
                        ds.harga_sewa_perhari, 
                        ds.denda, 
                        ds.status_sewa, 
                        ds.tgl_sewa, 
                        ds.tgl_pengembalian, 
                        op.opsi_pengembalian
                    FROM transaksi t
                    LEFT JOIN pesanan p ON t.pesanan_id = p.pesanan_id
                    LEFT JOIN detail_transaksi_sewa ds ON t.transaksi_id = ds.transaksi_id
                    LEFT JOIN alat_sewa a ON ds.alat_sewa_id = a.alat_sewa_id
                    LEFT JOIN opsi_pengembalian op ON ds.opsi_pengembalian_id = op.opsi_pengembalian_id
                    WHERE t.status_transaksi = 'Selesai' 
                      AND DATE(t.created_at) >= DATE(@dariTanggal) 
                      AND DATE(t.created_at) <= DATE(@keTanggal)";

                if (!string.IsNullOrWhiteSpace(searchId))
                {
                    sql += " AND CAST(t.transaksi_id AS VARCHAR) ILIKE @searchId";
                }

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("dariTanggal", dariTanggal);
                    cmd.Parameters.AddWithValue("keTanggal", keTanggal);
                    if (!string.IsNullOrWhiteSpace(searchId))
                    {
                        cmd.Parameters.AddWithValue("searchId", "%" + searchId + "%");
                    }

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                            list.Add(ReadRow(dr));
                    }
                }
            }
            return list;
        }

        // UNTUK ADMIN: Menampilkan log audit transaksi
        public System.Data.DataTable GetAuditTransaksi()
        {
            var dt = new System.Data.DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT audit_id, transaksi_id, aksi, kolom_perubahan, waktu_perubahan FROM audit_transaksi ORDER BY waktu_perubahan DESC";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        dt.Load(dr);
                    }
                }
            }
            return dt;
        }
    }
}
