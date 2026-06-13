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
using WinFormsApp1.Models.Context;
using WinFormsApp1.Models.User;

namespace WinFormsApp1.View.Kerjaan_Tiwi
{
    public partial class PopUpPesananAlat : Form
    {
        private Users User;
        c_pesanan controller = new c_pesanan();
        private AlatTani Alat;
        public PopUpPesananAlat()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public PopUpPesananAlat(Users user, AlatTani alat) : this()
        {
            User = user;
            Alat = alat;

            AturTampilanOpsiPengiriman();
        }

        private void AturTampilanOpsiPengiriman()
        {
            bool pesananSudahAda = controller.CekPesananApakahAda(User);

            if (pesananSudahAda)
            {
                Lbl_OpsiPengiriman.Visible = false;
                cmbPengiriman.Visible = false;
            }
            else
            {
                Lbl_OpsiPengiriman.Visible = true;
                Lbl_OpsiPengiriman.Visible = true;
            }
        }

        private void Btn_Tambah_Click(object sender, EventArgs e) //LANJUT DI SINI MAR
        {
            if (string.IsNullOrWhiteSpace(TbStok.Text))
            {
                MessageBox.Show("Data harus terisi!", "Peringatan", MessageBoxButtons.OK);
                return;
            }
            else if (Dtp_TanggalSewa.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Tanggal pengembalian tidak boleh kurang dari tanggal hari ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                DateOnly tanggalPilihan = DateOnly.FromDateTime(Dtp_TanggalSewa.Value);
                string opsiPengiriman = cmbPengiriman.SelectedItem?.ToString() ?? "Diambil Sendiri";
                controller.CreatePesananAlatSewa(User, Alat, opsiPengiriman, Convert.ToInt32(TbStok.Text), tanggalPilihan);
            }
        }

        
    }
}
