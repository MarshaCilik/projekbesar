using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using WinFormsApp1.Controller;
using WinFormsApp1.Helpers;

namespace WinFormsApp1.View
{
    public partial class Dashboard_Karyawan : Form
    {
        private KaryawanController db = new KaryawanController();
        private ProfilController profCtrl = new ProfilController();

        // Update Stok Tab States
        private string stokMode = "barang"; // "barang" or "alat"
        private int selectedStokId = -1;

        public Dashboard_Karyawan()
        {
            InitializeComponent();
            WireEvents();
        }


        private void WireEvents()
        {
            btnKirim.Click += btnKirim_Click;

            this.Load += Dashboard_Karyawan_Load;

            // Sidebar Navigation
            btnDashboardKaryawan.Click += (s, e) => NavigateToTab(0, btnDashboardKaryawan); // Dashboard
            btnUpdateStok.Click += (s, e) => NavigateToTab(1, btnUpdateStok); // Update Stok
            btnDistribusi.Click += (s, e) => NavigateToTab(2, btnDistribusi); // Manajemen Distribusi
            btnLaporan.Click += (s, e) => NavigateToTab(3, btnLaporan); // Laporan dan Rekap
            btnProfil.Click += (s, e) => NavigateToTab(4, btnProfil); // Profil

            // Logout Picture
            Logout.Click += pictureBox7_Click;
            Logout.Cursor = Cursors.Hand;

            // Dashboard Aksi Labels
            if (label18 != null)
            {
                label18.Click += labelStatusPembayaran_Click;
                label18.Cursor = Cursors.Hand;
                label18.MouseEnter += (s, e) => label18.ForeColor = Color.ForestGreen;
                label18.MouseLeave += (s, e) => label18.ForeColor = Color.White;
            }

            if (label17 != null)
            {
                label17.Click += labelStatusTransaksi_Click;
                label17.Cursor = Cursors.Hand;
                label17.MouseEnter += (s, e) => label17.ForeColor = Color.ForestGreen;
                label17.MouseLeave += (s, e) => label17.ForeColor = Color.White;
            }

            btnRefresh1.Click += (s, e) => LoadDashboardData();

            // Update Stok Tab Events
            btnProduk1.Click += btnStokProduk_Click;
            btnAlatSewa2.Click += btnStokAlat_Click;
            dgvUpdateStok.CellDoubleClick += dgvStok_CellDoubleClick;
            btnUpdate.Click += btnUpdateStokAction_Click;
            txtCariNamaBarang2.KeyDown += txtCariNamaBarang2_KeyDown;
            btnRefresh2.Click += btnRefresh2_Click;

            // Manajemen Distribusi Search & Grid Events
            txtCariID3.TextChanged += txtSearchDistribusi_TextChanged;
            btnRefresh3.Click += (s, e) => { txtCariID3.Text = ""; LoadDistribusiData(); };
            dgvDistribusi.CellDoubleClick += dgvDistribusi_CellDoubleClick;

            // Laporan & Rekap Tab Events
            btnLaporanTransaksi.Click += (s, e) => PilihMenuLaporan("Transaksi");
            btnLaporanStok.Click += (s, e) => PilihMenuLaporan("Stok");
            btnLaporanDenda.Click += (s, e) => PilihMenuLaporan("Denda");

            // Laporan Transaksi Events
            btn_Filter41.Click += btnLaporanTransaksiFilter_Click;
            btn_Refresh41.Click += btnLaporanTransaksiRefresh_Click;
            txt_CariID41.KeyDown += txtLaporanTransaksiCari_KeyDown;

            // Laporan Stok Events
            btnProduk42.Click += (s, e) => LoadLaporanStok("produk");
            btnAlat42.Click += (s, e) => LoadLaporanStok("alat");
            btnAlat42.Click += (s, e) => LoadLaporanStok("alat");

            // Laporan Denda Events
            txtCariNamaDenda.TextChanged += txtCariDenda_TextChanged;
            btnLunas.Click += btnDendaLunas_Click;
            dgvDenda.CellDoubleClick += dgvDenda_CellDoubleClick;

            // Profil Tab Events
            btnEdit.Click += btnProfilEdit_Click;
            btnSimpan.Click += btnProfilSimpan_Click;
            btnBatal.Click += btnProfilBatal_Click;
        }

        private void Dashboard_Karyawan_Load(object sender, EventArgs e)
        {
            // Hide Tab Control headers
            tabControl1.Appearance = TabAppearance.FlatButtons;
            tabControl1.ItemSize = new Size(0, 1);
            tabControl1.SizeMode = TabSizeMode.Fixed;

            // Load default dashboard settings
            txtNamaKaryawan1.Text = UserSession.Username;
            dtpDashboard.Value = DateTime.Now;

            // Setup DataGridViews style settings
            ConfigureDgvStyle(dgvDashboard);
            ConfigureDgvStyle(dgvUpdateStok);
            ConfigureDgvStyle(dgvDistribusi);
            ConfigureDgvStyle(dgvTransaksi);
            ConfigureDgvStyle(dgvStok);
            ConfigureDgvStyle(dgvDenda);

            // Load initial view
            NavigateToTab(0, btnDashboardKaryawan);
        }

        private void ConfigureDgvStyle(DataGridView dgv)
        {
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.RowHeadersVisible = false;
        }

        private void NavigateToTab(int index, Button activeBtn)
        {
            tabControl1.SelectedIndex = index;
            SetActiveSidebarButton(activeBtn);

            if (index == 0)
            {
                LoadDashboardData();
            }
            else if (index == 1)
            {
                txtNamaKaryawan2.Text = UserSession.Username;
                SwitchStokView("barang");
            }
            else if (index == 2)
            {
                txtNamaKaryawan3.Text = UserSession.Username;
                LoadDistribusiData();
            }
            else if (index == 3)
            {
                txtNamaKaryawan4.Text = UserSession.Username;
                PilihMenuLaporan("Transaksi");
                tcLaporan.ItemSize = new Size(0, 1);
            }
            else if (index == 4)
            {
                LoadProfilData();
            }
        }

        private void SetActiveSidebarButton(Button activeBtn)
        {
            Button[] buttons = { btnDashboardKaryawan, btnUpdateStok, btnDistribusi, btnLaporan, btnProfil };
            foreach (var btn in buttons)
            {
                if (btn == activeBtn)
                {
                    btn.BackColor = Color.FromArgb(49, 106, 14);
                    btn.ForeColor = Color.White;
                }
                else
                {
                    btn.BackColor = Color.FromArgb(168, 197, 152);
                    btn.ForeColor = Color.FromArgb(49, 106, 14);
                }
            }
        }

        // =========================================================================
        // FEATURE 1: DASHBOARD
        // =========================================================================
        private void LoadDashboardData()
        {
            try
            {
                var stats = db.GetDashboardStats();
                txtJumlahTransaksi.Text = stats.TotalTransaksiDiproses.ToString();
                txtJumlahDiantar.Text = stats.TotalTransaksiDiantar.ToString();
                txtJumlahPesanan.Text = stats.TotalPesananMasuk.ToString();

                DataTable dt = db.GetDashboardTransaksi();
                DataView dv = dt.DefaultView;
                dv.RowFilter = "status_transaksi = 'Diproses'";
                dgvDashboard.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data dashboard: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelStatusPembayaran_Click(object sender, EventArgs e)
        {
            if (dgvDashboard.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih transaksi terlebih dahulu di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvDashboard.SelectedRows[0];
            int transaksiId = Convert.ToInt32(row.Cells["transaksi_id"].Value);
            string statusPembayaran = row.Cells["status_pembayaran"].Value.ToString();

            if (statusPembayaran.Equals("lunas", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Transaksi ini sudah lunas!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Ubah status pembayaran transaksi #{transaksiId} menjadi LUNAS?", "Konfirmasi Pembayaran", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.UpdatePaymentStatus(transaksiId, "lunas", UserSession.UserId);
                    MessageBox.Show("Status pembayaran berhasil diperbarui menjadi LUNAS!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal memperbarui status pembayaran: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void labelStatusTransaksi_Click(object sender, EventArgs e)
        {
            if (dgvDashboard.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih transaksi terlebih dahulu di tabel!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvDashboard.SelectedRows[0];
            int transaksiId = Convert.ToInt32(row.Cells["transaksi_id"].Value);
            string statusTransaksi = row.Cells["status_transaksi"].Value.ToString();
            string jenisPesanan = row.Cells["jenis_pesanan"].Value?.ToString() ?? "";

            if (jenisPesanan != "Penyewaan")
            {
                MessageBox.Show("Aksi ini hanya berlaku untuk penyewaan alat!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (statusTransaksi.Equals("Selesai", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Transaksi ini sudah selesai!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Validasi denda sebelum diselesaikan
            if (db.HasUnpaidDenda(transaksiId))
            {
                MessageBox.Show("Transaksi ini tidak dapat diselesaikan karena ada denda alat sewa yang belum dilunasi. Silakan lunasi denda di Laporan Denda terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show($"Ubah status transaksi #{transaksiId} menjadi Selesai?", "Konfirmasi Transaksi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.UpdateTransactionStatus(transaksiId, "Selesai", UserSession.UserId);
                    MessageBox.Show("Status transaksi berhasil diperbarui menjadi Selesai!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDashboardData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menyelesaikan transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // =========================================================================
        // FEATURE 2: UPDATE STOK
        // =========================================================================
        private void SwitchStokView(string mode)
        {
            stokMode = mode;

            if (mode == "barang")
            {
                btnProduk1.BackColor = Color.ForestGreen;
                btnProduk1.ForeColor = Color.White;
                btnAlatSewa2.BackColor = Color.WhiteSmoke;
                btnAlatSewa2.ForeColor = Color.Black;

                dgvUpdateStok.DataSource = db.GetStokBarang();
            }
            else
            {
                btnAlatSewa2.BackColor = Color.ForestGreen;
                btnAlatSewa2.ForeColor = Color.White;
                btnProduk1.BackColor = Color.WhiteSmoke;
                btnProduk1.ForeColor = Color.Black;

                dgvUpdateStok.DataSource = db.GetStokAlat();
            }
        }

        private void btnStokProduk_Click(object sender, EventArgs e) => SwitchStokView("barang");
        private void btnStokAlat_Click(object sender, EventArgs e) => SwitchStokView("alat");

        private void dgvStok_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvUpdateStok.Rows[e.RowIndex];
            selectedStokId = Convert.ToInt32(row.Cells["id"].Value);
            string nama = row.Cells["nama"].Value.ToString();
            int stok = Convert.ToInt32(row.Cells["stok"].Value);

            ShowUpdateStokPopup(nama, stok);
        }

        private void ShowUpdateStokPopup(string namaBarang, int currentStok)
        {
            using (UpdateStok popup = new UpdateStok(namaBarang, currentStok))
            {
                popup.StartPosition = FormStartPosition.CenterParent;
                if (popup.ShowDialog() == DialogResult.OK)
                {
                    int newStok = popup.StokBaru;
                    if (newStok >= 0)
                    {
                        try
                        {
                            db.UpdateStok(selectedStokId, newStok, stokMode, UserSession.UserId);
                            MessageBox.Show("Stok berhasil diperbarui!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            SwitchStokView(stokMode);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal menyimpan perubahan stok: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Jumlah stok harus berupa angka positif!", "Validasi Gagal", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnUpdateStokAction_Click(object sender, EventArgs e)
        {
            if (dgvUpdateStok.SelectedRows.Count == 0)
            {
                MessageBox.Show("Silakan pilih barang atau alat sewa terlebih dahulu!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvUpdateStok.SelectedRows[0];
            selectedStokId = Convert.ToInt32(row.Cells["id"].Value);
            string nama = row.Cells["nama"].Value.ToString();
            int stok = Convert.ToInt32(row.Cells["stok"].Value);

            ShowUpdateStokPopup(nama, stok);
        }

        private void txtCariNamaBarang2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Prevent ding sound
                string keyword = txtCariNamaBarang2.Text.Trim();
                try
                {
                    DataTable dt = stokMode == "barang" ? db.GetStokBarang() : db.GetStokAlat();
                    if (string.IsNullOrEmpty(keyword))
                    {
                        dgvUpdateStok.DataSource = dt;
                        return;
                    }

                    DataView dv = dt.DefaultView;
                    dv.RowFilter = string.Format("nama LIKE '%{0}%'", keyword.Replace("'", "''"));
                    dgvUpdateStok.DataSource = dv.ToTable();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan saat mencari: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRefresh2_Click(object sender, EventArgs e)
        {
            txtCariNamaBarang2.Text = "";
            SwitchStokView(stokMode);
        }

        // =========================================================================
        // FEATURE 3: MANAJEMEN DISTRIBUSI
        // =========================================================================
        private void LoadDistribusiData()
        {
            try
            {
                dgvDistribusi.DataSource = db.GetManajemenDistribusi();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat data distribusi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchDistribusi_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariID3.Text.Trim();
            try
            {
                DataTable dt = db.GetManajemenDistribusi();
                if (string.IsNullOrEmpty(keyword))
                {
                    dgvDistribusi.DataSource = dt;
                    return;
                }

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format(
                    "Convert([ID Pesanan], 'System.String') LIKE '%{0}%' OR [Nama Petani] LIKE '%{0}%' OR [Nama Item] LIKE '%{0}%' OR [Jenis] LIKE '%{0}%' OR [Pengiriman] LIKE '%{0}%'",
                    keyword.Replace("'", "''")
                );
                dgvDistribusi.DataSource = dv.ToTable();
            }
            catch (Exception)
            {
                // Catch search format errors during typing
            }
        }

        private void btnKirim_Click(object sender, EventArgs e)
        {
            if (dgvDistribusi.SelectedRows.Count > 0)
            {
                try
                {
                    int transaksiId = Convert.ToInt32(dgvDistribusi.SelectedRows[0].Cells["transaksi_id"].Value);
                    db.UpdateStatusDistribusi(transaksiId, 2);
                    MessageBox.Show("Status distribusi berhasil diubah menjadi 'Dikirim'.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDistribusiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Terjadi kesalahan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Silakan pilih transaksi pada tabel terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvDistribusi_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDistribusi.Rows[e.RowIndex];
            int pesananId = Convert.ToInt32(row.Cells["ID Pesanan"].Value);
            string namaPetani = row.Cells["Nama Petani"].Value?.ToString() ?? "";
            string namaItem = row.Cells["Nama Item"].Value?.ToString() ?? "";
            int jumlah = Convert.ToInt32(row.Cells["Jumlah"].Value);
            int stokSekarang = Convert.ToInt32(row.Cells["Stok Sekarang"].Value);
            string jenis = row.Cells["Jenis"].Value?.ToString() ?? "";

            string message = $"Detail Pesanan:\n" +
                             $"- ID Pesanan: {pesananId}\n" +
                             $"- Petani: {namaPetani}\n" +
                             $"- Item: {namaItem} ({jenis})\n" +
                             $"- Jumlah Dipesan: {jumlah}\n" +
                             $"- Stok Saat Ini: {stokSekarang}\n\n" +
                             $"Apakah Anda ingin MENERIMA pesanan ini?\n" +
                             $"(Klik 'Yes' untuk Terima, 'No' untuk Membatalkan/Tolak, atau 'Cancel' untuk Batal)";

            DialogResult result = MessageBox.Show(message, "Konfirmasi Manajemen Pesanan", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Batasan stok lokal
                if (jumlah > stokSekarang)
                {
                    MessageBox.Show($"Gagal Menerima Pesanan: Jumlah dipesan ({jumlah}) melebihi stok saat ini ({stokSekarang})!",
                        "Batas Stok Melebihi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    //db.TerimaPesanan(pesananId, UserSession.Username, ku);
                    MessageBox.Show("Pesanan berhasil diterima dan dikirim ke transaksi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDistribusiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal menerima pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (result == DialogResult.No)
            {
                // Mintakan alasan pembatalan
                string alasan = Prompt.ShowDialog("Masukkan alasan pembatalan pesanan:", "Alasan Pembatalan");
                if (string.IsNullOrWhiteSpace(alasan))
                {
                    MessageBox.Show("Pembatalan dibatalkan karena alasan tidak diisi.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                try
                {
                    db.BatalPesanan(pesananId, alasan);
                    MessageBox.Show("Pesanan berhasil dibatalkan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadDistribusiData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal membatalkan pesanan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 220,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen,
                    MaximizeBox = false,
                    MinimizeBox = false
                };
                Label textLabel = new Label() { Left = 20, Top = 20, Width = 460, Text = text, AutoSize = true };
                TextBox textBox = new TextBox() { Left = 20, Top = 60, Width = 440 };
                Button confirmation = new Button() { Text = "Ok", Left = 350, Width = 110, Top = 110, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Batal", Left = 230, Width = 110, Top = 110, DialogResult = DialogResult.Cancel };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                cancel.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;
                prompt.CancelButton = cancel;
                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }

        // =========================================================================
        // FEATURE 4: REKAP & LAPORAN
        // =========================================================================
        private void LoadLaporanTransaksi()
        {
            try
            {
                dgvTransaksi.Visible = true;
                DataTable dt = db.GetDashboardTransaksi();
                DataView dv = dt.DefaultView;
                dv.RowFilter = "status_transaksi IN ('Selesai', 'Ditolak', 'Dibatalkan')";
                dgvTransaksi.DataSource = dv.ToTable();

                // Hitung rekap opsional
                Lbl_JumlahTransaksi.Text = dv.Count.ToString();
                decimal pemasukan = 0;
                foreach (DataRowView row in dv)
                {
                    if (row["status_transaksi"].ToString() == "Selesai")
                        pemasukan += Convert.ToDecimal(row["total"]);
                }
                Lbl_Pemasukan.Text = "Rp " + pemasukan.ToString("N0");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan transaksi: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLaporanTransaksiFilter_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = db.GetDashboardTransaksi();
                DataView dv = dt.DefaultView;
                string start = dtp_DariTanggal.Value.ToString("yyyy-MM-dd");
                string end = dtp_KeTanggal.Value.ToString("yyyy-MM-dd 23:59:59");
                dv.RowFilter = $"status_transaksi IN ('Selesai', 'Ditolak', 'Dibatalkan') AND created_at >= '{start}' AND created_at <= '{end}'";
                dgvTransaksi.DataSource = dv.ToTable();

                Lbl_JumlahTransaksi.Text = dv.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Filter error: " + ex.Message);
            }
        }

        private void btnLaporanTransaksiRefresh_Click(object sender, EventArgs e)
        {
            txt_CariID41.Text = "";
            LoadLaporanTransaksi();
        }

        private void txtLaporanTransaksiCari_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                string keyword = txt_CariID41.Text.Trim();
                try
                {
                    DataTable dt = db.GetDashboardTransaksi();
                    DataView dv = dt.DefaultView;
                    if (string.IsNullOrEmpty(keyword))
                    {
                        dv.RowFilter = "status_transaksi IN ('Selesai', 'Ditolak', 'Dibatalkan')";
                    }
                    else
                    {
                        dv.RowFilter = $"status_transaksi IN ('Selesai', 'Ditolak', 'Dibatalkan') AND Convert(transaksi_id, 'System.String') LIKE '%{keyword.Replace("'", "''")}%'";
                    }
                    dgvTransaksi.DataSource = dv.ToTable();
                }
                catch { }
            }
        }

        private void LoadLaporanStok(string jenis)
        {
            try
            {
                dgvStok.Visible = true;
                dgvStok.DataSource = db.GetLaporanStok(jenis);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan stok: " + ex.Message);
            }
        }

        private void LoadLaporanDenda()
        {
            try
            {
                dgvDenda.Visible = true;
                dgvDenda.DataSource = db.GetLaporanDenda();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat laporan denda: " + ex.Message);
            }
        }

        private void txtCariDenda_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtCariNamaDenda.Text.Trim();
            try
            {
                DataTable dt = db.GetLaporanDenda();
                if (string.IsNullOrEmpty(keyword))
                {
                    dgvDenda.DataSource = dt;
                    return;
                }

                DataView dv = dt.DefaultView;
                dv.RowFilter = string.Format("nama_petani LIKE '%{0}%'", keyword.Replace("'", "''"));
                dgvDenda.DataSource = dv.ToTable();
            }
            catch { }
        }

        private void btnDendaLunas_Click(object sender, EventArgs e)
        {
            if (dgvDenda.SelectedRows.Count == 0)
            {
                MessageBox.Show("Pilih alat sewa yang dendanya ingin dilunaskan!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int dendaId = Convert.ToInt32(dgvDenda.SelectedRows[0].Cells["denda_id"].Value);
            string namaAlat = dgvDenda.SelectedRows[0].Cells["nama_alat"].Value?.ToString() ?? "";

            DialogResult confirm = MessageBox.Show($"Tandai denda alat sewa {namaAlat} (ID: {dendaId}) sebagai LUNAS?", "Konfirmasi Pelunasan", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    db.LunaskanDenda(dendaId);
                    MessageBox.Show("Denda berhasil dilunaskan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadLaporanDenda();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Gagal melunaskan denda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PilihMenuLaporan(string menu)
        {
            btnLaporanTransaksi.BackColor = Color.FromArgb(224, 224, 224);
            btnLaporanStok.BackColor = Color.FromArgb(224, 224, 224);
            btnLaporanDenda.BackColor = Color.FromArgb(224, 224, 224);

            dgvTransaksi.Visible = false;
            dgvStok.Visible = false;
            dgvDenda.Visible = false;

            if (menu == "Transaksi")
            {
                btnLaporanTransaksi.BackColor = Color.White;
                tcLaporan.SelectedTab = tcLaporan.TabPages[0];
                LoadLaporanTransaksi();
            }
            else if (menu == "Stok")
            {
                btnLaporanStok.BackColor = Color.White;
                tcLaporan.SelectedTab = tcLaporan.TabPages[1];
                LoadLaporanStok("produk");
            }
            else if (menu == "Denda")
            {
                btnLaporanDenda.BackColor = Color.White;
                tcLaporan.SelectedTab = tcLaporan.TabPages[2];
                LoadLaporanDenda();
            }
        }

        private void ResetReportButton(Button btn)
        {
            btn.BackColor = Color.WhiteSmoke;
            btn.ForeColor = Color.Black;
        }

        private void SetActiveReportButton(Button btn)
        {
            btn.BackColor = Color.ForestGreen;
            btn.ForeColor = Color.White;
        }

        private void btnLaporanTransaksi_Click(object sender, EventArgs e) => PilihMenuLaporan("Transaksi");
        private void btnLaporanStok_Click(object sender, EventArgs e) => PilihMenuLaporan("Stok");
        private void btnLaporanDenda_Click(object sender, EventArgs e) => PilihMenuLaporan("Denda");
        private void btnLaporanKeuangan_Click(object sender, EventArgs e) => PilihMenuLaporan("Keuangan");

        private void dgvDenda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int idDenda = Convert.ToInt32(dgvDenda.Rows[e.RowIndex].Cells["denda_id"].Value);
                string status = dgvDenda.Rows[e.RowIndex].Cells["status_pembayaran"].Value?.ToString() ?? "";

                if (status != "Lunas")
                {
                    DialogResult dialogResult = MessageBox.Show("Apakah petani ini sudah melunasi denda tersebut?", "Konfirmasi Pelunasan Denda", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        try
                        {
                            db.LunaskanDenda(idDenda);
                            MessageBox.Show("Denda berhasil dilunasi!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PilihMenuLaporan("Denda");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Gagal melunasi denda: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Denda ini sudah lunas!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        // =========================================================================
        // FEATURE 5: PROFIL
        // =========================================================================
        private void LoadProfilData()
        {
            try
            {
                LockProfilFields();
                DataTable dt = profCtrl.GetProfilKaryawan(UserSession.UserId);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtNama.Text = row["nama"].ToString();
                    txtNoTelp.Text = row["no_telp"].ToString();
                    txtEmail.Text = row["email"].ToString();
                    txtUsername.Text = row["username"].ToString();
                    txtPassword.Text = row["password"].ToString();
                    txtAlamat.Text = row["alamat"].ToString();
                    txtDesa.Text = row["nama_desa"].ToString();
                    txtKecamatan.Text = row["nama_kecamatan"].ToString();
                    chkStatusAktif.Checked = Convert.ToBoolean(row["isactive"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal memuat profil karyawan: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LockProfilFields()
        {
            txtNama.ReadOnly = true;
            txtNoTelp.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtUsername.ReadOnly = true;
            txtAlamat.ReadOnly = true;
            txtDesa.ReadOnly = true;
            txtKecamatan.ReadOnly = true;

            txtPassword.ReadOnly = true;
            txtPassword.UseSystemPasswordChar = true;

            chkStatusAktif.Enabled = false;
            btnSimpan.Enabled = false; // Simpan
            btnBatal.Enabled = false; // Batal
        }

        private void btnProfilEdit_Click(object? sender, EventArgs e)
        {
            txtPassword.ReadOnly = false;
            txtPassword.UseSystemPasswordChar = false;
            txtPassword.Focus();

            btnSimpan.Enabled = true; // Simpan
            btnBatal.Enabled = true; // Batal
        }

        private void btnProfilSimpan_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Password tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                profCtrl.UpdatePassword(UserSession.UserId, txtPassword.Text);
                MessageBox.Show("Password berhasil diupdate!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LockProfilFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menyimpan password baru: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnProfilBatal_Click(object? sender, EventArgs e)
        {
            LoadProfilData();
        }

        // =========================================================================
        // LOGOUT & CLOSE EVENT
        // =========================================================================
        private void pictureBox7_Click(object? sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                var loginForm = Application.OpenForms["LoginForm"] ?? new LoginForm();
                loginForm.Show();
                this.Close();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Karyawan_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Lbl_DetailPesanan_Click(object sender, EventArgs e)
        {
            PesananMasuk pesananForm = new PesananMasuk();
            pesananForm.ShowDialog();
            LoadDashboardData();
        }

        private void txtJumlahTransaksi_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvUpdateStok_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Logout_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Hide();
            loginForm.Show();
        }

        private void btnLaporan_Click(object sender, EventArgs e)
        {

        }
    }
}
