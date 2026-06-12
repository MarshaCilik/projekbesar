using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1.View
{
    public partial class CRUD_Barang : Form
    {
        public CRUD_Barang()
        {
            InitializeComponent();
        }

        private void SetSubMenuAktif(Button tombolAktif, string tipeData)
        {
            // 1. RESET KEDUA TOMBOL KE WARNA DEFAULT (TIDAK AKTIF)
            // Menggunakan warna abu-abu standar WinForms dan teks hitam
            Btn_Barang.BackColor = Color.LightGray;
            Btn_Barang.ForeColor = Color.Black;

            Btn_AlatSewa.BackColor = Color.LightGray;
            Btn_AlatSewa.ForeColor = Color.Black;

            // 2. SET TOMBOL YANG DIKLIK MENJADI WARNA HIJAU GELAP
            // Teks diubah menjadi putih agar kontras dan terbaca jelas
            tombolAktif.BackColor = Color.FromArgb(40, 78, 34); // Hijau gelap PASTANI
            tombolAktif.ForeColor = Color.White;

            // 3. LOGIKA UNTUK MENAMPILKAN DATA KE DATAGRIDVIEW
            if (tipeData == "barang")
            {
                // Panggil fungsi untuk mengambil data barang dari database/controller kamu
                // Contoh: dgvProduk.DataSource = barangController.ReadBarang();
            }
            else if (tipeData == "alat_sewa")
            {
                // Panggil fungsi untuk mengambil data alat sewa dari database/controller kamu
                // Contoh: dgvProduk.DataSource = barangController.ReadAlatSewa();
            }
        }

        // --- EVENT CLICK PADA TOMBOL DI FORM ---

        private void Btn_AlatSewa_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(Btn_AlatSewa, "alat_sewa");
        }

        private void Btn_Barang_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(Btn_Barang, "barang");
        }
    }
}
