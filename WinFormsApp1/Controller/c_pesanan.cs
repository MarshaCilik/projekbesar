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

        public List<Pesanan> ReadPesananUser(Users user)
        {
            return context.ReadPesanan(user);
        }

        public void CreatePesananAlatSewa(Users user, AlatTani alat, string opsiPengiriman, int quantity, DateOnly tanggalPengembalian)
        {
            context.CreatePesanan_AlatSewa(user, alat, opsiPengiriman, quantity, tanggalPengembalian);
        }

        public void CreatePesananBarang(Users user, barangTani barang, int quantity, string opsiPengiriman)
        {
            context.CreatePesanan_Barang(user, barang, quantity, opsiPengiriman);
        }

        public bool ProsesCheckout(Pesanan pesanan)
        {
            if (pesanan.Id <= 0)
            {
                MessageBox.Show("Validasi Gagal: ID Pesanan tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool apakahSukses = context.CheckoutPesanan(pesanan);

            return apakahSukses;
        }

        public List<Pesanan> ReadCheckout(Users user)
        {
            if (user == null)
            {
                MessageBox.Show("Validasi Gagal: Data pengguna aktif tidak ditemukan!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pesanan>();
            }
            return context.ReadPesananCheckout(user);
        }

        public bool ProsesBatalPesanan(int pesananId, string jenisPesanan, string namaItem)
        {
            if (pesananId <= 0)
            {
                MessageBox.Show("Validasi Gagal: ID Pesanan tidak valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(jenisPesanan) || string.IsNullOrWhiteSpace(namaItem))
            {
                MessageBox.Show("Validasi Gagal: Data item yang dipilih tidak lengkap!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return context.BatalkanItemPesanan(pesananId, jenisPesanan, namaItem);
        }
    }
}
