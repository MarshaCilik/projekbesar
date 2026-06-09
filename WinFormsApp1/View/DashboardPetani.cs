using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;
using WinFormsApp1.View;

namespace WinFormsApp1
{
    public partial class DashboardPetani : Form
    {
        private string username;

        c_barangtani controller = new c_barangtani();

        private List<barangTani> listbarangtani;
        public DashboardPetani(string username)
        {
            InitializeComponent();
            this.username = username;
            usernameShow.Text = $"Selamat Datang! {username}";
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_BarangTani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
        }
        public void LoadData()
        {
            listbarangtani = controller.ReadBarangTani();

            Dgv_BarangTani.DataSource = null;
            Dgv_BarangTani.DataSource = listbarangtani;
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btn_LihatProdukTani_Click(object sender, EventArgs e)
        {
            LihatProdukTani form = new LihatProdukTani();
            form.Show();
            this.Hide();
        }

        private void btn_PesanProduk_Click(object sender, EventArgs e)
        {
            if (Dgv_BarangTani != null)
            {
                barangTani selectedbarang = (barangTani)Dgv_BarangTani.CurrentRow.DataBoundItem;
                PopUpPesanan form = new PopUpPesanan(selectedbarang);
                //if (form.ShowDialog() == DialogResult.OK)
                //{
                //    string result = controller.Create(form.barangTani);
                //    MessageBox.Show(
                //        result,
                //        "Informasi",
                //        MessageBoxButtons.OK,
                //        MessageBoxIcon.Information);
                //}

                //form.Show();

            }
        }
    }
}
