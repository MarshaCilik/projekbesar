using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;

namespace WinFormsApp1.Controller
{
    class c_user
    {
        userContext context = new userContext();

        public string Validation(usersData user) //Method validasi
        {
            if (string.IsNullOrWhiteSpace(user.nama) ||
                string.IsNullOrWhiteSpace(user.alamat) ||
                string.IsNullOrWhiteSpace(user.desa) ||
                string.IsNullOrWhiteSpace(user.kecamatan) ||
                string.IsNullOrWhiteSpace(user.username) ||
                string.IsNullOrWhiteSpace(user.password) ||
                string.IsNullOrWhiteSpace(user.email) ||
                string.IsNullOrWhiteSpace(user.nomor_telepon))
            {
                return "Semua data harus terisi!";
            }

            return null;
        }

        public string Create(usersData user) //method create
        {
            string validation = Validation(user);

            if (validation != null)
            {
                return validation;
            }

            context.Create(user);

            return "Data berhasil ditambahkan!";
        }
    }

    class c_autentikasi
    {
        userContext context = new userContext();

        public (bool IsSukses, string Pesan, int Role) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return (false, "Username atau Password tidak boleh kosong!", 0);
            }

            var autData = context.GetRolePasswordByUsername(username);

            if (autData.Password == null)
            {
                return (false, "Username tidak ditemukan!", 0);
            }

            if (autData.Password != password)
            {
                return (false, "Password salah!", 0);
            }
            return (true, "Sukses", autData.roles);
        }

    }
}
