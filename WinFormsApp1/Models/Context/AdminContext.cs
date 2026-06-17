using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Models.Context
{
    public class AdminContext
    {
        public void CreateKurir(Kurir kurir)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "INSERT INTO kurir (nama_kurir, no_telp, alamat) VALUES (@nama, @notelp, @alamat)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", kurir.Nama);
                    cmd.Parameters.AddWithValue("notelp", kurir.Nomor_Telepon);
                    cmd.Parameters.AddWithValue("alamat", kurir.Alamat);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateKurir(Kurir kurir)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "UPDATE kurir SET nama_kurir = @nama, no_telp = @notelp, alamat = @alamat WHERE kurir_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", kurir.Nama);
                    cmd.Parameters.AddWithValue("notelp", kurir.Nomor_Telepon);
                    cmd.Parameters.AddWithValue("alamat", kurir.Alamat);
                    cmd.Parameters.AddWithValue("id", kurir.Id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateKaryawan(Users user)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = @"
                    INSERT INTO users (nama, no_telp, email, username, passwords, isactive, alamat, roles_id, desa_id) 
                    VALUES (@nama, @no_telp, @email, @username, @password, true, @alamat, 2, 
                    (SELECT desa_id FROM desa WHERE nama_desa = @desa LIMIT 1))";
                
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", user.Nama);
                    cmd.Parameters.AddWithValue("no_telp", user.NoTelp);
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("username", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("alamat", user.Alamat);
                    cmd.Parameters.AddWithValue("desa", user.NamaDesa);
                    
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void CreateBarangTani(barangTani barang)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // Subquery akan mencari id kategori berdasarkan nama kategori yang diketikkan
                string sql = "CALL add_new_barang(@nama, @stok, @harga, @kategori)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", barang.nama_barang);
                    cmd.Parameters.AddWithValue("harga", barang.harga);
                    cmd.Parameters.AddWithValue("stok", barang.stok);
                    cmd.Parameters.AddWithValue("kategori", barang.kategori);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<barangTani> ReadBarangTani()
        {
            List<barangTani> list = new List<barangTani>();
            try
            {
                using (NpgsqlConnection conn = connectDB.GetConnection())
                {
                    string query = "SELECT * FROM lihat_barang_petani";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                list.Add(new barangTani(
                                    Convert.ToInt32(dr["barang_id"]),
                                    dr["nama barang"].ToString(),
                                    Convert.ToInt32(dr["stok"]),
                                    Convert.ToDecimal(dr["harga per unit"]),
                                    dr["kategori"].ToString(),
                                    Convert.ToDateTime(dr["added_at"]).Date
                                    ));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Kalau ada error (misal lupa nyalain server postgres), muncul popup ini
                MessageBox.Show("Gagal menarik data, coba lagi: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return list;
        }
    }
}
