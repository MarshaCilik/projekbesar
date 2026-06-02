using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.Marshalling;
using System.Text;

namespace WinFormsApp1.Models
{
    public class usersData : userLogin
    {
        public string nama { get; set; }
        public string email { get; set; }
        public string nomor_telepon { get; set; }
        public string alamat { get; set; }
        public string kecamatan { get; set; }
        public string desa { get; set; }

        public usersData(string nama, string email, string nomor_telepon, string alamat, string kecamatan, string desa, string username, string password) : base(username, password)
        {
            this.nama = nama;
            this.email = email;
            this.nomor_telepon = nomor_telepon;
            this.alamat = alamat;
            this.kecamatan = kecamatan;
            this.desa = desa;
        }
    }
}
