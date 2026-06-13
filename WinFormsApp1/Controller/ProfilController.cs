using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.Controller
{
    internal class ProfilController
    {
        public DataTable GetProfilKaryawan(int userId)
        {
            DataTable dt = new DataTable();
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                // JOIN tabel desa dan kecamatan biar dapet nama aslinya
                string query = @"
            SELECT u.username AS nama, u.no_telp, u.email, u.username, 
                   u.password, u.alamat, d.nama_desa, k.nama_kecamatan, u.""isActive""
            FROM users u
            LEFT JOIN desa d ON u.desa_id = d.desa_id
            LEFT JOIN kecamatan k ON d.kecamatan_id = k.kecamatan_id
            WHERE u.users_id = @id";

                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", userId);
                    NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(cmd);
                    adapter.Fill(dt);
                }
            }
            return dt;
        }
        public void UpdatePassword(int userId, string passwordBaru)
        {
            using (NpgsqlConnection conn = connectDB.GetConnection())
            {
                string query = "UPDATE users SET password = @pass, updated_at = NOW() WHERE users_id = @id";
                using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@pass", passwordBaru);
                    cmd.Parameters.AddWithValue("@id", userId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
