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
    public partial class Form_Edit_barang : Form
    {
        private c_barangtani controller = new c_barangtani();
        private barangTani barangTerpilih;
        private TextBox Tb_Kategori;
        private Label labelKategori;

        public Form_Edit_barang(barangTani barang)
        {
            InitializeComponent();
            this.barangTerpilih = barang;

            TambahInputKategori();
            RegisterEvents();

            this.Text = "Edit Barang";
            label2.Text = "EDIT BARANG";

            // Mengisi data lama ke form
            Tb_Nama_Barang.Text = barang.nama_barang;
            Tb_Harga.Text = barang.harga.ToString("0.##");
            Tb_Kategori.Text = barang.kategori;
            Tb_Stok.Text = barang.stok.ToString();
        }

        private void TambahInputKategori()
        {
            labelKategori = new Label();
            labelKategori.Text = "Kategori:";
            labelKategori.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelKategori.ForeColor = Color.Black;
            labelKategori.Location = new Point(57, 275);
            labelKategori.Size = new Size(100, 15);

            Tb_Kategori = new TextBox();
            Tb_Kategori.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kategori.ForeColor = Color.White;
            Tb_Kategori.Font = new Font("Segoe UI", 11F);
            Tb_Kategori.Location = new Point(57, 292);
            Tb_Kategori.Size = new Size(374, 27);
            Tb_Kategori.TabIndex = 2;

            this.Controls.Add(labelKategori);
            this.Controls.Add(Tb_Kategori);

            // Menyesuaikan posisi Stok di Form_Edit_barang
            if (this.Controls.ContainsKey("label4"))
            {
                this.Controls["label4"].Location = new Point(218, 325);
            }
            if (this.Controls.ContainsKey("Tb_Stok"))
            {
                this.Controls["Tb_Stok"].Location = new Point(204, 345);
            }
        }

        private void RegisterEvents()
        {
            
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = Tb_Nama_Barang.Text.Trim();
                string kategori = Tb_Kategori.Text.Trim();

                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kategori))
                {
                    MessageBox.Show("Nama barang dan Kategori wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(Tb_Harga.Text, out decimal harga) || harga < 0)
                {
                    MessageBox.Show("Harga harus berupa angka desimal positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(Tb_Stok.Text, out int stok) || stok < 0)
                {
                    MessageBox.Show("Stok harus berupa angka bulat positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buat objek barangTani dengan ID lama
                barangTani barang = new barangTani(barangTerpilih.Id, nama, stok, harga, kategori);
                string hasil = controller.UpdateBarangTani(barang);

                MessageBox.Show(hasil, "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (hasil.Contains("berhasil"))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btn_Batal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
