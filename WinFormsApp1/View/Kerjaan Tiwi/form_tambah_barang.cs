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

        private void btn_selesai_barang_Click(object sender, EventArgs e)
        {
            // Ngecek biar nggak ada isian yang dibiarin kosong
            if (string.IsNullOrWhiteSpace(Tb_Nama_Barang.Text) || string.IsNullOrWhiteSpace(Tb_Harga.Text) || string.IsNullOrWhiteSpace(Tb_Stok.Text))
            {
                MessageBox.Show("Jangan ada yang kosong ya isiannya!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Langsung manggil koneksi dari helper buatan kelompokmu (udah otomatis kebuka koneksinya)
                using (NpgsqlConnection conn = Helpers.connectDB.GetConnection())
                {
                    // Query buat nyimpen data ke tabel barang
                    string query = "INSERT INTO barang (nama_barang, harga_per_item, stok) VALUES (@nama, @harga, @stok)";

                    using (NpgsqlCommand cmd = new NpgsqlCommand(query, conn))
                    {
                        // Narik data dari textbox punya kamu
                        cmd.Parameters.AddWithValue("nama", Tb_Nama_Barang.Text);
                        cmd.Parameters.AddWithValue("harga", int.Parse(Tb_Harga.Text));
                        cmd.Parameters.AddWithValue("stok", int.Parse(Tb_Stok.Text));

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Data barang berhasil disimpan!", "Berhasil", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Nutup pop-up otomatis kalau udah sukses
                this.Close();
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