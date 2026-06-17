using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using WinFormsApp1.Models;

namespace WinFormsApp1.View.Dashboard_Admin
{
    public partial class EditDataKurir : Form
    {
        public Kurir KurirData { get; private set; }

        public EditDataKurir()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public EditDataKurir(Kurir kurir) : this()
        {
            KurirData = kurir;
            if (kurir != null)
            {
                Tb_Nama.Text = kurir.Nama;
                Tb_NoTelp.Text = kurir.Nomor_Telepon;
                Tb_Alamat.Text = kurir.Alamat;
            }
        }

        private void Btn_Simpan_Click(object sender, EventArgs e)
        {
            if (KurirData == null)
            {
                KurirData = new Kurir(0, Tb_Nama.Text, Tb_NoTelp.Text, Tb_Alamat.Text);
            }
            else
            {
                KurirData.Nama = Tb_Nama.Text;
                KurirData.Nomor_Telepon = Tb_NoTelp.Text;
                KurirData.Alamat = Tb_Alamat.Text;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Btn_Batal_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
