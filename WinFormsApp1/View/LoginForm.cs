using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            c_autentikasi aut = new c_autentikasi();

            var hasilLogin = aut.Login(TbUsername.Text, TbPassword.Text);

            if (hasilLogin.Pesan == "Sukses" && hasilLogin.Role == 1)
            {
                MessageBox.Show("Selamat Datang!");
                DashboardPetani dashboardpetani1 = new DashboardPetani(TbUsername.Text);
                dashboardpetani1.Show();

            }
            else if (hasilLogin.Pesan == "Username atau Password tidak boleh kosong!")
            {
                MessageBox.Show($"{hasilLogin.Pesan}", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (hasilLogin.Pesan == "Username tidak ditemukan!")
            {
                MessageBox.Show($"{hasilLogin.Pesan}", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (hasilLogin.Pesan == "Password salah!")
            {
                MessageBox.Show($"{hasilLogin.Pesan}", "Peringatan!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            else if (hasilLogin.Pesan == "Sukses" && hasilLogin.Role == 2)
            {
                //Masuk dashboard karyawan
            }
            else if (hasilLogin.Pesan == "Sukses" && hasilLogin.Role == 3)
            {
                //Masuk dashboard admin
            }
            this.Hide();
        }

        private void btn_BuatAkun_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRegistrasi form = new FormRegistrasi();
            form.Show();
        }
    }
}
