using System;
using System.Windows.Forms;
using Npgsql;

namespace WinFormsApp1.View
{
    public partial class form_tambah_barang : Form
    {
        public form_tambah_barang()
        {
            InitializeComponent();
        }

        private Controller.c_admin controller = new Controller.c_admin();

        private void btn_selesai_barang_Click(object sender, EventArgs e)
        {
            try
            {
                int harga = int.Parse(Tb_Harga.Text);
                int stok = int.Parse(Tb_Stok.Text);

                Models.barangTani barang = new Models.barangTani(0, Tb_Nama_Barang.Text, stok, harga, Tb_Kategori.Text);
                string result = controller.CreateBarangTani(barang);

                if (result.Contains("berhasil"))
                {
                    MessageBox.Show(result, "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result, "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Harga dan Stok harus berupa angka!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal tersimpan: " + ex.Message, "Error Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_batal_barang_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}