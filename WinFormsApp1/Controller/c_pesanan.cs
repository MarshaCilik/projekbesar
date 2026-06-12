using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WinFormsApp1.Models;
using WinFormsApp1.Models.Context;
using WinFormsApp1.Models.User;


namespace WinFormsApp1.Controller
{
    public class c_pesanan
    {
        PesananContext context = new PesananContext();

        public bool CekPesananApakahAda(Users user)
        {
            return context.CekApakahPesananSudahAda(user);
        }

        public List<Pesanan> ReadPesananUser()
        {
            return context.ReadPesanan();
        }

        public void CreatePesananAlatSewa(Users user, AlatTani alat, string opsiPengiriman, int quantity, DateOnly tanggalPengembalian)
        {
            context.CreatePesanan_AlatSewa(user, alat, opsiPengiriman, quantity, tanggalPengembalian);
        }
    }
}
