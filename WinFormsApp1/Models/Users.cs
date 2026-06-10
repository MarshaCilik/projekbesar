using System;
using System.Collections.Generic;
using System.Text;

namespace WinFormsApp1.Models
{
    public abstract class Users
    {
        // Properti Umum (Sekarang wilayah masuk ke sini karena WAJIB untuk semua)
        public int UsersId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nama { get; set; }
        public string NoTelp { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public DateOnly? CreatedAt { get; set; }
        public DateOnly? UpdateAt { get; set; }

        public string Alamat { get; set; }

        public string NamaDesa { get; set; }       // <-- Pindah ke sini
        public string NamaKecamatan { get; set; }  // <-- Pindah ke sini

        // Constructor Induk (Menerima semua data termasuk wilayah)
        public Users(int id, string username, string password, string nama, string noTelp, string email,
                    bool isActive, DateOnly? createdAt, DateOnly? updateAt, string alamat, string namaDesa, string namaKecamatan)
        {
            UsersId = id;
            Username = username;
            Password = password;
            Nama = nama;
            NoTelp = noTelp;
            Email = email;
            IsActive = isActive;
            CreatedAt = createdAt;
            UpdateAt = updateAt;
            NamaDesa = namaDesa;
            NamaKecamatan = namaKecamatan;
            Alamat = alamat;
        }

        public abstract void BukaDashboard();
    }
}
