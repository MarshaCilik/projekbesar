using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class barangTani
    {
        public string nama_barang { get; set; }
        public int stok { get; set; }
        public decimal harga { get; set; }
        public string kategori { get; set; }

        public barangTani(string nama_barang, int stok, decimal harga, string kategori)
        {
            this.nama_barang = nama_barang;
            this.stok = stok;
            this.harga = harga;
            this.kategori = kategori;
        }
    }
}
