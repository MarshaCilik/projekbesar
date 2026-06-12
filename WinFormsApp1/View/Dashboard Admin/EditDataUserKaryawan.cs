using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.View
{
    public partial class EditDataUserKaryawan : Form
    {
        public Users UserData { get; private set; }
        public EditDataUserKaryawan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public EditDataUserKaryawan(Users user) : this()
        {
            UserData = user;

            Tb_Username.Text = user.Username;
            Tb_Password.Text = user.Password;
            Tb_Alamat.Text = user.Alamat;
            Tb_Desa.Text = user.NamaDesa;
            Tb_Kecamatan.Text = user.NamaKecamatan;
            Tb_Nama.Text = user.Nama;
            Tb_NoTelp.Text = user.NoTelp;
            Tb_Email.Text = user.Email;
            Cbx_Status.Checked = user.IsActive;
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Tb_Nama.Text) ||
                string.IsNullOrWhiteSpace(Tb_Username.Text) ||
                string.IsNullOrWhiteSpace(Tb_Password.Text) ||
                string.IsNullOrWhiteSpace(Tb_Alamat.Text) ||
                string.IsNullOrWhiteSpace(Tb_Desa.Text) ||
                string.IsNullOrWhiteSpace(Tb_Kecamatan.Text) ||
                string.IsNullOrWhiteSpace(Tb_NoTelp.Text) ||
                string.IsNullOrWhiteSpace(Tb_Email.Text)
                )
            {
                MessageBox.Show("Data harus diisi!", "Peringatan!", MessageBoxButtons.OK);
                return;
            }

            DialogResult dr = MessageBox.Show(
            "Apakah Anda ingin menyimpan data ini?",
            "Informasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                UserData = new KaryawanUser(UserData.UsersId, Tb_Username.Text, Tb_Password.Text,
                                            Tb_Nama.Text, Tb_NoTelp.Text, Tb_Email.Text,
                                            Cbx_Status.Checked, UserData.CreatedAt, null, Tb_Alamat.Text, Tb_Desa.Text, Tb_Kecamatan.Text);
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}
