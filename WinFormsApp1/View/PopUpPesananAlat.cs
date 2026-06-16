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
        private bool alatSudahAdaDiPesanan = false;

        public PopUpPesananAlat()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        public PopUpPesananAlat(Users user, AlatTani alat) : this()
        {
            User = user;
            Alat = alat;

            Lbl_FormAlat.Text = $"Form Alat {alat.Nama}";

            AturTampilanBerdasarkanPesanan();
        }

        private void AturTampilanBerdasarkanPesanan()
        {
            bool pesananSudahAda = controller.CekPesananApakahAda(User);

            // 1. Sembunyikan opsi pengiriman jika pesanan sudah ada
            if (pesananSudahAda)
            {
                Lbl_OpsiPengiriman.Visible = false;
                cmbPengiriman.Visible = false;
            }
            else
            {
                Lbl_OpsiPengiriman.Visible = true;
                cmbPengiriman.Visible = true;
            }

            // 2. Sembunyikan opsi pengembalian jika sudah ada di pesanan (satu pesanan satu opsi pengembalian)
            bool opsiPengembalianSudahAda = pesananSudahAda && controller.CekOpsiPengembalianSudahAda(User);
            if (opsiPengembalianSudahAda)
            {
                label2.Visible = false;
                Cbx_OpsiPengembalian.Visible = false;
            }

            // 3. Cek apakah alat ini sudah ada di pesanan yang belum checkout
            alatSudahAdaDiPesanan = pesananSudahAda && controller.CekAlatSudahAdaDiPesanan(User, Alat.Id);

            if (alatSudahAdaDiPesanan)
            {
                // Set Dtp_TanggalSewa ke tanggal pengembalian yang sudah ada
                DateOnly? tanggalExisting = controller.GetTanggalPengembalianAlat(User, Alat.Id);
                if (tanggalExisting.HasValue)
                {
                    Dtp_TanggalSewa.Value = tanggalExisting.Value.ToDateTime(TimeOnly.MinValue);
                }
            }
        }

        private void Btn_Tambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TbStok.Text))
            {
                MessageBox.Show("Data harus terisi!", "Peringatan", MessageBoxButtons.OK);
                return;
            }

            if (!int.TryParse(TbStok.Text, out int quantity) || quantity <= 0)
            {
                MessageBox.Show("Jumlah harus berupa angka yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (Dtp_TanggalSewa.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Tanggal pengembalian tidak boleh kurang dari tanggal hari ini!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateOnly tanggalPilihan = DateOnly.FromDateTime(Dtp_TanggalSewa.Value);

            if (alatSudahAdaDiPesanan)
            {
                // Alat sudah ada di pesanan: tambah quantity & update tanggal jika berbeda
                controller.TambahQuantityAlatDanUpdateTanggal(User, Alat.Id, quantity, tanggalPilihan);

                MessageBox.Show($"Berhasil menambahkan {quantity} {Alat.Nama} ke pesanan yang sudah ada!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Alat belum ada di pesanan: buat pesanan baru atau tambah ke pesanan yang ada
                string opsiPengiriman = cmbPengiriman.SelectedItem?.ToString() ?? "Diambil Sendiri";
                string opsiPengembalian = Cbx_OpsiPengembalian.Visible
                    ? (Cbx_OpsiPengembalian.SelectedItem?.ToString() ?? "Antar sendiri")
                    : string.Empty;

                if (!string.IsNullOrEmpty(opsiPengembalian))
                {
                    controller.CreatePesananAlatSewa(User, Alat, opsiPengiriman, quantity, tanggalPilihan, opsiPengembalian);
                }
                else
                {
                    // Opsi pengembalian sudah di-set sebelumnya, lewatkan parameter opsi
                    controller.CreatePesananAlatSewa(User, Alat, opsiPengiriman, quantity, tanggalPilihan, string.Empty);
                }

                MessageBox.Show($"Berhasil menambahkan {quantity} {Alat.Nama} ke pesanan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
