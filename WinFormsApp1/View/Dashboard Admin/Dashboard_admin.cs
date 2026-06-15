using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            this.Username = user.Username;
            this.StartPosition = FormStartPosition.CenterScreen;
            dgv_AllUser.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Load("semua");
            Lbl_UsernameAtas.Text = $"{Username}";

            // Set default tampilan awal saat form pertama kali dibuka
            SetMenuKiriAktif(btn_Dashboard);
            SetSubMenuAtasAktif(Btn_SeluruhUser);

            // Wire up CRUD Produk events programmatically
            Btn_Barang.Click += Btn_Barang_Click;
            Btn_AlatSewa.Click += Btn_AlatSewa_Click;
            button1.Click += Btn_TambahProduk_Click;
            button2.Click += Btn_EditProduk_Click;

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
        private void SetMenuKiriAktif(Button tombolAktif)
        {
            // Reset semua tombol kiri ke warna default (Tulisan hijau/hitam, background transparan)
            btn_Dashboard.BackColor = warnaDefaultKiri;
            btn_Dashboard.ForeColor = Color.FromArgb(40, 78, 34); // Atau Color.Black tergantung desain awalmu

            btn_CRUDProduk.BackColor = warnaDefaultKiri;
            btn_CRUDProduk.ForeColor = Color.FromArgb(40, 78, 34);

            btn_TambahKaryawan.BackColor = warnaDefaultKiri;
            btn_TambahKaryawan.ForeColor = Color.FromArgb(40, 78, 34);

            btn_Profil.BackColor = warnaDefaultKiri;
            btn_Profil.ForeColor = Color.FromArgb(40, 78, 34);

            // Set hanya tombol yang diklik menjadi Hijau PASTANI dengan tulisan putih
            tombolAktif.BackColor = warnaHijauPastani;
            tombolAktif.ForeColor = Color.White;
        }

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

        private void btn_TambahKaryawan_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_TambahKaryawan);
            tabControl1.SelectedIndex = 2;
        }

        private void btn_Profil_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_Profil);
            tabControl1.SelectedIndex = 3;
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

        private void Btn_Edit_Click(object sender, EventArgs e)
        {
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

                    EditDataUserKaryawan form = new EditDataUserKaryawan(selecteduser);
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

                    EditDataUserPetani form = new EditDataUserPetani(selecteduser);
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

        private void LoadProduk(string tipe)
        {
            activeProdukTab = tipe;
            if (tipe == "barang")
            {
                Btn_Barang.BackColor = warnaHijauPastani;
                Btn_Barang.ForeColor = Color.White;
                Btn_AlatSewa.BackColor = warnaDefaultAtas;
                Btn_AlatSewa.ForeColor = Color.Black;

                Dgv_Barang.Visible = true;
                dataGridView1.Visible = false;

                Dgv_Barang.DataSource = null;
                Dgv_Barang.DataSource = controllerBarang.ReadBarangTani();
                Dgv_Barang.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            else if (tipe == "alat_sewa")
            {
                Btn_AlatSewa.BackColor = warnaHijauPastani;
                Btn_AlatSewa.ForeColor = Color.White;
                Btn_Barang.BackColor = warnaDefaultAtas;
                Btn_Barang.ForeColor = Color.Black;

                dataGridView1.Visible = true;
                Dgv_Barang.Visible = false;

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = controllerBarang.ReadAlatTani();
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void Btn_TambahProduk_Click(object sender, EventArgs e)
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

        private void Btn_EditProduk_Click(object sender, EventArgs e)
        {
            if (activeProdukTab == "barang")
            {
                if (Dgv_Barang.CurrentRow != null && Dgv_Barang.CurrentRow.DataBoundItem is barangTani selectedBarang)
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
                if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is AlatTani selectedAlat)
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

        private void SetupContextMenu()
        {
            ContextMenuStrip menuBarang = new ContextMenuStrip();
            ToolStripMenuItem hapusBarang = new ToolStripMenuItem("Hapus Barang");
            hapusBarang.Click += HapusBarang_Click;
            menuBarang.Items.Add(hapusBarang);
            Dgv_Barang.ContextMenuStrip = menuBarang;

            ContextMenuStrip menuAlat = new ContextMenuStrip();
            ToolStripMenuItem hapusAlat = new ToolStripMenuItem("Hapus Alat Sewa");
            hapusAlat.Click += HapusAlat_Click;
            menuAlat.Items.Add(hapusAlat);
            dataGridView1.ContextMenuStrip = menuAlat;
        }

        private void HapusBarang_Click(object sender, EventArgs e)
        {
            if (Dgv_Barang.CurrentRow != null && Dgv_Barang.CurrentRow.DataBoundItem is barangTani selectedBarang)
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
            if (dataGridView1.CurrentRow != null && dataGridView1.CurrentRow.DataBoundItem is AlatTani selectedAlat)
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
    }
}