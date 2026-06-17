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
            => context.GetStatusDistribusi(transaksiId);

        public bool TerimaPesanan(int transaksiId)
            => context.TerimaPesanan(transaksiId);

        // ================= UNTUK ADMIN =================

        public List<Transaksi> GetAllTransaksiSelesai(DateTime dariTanggal, DateTime keTanggal, string searchId)
        {
            return context.GetAllTransaksiSelesai(dariTanggal, keTanggal, searchId);
        }

        public System.Data.DataTable GetAuditTransaksi()
        {
            return context.GetAuditTransaksi();
        }
    }
}
