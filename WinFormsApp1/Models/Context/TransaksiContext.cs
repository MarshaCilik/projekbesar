using Npgsql;
using System;
using System.Collections.Generic;
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
            return list;
        }

        // btn_TransaksiBerlangsung: status_transaksi = 'Diproses'
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
            return list;
        }

        // btn_TagihanDenda: 'Diproses' + ada sewa dengan denda != 0 dan status_sewa = 'Sedang disewa'
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
            return list;
        }
    }
}
