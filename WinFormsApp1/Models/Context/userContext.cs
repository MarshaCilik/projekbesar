using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models.User;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace WinFormsApp1.Models.Context
{
    public class userContext
    {
        public void Update(Users user)
        {
            List<Users> list = new List<Users>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL update_users(@nama, @notelp, @email, @username, @password, @status, @alamat, @desa, @kecamatan)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", user.Nama);
                    cmd.Parameters.AddWithValue("notelp", user.NoTelp);
                    cmd.Parameters.AddWithValue("username", user.Username);
                    cmd.Parameters.AddWithValue("password", user.Password);
                    cmd.Parameters.AddWithValue("status", user.IsActive);
                    cmd.Parameters.AddWithValue("alamat", user.Alamat);
                    cmd.Parameters.AddWithValue("desa", user.NamaDesa);
                    cmd.Parameters.AddWithValue("kecamatan", user.NamaKecamatan);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<Users> ReadUserDataForAdmin(string DataUser)
        {
            if (DataUser == "semua")
            {
                DataUser = "v_SemuaDataUser";
            }
            else if (DataUser == "karyawan")
            {
                DataUser = "v_KaryawanDataUser";
            }
            else if (DataUser == "petani")
            {
                DataUser = "v_PetaniDataUser";
            }
            List<Users> list = new List<Users>();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = $"SELECT * FROM {DataUser}";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using (NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DateOnly? createdAt = dr["created_at"] != DBNull.Value
                                ? DateOnly.FromDateTime(Convert.ToDateTime(dr["created_at"]))
                                : null;

                            DateOnly? updateAt = dr["update_at"] != DBNull.Value
                                ? DateOnly.FromDateTime(Convert.ToDateTime(dr["update_at"]))
                                : null;

                            string role = dr["roles"].ToString().ToLower();

                            int userId = Convert.ToInt32(dr["users_id"]);
                            string username = dr["username"].ToString();
                            string password = dr["passwords"].ToString();
                            string nama = dr["nama"].ToString();
                            string noTelp = dr["no_telp"].ToString();
                            string email = dr["email"].ToString();
                            string alamat = dr["alamat"].ToString();
                            bool isActive = Convert.ToBoolean(dr["isactive"]);
                            string namaDesa = dr["nama_desa"].ToString();
                            string namaKecamatan = dr["nama_kecamatan"].ToString();

                            Users userObj;

                            if (role == "admin")
                            {
                                userObj = new AdminUser(userId, username, password, nama, noTelp, email, isActive, createdAt, updateAt, alamat, namaDesa, namaKecamatan);
                            }
                            else if (role == "karyawan")
                            {
                                userObj = new KaryawanUser(userId, username, password, nama, noTelp, email, isActive, createdAt, updateAt, alamat, namaDesa, namaKecamatan);
                            }
                            else // petani
                            {
                                userObj = new PetaniUser(userId, username, password, nama, noTelp, email, isActive, createdAt, updateAt, alamat, namaDesa, namaKecamatan);
                            }

                            list.Add(userObj);
                        }
                    }
                }
            }
            return list;
        }

        public List<Kurir> ReadKurir()
        {
            List<Kurir> list = new List<Kurir>();
            using(NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT * FROM Kurir";
                using(NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    using(NpgsqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            list.Add(new Kurir(Convert.ToInt32(dr["kurir_id"]),
                                               dr["nama_kurir"].ToString(),
                                               dr["no_telp"].ToString(),
                                               dr["alamat"].ToString()
                                                ));
                        }
                    }
                }
            }
            return list;
        }
        public void Create(usersDataRegister user)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "CALL add_new_users_petani(@nama, @email, @no_telp, @username, @password, @alamat, @kecamatan, @desa)";
                using(NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("nama", user.nama);
                    cmd.Parameters.AddWithValue("email", user.email);
                    cmd.Parameters.AddWithValue("no_telp", user.nomor_telepon);
                    cmd.Parameters.AddWithValue("username", user.username);
                    cmd.Parameters.AddWithValue("password", user.password);
                    cmd.Parameters.AddWithValue("alamat", user.alamat);
                    cmd.Parameters.AddWithValue("kecamatan", user.kecamatan);
                    cmd.Parameters.AddWithValue("desa", user.desa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public (string Password, int roles) GetRolePasswordByUsername(string username)
        {
            string dbPassword = null;
            int dbRoles = 0;
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "select * from get_password_by_username(@username)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("username", username);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            dbPassword = reader["db_password"].ToString();
                            dbRoles = Convert.ToInt32(reader["db_role"]);
                        }
                    }
                }


            }
            return (dbPassword, dbRoles);
        }
    }
}
