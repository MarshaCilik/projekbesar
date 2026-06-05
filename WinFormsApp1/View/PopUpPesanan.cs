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
        public int stok;

        public PopUpPesanan()
        {
            InitializeComponent();

        }

        public PopUpPesanan(barangTani barangtani) : this()
        {
            barangTani = barangtani;

        }

        public void LoadOpsiPengiriman()
        {

        }

        private void Btn_Tambah_Click(object sender, EventArgs e)
        {

        }
    }
}
