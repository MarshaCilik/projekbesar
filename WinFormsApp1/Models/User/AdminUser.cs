using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.View;

namespace WinFormsApp1.Models.User
{
    public class AdminUser : Users
    {
        public AdminUser(int id, string username, string password, string nama, string noTelp, string email,
                         bool isActive, DateOnly? createdAt, DateOnly? updateAt, string alamat, string namaDesa, string namaKecamatan)
                         : base(id, username, password, nama, noTelp, email, isActive, createdAt, updateAt, alamat, namaDesa, namaKecamatan) 
        {
            Roles = "admin";
        }

        public override void BukaDashboard()
        {
            new Dashboard_admin(Username).Show();
        }
    }
}
