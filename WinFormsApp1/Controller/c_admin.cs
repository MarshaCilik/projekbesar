using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.View;
using WinFormsApp1.Models;
using WinFormsApp1.Models.User;
using WinFormsApp1.Models.Context;

namespace WinFormsApp1.Controller
{
    public class c_admin : c_user
    {
        private Models.Context.AdminContext adminContext = new Models.Context.AdminContext();
        private barangTaniContext barangcontext = new barangTaniContext();

        public List<Users> ReadAllUser(string DataUser) //method read
        {
            return context.ReadUserDataForAdmin(DataUser);
        }

        public string Validation(Users user)
        {
            if (string.IsNullOrWhiteSpace(user.Nama) ||
                string.IsNullOrWhiteSpace(user.NoTelp) ||
                string.IsNullOrWhiteSpace(user.Email) ||
                string.IsNullOrWhiteSpace(user.Alamat) ||
                string.IsNullOrWhiteSpace(user.NamaKecamatan) ||
                string.IsNullOrWhiteSpace(user.NamaDesa) ||
                string.IsNullOrWhiteSpace(user.Username) ||
                string.IsNullOrWhiteSpace(user.Password)
                )
            {
                return "data kosong";
            }
            return null;
        }

        public string ValidationKurir(Kurir kurir)
        {
            if (string.IsNullOrWhiteSpace(kurir.Nama) ||
                string.IsNullOrWhiteSpace(kurir.Nomor_Telepon) ||
                string.IsNullOrWhiteSpace(kurir.Alamat))
            {
                return "Data kurir tidak boleh kosong!";
            }
            return null;
        }

        public string Update(Users user, string usernameLama)
        {
            string validation = Validation(user);

            if (validation != null)
            {
                return validation;
            }

            try
            {
                context.UpdateProfil(user, usernameLama);
                return "data terupdate";
            }
            catch (Exception ex)
            {
                return "Gagal mengupdate data: " + ex.Message;
            }
        }

        public string CreateKaryawan(Users user)
        {
            string validation = Validation(user);
            if (validation != null) return validation;

            try
            {
                adminContext.CreateKaryawan(user);
                return "Karyawan berhasil ditambahkan.";
            }
            catch (Exception ex)
            {
                return "Gagal menambah karyawan: " + ex.Message;
            }
        }

        public string CreateKurir(Kurir kurir)
        {
            string validation = ValidationKurir(kurir);
            if (validation != null) return validation;

            try
            {
                adminContext.CreateKurir(kurir);
                return "Kurir berhasil ditambahkan.";
            }
            catch (Exception ex)
            {
                return "Gagal menambah kurir: " + ex.Message;
            }
        }

        public string CreateBarangTani(barangTani barang)
        {
            if (string.IsNullOrWhiteSpace(barang.nama_barang) || barang.harga < 0 || barang.stok < 0 || string.IsNullOrWhiteSpace(barang.kategori))
            {
                return "Data barang tidak valid, pastikan terisi dengan benar (termasuk kategori)!";
            }

            try
            {
                adminContext.CreateBarangTani(barang);
                return "Data barang berhasil disimpan!";
            }
            catch (Exception ex)
            {
                return "Gagal tersimpan: " + ex.Message;
            }
        }

        public string UpdateKurir(Kurir kurir)
        {
            string validation = ValidationKurir(kurir);
            if (validation != null) return validation;

            try
            {
                adminContext.UpdateKurir(kurir);
                return "Data kurir berhasil diupdate.";
            }
            catch (Exception ex)
            {
                return "Gagal mengupdate kurir: " + ex.Message;
            }
        }

        public List<barangTani> ReadBarangTani()
        {
            return barangcontext.ReadBarangTani();
        }
    }
}
