using System;
using System.Data;
using Npgsql;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Controller
{
    public class ProfilController
    {
        public DataTable GetProfilKaryawan(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "SELECT u.nama, u.no_telp, u.email, u.username, u.passwords AS password,u. alamat, d.nama_desa, \nk.nama_kecamatan, isactive FROM users u JOIN desa d using(desa_id)JOIN kecamatan k using(kecamatan_id)\nWHERE users_id = @userId;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("userId", userId);
                    using (NpgsqlDataAdapter da = new NpgsqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public void UpdatePassword(int userId, string newPassword)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string sql = "UPDATE users SET passwords = @newPassword, update_at = CURRENT_DATE WHERE users_id = @userId;";
                using (NpgsqlCommand cmd = new NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("newPassword", newPassword);
                    cmd.Parameters.AddWithValue("userId", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
