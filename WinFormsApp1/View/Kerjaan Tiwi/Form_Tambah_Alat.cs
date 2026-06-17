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
    public partial class Form_Tambah_Alat : Form
    {
        private c_barangtani controller = new c_barangtani();

        public Form_Tambah_Alat()
        {
            InitializeComponent();
        }

        private void btn_selesai_alat_Click(object sender, EventArgs e)
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

                // Membuat objek AlatTani (Id diset 0 karena akan auto-increment di database)
                AlatTani alat = new AlatTani(0, nama, stok, hargaSewa, hargaDenda, kategori);
                
                // Memanggil method di controller
                string hasil = controller.AddAlatTani(alat);

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

        private void btn_batal_alat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
