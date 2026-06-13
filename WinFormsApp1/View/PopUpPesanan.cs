using Microsoft.VisualBasic.ApplicationServices;
using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;
using WinFormsApp1.Models;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.View
{
    public partial class PopUpPesanan : Form
    {
        private Users User;
        private barangTani Barang;
        c_pesanan controller = new c_pesanan();

        // Constructor Default bawaan WinForms Designer
        public PopUpPesanan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        // Constructor utama yang dipanggil dari Dashboard saat memilih Barang Tani
        public PopUpPesanan(Users user, barangTani barangtani) : this()
        {
            this.User = user;
            this.Barang = barangtani;

            // Tampilkan nama barang di label form agar informatif
            lbl_formbarang.Text = $"{Barang.nama_barang}";

            // Jalankan pengecekan visibilitas opsi pengiriman seperti pada alat sewa
            AturTampilanOpsiPengiriman();
        }

        private void AturTampilanOpsiPengiriman()
        {
            // Cek ke database lewat controller apakah user ini sudah punya pesanan 'Belum Checkout'
            bool pesananSudahAda = controller.CekPesananApakahAda(User);

            if (pesananSudahAda)
            {
                // Jika keranjang sudah ada, sembunyikan label dan combobox pengiriman
                Lbl_OpsiPengiriman.Visible = false; // Pastikan nama label pengiriman di UI kamu sesuai
                cmbPengiriman.Visible = false;
            }
            else
            {
                // Jika keranjang baru, tampilkan opsi pengirimannya
                Lbl_OpsiPengiriman.Visible = true;
                cmbPengiriman.Visible = true;
            }
        }

        private void Btn_Tambah_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input: Pastikan jumlah stok/kuantitas tidak kosong
            if (string.IsNullOrWhiteSpace(TbStok.Text))
            {
                MessageBox.Show("Data kuantitas harus terisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Proteksi Konversi: Pastikan input teks di TbStok benar-benar berupa angka valid (menghindari FormatException 'na')
            if (!int.TryParse(TbStok.Text, out int quantity))
            {
                MessageBox.Show("Jumlah barang harus berupa angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Konfirmasi Penyimpanan Data ke User
            DialogResult dr = MessageBox.Show(
                $"Apakah Anda ingin menambahkan {Barang.nama_barang} sebanyak {quantity} ke keranjang?",
                "Konfirmasi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                // Ambil string teks dari ComboBox pengiriman. Jika tersembunyi/tidak dipilih, set default ke "Diambil Sendiri"
                string opsiPengiriman = cmbPengiriman.SelectedItem?.ToString() ?? "Diambil Sendiri";

                try
                {
                    // 4. Eksekusi Stored Procedure baru yang sudah diperbaiki melalui controller
                    controller.CreatePesananBarang(User, Barang, quantity, opsiPengiriman);

                    // Beritahu user bahwa proses berhasil dan tutup form dengan status OK
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat menyimpan pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
