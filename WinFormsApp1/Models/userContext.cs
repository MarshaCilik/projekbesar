using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Models
{
    public class userContext
    {
        public void ReadAllUserData()
        {

        }
        public void Create(usersData user)
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
