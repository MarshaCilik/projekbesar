using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Text;
using WinFormsApp1.Models;
using WinFormsApp1.Models.Context;

namespace WinFormsApp1.Controller
{
    public class c_barangtani
    {
        barangTaniContext context = new barangTaniContext();


        public List<barangTani> ReadBarangTani() //method read
        {
            return context.ReadBarangTani();
        }

        public List<AlatTani> ReadAlatTani()
        {
            return context.ReadAlatTani();
        }

        public string ValidationBarang(barangTani barang)
        {
            if (string.IsNullOrWhiteSpace(barang.nama_barang) ||
                string.IsNullOrWhiteSpace(barang.kategori) ||
                barang.stok < 0 ||
                barang.harga < 0)
            {
                return "Data barang tidak valid atau kosong.";
            }
            return null;
        }

        public string ValidationAlat(AlatTani alat)
        {
            if (string.IsNullOrWhiteSpace(alat.Nama) ||
                string.IsNullOrWhiteSpace(alat.Kategori) ||
                alat.Stok < 0 ||
                alat.Harga_sewa_perhari < 0 ||
                alat.Harga_denda_perhari < 0)
            {
                return "Data alat sewa tidak valid atau kosong.";
            }
            return null;
        }

        public string AddBarangTani(AlatTani barang)
        {
            try
            {
                context.AddAlatTani(barang);
                return "Data barang berhasil ditambahkan.";
            }
            catch (Exception ex)
            {
                return "Gagal menambahkan barang: " + ex.Message;
            }
        }

        public string UpdateBarangTani(barangTani barang)
        {
            string val = ValidationBarang(barang);
            if (val != null) return val;
            try
            {
                context.UpdateBarangTani(barang);
                return "Data barang berhasil diubah.";
            }
            catch (Exception ex)
            {
                return "Gagal mengubah barang: " + ex.Message;
            }
        }

        public string DeleteBarangTani(int id)
        {
            try
            {
                context.DeleteBarangTani(id);
                return "Data barang berhasil dihapus.";
            }
            catch (Exception ex)
            {
                return "Gagal menghapus barang: " + ex.Message;
            }
        }

        public string AddAlatTani(AlatTani alat)
        {
            string val = ValidationAlat(alat);
            if (val != null) return val;
            try
            {
                context.AddAlatSewa(alat);
                return "Data alat sewa berhasil ditambahkan.";
            }
            catch (Exception ex)
            {
                return "Gagal menambahkan alat sewa: " + ex.Message;
            }
        }

        public string UpdateAlatTani(AlatTani alat)
        {
            string val = ValidationAlat(alat);
            if (val != null) return val;
            try
            {
                context.UpdateAlatTani(alat);
                return "Data alat sewa berhasil diubah.";
            }
            catch (Exception ex)
            {
                return "Gagal mengubah alat sewa: " + ex.Message;
            }
        }

        public string DeleteAlatTani(int id)
        {
            try
            {
                context.DeleteAlatTani(id);
                return "Data alat sewa berhasil dihapus.";
            }
            catch (Exception ex)
            {
                return "Gagal menghapus alat sewa: " + ex.Message;
            }
        }

        public List<barangTani> SearchBarangTani(string keyword)
        {
            return context.SearchBarangTani(keyword);
        }

        public List<AlatTani> SearchAlatTani(string keyword)
        {
            return context.SearchAlatTani(keyword);
        }

        public System.Data.DataTable GetStokTersedikit()
        {
            return context.GetStokTersedikit();
        }

        public System.Data.DataTable GetProdukTerlaris()
        {
            return context.GetProdukTerlaris();
        }
    }
}