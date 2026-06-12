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

namespace WinFormsApp1.View
{
    public partial class PopUpPesanan : Form
    {
        public barangTani barangTani;
        public AlatTani alat_tani;
        public int stok;

        public PopUpPesanan()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public PopUpPesanan(barangTani barangtani) : this()
        {
            barangTani = barangtani;
            lbl_formbarang.Text = $"{barangTani.nama_barang}";

        }

        private void Btn_Tambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbStok.Text) ||
                string.IsNullOrWhiteSpace(cmbPengiriman.Text)
                )
            {
                MessageBox.Show("Data harus diisi!", "Peringatan!", MessageBoxButtons.OK);
                return;
            }
            if (!int.TryParse(TbStok.Text, out int umur))
            {
                MessageBox.Show("Umur harus berupa angka!");
                TbStok.Focus();
                return;
            }

            DialogResult dr = MessageBox.Show(
            "Apakah Anda ingin menyimpan data ini?",
            "Informasi",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);


            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
