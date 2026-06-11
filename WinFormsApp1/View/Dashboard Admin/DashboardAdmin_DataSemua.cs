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

namespace WinFormsApp1.View
{
    public partial class Dashboard_admin : Form
    {
        c_admin controller = new c_admin();

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

        private void Btn_Petani_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataPetani form = new DashboardAdmin_DataPetani(Username);
            form.Show();
            this.Hide();
        }

        private void Btn_Kurir_Click(object sender, EventArgs e)
        {
            DashboardAdmin_DataKurir form = new DashboardAdmin_DataKurir(Username);
            form.Show();
            this.Hide();
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
                Load();
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
    }
}
