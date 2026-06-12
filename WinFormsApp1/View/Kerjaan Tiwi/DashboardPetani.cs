using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;
using WinFormsApp1.Models.User;
using WinFormsApp1.View;
using WinFormsApp1.View.Kerjaan_Tiwi;

namespace WinFormsApp1
{
    public partial class DashboardPetani : Form
    {
        private string username;

        c_pesanan controller_pesanan = new c_pesanan();
        c_barangtani controller = new c_barangtani();


        public Users User;
        private List<barangTani> listbarangtani;
        private List<Pesanan> listpesanan;
        private List<AlatTani> List_alat_tani;

        private string tipeDataAktif = "barang";
        public DashboardPetani(Users user)
        {
            InitializeComponent();
            this.User = user;
            this.username = user.Username;
            usernameShow.Text = $"Selamat Datang! {username}";
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_BarangTani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData("barang");
        }
        public void LoadData(string data)
        {
            if (data == "barang")
            {
                listbarangtani = controller.ReadBarangTani();

                Dgv_BarangTani.DataSource = null;
                Dgv_BarangTani.DataSource = listbarangtani;
                Dgv_BarangTani.Columns["tanggal_ditambahkan"].Visible = false;
            }
            else if (data == "alat_sewa")
            {
                List_alat_tani = controller.ReadAlatTani();

                Dgv_BarangTani.DataSource = null;
                Dgv_BarangTani.DataSource = List_alat_tani;
                Dgv_BarangTani.Columns["Added_at"].Visible = false;
            }
            else if (data == "pesanan_belum_co")
            {
                listpesanan = controller_pesanan.ReadPesananUser();

                Dgv_Pesanan.DataSource = null;
                Dgv_Pesanan.DataSource = listpesanan;

                
            }
            else if (data == "pesanan_sudah_co")
            {

            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btn_PesanProduk_Click(object sender, EventArgs e)
        {
            if (Dgv_BarangTani != null)
            {
                if (tipeDataAktif == "barang")
                {
                    barangTani selectedbarang = (barangTani)Dgv_BarangTani.CurrentRow.DataBoundItem;

                    PopUpPesanan form = new PopUpPesanan(selectedbarang);
                    form.ShowDialog();
                }
                else if (tipeDataAktif == "alat_sewa")
                {
                    // Ambil data sebagai objek AlatTani
                    AlatTani selectedAlat = (AlatTani)Dgv_BarangTani.CurrentRow.DataBoundItem;

                    // Panggil PopUpPesanan khusus Alat Sewa
                    // Catatan: Anda perlu membuat constructor baru di kelas PopUpPesanan yang menerima (AlatTani)
                    PopUpPesananAlat form = new PopUpPesananAlat(User, selectedAlat);
                    form.ShowDialog();
                }
            }
        }

        private void btn_LihatAlatSewa_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(btn_LihatAlatSewa, "alat_sewa");

        }

        private void btn_LihatProdukTani_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(btn_LihatProdukTani, "barang");
        }

        private void SetSubMenuAktif(Button tombolAktif, string tipeData)
        {
            this.tipeDataAktif = tipeData;
            // 1. RESET KEDUA TOMBOL KE WARNA DEFAULT (TIDAK AKTIF)
            // Menggunakan warna abu-abu standar WinForms dan teks hitam
            btn_LihatAlatSewa.BackColor = Color.LightGray;
            btn_LihatAlatSewa.ForeColor = Color.Black;

            btn_LihatProdukTani.BackColor = Color.LightGray;
            btn_LihatProdukTani.ForeColor = Color.Black;

            Btn_BelumCO.BackColor = Color.LightGray;
            Btn_BelumCO.ForeColor = Color.Black;

            Btn_SudahCO.BackColor = Color.LightGray;
            Btn_SudahCO.ForeColor = Color.Black;


            // 2. SET TOMBOL YANG DIKLIK MENJADI WARNA HIJAU GELAP
            // Teks diubah menjadi putih agar kontras dan terbaca jelas
            tombolAktif.BackColor = Color.FromArgb(40, 78, 34); // Hijau gelap PASTANI
            tombolAktif.ForeColor = Color.White;

            // 3. LOGIKA UNTUK MENAMPILKAN DATA KE DATAGRIDVIEW
            if (tipeData == "barang")
            {
                LoadData(tipeData);
            }
            else if (tipeData == "alat_sewa")
            {
                LoadData(tipeData);
            }
        }

        private void Btn_Pesanan_Click(object sender, EventArgs e)
        {
            SetMenuAktif(Btn_Pesanan, "pesanan");
            Tc_Petani.SelectedIndex = 1;

        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            SetMenuAktif(Btn_Dashboard, "dashboard");
            Tc_Petani.SelectedIndex = 0;
        }

        private void SetMenuAktif(Button tombolAktif, string pilihan)
        {
            Btn_Pesanan.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Pesanan.ForeColor = Color.Black;

            Btn_Profil.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Profil.ForeColor = Color.Black;

            Btn_Riwayat.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Riwayat.ForeColor = Color.Black;

            Btn_Tagihan.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Tagihan.ForeColor = Color.Black;

            Btn_Dashboard.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Dashboard.ForeColor = Color.Black;

            tombolAktif.ForeColor = Color.White;
            tombolAktif.BackColor = Color.FromArgb(40, 78, 34);
        }

        private void Btn_SudahCO_Click(object sender, EventArgs e)
        {

        }

        private void Btn_BelumCO_Click(object sender, EventArgs e)
        {
            LoadData("pesanan_belum_co");
        }
    }
}
