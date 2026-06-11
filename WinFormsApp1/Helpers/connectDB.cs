using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace WinFormsApp1.Helpers
{
    public class connectDB
    {
        private static string connString =
          "Host=localhost;" +  // server PostgreSQL
          "Port=5432;" +  // port default PostgreSQL
          "Database=projek_semester2;" +  // nama database
          "Username=postgres;" +  // username
          "Password=devara2006";  // password

        public void TestKoneksi()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            try
            {
                conn.Open();
                MessageBox.Show("Koneksi Berhasil!");
            }
            catch (Exception e)
            {
                MessageBox.Show("Koneksi gagal di: " + e.Message);
            }
        }

        public static NpgsqlConnection GetConnection()
        {
            NpgsqlConnection conn = new NpgsqlConnection(connString);
            conn.Open();

            return conn;
        }
    }
}
