using System;
using System.Collections.Generic;
using WinFormsApp1.Models.Context;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Controller
{
    public class c_transaksi
    {
        private TransaksiContext context = new TransaksiContext();

        public List<Transaksi> GetRiwayatTransaksi(Users user)
            => context.GetTransaksiSelesai(user);

        public List<Transaksi> GetTransaksiBerlangsung(Users user)
            => context.GetTransaksiBerlangsung(user);

        public List<Transaksi> GetTagihanDenda(Users user)
            => context.GetTagihanDenda(user);

        public string GetStatusDistribusi(int transaksiId)
        {
            using (var conn = WinFormsApp1.Helpers.connectDB.GetConnection())
            {
                string sql = "SELECT sd.status_distribusi FROM transaksi t JOIN status_distribusi sd ON t.status_distribusi_id = sd.status_distribusi_id WHERE t.transaksi_id = @id";
                using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("id", transaksiId);
                    var result = cmd.ExecuteScalar();
                    return result?.ToString() ?? "";
                }
            }
        }

        public bool TerimaPesanan(int transaksiId)
        {
            using (var conn = WinFormsApp1.Helpers.connectDB.GetConnection())
            {
                try
                {
                    string sql = "UPDATE transaksi SET status_distribusi_id = 3 WHERE transaksi_id = @id";
                    using (var cmd = new Npgsql.NpgsqlCommand(sql, conn))
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
    }
}
