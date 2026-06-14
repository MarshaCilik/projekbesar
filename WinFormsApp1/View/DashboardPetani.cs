using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;
using WinFormsApp1.Models.User;
using WinFormsApp1.View;
using WinFormsApp1.View.Kerjaan_Tiwi;

namespace WinFormsApp1
{
    public partial class DashboardPetani : Form
    {
        private string username;

        c_user controllerUser = new c_user();
        c_pesanan controller_pesanan = new c_pesanan();
        c_barangtani controller = new c_barangtani();


        public Users User;
        private List<Pesanan> listRiwayat;
        private List<barangTani> listbarangtani;
        private List<Pesanan> listpesanan;
        private List<AlatTani> List_alat_tani;

        private string tipeDataAktif = "barang";
        public DashboardPetani(Users user)
        {
            InitializeComponent();
            this.User = user;
            this.username = user.Username;
            LoadUsernameDinamis(user);
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_BarangTani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Dgv_Pesanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData("barang");
        }

        public void LoadUsernameDinamis(Users user)
        {
            usernameShow.Text = $"Selamat Datang! {username} ID : {User.UsersId}";
        }
        public void LoadData(string data)
        {
            if (data == "barang")
            {
                listbarangtani = controller.ReadBarangTani();

                Dgv_BarangTani.DataSource = null;
                Dgv_BarangTani.DataSource = listbarangtani;
                Dgv_BarangTani.Columns["tanggal_ditambahkan"].Visible = false;
            }
            else if (data == "alat_sewa")
            {
                List_alat_tani = controller.ReadAlatTani();

                Dgv_BarangTani.DataSource = null;
                Dgv_BarangTani.DataSource = List_alat_tani;
                Dgv_BarangTani.Columns["Added_at"].Visible = false;
            }
            else if (data == "pesanan_belum_co")
            {
                listpesanan = controller_pesanan.ReadPesananUser(User);

                Dgv_Pesanan.DataSource = null;
                Dgv_Pesanan.DataSource = listpesanan;


            }
            else if (data == "pesanan_sudah_co")
            {
                try
                {
                    listRiwayat = controller_pesanan.ReadCheckout(this.User);

                    Dgv_Pesanan.DataSource = null;

                    Dgv_Pesanan.DataSource = listRiwayat;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memuat riwayat pesanan: " + ex.Message, "Error Tampilan", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            LoginForm login = new LoginForm();
            login.Show();
            this.Hide();
        }

        private void btn_PesanProduk_Click(object sender, EventArgs e)
        {
            if (Dgv_BarangTani != null && Dgv_BarangTani.CurrentRow != null)
            {
                if (tipeDataAktif == "barang")
                {
                    barangTani selectedbarang = (barangTani)Dgv_BarangTani.CurrentRow.DataBoundItem;

                    PopUpPesanan form = new PopUpPesanan(User, selectedbarang);
                    form.ShowDialog();
                }
                else if (tipeDataAktif == "alat_sewa")
                {
                    AlatTani selectedAlat = (AlatTani)Dgv_BarangTani.CurrentRow.DataBoundItem;

                    PopUpPesananAlat form = new PopUpPesananAlat(User, selectedAlat);
                    form.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Tolong pilih alat!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_LihatAlatSewa_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(btn_LihatAlatSewa, "alat_sewa");

        }

        private void btn_LihatProdukTani_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(btn_LihatProdukTani, "barang");
        }

        private void SetSubMenuAktif(Button tombolAktif, string tipeData)
        {
            this.tipeDataAktif = tipeData;
            btn_LihatAlatSewa.BackColor = Color.LightGray;
            btn_LihatAlatSewa.ForeColor = Color.Black;

            btn_LihatProdukTani.BackColor = Color.LightGray;
            btn_LihatProdukTani.ForeColor = Color.Black;

            Btn_BelumCO.BackColor = Color.LightGray;
            Btn_BelumCO.ForeColor = Color.Black;

            Btn_SudahCO.BackColor = Color.LightGray;
            Btn_SudahCO.ForeColor = Color.Black;


            tombolAktif.BackColor = Color.FromArgb(40, 78, 34); // Hijau gelap PASTANI
            tombolAktif.ForeColor = Color.White;

            if (tipeData == "barang")
            {
                LoadData(tipeData);
            }
            else if (tipeData == "alat_sewa")
            {
                LoadData(tipeData);
            }
            else if (tipeData == "pesanan_sudah_co")
            {
                LoadData(tipeData);
            }
        }

        private void Btn_Pesanan_Click(object sender, EventArgs e)
        {
            LoadData("pesanan_belum_co");
            SetMenuAktif(Btn_Pesanan, "pesanan");
            Tc_Petani.SelectedIndex = 1;

        }

        private void Btn_Dashboard_Click(object sender, EventArgs e)
        {
            this.username = this.User.Username;
            LoadUsernameDinamis(this.User);
            SetMenuAktif(Btn_Dashboard, "dashboard");
            Tc_Petani.SelectedIndex = 0;

            this.Refresh();
        }

        private void SetMenuAktif(Button tombolAktif, string pilihan)
        {
            Btn_Pesanan.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Pesanan.ForeColor = Color.Black;

            Btn_Profil.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Profil.ForeColor = Color.Black;

            Btn_Riwayat.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Riwayat.ForeColor = Color.Black;

            Btn_Dashboard.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Dashboard.ForeColor = Color.Black;

            tombolAktif.ForeColor = Color.White;
            tombolAktif.BackColor = Color.FromArgb(40, 78, 34);
        }

        private void Btn_SudahCO_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(Btn_SudahCO, "pesanan_sudah_co");
            Btn_CheckOut.Enabled = false;
            LoadData("pesanan_sudah_co");
        }

        private void Btn_BelumCO_Click(object sender, EventArgs e)
        {
            SetSubMenuAktif(Btn_BelumCO, "pesanan_belum_co");
            Btn_CheckOut.Enabled = true;
            LoadData("pesanan_belum_co");
        }

        private void Btn_Keluar_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm form = new LoginForm();
            form.Show();
        }

        private void DashboardPetani_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Btn_CheckOut_Click(object sender, EventArgs e)
        {
            if (Dgv_Pesanan.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih pesanan yang ingin di-checkout dari tabel terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pesanan selectedPesanan = (Pesanan)Dgv_Pesanan.CurrentRow.DataBoundItem;

            if (selectedPesanan == null)
            {
                MessageBox.Show("Gagal membaca data pesanan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Apakah Anda yakin ingin melakukan Check Out untuk Pesanan ID: {selectedPesanan.Id}?",
                                                   "Konfirmasi Check Out", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                c_pesanan controllerPesanan = new c_pesanan();

                bool statusSukses = controllerPesanan.ProsesCheckout(selectedPesanan);

                if (statusSukses)
                {
                    MessageBox.Show("Pesanan berhasil di-checkout!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Refresh tabel keranjang belanja agar item yang di-CO langsung hilang dari view
                    Btn_BelumCO_Click(sender, e);
                }
            }
        }

        private void Btn_BatalPesanan_Click(object sender, EventArgs e)
        {
            if (Dgv_Pesanan.CurrentRow == null)
            {
                MessageBox.Show("Silakan pilih salah satu item pesanan yang ingin dibatalkan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Pesanan pesananTerpilih = (Pesanan)Dgv_Pesanan.CurrentRow.DataBoundItem;

            if (pesananTerpilih == null)
            {
                MessageBox.Show("Gagal membaca data pesanan.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (pesananTerpilih.Status == "Sudah Checkout")
            {
                MessageBox.Show("Pesanan yang sudah di-checkout tidak dapat dibatalkan!", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            DialogResult konfirmasi = MessageBox.Show($"Apakah Anda yakin ingin membatalkan pesanan '{pesananTerpilih.Nama}' pada ID Pesanan: {pesananTerpilih.Id}?",
                                                      "Konfirmasi Pembatalan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (konfirmasi == DialogResult.Yes)
            {
                // Kirim ID, Jenis ('Pembelian'/'Penyewaan'), dan Nama Item ke Controller
                bool suksesBatal = controller_pesanan.ProsesBatalPesanan(pesananTerpilih.Id, pesananTerpilih.Jenis_Pesanan, pesananTerpilih.Nama);

                if (suksesBatal)
                {
                    MessageBox.Show("Item pesanan berhasil dibatalkan dan dihapus!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // 5. REFRESH TABEL: Panggil otomatis fungsi "Belum Check Out" agar item yang dihapus langsung lenyap dari layar
                    Btn_BelumCO_Click(sender, e);
                }
            }
        }

        private void TampilkanProfilPetani()
        {
            // 1. Masukkan data session user aktif ke masing-masing TextBox profil
            Tb_Nama.Text = this.User.Nama;
            Tb_NoTelp.Text = this.User.NoTelp;
            Tb_Email.Text = this.User.Email;
            Tb_Username.Text = this.User.Username;
            Tb_Password.Text = this.User.Password;
            Tb_Alamat.Text = this.User.Alamat;
            Tb_Desa.Text = this.User.NamaDesa;
            Tb_Kecamatan.Text = this.User.NamaKecamatan;

            if (this.User.IsActive)
            {
                Lbl_Status.Text = "STATUS: AKTIF";
                Lbl_Status.ForeColor = Color.Green; // (Opsional) Bikin teks warna hijau biar segar
            }
            else
            {
                Lbl_Status.Text = "STATUS: TIDAK AKTIF";
                Lbl_Status.ForeColor = Color.Red; // (Opsional) Bikin teks warna merah
            }
        }

        private void Btn_Profil_Click(object sender, EventArgs e)
        {
            TampilkanProfilPetani();
            SetMenuAktif(Btn_Profil, "profil");
            Tc_Petani.SelectedIndex = 4;
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            string usernameLamaAsli = this.User.Username;

            string nama = Tb_Nama.Text;
            string noTelp = Tb_NoTelp.Text;
            string email = Tb_Email.Text;
            string username = Tb_Username.Text;
            string password = Tb_Password.Text;
            string alamat = Tb_Alamat.Text;
            string desa = Tb_Desa.Text;
            string kecamatan = Tb_Kecamatan.Text;


            bool suksesUpdate = controllerUser.ProsesUpdateProfil(this.User, nama, noTelp, email, 
                username, password, alamat, desa, kecamatan, usernameLamaAsli);

            if (suksesUpdate)
            {
                MessageBox.Show("Profil Anda berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Perbarui data session lokal agar sinkron dengan yang baru disimpan
                this.User.Nama = nama;
                this.User.NoTelp = noTelp;
                this.User.Email = email;
                this.User.Username = username;
                this.User.Password = password;
                this.User.Alamat = alamat;
                this.User.NamaDesa = desa;
                this.User.NamaKecamatan = kecamatan;

                LoadUsernameDinamis(this.User);

            }
        }
    }
}
