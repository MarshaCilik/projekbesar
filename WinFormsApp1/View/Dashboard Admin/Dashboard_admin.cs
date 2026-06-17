using System;
using System.Collections.Generic;
using System.ComponentModel;
using Npgsql;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models.User;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WinFormsApp1.Models;


namespace WinFormsApp1.View.Dashboard_Admin
{
    public partial class Dashboard_admin : Form
    {
        // Variabel warna PASTANI agar konsisten
        private readonly Color warnaHijauPastani = Color.FromArgb(40, 78, 34);
        private readonly Color warnaDefaultKiri = Color.Transparent; // Menyesuaikan warna panel kiri bawaan
        private readonly Color warnaDefaultAtas = Color.LightGray;    // Warna tombol sub-menu saat tidak aktif

        c_admin controller = new c_admin();

        public string Username;

        private List<Kurir> listKurir;
        private List<Users> list;

        public Users user;

        public Dashboard_admin(Users user)
        {
            InitializeComponent();
            this.user = user;
            this.Username = user.Username;
            this.StartPosition = FormStartPosition.CenterScreen;

            // Menampilkan username admin saat ini ke label
            Lbl_UsernameAdmin.Text = this.Username;
            Lbl_UsernameAdmin1.Text = this.Username;

            dgv_AllUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Load("semua");

            // Set default tampilan awal saat form pertama kali dibuka
            SetMenuKiriAktif(btn_Dashboard);
            SetSubMenuAtasAktif(Btn_SeluruhUser);

            // Wire up CRUD Produk events programmatically
            Btn_Barang.Click += Btn_Barang_Click;
            Btn_AlatSewa.Click += Btn_AlatSewa_Click;
            btn_editData.Click += Btn_EditProduk_Click;
            btn_TambahUser.Click += Btn_TambahUser_Click;
            Btn_Simpan.Click += Btn_Simpan_Click;

            // Setup right-click delete menu
            SetupContextMenu();

            // Set initial state for CRUD Produk
            LoadProduk("barang");
        }

        public void Load(string DataUser)
        {
            if (DataUser == "semua" || DataUser == "karyawan" || DataUser == "petani")
            {
                list = controller.ReadAllUser(DataUser);

                dgv_AllUser.DataSource = null;
                dgv_AllUser.DataSource = list;
            }
        }

        /// <summary>
        /// Mengatur warna dinamis untuk menu utama di panel sebelah kiri
        /// </summary>


        /// <summary>
        /// Mengatur warna dinamis untuk sub-menu filter user di bagian atas
        /// </summary>
        private void SetSubMenuAtasAktif(Button tombolAktif)
        {
            // Reset semua tombol filter atas ke warna abu-abu default
            Btn_SeluruhUser.BackColor = warnaDefaultAtas;
            Btn_SeluruhUser.ForeColor = Color.Black;

            Btn_Karyawan.BackColor = warnaDefaultAtas;
            Btn_Karyawan.ForeColor = Color.Black;

            Btn_Petani.BackColor = warnaDefaultAtas;
            Btn_Petani.ForeColor = Color.Black;

            Btn_Kurir.BackColor = warnaDefaultAtas;
            Btn_Kurir.ForeColor = Color.Black;

            // Set hanya sub-menu yang diklik menjadi Hijau PASTANI dengan tulisan putih
            tombolAktif.BackColor = warnaHijauPastani;
            tombolAktif.ForeColor = Color.White;

            if (tombolAktif == Btn_Karyawan || tombolAktif == Btn_Kurir)
            {
                btn_TambahUser.Visible = true;
            }
            else
            {
                btn_TambahUser.Visible = false;
            }
        }


        private void btn_Dashboard_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_Dashboard);
            tabControl1.SelectedIndex = 0;
        }

        private void btn_CRUDProduk_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_CRUDProduk);
            tabControl1.SelectedIndex = 1;
            LoadProduk("barang");
        }

        private void btn_Profil_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_Profil);
            tabControl1.SelectedIndex = 4;

            // Populate textboxes with current admin data
            Tb_Nama.Text = this.user.Nama;
            Tb_NoTelp.Text = this.user.NoTelp;
            Tb_Email.Text = this.user.Email;
            Tb_Username.Text = this.user.Username;
            Tb_Password.Text = this.user.Password;
            Tb_Alamat.Text = this.user.Alamat;
            Tb_Kecamatan.Text = this.user.NamaKecamatan;
            Tb_Desa.Text = this.user.NamaDesa;
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            try
            {
                // Minta konfirmasi sebelum menyimpan
                var confirmResult = MessageBox.Show("Apakah Anda yakin ingin menyimpan perubahan data profil?",
                                     "Konfirmasi Simpan",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);

                if (confirmResult == DialogResult.Yes)
                {
                    // Buat object user baru berdasarkan input form
                    Users userUpdate = new AdminUser(
                        this.user.UsersId,
                        Tb_Username.Text.Trim(),
                        Tb_Password.Text.Trim(),
                        Tb_Nama.Text.Trim(),
                        Tb_NoTelp.Text.Trim(),
                        Tb_Email.Text.Trim(),
                        this.user.IsActive,
                        this.user.CreatedAt,
                        this.user.UpdateAt,
                        Tb_Alamat.Text.Trim(),
                        Tb_Desa.Text.Trim(),
                        Tb_Kecamatan.Text.Trim()
                    );

                    string result = controller.Update(userUpdate, this.user.Username);
                    MessageBox.Show(result, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (result.ToLower().Contains("update") || result.ToLower().Contains("berhasil"))
                    {
                        this.user = userUpdate;
                        this.Username = userUpdate.Username;
                        Lbl_UsernameAdmin.Text = this.Username;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Btn_SeluruhUser_Click(object sender, EventArgs e)
        {
            SetSubMenuAtasAktif(Btn_SeluruhUser);
            Load("semua");
        }

        private void Btn_Karyawan_Click(object sender, EventArgs e)
        {
            SetSubMenuAtasAktif(Btn_Karyawan);
            Load("karyawan");
        }

        private void Btn_Petani_Click(object sender, EventArgs e)
        {
            SetSubMenuAtasAktif(Btn_Petani);
            Load("petani");
        }

        private void Btn_Kurir_Click(object sender, EventArgs e)
        {
            SetSubMenuAtasAktif(Btn_Kurir);
            listKurir = controller.ReadKurir();

            dgv_AllUser.DataSource = null;
            dgv_AllUser.DataSource = listKurir;
        }

        private void Btn_TambahUser_Click(object sender, EventArgs e)
        {
            if (Btn_Karyawan.BackColor == warnaHijauPastani)
            {
                EditDataUserKaryawan form = new EditDataUserKaryawan(null);
                if (form.ShowDialog() == DialogResult.OK && form.UserData != null)
                {
                    string result = controller.CreateKaryawan(form.UserData);
                    MessageBox.Show(result, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Load("karyawan");
                }
            }
            else if (Btn_Kurir.BackColor == warnaHijauPastani)
            {
                EditDataKurir form = new EditDataKurir(null);
                if (form.ShowDialog() == DialogResult.OK && form.KurirData != null)
                {
                    string result = controller.CreateKurir(form.KurirData);
                    MessageBox.Show(result, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    listKurir = controller.ReadKurir();
                    dgv_AllUser.DataSource = null;
                    dgv_AllUser.DataSource = listKurir;
                }
            }
        }

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
            if (Btn_Kurir.BackColor == warnaHijauPastani)
            {
                if (dgv_AllUser.CurrentRow != null && dgv_AllUser.CurrentRow.DataBoundItem is Kurir selectedKurir)
                {
                    EditDataKurir form = new EditDataKurir(selectedKurir);
                    if (form.ShowDialog() == DialogResult.OK && form.KurirData != null)
                    {
                        string result = controller.UpdateKurir(form.KurirData);
                        MessageBox.Show(result, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        listKurir = controller.ReadKurir();
                        dgv_AllUser.DataSource = null;
                        dgv_AllUser.DataSource = listKurir;
                    }
                }
                else
                {
                    MessageBox.Show("Pilih kurir yang ingin diedit dari tabel!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return;
            }

            Users selecteduser = (Users)dgv_AllUser.CurrentRow.DataBoundItem;
            string roleTerpilih = dgv_AllUser.CurrentRow.Cells["Roles"].Value.ToString().ToLower();

            Users dataYangMauDiedit = null;

            string statusKondisiLoad = "semua";

            if (Btn_SeluruhUser.BackColor == warnaHijauPastani) statusKondisiLoad = "semua";
            else if (Btn_Karyawan.BackColor == warnaHijauPastani) statusKondisiLoad = "karyawan";
            else if (Btn_Petani.BackColor == warnaHijauPastani) statusKondisiLoad = "petani";

            int id = Convert.ToInt32(dgv_AllUser.CurrentRow.Cells["UsersId"].Value);
            string username = dgv_AllUser.CurrentRow.Cells["Username"].Value.ToString();
            string password = dgv_AllUser.CurrentRow.Cells["Password"].Value.ToString();
            string nama = dgv_AllUser.CurrentRow.Cells["Nama"].Value.ToString();
            string noTelp = dgv_AllUser.CurrentRow.Cells["NoTelp"].Value.ToString();
            string email = dgv_AllUser.CurrentRow.Cells["Email"].Value.ToString();
            string alamat = dgv_AllUser.CurrentRow.Cells["Alamat"].Value.ToString();
            string desa = dgv_AllUser.CurrentRow.Cells["NamaDesa"].Value.ToString();
            string kecamatan = dgv_AllUser.CurrentRow.Cells["NamaKecamatan"].Value.ToString();
            bool isActive = Convert.ToBoolean(dgv_AllUser.CurrentRow.Cells["IsActive"].Value);
            if (dgv_AllUser.CurrentRow != null)
            {
                if (roleTerpilih == "karyawan")
                {
                    DateOnly? tglBuat = null;
                    DateOnly? tglUpdate = null;
                    dataYangMauDiedit = new KaryawanUser(
                        id,
                        username,
                        password,
                        nama,
                        noTelp,
                        email,
                        isActive,
                        tglBuat,
                        tglUpdate,
                        alamat,
                        desa,
                        kecamatan
                        );

                    EditDataUserKaryawan form = new EditDataUserKaryawan(dataYangMauDiedit);
                    string usernameLamaKaryawan = selecteduser.Username;
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string result = controller.Update(form.UserData, usernameLamaKaryawan);

                        MessageBox.Show(
                        result,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        if (statusKondisiLoad == "semua")
                        {
                            Load("semua");
                        }
                        else
                        {
                            Load("karyawan");
                        }
                    }

                }
                else if (roleTerpilih == "petani")
                {
                    DateOnly? tglBuat = null;
                    DateOnly? tglUpdate = null;
                    dataYangMauDiedit = new PetaniUser(
                        id,
                        username,
                        password,
                        nama,
                        noTelp,
                        email,
                        isActive,
                        tglBuat,
                        tglUpdate,
                        alamat,
                        desa,
                        kecamatan
                        );

                    EditDataUserPetani form = new EditDataUserPetani(dataYangMauDiedit);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show(
                        "Data berhasil update",
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                        if (statusKondisiLoad == "semua")
                        {
                            Load("semua");
                        }
                        else
                        {
                            Load("petani");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show(
                "Tolong pilih data!",
                "Informasi",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
        }

        private string activeProdukTab = "barang";
        private c_barangtani controllerBarang = new c_barangtani();
        private c_transaksi controllerTransaksi = new c_transaksi();

        private void LoadProduk(string tipe)
        {
            activeProdukTab = tipe;
            if (tipe == "barang")
            {
                Btn_Barang.BackColor = warnaHijauPastani;
                Btn_Barang.ForeColor = Color.White;
                Btn_AlatSewa.BackColor = warnaDefaultAtas;
                Btn_AlatSewa.ForeColor = Color.Black;

                dgv_Produk.Visible = true;
                dgv_Produk.BringToFront();

                if (menuBarang != null) dgv_Produk.ContextMenuStrip = menuBarang;

                dgv_Produk.DataSource = null;
                dgv_Produk.DataSource = controllerBarang.ReadBarangTani();
                dgv_Produk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else if (tipe == "alat_sewa")
            {
                Btn_AlatSewa.BackColor = warnaHijauPastani;
                Btn_AlatSewa.ForeColor = Color.White;
                Btn_Barang.BackColor = warnaDefaultAtas;
                Btn_Barang.ForeColor = Color.Black;

                dgv_Produk.Visible = true;
                dgv_Produk.BringToFront();

                if (menuAlat != null) dgv_Produk.ContextMenuStrip = menuAlat;

                dgv_Produk.DataSource = null;
                dgv_Produk.DataSource = controllerBarang.ReadAlatTani();
                dgv_Produk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void Btn_Barang_Click(object sender, EventArgs e)
        {
            LoadProduk("barang");
        }

        private void Btn_AlatSewa_Click(object sender, EventArgs e)
        {
            LoadProduk("alat_sewa");
        }



        private void Btn_EditProduk_Click(object sender, EventArgs e)
        {
            if (activeProdukTab == "barang")
            {
                if (dgv_Produk.CurrentRow != null && dgv_Produk.CurrentRow.DataBoundItem is barangTani selectedBarang)
                {
                    Form_Edit_barang form = new Form_Edit_barang(selectedBarang);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProduk("barang");
                    }
                }
                else
                {
                    MessageBox.Show("Silakan pilih data barang yang ingin diedit dari tabel!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (activeProdukTab == "alat_sewa")
            {
                if (dgv_Produk.CurrentRow != null && dgv_Produk.CurrentRow.DataBoundItem is AlatTani selectedAlat)
                {
                    Form_Edit_Alat form = new Form_Edit_Alat(selectedAlat);
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        LoadProduk("alat_sewa");
                    }
                }
                else
                {
                    MessageBox.Show("Silakan pilih data alat sewa yang ingin diedit dari tabel!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private ContextMenuStrip menuBarang;
        private ContextMenuStrip menuAlat;

        private void SetupContextMenu()
        {
            menuBarang = new ContextMenuStrip();
            ToolStripMenuItem hapusBarang = new ToolStripMenuItem("Hapus Barang");
            hapusBarang.Click += HapusBarang_Click;
            menuBarang.Items.Add(hapusBarang);

            menuAlat = new ContextMenuStrip();
            ToolStripMenuItem hapusAlat = new ToolStripMenuItem("Hapus Alat Sewa");
            hapusAlat.Click += HapusAlat_Click;
            menuAlat.Items.Add(hapusAlat);
        }

        private void HapusBarang_Click(object sender, EventArgs e)
        {
            if (dgv_Produk.CurrentRow != null && dgv_Produk.CurrentRow.DataBoundItem is barangTani selectedBarang)
            {
                var confirm = MessageBox.Show($"Apakah Anda yakin ingin menghapus barang '{selectedBarang.nama_barang}'?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string hasil = controllerBarang.DeleteBarangTani(selectedBarang.Id);
                    MessageBox.Show(hasil, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProduk("barang");
                }
            }
        }

        private void HapusAlat_Click(object sender, EventArgs e)
        {
            if (dgv_Produk.CurrentRow != null && dgv_Produk.CurrentRow.DataBoundItem is AlatTani selectedAlat)
            {
                var confirm = MessageBox.Show($"Apakah Anda yakin ingin menghapus alat sewa '{selectedAlat.Nama}'?",
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (confirm == DialogResult.Yes)
                {
                    string hasil = controllerBarang.DeleteAlatTani(selectedAlat.Id);
                    MessageBox.Show(hasil, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadProduk("alat_sewa");
                }
            }
        }

        private void Dashboard_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btn_tambahBarang_Click(object sender, EventArgs e)
        {
            if (activeProdukTab == "barang")
            {
                form_tambah_barang form = new form_tambah_barang();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProduk("barang");
                }
            }
            else if (activeProdukTab == "alat_sewa")
            {
                Form_Tambah_Alat form = new Form_Tambah_Alat();
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadProduk("alat_sewa");
                }
            }
        }

        private void btn_Hapus_Click(object sender, EventArgs e)
        {
            if (activeProdukTab == "barang")
            {
                HapusBarang_Click(sender, e);
            }
            else if (activeProdukTab == "alat_sewa")
            {
                HapusAlat_Click(sender, e);
            }
        }

        private void SetMenuLaporanAktif(Button tombolAktif)
        {
            // Reset warna tombol laporan ke abu-abu default
            btnLaporanTransaksi.BackColor = Color.FromArgb(217, 217, 217);
            btnLaporanTransaksi.ForeColor = Color.Black;

            btnLaporanStok.BackColor = Color.FromArgb(217, 217, 217);
            btnLaporanStok.ForeColor = Color.Black;

            btnLaporanDenda.BackColor = Color.FromArgb(217, 217, 217);
            btnLaporanDenda.ForeColor = Color.Black;

            // Set tombol yang aktif ke warna hijau sesuai permintaan (49, 106, 14)
            tombolAktif.BackColor = Color.FromArgb(49, 106, 14);
            tombolAktif.ForeColor = Color.White;
        }

        private void btnLaporanStok_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage7;
            SetMenuLaporanAktif(btnLaporanStok);
        }

        private void btnLaporanDenda_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage8;
            SetMenuLaporanAktif(btnLaporanDenda);
        }

        private void btnLaporanTransaksi_Click(object sender, EventArgs e)
        {
            tabControl2.SelectedTab = tabPage6;
            SetMenuLaporanAktif(btnLaporanTransaksi);
        }

        private void btn_LaporanRekap_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
            SetMenuKiriAktif(btn_LaporanRekap);
        }

        private void SetMenuKiriAktif(Button tombolAktif)
        {
            // Reset semua tombol kiri ke warna default (Tulisan hijau/hitam, background transparan)
            btn_Dashboard.BackColor = warnaDefaultKiri;
            btn_Dashboard.ForeColor = Color.FromArgb(40, 78, 34); // Atau Color.Black tergantung desain awalmu

            btn_CRUDProduk.BackColor = warnaDefaultKiri;
            btn_CRUDProduk.ForeColor = Color.FromArgb(40, 78, 34);

            btn_Profil.BackColor = warnaDefaultKiri;
            btn_Profil.ForeColor = Color.FromArgb(40, 78, 34);

            btn_LaporanRekap.BackColor = warnaDefaultKiri;
            btn_LaporanRekap.ForeColor = Color.FromArgb(40, 78, 34);
            // Set hanya tombol yang diklik menjadi Hijau PASTANI dengan tulisan putih
            tombolAktif.BackColor = warnaHijauPastani;
            tombolAktif.ForeColor = Color.White;
        }

        private void Tb_pencarian_TextChanged(object sender, EventArgs e)
        {
            // Cek apakah textbox itu sendiri belum dinisialisasi
            if (sender is TextBox tb)
            {
                string keyword = tb.Text.Trim();

                if (string.IsNullOrEmpty(keyword))
                {
                    // Jika kosong, load semua data
                    LoadProduk(activeProdukTab);
                }
                else
                {
                    // Lakukan pencarian melalui controller
                    if (activeProdukTab == "barang")
                    {
                        dgv_Produk.DataSource = null;
                        dgv_Produk.DataSource = controllerBarang.SearchBarangTani(keyword);
                        dgv_Produk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                    else if (activeProdukTab == "alat_sewa")
                    {
                        dgv_Produk.DataSource = null;
                        dgv_Produk.DataSource = controllerBarang.SearchAlatTani(keyword);
                        dgv_Produk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    }
                }
            }
        }

        private void btn_TerapkanFilter_Click(object sender, EventArgs e)
        {
            DateTime dariTanggal = dtp_DariTanggal.Value.Date;
            DateTime keTanggal = dtp_KeTanggal.Value.Date;
            string searchId = Tb_CariID.Text.Trim();

            // Panggil method controller untuk GetAllTransaksiSelesai (filter untuk Admin)
            var listTransaksi = controllerTransaksi.GetAllTransaksiSelesai(dariTanggal, keTanggal, searchId);

            dgvTransaksi.DataSource = null;
            dgvTransaksi.DataSource = listTransaksi;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btn_AuditTransaksi_Click(object sender, EventArgs e)
        {
            try
            {
                // Ambil data DataTable dari Audit Log dan bind ke dgvTransaksi
                System.Data.DataTable dtAudit = controllerTransaksi.GetAuditTransaksi();

                dgvTransaksi.DataSource = null;
                dgvTransaksi.DataSource = dtAudit;
                dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal mengambil log audit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_StokTersedikit_Click(object sender, EventArgs e)
        {
            try
            {
                var dtStok = controllerBarang.GetStokTersedikit();
                dgvStok.DataSource = null;
                dgvStok.DataSource = dtStok;
                dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat Laporan Stok Tersedikit: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ProdukTerlaris_Click(object sender, EventArgs e)
        {
            try
            {
                var dtLaris = controllerBarang.GetProdukTerlaris();
                dgvStok.DataSource = null;
                dgvStok.DataSource = dtLaris;
                dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat Laporan Produk Terlaris: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRiwayat_Click(object sender, EventArgs e)
        {

        }
    }
}