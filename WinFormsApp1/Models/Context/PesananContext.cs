using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Models.Context
{
    public class PesananContext
    {
        public bool CekApakahPesananSudahAda(Users user)
        {
            bool sudahAda = false;
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT COUNT(*) FROM pesanan WHERE users_id = @userid AND status_pesanan ilike 'Belum Checkout'";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0) sudahAda = true;
                }
            }
            return sudahAda;
        }

        public 

        public List<Pesanan> ReadPesanan()
        {
            List<Pesanan> list = new List<Pesanan>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "select * from v_pesanan_for_user";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Pesanan(
                                Convert.ToInt32(dr["ID"]),
                                dr["Jenis Pesanan"].ToString(),
                                dr["Nama Item"].ToString(),
                                Convert.ToDecimal(dr["Harga Satuan"]),
                                Convert.ToInt32(dr["Jumlah"]),
                                Convert.ToInt32(dr["Lama Sewa (Hari)"]),
                                Convert.ToDateTime(dr["Tanggal Pemesanan"]),
                                dr["Status"].ToString()
                                ));
                        }
                    }
                }
            }
            return list;
        }

        public void CreatePesanan_AlatSewa(Users user, AlatTani alat, string opsiPengiriman, int quantity, DateOnly tanggalPengembalian)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL add_pesanan_alat_sewa(@userid, @opsi_pengiriman, @alat_sewa_id, @quantity, @tanggal_pengembalian)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("opsi_pengiriman", opsiPengiriman);
                    cmd.Parameters.AddWithValue("alat_sewa_id", alat.Id);
                    cmd.Parameters.AddWithValue("quantity", quantity);
                    cmd.Parameters.AddWithValue("tanggal_pengembalian", tanggalPengembalian);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex)
                    {
                        // Menampilkan error spesifik dari PostgreSQL jika ada constraint yang melanggar
                        MessageBox.Show("Gagal mengeksekusi stored procedure: " + ex.MessageText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}
