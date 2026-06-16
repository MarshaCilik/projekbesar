using System;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;

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
            LoadPesananData();
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

            int pesananId = Convert.ToInt32(dgvPesanan.SelectedRows[0].Cells["ID Pesanan"].Value);
            string namaItem = dgvPesanan.SelectedRows[0].Cells["Nama Item"].Value.ToString();
            
            DialogResult confirm = MessageBox.Show($"Terima pesanan #{pesananId} untuk item {namaItem}?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.TerimaPesanan(pesananId, UserSession.Username);
                    MessageBox.Show("Pesanan diterima!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPesananData();
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
