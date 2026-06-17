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
        private bool barangSudahAdaDiPesanan = false;

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

            // Jalankan pengecekan visibilitas dan status duplikasi
            AturTampilanBerdasarkanPesanan();
        }

        private void AturTampilanBerdasarkanPesanan()
        {
            // Cek ke database lewat controller apakah user ini sudah punya pesanan 'Belum Checkout'
            bool pesananSudahAda = controller.CekPesananApakahAda(User);

            if (pesananSudahAda)
            {
                // Jika keranjang sudah ada, sembunyikan label dan combobox pengiriman
                Lbl_OpsiPengiriman.Visible = false;
                cmbPengiriman.Visible = false;
                Lbl_MetodePembayaran.Visible = false;
                Cbx_MetodePembayaran.Visible = false;
            }
            else
            {
                // Jika keranjang baru, tampilkan opsi pengirimannya
                Lbl_OpsiPengiriman.Visible = true;
                cmbPengiriman.Visible = true;
                Lbl_MetodePembayaran.Visible = true;
                Cbx_MetodePembayaran.Visible = true;
            }

            // Cek apakah barang ini sudah ada di pesanan yang belum checkout
            barangSudahAdaDiPesanan = pesananSudahAda && controller.CekBarangSudahAdaDiPesanan(User, Barang.Id);
        }

        private void Btn_Tambah_Click(object sender, EventArgs e)
        {
            // 1. Validasi Input: Pastikan jumlah stok/kuantitas tidak kosong
            if (string.IsNullOrWhiteSpace(TbStok.Text))
            {
                MessageBox.Show("Data kuantitas harus terisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Proteksi Konversi: Pastikan input teks di TbStok benar-benar berupa angka valid
            if (!int.TryParse(TbStok.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Jumlah barang harus berupa angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (quantity > Barang.stok)
            {
                MessageBox.Show($"Stok tidak mencukupi! Stok yang tersedia hanya {Barang.stok}.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (barangSudahAdaDiPesanan)
            {
                // Barang sudah ada di pesanan: tambah quantity saja
                controller.TambahQuantityBarang(User, Barang.Id, quantity);

                MessageBox.Show($"Berhasil menambahkan {quantity} {Barang.nama_barang} ke pesanan yang sudah ada!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Barang belum ada: buat entry baru
                string opsiPengiriman = cmbPengiriman.SelectedItem?.ToString() ?? "Diambil Sendiri";
                string metodePembayaran = Cbx_MetodePembayaran.SelectedItem?.ToString() ?? "Tunai";

                try
                {
                    controller.CreatePesananBarang(User, Barang, quantity, opsiPengiriman, metodePembayaran);

                    MessageBox.Show($"Berhasil menambahkan {quantity} {Barang.nama_barang} ke pesanan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
