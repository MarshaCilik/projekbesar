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

        public bool CekBarangSudahAdaDiPesanan(Users user, int barangId)
        {
            return context.CekBarangSudahAdaDiPesanan(user, barangId);
        }

        public bool CekAlatSudahAdaDiPesanan(Users user, int alatId)
        {
            return context.CekAlatSudahAdaDiPesanan(user, alatId);
        }

        public DateOnly? GetTanggalPengembalianAlat(Users user, int alatId)
        {
            return context.GetTanggalPengembalianAlat(user, alatId);
        }

        public bool CekOpsiPengembalianSudahAda(Users user)
        {
            return context.CekOpsiPengembalianSudahAda(user);
        }

        public void TambahQuantityBarang(Users user, int barangId, int tambahanQuantity)
        {
            context.TambahQuantityBarang(user, barangId, tambahanQuantity);
        }

        public void TambahQuantityAlatDanUpdateTanggal(Users user, int alatId, int tambahanQuantity, DateOnly tanggalPengembalianBaru)
        {
            context.TambahQuantityAlatDanUpdateTanggal(user, alatId, tambahanQuantity, tanggalPengembalianBaru);
        }

        public List<Pesanan> ReadPesananUser(Users user)
        {
            return context.ReadPesanan(user);
        }

        public void CreatePesananAlatSewa(Users user, AlatTani alat, string opsiPengiriman, string metodePembayaran, int quantity, DateOnly tanggalPengembalian, string opsiPengembalian)
        {
            context.CreatePesanan_AlatSewa(user, alat, opsiPengiriman, metodePembayaran, quantity, tanggalPengembalian, opsiPengembalian ?? "");
        }

        public void CreatePesananBarang(Users user, barangTani barang, int quantity, string opsiPengiriman, string metodePembayaran)
        {
            context.CreatePesanan_Barang(user, barang, quantity, opsiPengiriman, metodePembayaran);
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
