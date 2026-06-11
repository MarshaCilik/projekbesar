using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class Kurir
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Nomor_Telepon { get; set; }
        public string Alamat { get; set; }

        public Kurir(int id, string nama, string noTelp, string alamat)
        {
            Id = id;
            Nama = nama;
            Nomor_Telepon = noTelp;
            Alamat = alamat;
        }
    }
}
