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
    public partial class form_tambah_barang : Form
    {
        private c_barangtani controller = new c_barangtani();
        private TextBox Tb_Kategori;
        private Label labelKategori;

        public form_tambah_barang()
        {
            InitializeComponent();
            TambahInputKategori();
            RegisterEvents();
            this.Text = "Tambah Barang";
            label2.Text = "TAMBAH BARANG";
        }

        private void TambahInputKategori()
        {
            labelKategori = new Label();
            labelKategori.Text = "Kategori:";
            labelKategori.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelKategori.ForeColor = Color.Black;
            labelKategori.Location = new Point(62, 290);
            labelKategori.Size = new Size(100, 15);

            Tb_Kategori = new TextBox();
            Tb_Kategori.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kategori.ForeColor = Color.White;
            Tb_Kategori.Font = new Font("Segoe UI", 11F);
            Tb_Kategori.Location = new Point(62, 310);
            Tb_Kategori.Size = new Size(374, 27);
            Tb_Kategori.TabIndex = 2; // after Tb_Harga

            this.Controls.Add(labelKategori);
            this.Controls.Add(Tb_Kategori);

            // Menyesuaikan posisi komponen Stok agar tidak tumpang tindih
            if (this.Controls.ContainsKey("label4"))
            {
                this.Controls["label4"].Location = new Point(220, 345);
            }
            if (this.Controls.ContainsKey("Tb_Stok"))
            {
                this.Controls["Tb_Stok"].Location = new Point(209, 365);
                this.Controls["Tb_Stok"].Size = new Size(67, 30);
            }
        }

        private void RegisterEvents()
        {
            panel5.Click += Btn_Simpan_Click;
            label5.Click += Btn_Simpan_Click;
            panel6.Click += Btn_Batal_Click;
            label6.Click += Btn_Batal_Click;
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

                // Buat objek barangTani baru (ID = 0 untuk insert)
                barangTani barang = new barangTani(0, nama, stok, harga, kategori);
                string hasil = controller.AddBarangTani(barang);

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
