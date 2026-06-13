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
        public bool BatalkanItemPesanan(int pesananId, string jenisPesanan, string namaItem)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL batal_pesanan_item(@p_id, @p_jenis, @p_nama)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_id", pesananId);
                    cmd.Parameters.AddWithValue("p_jenis", jenisPesanan);
                    cmd.Parameters.AddWithValue("p_nama", namaItem);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal membatalkan pesanan: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
        public bool CheckoutPesanan(Pesanan pesanan)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL checkout_pesanan(@p_id)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("p_id", pesanan.Id);

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true; 
                    }
                    catch (Exception ex)
                    {
                        System.Windows.Forms.MessageBox.Show("Gagal melakukan checkout: " + ex.Message, "Error Database", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }
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

        public List<Pesanan> ReadPesananCheckout(Users user)
        {
            List<Pesanan> list = new List<Pesanan>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_pesanan_already_by_user(@userId)";

                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", user.UsersId);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int lamaSewa = dr["Lama Sewa (Hari)"] != DBNull.Value
                                ? Convert.ToInt32(dr["Lama Sewa (Hari)"])
                                : 0;

                            DateOnly tanggalPemesanan = DateOnly.FromDateTime(DateTime.Today); 

                            if (dr["Tanggal Pemesanan"] != DBNull.Value)
                            {
                                if (dr["Tanggal Pemesanan"] is DateOnly dateOnlyValue)
                                {
                                    tanggalPemesanan = dateOnlyValue;
                                }
                                else
                                {
                                    tanggalPemesanan = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pemesanan"]));
                                }
                            }

                            int id = Convert.ToInt32(dr["ID"]);
                            string jenisPesanan = dr["Jenis Pesanan"].ToString();
                            string namaItem = dr["Nama Item"].ToString();
                            decimal hargaSatuan = Convert.ToDecimal(dr["Harga Satuan"]);
                            int jumlah = Convert.ToInt32(dr["Jumlah"]);
                            string status = dr["Status"].ToString();

                            Pesanan pesananObj = new Pesanan(
                                id,
                                jenisPesanan,
                                namaItem,
                                hargaSatuan,
                                jumlah,
                                lamaSewa,
                                tanggalPemesanan,
                                status
                            );

                            list.Add(pesananObj);
                        }
                    }
                }
            }
            return list;
        }

        public List<Pesanan> ReadPesanan(Users user)
        {
            List<Pesanan> list = new List<Pesanan>();

            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM get_pesanan_by_user(@userId)";
                
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", user.UsersId);

                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            int lamaSewa = dr["Lama Sewa (Hari)"] != DBNull.Value ? Convert.ToInt32(dr["Lama Sewa (Hari)"]) : 0;

                            DateOnly tanggalPemesanan;
                            if (dr["Tanggal Pemesanan"] is DateOnly dateOnlyValue)
                            {
                                tanggalPemesanan = dateOnlyValue;
                            }
                            else
                            {
                                tanggalPemesanan = DateOnly.FromDateTime(Convert.ToDateTime(dr["Tanggal Pemesanan"]));
                            }

                            int id = Convert.ToInt32(dr["ID"]);
                            string jenisPesanan = dr["Jenis Pesanan"].ToString();
                            string namaItem = dr["Nama Item"].ToString();
                            decimal hargaSatuan = Convert.ToDecimal(dr["Harga Satuan"]);
                            int jumlah = Convert.ToInt32(dr["Jumlah"]);
                            string status = dr["Status"].ToString();

                            list.Add(new Pesanan(
                                id,
                                jenisPesanan,
                                namaItem,
                                hargaSatuan,
                                jumlah,
                                lamaSewa,
                                tanggalPemesanan, 
                                status
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
                        MessageBox.Show("Gagal mengeksekusi stored procedure: " + ex.MessageText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }

        public void CreatePesanan_Barang(Users user, barangTani barang, int quantity, string opsiPengiriman)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL add_pesanan_barang(@userid, @opsi_pengiriman, @barang_id, @quantity)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userid", user.UsersId);
                    cmd.Parameters.AddWithValue("opsi_pengiriman", opsiPengiriman);
                    cmd.Parameters.AddWithValue("barang_id", barang.Id);
                    cmd.Parameters.AddWithValue("quantity", quantity);

                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (PostgresException ex)
                    {
                        MessageBox.Show("Gagal mengeksekusi stored procedure: " + ex.MessageText, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        throw;
                    }
                }
            }
        }
    }
}
