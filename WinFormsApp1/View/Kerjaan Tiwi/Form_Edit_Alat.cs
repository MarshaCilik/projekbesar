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
    public partial class Form_Edit_Alat : Form
    {
        private c_barangtani controller = new c_barangtani();
        private AlatTani alatTerpilih;
        private TextBox Tb_Kategori;
        private Label labelKategori;

        public Form_Edit_Alat(AlatTani alat)
        {
            InitializeComponent();
            this.alatTerpilih = alat;
            
            TambahInputKategori();
            RegisterEvents();
            
            this.Text = "Edit Alat Sewa";
            label2.Text = "EDIT ALAT";

            // Mengisi data lama ke form
            Tb_Nama_Alat.Text = alat.Nama;
            Tb_Harga.Text = alat.Harga_sewa_perhari.ToString("0.##");
            Tb_Denda_Perhari.Text = alat.Harga_denda_perhari.ToString("0.##");
            Tb_Kategori.Text = alat.Kategori;
            Tb_Stok.Text = alat.Stok.ToString();
        }

        private void TambahInputKategori()
        {
            labelKategori = new Label();
            labelKategori.Text = "Kategori:";
            labelKategori.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelKategori.ForeColor = Color.Black;
            labelKategori.Location = new Point(62, 305);
            labelKategori.Size = new Size(100, 15);

            Tb_Kategori = new TextBox();
            Tb_Kategori.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kategori.ForeColor = Color.White;
            Tb_Kategori.Font = new Font("Segoe UI", 11F);
            Tb_Kategori.Location = new Point(62, 322);
            Tb_Kategori.Size = new Size(374, 27);
            Tb_Kategori.TabIndex = 3;

            this.Controls.Add(labelKategori);
            this.Controls.Add(Tb_Kategori);

            // Sesuaikan posisi komponen Stok di Form_Edit_Alat
            if (this.Controls.ContainsKey("label4"))
            {
                this.Controls["label4"].Location = new Point(222, 355);
            }
            if (this.Controls.ContainsKey("Tb_Stok"))
            {
                this.Controls["Tb_Stok"].Location = new Point(208, 375);
                this.Controls["Tb_Stok"].Size = new Size(67, 30);
            }
        }

        private void RegisterEvents()
        {
            btn_selesai_editAlat.Click += Btn_Simpan_Click;
            btn_batal_editAlat.Click += Btn_Batal_Click;
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            try
            {
                string nama = Tb_Nama_Alat.Text.Trim();
                string kategori = Tb_Kategori.Text.Trim();

                if (string.IsNullOrEmpty(nama) || string.IsNullOrEmpty(kategori))
                {
                    MessageBox.Show("Nama alat sewa dan Kategori wajib diisi!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(Tb_Harga.Text, out decimal hargaSewa) || hargaSewa < 0)
                {
                    MessageBox.Show("Harga sewa perhari harus berupa angka desimal positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!decimal.TryParse(Tb_Denda_Perhari.Text, out decimal hargaDenda) || hargaDenda < 0)
                {
                    MessageBox.Show("Harga denda perhari harus berupa angka desimal positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(Tb_Stok.Text, out int stok) || stok < 0)
                {
                    MessageBox.Show("Stok harus berupa angka bulat positif!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Buat objek AlatTani baru dengan ID lama
                AlatTani alat = new AlatTani(alatTerpilih.Id, nama, stok, hargaSewa, hargaDenda, kategori);
                string hasil = controller.UpdateAlatTani(alat);

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
