using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public class KaryawanUser : Users
    {
        public KaryawanUser(int id, string username, string password, string nama, string noTelp, string email,
                            bool isActive, DateOnly? createdAt, DateOnly? updateAt, string alamat, string namaDesa, string namaKecamatan)
                            : base(id, username, password, nama, noTelp, email, isActive, createdAt, updateAt, alamat,namaDesa, namaKecamatan) { }

        public override void BukaDashboard()
        {

        }
    }
}
