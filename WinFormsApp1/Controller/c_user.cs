using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using WinFormsApp1.Models;
using WinFormsApp1.Models.Context;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.Controller
{
    public class c_user
    {
        protected userContext context = new userContext();

        public bool ProsesUpdateProfil(Users user, string nama, string noTelp, string email, string usernameBaru, string password, string alamat, string desa, string kecamatan)
        {
            // --- 1. VALIDASI DATA KOSONG ---
            if (string.IsNullOrWhiteSpace(nama) || string.IsNullOrWhiteSpace(usernameBaru) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Nama, Username, dan Password wajib diisi!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            string usernameLamaAsli = user.Username;

            // Timpa isi properti dengan data baru dari UI
            user.Nama = nama;
            user.NoTelp = noTelp;
            user.Email = email;
            user.Username = usernameBaru; // Tampung username baru ke objek
            user.Password = password;
            user.Alamat = alamat;
            user.NamaDesa = desa;
            user.NamaKecamatan = kecamatan;

            // Status dikunci total berdasarkan session database asli! Petani tidak bisa melakukan manipulasi data
            try
            {
                context.UpdateProfil(user, usernameLamaAsli); // Memanggil SP update_users milikmu yang sudah ada
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan ke database: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<Kurir> ReadKurir()
        {
            return context.ReadKurir();
        }

        public virtual string Validation(usersDataRegister user) //Method validasi Register
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

        public string Create(usersDataRegister user) //method create
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

        public (bool IsSukses, string Pesan, Users user) Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                return (false, "Username atau Password tidak boleh kosong!", null);
            }

            var autData = context.GetRolePasswordByUsername(username);

            if (autData.Password == null)
            {
                return (false, "Username tidak ditemukan!", null);
            }

            if (autData.Password != password)
            {
                return (false, "Password salah!", null);
            }
            List<Users> semuaUser = context.ReadUserDataForAdmin("semua");

            Users userLoggedIn = semuaUser.Find(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));

            if (userLoggedIn == null)
            {
                return (false, "Gagal memuat data profil user!", null);
            }

            return (true, "Sukses", userLoggedIn);
        }

    }
}
