using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models.User
{
    public class Transaksi
    {
        public int TransaksiId { get; set; }
        public DateTime CreatedAt { get; set; }
        public string StatusTransaksi { get; set; }
        public string MetodePembayaran { get; set; }
        public string StatusPembayaran { get; set; }
        public string Catatan { get; set; }
        // For detail rows (used in TagihanDenda view)
        public string NamaAlat { get; set; }
        public int Quantity { get; set; }
        public decimal HargaSewaPerhari { get; set; }
        public decimal Denda { get; set; }
        public string StatusSewa { get; set; }
        public DateOnly TglSewa { get; set; }
        public DateOnly TglPengembalian { get; set; }
        public string OpsiPengembalian { get; set; }

        public Transaksi(int transaksiId, DateTime createdAt, string statusTransaksi,
            string metodePembayaran, string statusPembayaran, string catatan,
            string namaAlat, int quantity, decimal hargaSewaPerhari, decimal denda,
            string statusSewa, DateOnly tglSewa, DateOnly tglPengembalian, string opsiPengembalian)
        {
            TransaksiId = transaksiId;
            CreatedAt = createdAt;
            StatusTransaksi = statusTransaksi;
            MetodePembayaran = metodePembayaran;
            StatusPembayaran = statusPembayaran;
            Catatan = catatan;
            NamaAlat = namaAlat;
            Quantity = quantity;
            HargaSewaPerhari = hargaSewaPerhari;
            Denda = denda;
            StatusSewa = statusSewa;
            TglSewa = tglSewa;
            TglPengembalian = tglPengembalian;
            OpsiPengembalian = opsiPengembalian;
        }
    }
}
