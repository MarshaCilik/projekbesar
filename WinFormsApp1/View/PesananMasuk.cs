using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;

namespace WinFormsApp1.View
{
    public partial class PesananMasuk : Form
    {
        private KaryawanController db = new KaryawanController();

        public PesananMasuk()
        {
            InitializeComponent();
            this.Load += PesananMasuk_Load;
            btnDiterima.Click += btnDiterima_Click;
            btnDItolak.Click += btnDitolak_Click;
            btnBack.Click += (s, e) => this.Close();
        }

        private void PesananMasuk_Load(object sender, EventArgs e)
        {
            dgvPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPesanan.MultiSelect = false;
            dgvPesanan.ReadOnly = true;
            dgvPesanan.AllowUserToAddRows = false;
            dgvPesanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            LoadKurirComboBox();
            LoadPesananData();

            dgvPesanan.SelectionChanged += dgvPesanan_SelectionChanged;
        }

        private void LoadKurirComboBox()
        {
            try
            {
                c_user userCtrl = new c_user();
                var listKurir = userCtrl.ReadKurir();
                cbxKurir.DataSource = listKurir;
                cbxKurir.DisplayMember = "Nama";
                cbxKurir.ValueMember = "Id";
                cbxKurir.SelectedIndex = -1;
                cbxKurir.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data kurir: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvPesanan_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvPesanan.SelectedRows.Count > 0)
            {
                var row = dgvPesanan.SelectedRows[0];
                if (row.Cells["Pengiriman"].Value != null)
                {
                    string pengiriman = row.Cells["Pengiriman"].Value.ToString().ToLower();
                    if (pengiriman.Contains("diantar"))
                    {
                        cbxKurir.Enabled = true;
                    }
                    else
                    {
                        cbxKurir.Enabled = false;
                        cbxKurir.SelectedIndex = -1;
                    }
                }
            }
            else
            {
                cbxKurir.Enabled = false;
                cbxKurir.SelectedIndex = -1;
            }
        }

        private void LoadPesananData()
        {
            try
            {
                dgvPesanan.DataSource = db.GetPesananCheckout(); // Load from v_pesanan_checkout
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDiterima_Click(object sender, EventArgs e)
        {
            if (dgvPesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih pesanan yang akan diterima!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = dgvPesanan.SelectedRows[0];
            int pesananId = Convert.ToInt32(selectedRow.Cells["ID Pesanan"].Value);
            string namaItem = selectedRow.Cells["Nama Item"].Value.ToString();
            string pengiriman = selectedRow.Cells["Pengiriman"].Value != null ? selectedRow.Cells["Pengiriman"].Value.ToString().ToLower() : "";

            int? kurirId = null;

            if (pengiriman.Contains("diantar"))
            {
                if (cbxKurir.SelectedValue == null || cbxKurir.SelectedIndex == -1)
                {
                    MessageBox.Show("Silakan pilih kurir terlebih dahulu untuk metode pengiriman diantar!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                kurirId = Convert.ToInt32(cbxKurir.SelectedValue);
            }

            DialogResult confirm = MessageBox.Show($"Terima pesanan #{pesananId} untuk item {namaItem}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.TerimaPesanan(pesananId, UserSession.Username, kurirId);
                    MessageBox.Show("Pesanan diterima!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPesananData();
                    cbxKurir.SelectedIndex = -1;
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Gagal menerima pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnDitolak_Click(object sender, EventArgs e)
        {
            if (dgvPesanan.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih pesanan yang akan ditolak!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int pesananId = Convert.ToInt32(dgvPesanan.SelectedRows[0].Cells["ID Pesanan"].Value);
            string alasan = WinFormsApp1.View.Dashboard_Karyawan.Prompt.ShowDialog("Masukkan alasan penolakan:", "Tolak Pesanan");

            if (!string.IsNullOrWhiteSpace(alasan))
            {
                try
                {
                    db.BatalPesanan(pesananId, alasan);
                    MessageBox.Show("Pesanan ditolak!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPesananData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menolak pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
