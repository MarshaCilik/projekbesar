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
        public DateTime Tanggal_Pemesanan { get; set; }
        public string Status { get; set; }

        public Pesanan(int id, string jenis_pesanan, string nama, decimal harga, int jumlah, int lama_sewa, DateTime tanggal_pesan, string status)
        {
            Id = id;
            Jenis_Pesanan = jenis_pesanan;
            Nama = nama;
            Harga_Satuan = harga;
            Jumlah = jumlah;
            Lama_Sewa_Hari = lama_sewa;
            Tanggal_Pemesanan = tanggal_pesan;
            Status = status;
        }
    }
}
