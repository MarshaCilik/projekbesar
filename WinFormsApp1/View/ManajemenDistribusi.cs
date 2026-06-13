using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.View
{
    public partial class ManajemenDistribusi : Form
    {
        private DistribusiController distCtrl = new DistribusiController();
        public ManajemenDistribusi()
        {
            InitializeComponent();
        }

        private void Manajemen_Distribusi_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void RefreshData()
        {
            // Tulis nama karyawan pakai UserSession
            txtNamaKaryawan.Text = UserSession.Username;

            // Tarik datanya dan langsung lempar ke tabel
            int currentUserId = UserSession.UserId;
            dgvDistribusi.DataSource = distCtrl.GetDistribusi(currentUserId);
        }

        // --- KODINGAN TOMBOL MENU SIDEBAR ---
        private void btnMenuDashboard_Click(object sender, EventArgs e)
        {
            Dashboard_Karyawan formDash = new Dashboard_Karyawan();
            formDash.Show();
            this.Hide();
        }

        private void btnMenuProfil_Click(object sender, EventArgs e)
        {
            Profil_Karyawan formProfil = new Profil_Karyawan();
            formProfil.Show();
            this.Hide();
        }

        // (Copas juga tombol menu lainnya di sini)

        private void btnKeluar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Yakin mau keluar?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                UserSession.UserId = 0;
                UserSession.Username = "";
                Application.Exit();
            }
        }
    }
}
