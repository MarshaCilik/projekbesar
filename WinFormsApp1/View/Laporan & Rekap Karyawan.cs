using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.View
{
    public partial class Laporan___Rekap : Form
    {
        private LaporanController lapCtrl = new LaporanController();

        public Laporan___Rekap()
        {
            InitializeComponent();
        }

        private void Laporan_Rekap_Load(object sender, EventArgs e)
        {
            // Tulis nama karyawan
            txtNamaKaryawan.Text = UserSession.Username;

            // Pas baru buka, default-nya nampilin laporan transaksi
            PilihMenuLaporan("Transaksi");
        }

        // === FUNGSI SAKTI BUAT GANTI-GANTI TABEL ===
        private void PilihMenuLaporan(string menu)
        {
            // 1. Balikin semua tombol ke warna putih/abu-abu terang
            btnLaporanTransaksi.BackColor = Color.WhiteSmoke;
            btnLaporanStok.BackColor = Color.WhiteSmoke;
            btnLaporanDenda.BackColor = Color.WhiteSmoke;
            btnLaporanKeuangan.BackColor = Color.WhiteSmoke;

            // 2. Sembunyiin semua tabel dulu
            dgvTransaksi.Visible = false;
            dgvStok.Visible = false;
            dgvDenda.Visible = false;
            dgvKeuangan.Visible = false;

            // 3. Cek menu mana yang diklik, trus warnain ijo dan munculin tabelnya
            if (menu == "Transaksi")
            {
                btnLaporanTransaksi.BackColor = Color.ForestGreen; // Sesuaikan warna ijo tuamu
                btnLaporanTransaksi.ForeColor = Color.White;
                dgvTransaksi.Visible = true;
                dgvTransaksi.DataSource = lapCtrl.GetTransaksi(UserSession.UserId);
            }
            else if (menu == "Stok")
            {
                btnLaporanStok.BackColor = Color.ForestGreen;
                btnLaporanStok.ForeColor = Color.White;
                dgvStok.Visible = true;
                dgvStok.DataSource = lapCtrl.GetStok();
            }
            else if (menu == "Denda")
            {
                btnLaporanDenda.BackColor = Color.ForestGreen;
                btnLaporanDenda.ForeColor = Color.White;
                dgvDenda.Visible = true;
                dgvDenda.DataSource = lapCtrl.GetDenda();
            }
            else if (menu == "Keuangan")
            {
                btnLaporanKeuangan.BackColor = Color.ForestGreen;
                btnLaporanKeuangan.ForeColor = Color.White;
                dgvKeuangan.Visible = true;
                dgvKeuangan.DataSource = lapCtrl.GetKeuangan();
            }
        }

        // === EVENT KLIK TOMBOL ===
        private void btnLaporanTransaksi_Click(object sender, EventArgs e) => PilihMenuLaporan("Transaksi");
        private void btnLaporanStok_Click(object sender, EventArgs e) => PilihMenuLaporan("Stok");
        private void btnLaporanDenda_Click(object sender, EventArgs e) => PilihMenuLaporan("Denda");
        private void btnLaporanKeuangan_Click(object sender, EventArgs e) => PilihMenuLaporan("Keuangan");

        // === EVENT KLIK LUNASI DENDA ===
        private void dgvDenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Ambil ID Denda dari baris yang di-klik dua kali
                int idDenda = Convert.ToInt32(dgvDenda.Rows[e.RowIndex].Cells["denda_id"].Value);
                string status = dgvDenda.Rows[e.RowIndex].Cells["status_pembayaran"].Value.ToString();

                if (status != "Lunas")
                {
                    DialogResult dialogResult = MessageBox.Show("Petani ini udah bayar denda?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        lapCtrl.LunasiDenda(idDenda);
                        MessageBox.Show("Denda berhasil dilunasi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PilihMenuLaporan("Denda"); // Refresh tabel denda
                    }
                }
                else
                {
                    MessageBox.Show("Denda ini udah Lunas kok!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
