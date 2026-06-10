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
    public partial class Dashboard_admin : Form
    {
        c_user controller = new c_user();

        public string Username;

        private List<Users> list;

        public Dashboard_admin(string username)
        {
            this.Username = username;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            dgv_AllUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Load();
            Lbl_UsernameAtas.Text = $"{Username}";
        }

        public void Load()
        {
            list = controller.ReadAllUser("semua");

            dgv_AllUser.DataSource = null;
            dgv_AllUser.DataSource = list;
        }

        private void Btn_Karyawan_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataKaryawan form = new DashboardAdmin_DataKaryawan(Username);
            form.Show();
            this.Hide();
        }
    }
}
