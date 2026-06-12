namespace WinFormsApp1
{
    partial class DashboardPetani
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            Btn_Profil = new Button();
            Btn_Riwayat = new Button();
            Btn_Tagihan = new Button();
            Btn_Pesanan = new Button();
            Btn_Dashboard = new Button();
            pictureBox1 = new PictureBox();
            btn_Logout = new Button();
            usernameShow = new Label();
            panel2 = new Panel();
            label1 = new Label();
            btn_LihatProdukTani = new Button();
            btn_LihatAlatSewa = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            panel3 = new Panel();
            Dgv_BarangTani = new DataGridView();
            btn_PesanProduk = new Button();
            imageList1 = new ImageList(components);
            Tc_Petani = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            Btn_SudahCO = new Button();
            Btn_CheckOut = new Button();
            panel4 = new Panel();
            Lbl_Pesanan = new Label();
            panel5 = new Panel();
            Dgv_Pesanan = new DataGridView();
            Btn_BelumCO = new Button();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();
            tabPage5 = new TabPage();
            Btn_Keluar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).BeginInit();
            Tc_Petani.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Pesanan).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(184, 224, 162);
            panel1.Controls.Add(Btn_Keluar);
            panel1.Controls.Add(Btn_Profil);
            panel1.Controls.Add(Btn_Riwayat);
            panel1.Controls.Add(Btn_Tagihan);
            panel1.Controls.Add(Btn_Pesanan);
            panel1.Controls.Add(Btn_Dashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btn_Logout);
            panel1.Location = new Point(-5, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 1013);
            panel1.TabIndex = 0;
            // 
            // Btn_Profil
            // 
            Btn_Profil.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Profil.FlatAppearance.BorderSize = 0;
            Btn_Profil.FlatStyle = FlatStyle.Flat;
            Btn_Profil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Profil.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Profil.Location = new Point(25, 403);
            Btn_Profil.Name = "Btn_Profil";
            Btn_Profil.Size = new Size(216, 44);
            Btn_Profil.TabIndex = 34;
            Btn_Profil.Text = "Profil";
            Btn_Profil.UseVisualStyleBackColor = false;
            // 
            // Btn_Riwayat
            // 
            Btn_Riwayat.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Riwayat.FlatAppearance.BorderSize = 0;
            Btn_Riwayat.FlatStyle = FlatStyle.Flat;
            Btn_Riwayat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Riwayat.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Riwayat.Location = new Point(25, 342);
            Btn_Riwayat.Name = "Btn_Riwayat";
            Btn_Riwayat.Size = new Size(216, 44);
            Btn_Riwayat.TabIndex = 33;
            Btn_Riwayat.Text = "Riwayat";
            Btn_Riwayat.UseVisualStyleBackColor = false;
            // 
            // Btn_Tagihan
            // 
            Btn_Tagihan.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Tagihan.FlatAppearance.BorderSize = 0;
            Btn_Tagihan.FlatStyle = FlatStyle.Flat;
            Btn_Tagihan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Tagihan.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Tagihan.Location = new Point(23, 279);
            Btn_Tagihan.Name = "Btn_Tagihan";
            Btn_Tagihan.Size = new Size(216, 44);
            Btn_Tagihan.TabIndex = 32;
            Btn_Tagihan.Text = "Tagihan";
            Btn_Tagihan.UseVisualStyleBackColor = false;
            // 
            // Btn_Pesanan
            // 
            Btn_Pesanan.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Pesanan.FlatAppearance.BorderSize = 0;
            Btn_Pesanan.FlatStyle = FlatStyle.Flat;
            Btn_Pesanan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Pesanan.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Pesanan.Location = new Point(23, 216);
            Btn_Pesanan.Name = "Btn_Pesanan";
            Btn_Pesanan.Size = new Size(216, 44);
            Btn_Pesanan.TabIndex = 31;
            Btn_Pesanan.Text = "Pesanan";
            Btn_Pesanan.UseVisualStyleBackColor = false;
            Btn_Pesanan.Click += Btn_Pesanan_Click;
            // 
            // Btn_Dashboard
            // 
            Btn_Dashboard.BackColor = Color.FromArgb(49, 106, 14);
            Btn_Dashboard.FlatAppearance.BorderSize = 0;
            Btn_Dashboard.FlatStyle = FlatStyle.Flat;
            Btn_Dashboard.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Dashboard.ForeColor = Color.White;
            Btn_Dashboard.Location = new Point(23, 157);
            Btn_Dashboard.Name = "Btn_Dashboard";
            Btn_Dashboard.Size = new Size(216, 44);
            Btn_Dashboard.TabIndex = 30;
            Btn_Dashboard.Text = "Dashboard";
            Btn_Dashboard.UseVisualStyleBackColor = false;
            Btn_Dashboard.Click += Btn_Dashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.PASTANI_DASHBOARD1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(25, 16);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(238, 74);
            pictureBox1.TabIndex = 9;
            pictureBox1.TabStop = false;
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Transparent;
            btn_Logout.FlatAppearance.BorderSize = 0;
            btn_Logout.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btn_Logout.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btn_Logout.FlatStyle = FlatStyle.Flat;
            btn_Logout.Location = new Point(17, 960);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(93, 29);
            btn_Logout.TabIndex = 4;
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // usernameShow
            // 
            usernameShow.AutoSize = true;
            usernameShow.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            usernameShow.ForeColor = SystemColors.ButtonFace;
            usernameShow.Location = new Point(26, 50);
            usernameShow.Name = "usernameShow";
            usernameShow.Size = new Size(573, 47);
            usernameShow.TabIndex = 1;
            usernameShow.Text = "Selamat Datang! UsernamePetani";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(49, 106, 14);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(usernameShow);
            panel2.Location = new Point(11, 17);
            panel2.Name = "panel2";
            panel2.Size = new Size(1061, 180);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Light", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(26, 97);
            label1.Name = "label1";
            label1.Size = new Size(774, 30);
            label1.TabIndex = 2;
            label1.Text = "Pantau stok produk koperasi dan atur penyewaan alat tani dengan lebih mudah hari ini.";
            // 
            // btn_LihatProdukTani
            // 
            btn_LihatProdukTani.BackColor = Color.FromArgb(49, 106, 14);
            btn_LihatProdukTani.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_LihatProdukTani.ForeColor = SystemColors.ButtonFace;
            btn_LihatProdukTani.Location = new Point(11, 267);
            btn_LihatProdukTani.Name = "btn_LihatProdukTani";
            btn_LihatProdukTani.Size = new Size(130, 32);
            btn_LihatProdukTani.TabIndex = 1;
            btn_LihatProdukTani.Text = "Produk";
            btn_LihatProdukTani.UseVisualStyleBackColor = false;
            btn_LihatProdukTani.Click += btn_LihatProdukTani_Click;
            // 
            // btn_LihatAlatSewa
            // 
            btn_LihatAlatSewa.BackColor = SystemColors.InactiveCaption;
            btn_LihatAlatSewa.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_LihatAlatSewa.ForeColor = Color.Black;
            btn_LihatAlatSewa.Location = new Point(147, 267);
            btn_LihatAlatSewa.Name = "btn_LihatAlatSewa";
            btn_LihatAlatSewa.Size = new Size(130, 32);
            btn_LihatAlatSewa.TabIndex = 2;
            btn_LihatAlatSewa.Text = "Alat Sewa";
            btn_LihatAlatSewa.UseVisualStyleBackColor = false;
            btn_LihatAlatSewa.Click += btn_LihatAlatSewa_Click;
            // 
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel3.BackColor = Color.FromArgb(122, 148, 114);
            panel3.Controls.Add(Dgv_BarangTani);
            panel3.Location = new Point(11, 318);
            panel3.Name = "panel3";
            panel3.Size = new Size(1061, 653);
            panel3.TabIndex = 3;
            // 
            // Dgv_BarangTani
            // 
            Dgv_BarangTani.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Dgv_BarangTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_BarangTani.Location = new Point(13, 15);
            Dgv_BarangTani.Name = "Dgv_BarangTani";
            Dgv_BarangTani.Size = new Size(1032, 621);
            Dgv_BarangTani.TabIndex = 1;
            // 
            // btn_PesanProduk
            // 
            btn_PesanProduk.Anchor = AnchorStyles.Right;
            btn_PesanProduk.BackColor = Color.LimeGreen;
            btn_PesanProduk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_PesanProduk.ForeColor = Color.Black;
            btn_PesanProduk.Location = new Point(865, 267);
            btn_PesanProduk.Name = "btn_PesanProduk";
            btn_PesanProduk.Size = new Size(191, 32);
            btn_PesanProduk.TabIndex = 4;
            btn_PesanProduk.Text = "Pesan Produk";
            btn_PesanProduk.UseVisualStyleBackColor = false;
            btn_PesanProduk.Click += btn_PesanProduk_Click;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // Tc_Petani
            // 
            Tc_Petani.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Tc_Petani.Controls.Add(tabPage1);
            Tc_Petani.Controls.Add(tabPage2);
            Tc_Petani.Controls.Add(tabPage3);
            Tc_Petani.Controls.Add(tabPage4);
            Tc_Petani.Controls.Add(tabPage5);
            Tc_Petani.ItemSize = new Size(61, 20);
            Tc_Petani.Location = new Point(264, -4);
            Tc_Petani.Name = "Tc_Petani";
            Tc_Petani.SelectedIndex = 0;
            Tc_Petani.Size = new Size(1107, 1013);
            Tc_Petani.TabIndex = 5;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(btn_PesanProduk);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(panel3);
            tabPage1.Controls.Add(btn_LihatProdukTani);
            tabPage1.Controls.Add(btn_LihatAlatSewa);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1099, 985);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(Btn_SudahCO);
            tabPage2.Controls.Add(Btn_CheckOut);
            tabPage2.Controls.Add(panel4);
            tabPage2.Controls.Add(panel5);
            tabPage2.Controls.Add(Btn_BelumCO);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1099, 985);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Btn_SudahCO
            // 
            Btn_SudahCO.BackColor = Color.FromArgb(49, 106, 14);
            Btn_SudahCO.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_SudahCO.ForeColor = SystemColors.ButtonFace;
            Btn_SudahCO.Location = new Point(147, 266);
            Btn_SudahCO.Name = "Btn_SudahCO";
            Btn_SudahCO.Size = new Size(130, 32);
            Btn_SudahCO.TabIndex = 10;
            Btn_SudahCO.Text = "Sudah Check Out";
            Btn_SudahCO.UseVisualStyleBackColor = false;
            Btn_SudahCO.Click += Btn_SudahCO_Click;
            // 
            // Btn_CheckOut
            // 
            Btn_CheckOut.BackColor = Color.LimeGreen;
            Btn_CheckOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_CheckOut.ForeColor = Color.Black;
            Btn_CheckOut.Location = new Point(865, 266);
            Btn_CheckOut.Name = "Btn_CheckOut";
            Btn_CheckOut.Size = new Size(191, 32);
            Btn_CheckOut.TabIndex = 9;
            Btn_CheckOut.Text = "Check Out";
            Btn_CheckOut.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(49, 106, 14);
            panel4.Controls.Add(Lbl_Pesanan);
            panel4.Location = new Point(11, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(1061, 89);
            panel4.TabIndex = 5;
            // 
            // Lbl_Pesanan
            // 
            Lbl_Pesanan.AutoSize = true;
            Lbl_Pesanan.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Pesanan.ForeColor = SystemColors.ButtonFace;
            Lbl_Pesanan.Location = new Point(355, 16);
            Lbl_Pesanan.Name = "Lbl_Pesanan";
            Lbl_Pesanan.Size = new Size(382, 47);
            Lbl_Pesanan.TabIndex = 1;
            Lbl_Pesanan.Text = "Berikut Pesanan Anda";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(122, 148, 114);
            panel5.Controls.Add(Dgv_Pesanan);
            panel5.Location = new Point(11, 317);
            panel5.Name = "panel5";
            panel5.Size = new Size(1061, 653);
            panel5.TabIndex = 8;
            // 
            // Dgv_Pesanan
            // 
            Dgv_Pesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_Pesanan.Location = new Point(13, 15);
            Dgv_Pesanan.Name = "Dgv_Pesanan";
            Dgv_Pesanan.Size = new Size(1032, 621);
            Dgv_Pesanan.TabIndex = 1;
            // 
            // Btn_BelumCO
            // 
            Btn_BelumCO.BackColor = Color.FromArgb(49, 106, 14);
            Btn_BelumCO.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_BelumCO.ForeColor = SystemColors.ButtonFace;
            Btn_BelumCO.Location = new Point(11, 266);
            Btn_BelumCO.Name = "Btn_BelumCO";
            Btn_BelumCO.Size = new Size(130, 32);
            Btn_BelumCO.TabIndex = 6;
            Btn_BelumCO.Text = "Belum Check Out";
            Btn_BelumCO.UseVisualStyleBackColor = false;
            Btn_BelumCO.Click += Btn_BelumCO_Click;
            // 
            // tabPage3
            // 
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1099, 985);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1099, 985);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1099, 985);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // Btn_Keluar
            // 
            Btn_Keluar.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Keluar.FlatAppearance.BorderSize = 0;
            Btn_Keluar.FlatAppearance.MouseDownBackColor = Color.Transparent;
            Btn_Keluar.FlatAppearance.MouseOverBackColor = Color.Transparent;
            Btn_Keluar.FlatStyle = FlatStyle.Flat;
            Btn_Keluar.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Keluar.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Keluar.Location = new Point(25, 929);
            Btn_Keluar.Name = "Btn_Keluar";
            Btn_Keluar.Size = new Size(195, 49);
            Btn_Keluar.TabIndex = 35;
            Btn_Keluar.Text = "Keluar";
            Btn_Keluar.UseVisualStyleBackColor = false;
            Btn_Keluar.Click += Btn_Keluar_Click;
            // 
            // DashboardPetani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1367, 1005);
            Controls.Add(Tc_Petani);
            Controls.Add(panel1);
            Name = "DashboardPetani";
            Text = "DashboardPetani";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).EndInit();
            Tc_Petani.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv_Pesanan).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button btn_LihatProdukTani;
        private Label usernameShow;
        private Button btn_LihatAlatSewa;
        private Button btn_Logout;
        private Label label1;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private Panel panel3;
        private DataGridView Dgv_BarangTani;
        private Button btn_PesanProduk;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private TabControl Tc_Petani;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private Button Btn_Pesanan;
        private Button Btn_Dashboard;
        private Button Btn_Profil;
        private Button Btn_Riwayat;
        private Button Btn_Tagihan;
        private Button Btn_CheckOut;
        private Panel panel4;
        private Label Lbl_Pesanan;
        private Panel panel5;
        private DataGridView Dgv_Pesanan;
        private Button Btn_BelumCO;
        private Button Btn_SudahCO;
        private Button Btn_Keluar;
    }
}