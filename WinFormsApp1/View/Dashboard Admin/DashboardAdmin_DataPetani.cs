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
    public partial class DashboardAdmin_DataPetani : Form
    {
        public List<Users> list;
        c_admin controller = new c_admin();
        private string Username;
        public DashboardAdmin_DataPetani(string Username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_UserPetani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Lbl_UsernameAtas.Text = Username;
            Load();
        }

        public void Load()
        {
            list = controller.ReadAllUser("petani");

            Dgv_UserPetani.DataSource = null;
            Dgv_UserPetani.DataSource = list;
        }

        private void Btn_Karyawan_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataKaryawan form = new DashboardAdmin_DataKaryawan(Username);
            form.Show();
            this.Hide();
        }

        private void Btn_SeluruhUser_Click(object sender, EventArgs e)
        {
            Dashboard_admin form = new Dashboard_admin(Username);
            form.Show();
            this.Hide();
        }

        private void Btn_Kurir_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataKurir form = new DashboardAdmin_DataKurir(Username);
            form.Show();
            this.Hide();
        }
    }
}
