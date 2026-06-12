using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class barangTani
    {
        public int Id { get; set; }
        public string nama_barang { get; set; }
        public int stok { get; set; }
        public decimal harga { get; set; }
        public string kategori { get; set; }
        public DateTime? tanggal_ditambahkan { get; set; }

        public barangTani(int id, string nama_barang, int stok, decimal harga, string kategori)
        {
            Id = id;
            this.nama_barang = nama_barang;
            this.stok = stok;
            this.harga = harga;
            this.kategori = kategori;
            tanggal_ditambahkan = null;
        }

        public barangTani(int id, string nama_barang, int stok, decimal harga, string kategori, DateTime createdat) : 
                            this(id, nama_barang, stok, harga, kategori)
        {
            tanggal_ditambahkan = createdat;
        }
    }
}
