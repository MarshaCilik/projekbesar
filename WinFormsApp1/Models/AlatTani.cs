using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class AlatTani
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Stok { get; set; }
        public decimal Harga_sewa_perhari { get; set; }
        public decimal Harga_denda_perhari { get; set; }
        public string Kategori { get; set; }
        public DateTime? Added_at { get; set; }

        public AlatTani(int id, string nama, int stok, decimal hargasewa, decimal hargadenda, string kategori)
        {
            Id = id;
            Nama = nama;
            Stok = stok;
            Harga_sewa_perhari = hargasewa;
            Harga_denda_perhari = hargadenda;
            Kategori = kategori;
            Added_at = null;
        }

        public AlatTani(int id, string nama, int stok, decimal hargasewa, decimal hargadenda, string kategori, DateTime added_at) : 
                   this(id, nama, stok, hargasewa, hargadenda, kategori)
        {
            Added_at = added_at;
        }
    }
}
