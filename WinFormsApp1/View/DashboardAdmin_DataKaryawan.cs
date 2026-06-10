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
    public partial class DashboardAdmin_DataKaryawan : Form
    {
        public List<Users> list;
        c_user controller = new c_user();
        private string Username;
        public DashboardAdmin_DataKaryawan(string Username)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Username = Username;
            Lbl_UsernameAtas.Text = $"{Username}";
            Load();

        }

        public void Load()
        {
            list = controller.ReadAllUser("karyawan");

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
    }
}
