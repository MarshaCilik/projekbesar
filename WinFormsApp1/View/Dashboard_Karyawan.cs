using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Models;
using WinFormsApp1.Controller;

namespace WinFormsApp1.View
{
    public partial class Dashboard_Karyawan : Form
    {
        private DashboardController dashCtrl = new DashboardController();
        private int idTransaksiDipilih = 0; // Nyimpen ID dari baris tabel yang diklik

        public Dashboard_Karyawan()
        {
            InitializeComponent();
        }

        // Kodingan yang jalan pertama kali pas halaman dashboard dibuka
        private void UcDashboard_Load(object sender, EventArgs e)
        {
            RefreshData();
        }

        // Fungsi buat narik data terbaru dari database
        private void RefreshData()
        {
            // Ambil ID Karyawan yang lagi login dari session
            int currentUserId = UserSession.UserId;

            // Tampilin nama karyawan yang lagi login (typo 's' udah ilang)
            txtNamaKaryawan.Text = UserSession.Username;

            // Set DateTimePicker ke hari ini
            dtpTanggal.Value = DateTime.Now;
            dtpTanggal.Enabled = false;

            // Tarik angka dari database (MASUKIN currentUserId KE DALAM KURUNG)
            txtJumlahTransaksi.Text = dashCtrl.GetTotalTransaksiHariIni(currentUserId).ToString();
            txtPesananDiantar.Text = dashCtrl.GetPesananButuhDiantar(currentUserId).ToString();

            // Masukin data ke tabel (MASUKIN currentUserId JUGA)
            dgvTransaksi.DataSource = dashCtrl.GetDetailTransaksiLengkap(currentUserId);

            idTransaksiDipilih = 0; // Reset ID tiap kali refresh
        }

        // Nangkep ID transaksi pas baris di tabel diklik
        private void dgvTransaksi_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvTransaksi.Rows[e.RowIndex];
                idTransaksiDipilih = Convert.ToInt32(row.Cells["transaksi_id"].Value);
            }
        }

        // Tombol: Ubah status Pembayaran
        private void btnUbahStatusPembayaran_Click(object sender, EventArgs e)
        {
            if (idTransaksiDipilih != 0)
            {
                dashCtrl.UpdateJadiLunas(idTransaksiDipilih);
                MessageBox.Show("Status pembayaran berhasil diubah jadi Lunas!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshData(); // Refresh layar biar tabelnya update
            }
            else
            {
                MessageBox.Show("Pilih datanya dulu di tabel, ya!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Tombol: Ubah status transaksi
        private void btnUbahStatusTransaksi_Click(object sender, EventArgs e)
        {
            if (idTransaksiDipilih != 0)
            {
                try
                {
                    dashCtrl.SelesaikanTransaksiAmbilSendiri(idTransaksiDipilih);
                    MessageBox.Show("Transaksi selesai karena barang diambil sendiri!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshData();
                }
                catch (Exception ex)
                {
                    // Kalau transaksinya belum lunas atau bukan ambil sendiri, error-nya dari controller bakal muncul di sini
                    MessageBox.Show(ex.Message, "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Pilih datanya dulu di tabel, ya!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
