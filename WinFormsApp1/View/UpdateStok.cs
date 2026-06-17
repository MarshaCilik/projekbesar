using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinFormsApp1.View
{
    public partial class UpdateStok : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NamaBarang
        {
            get => txtNamaBarang.Text;
            set => txtNamaBarang.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int StokBaru
        {
            get => int.TryParse(txtStok.Text, out int result) ? result : 0;
            set => txtStok.Text = value.ToString();
        }

        public UpdateStok(string namaBarang, int stok)
        {
            InitializeComponent();
            NamaBarang = namaBarang;
            StokBaru = stok;
            txtNamaBarang.ReadOnly = true;

            btnSimpan2.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            btnBatal2.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
        }
    }
}
