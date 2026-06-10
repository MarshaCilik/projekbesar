using Microsoft.VisualBasic.ApplicationServices;
using System.Text.RegularExpressions;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class FormRegistrasi : Form
    {
        public usersDataRegister UserData { get; private set; }

        c_user controller = new c_user();

        public FormRegistrasi()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            TbNomorTelepon.MaxLength = 13;
        }

        public FormRegistrasi(usersDataRegister user) : this()
        {
            UserData = user;

            TbNama.Text = user.nama;
            TbNomorTelepon.Text = user.nomor_telepon;
            TbAlamat.Text = user.alamat;
            TbDesa.Text = user.desa;
            TbKecamatan.Text = user.kecamatan;
            TbEmail.Text = user.email;
            TbUsername.Text = user.username;
            TbPassword.Text = user.password;
        }

        private void BtnKonfirmasi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbNama.Text) ||
                string.IsNullOrWhiteSpace(TbNomorTelepon.Text) ||
                string.IsNullOrWhiteSpace(TbAlamat.Text) ||
                string.IsNullOrWhiteSpace(TbDesa.Text) ||
                string.IsNullOrWhiteSpace(TbKecamatan.Text) ||
                string.IsNullOrWhiteSpace(TbEmail.Text) ||
                string.IsNullOrWhiteSpace(TbUsername.Text) ||
                string.IsNullOrWhiteSpace(TbPassword.Text)
                )
            {
                MessageBox.Show("Data harus terisi!", "Peringatan", MessageBoxButtons.OK);
                return;
            }
            else if (!long.TryParse(TbNomorTelepon.Text, out long nomor_telepon))
            {
                MessageBox.Show("Nomor Telepon harus berupa angka!", "Peringatan", MessageBoxButtons.OK);
                TbNomorTelepon.Focus();
                return;
            }
            else if (!Regex.IsMatch(TbNomorTelepon.Text, @"^\d+$"))
            {
                MessageBox.Show("Nomor Telepon harus berupa angkas saja!", "Peringatan", MessageBoxButtons.OK);
                TbNomorTelepon.Focus();
                return;
            }
            else if (!TbEmail.Text.Contains("@"))
            {
                MessageBox.Show("Masukkan Email dengan benar!", "Peringatan", MessageBoxButtons.OK);
                TbEmail.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show(
                "Apakah Anda ingin menyimpan data ini?",
                "Informasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                if (UserData == null)
                {
                    UserData = new usersDataRegister(TbNama.Text, TbEmail.Text, TbNomorTelepon.Text, TbAlamat.Text,
                        TbKecamatan.Text, TbDesa.Text, TbUsername.Text, TbPassword.Text);


                    string result = controller.Create(UserData);
                    MessageBox.Show(
                        result,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    if (result != "Data berhasil ditambahakan!")
                    {
                        return;
                    }
                }
                else
                {
                    UserData = new usersDataRegister(TbNama.Text, TbEmail.Text, TbNomorTelepon.Text, TbAlamat.Text,
                        TbKecamatan.Text, TbDesa.Text, TbUsername.Text, TbPassword.Text);
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_KembaliKeLogin(object sender, EventArgs e)
        {
            LoginForm login1 = new LoginForm();
            this.Hide();
            login1.Show();
        }
    }
}
