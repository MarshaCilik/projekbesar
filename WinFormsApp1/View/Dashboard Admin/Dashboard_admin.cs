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

            // TODO: Pindahkan TabControl ke index Dashboard (misal: tc_Admin.SelectedIndex = 0;)
        }

        private void btn_CRUDProduk_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_CRUDProduk);

            // TODO: Pindahkan TabControl ke index CRUD Produk
        }

        private void btn_TambahKaryawan_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_TambahKaryawan);

            // TODO: Pindahkan TabControl ke index Tambah Karyawan
        }

        private void btn_Profil_Click(object sender, EventArgs e)
        {
            SetMenuKiriAktif(btn_Profil);

            // TODO: Pindahkan TabControl ke index Profil Admin
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
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        string result = controller.Update(form.UserData);

                        MessageBox.Show(
                        result,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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
                        string result = controller.Update(form.UserData);

                        MessageBox.Show(
                        result,
                        "Informasi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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

        private void Dashboard_admin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
