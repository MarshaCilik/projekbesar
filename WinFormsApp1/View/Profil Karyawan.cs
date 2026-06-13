using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;

namespace WinFormsApp1.View
{
    public partial class Profil_Karyawan : Form
    {
        private ProfilController profCtrl = new ProfilController();

        public Profil_Karyawan()
        {
            InitializeComponent();
        }

        private void UcProfil_Load(object sender, EventArgs e)
        {
            SetReadOnlySemua();
            LoadDataProfil();
        }

        // Fungsi buat ngegembok semua Textbox dari ketikan iseng
        private void SetReadOnlySemua()
        {
            txtNama.ReadOnly = true;
            txtNoTelp.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtAlamat.ReadOnly = true;
            txtDesa.ReadOnly = true;
            txtKecamatan.ReadOnly = true;

            // Password digembok & dibikin bulet-bulet sensor
            txtPassword.ReadOnly = true;
            txtPassword.UseSystemPasswordChar = true;

            chkStatusAktif.Enabled = false; // Checkbox dikunci
            btnSimpan.Enabled = false; // Tombol simpan dimatiin dulu
        }

        private void LoadDataProfil()
        {
            // Panggil UserSession.UserId (ID karyawan yang lagi login)
            DataTable dt = profCtrl.GetProfilKaryawan(UserSession.UserId);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                // Masukin data ke masing-masing Textbox
                txtNama.Text = row["nama"].ToString();
                txtNoTelp.Text = row["no_telp"].ToString();
                txtEmail.Text = row["email"].ToString();
                txtUsername.Text = row["username"].ToString();
                txtPassword.Text = row["password"].ToString();
                txtAlamat.Text = row["alamat"].ToString();
                txtDesa.Text = row["nama_desa"].ToString();
                txtKecamatan.Text = row["nama_kecamatan"].ToString();

                // Kalo di database isActive itu boolean
                chkStatusAktif.Checked = Convert.ToBoolean(row["isActive"]);
            }
        }

        // Aksi pas tombol kecil "Edit" di samping password diklik
        private void btnEditPassword_Click(object sender, EventArgs e)
        {
            txtPassword.ReadOnly = false; // Buka gemboknya
            txtPassword.UseSystemPasswordChar = false; // Nampilin hurufnya pas mau diganti
            txtPassword.Focus(); // Kursor langsung lari ke kotak password

            btnSimpan.Enabled = true; // Nyalain tombol simpan
        }

        // Aksi pas tombol hijau "SIMPAN" diklik
        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password nggak boleh kosong dong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Lempar password baru ke database
                profCtrl.UpdatePassword(UserSession.UserId, txtPassword.Text);
                MessageBox.Show("Sip, password berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Habis disimpen, kunci lagi semuanya biar aman
                txtPassword.ReadOnly = true;
                txtPassword.UseSystemPasswordChar = true;
                btnSimpan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal update password: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Aksi pas tombol merah (Batal) diklik
        private void btnBatal_Click(object sender, EventArgs e)
        {
            // Batalin editan dan balikin password ke semula dari database
            LoadDataProfil();
            txtPassword.ReadOnly = true;
            txtPassword.UseSystemPasswordChar = true;
            btnSimpan.Enabled = false;
        }
    }
}
