using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Pesanan
    {
        public int Id { get; set; }
        public string Jenis_Pesanan { get; set; }
        public string Nama { get; set; }
        public decimal Harga_Satuan { get; set; }
        public int Jumlah { get; set; }
        public int Lama_Sewa_Hari { get; set; }
        public DateOnly Tanggal_Pemesanan { get; set; }
        public DateOnly? Tanggal_Pengembalian { get; set; }
        public string Opsi_Pengembalian { get; set; }
        public string Status { get; set; }

        public Pesanan(int id, string jenis_pesanan, string nama, decimal harga, int jumlah, int lama_sewa, DateOnly tanggal_pesan, DateOnly? tanggal_pengembalian, string opsi_pengembalian, string status)
        {
            Id = id;
            Jenis_Pesanan = jenis_pesanan;
            Nama = nama;
            Harga_Satuan = harga;
            Jumlah = jumlah;
            Lama_Sewa_Hari = lama_sewa;
            Tanggal_Pemesanan = tanggal_pesan;
            Tanggal_Pengembalian = tanggal_pengembalian;
            Opsi_Pengembalian = opsi_pengembalian;
            Status = status;
        }
    }
}
