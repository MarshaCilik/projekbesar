using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class DashboardPetani : Form
    {
        private string username;
        public DashboardPetani(string username)
        {
            InitializeComponent();
            this.username = username;
            usernameShow.Text = $"{username}";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }
    }
}
