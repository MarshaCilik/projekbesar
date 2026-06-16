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
    }
}
