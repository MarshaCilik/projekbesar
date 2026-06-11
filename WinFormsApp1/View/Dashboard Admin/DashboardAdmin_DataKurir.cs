using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;

namespace WinFormsApp1.View
{
    public partial class DashboardAdmin_DataKurir : Form
    {
        public List<Kurir> list;
        c_admin controller = new c_admin();
        private string Username;
        public DashboardAdmin_DataKurir(string username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_Karyawan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.Username = Username;
            Lbl_UsernameAtas.Text = $"{Username}";
            Load();
        }

        public void Load()
        {
            list = controller.ReadKurir();

            Dgv_Karyawan.DataSource = null;
            Dgv_Karyawan.DataSource = list;
        }

        private void Btn_SeluruhUser_Click(object sender, EventArgs e)
        {
            Dashboard_admin form = new Dashboard_admin(Username);
            form.Show();
            this.Hide();
        }

        private void Btn_Petani_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataPetani form = new DashboardAdmin_DataPetani(Username);
            form.Show();
            this.Hide();
        }

        private void Btn_Karyawan_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataKaryawan form = new DashboardAdmin_DataKaryawan(Username);
            form.Show();
            this.Hide();
        }
    }
}
