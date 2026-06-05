using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Models;
using WinFormsApp1.View;

namespace WinFormsApp1
{
    public partial class LihatProdukTani : Form
    {
        c_barangtani controller = new c_barangtani();

        private List<barangTani> listbarangtani;
        public LihatProdukTani()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            Dgv_BarangTani.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            LoadData();
        }

        public void LoadData()
        {
            listbarangtani = controller.ReadBarangTani();

            Dgv_BarangTani.DataSource = null;
            Dgv_BarangTani.DataSource = listbarangtani;
        }

        private void Btn_TambahPesanan_Click(object sender, EventArgs e)
        {
            if (Dgv_BarangTani != null)
            {
                barangTani selectedbarang = (barangTani)Dgv_BarangTani.CurrentRow.DataBoundItem;
                PopUpPesanan form = new PopUpPesanan(selectedbarang);

                form.Show();

            }
        }
    }
}
