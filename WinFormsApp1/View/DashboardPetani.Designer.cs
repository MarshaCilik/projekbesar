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
            panel1 = new Panel();
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
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BackgroundImage = Properties.Resources.dashbord_petani_kiri;
            panel1.Controls.Add(btn_Logout);
            panel1.Location = new Point(-5, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 1013);
            panel1.TabIndex = 0;
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
            panel2.BackColor = Color.FromArgb(49, 106, 14);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(usernameShow);
            panel2.Location = new Point(282, 31);
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
            btn_LihatProdukTani.Location = new Point(282, 281);
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
            btn_LihatAlatSewa.ForeColor = Color.FromArgb(49, 106, 14);
            btn_LihatAlatSewa.Location = new Point(418, 281);
            btn_LihatAlatSewa.Name = "btn_LihatAlatSewa";
            btn_LihatAlatSewa.Size = new Size(130, 32);
            btn_LihatAlatSewa.TabIndex = 2;
            btn_LihatAlatSewa.Text = "Alat Sewa";
            btn_LihatAlatSewa.UseVisualStyleBackColor = false;
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
            panel3.BackColor = Color.FromArgb(122, 148, 114);
            panel3.Controls.Add(Dgv_BarangTani);
            panel3.Location = new Point(282, 332);
            panel3.Name = "panel3";
            panel3.Size = new Size(1061, 653);
            panel3.TabIndex = 3;
            // 
            // Dgv_BarangTani
            // 
            Dgv_BarangTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_BarangTani.Location = new Point(13, 15);
            Dgv_BarangTani.Name = "Dgv_BarangTani";
            Dgv_BarangTani.Size = new Size(1032, 621);
            Dgv_BarangTani.TabIndex = 1;
            // 
            // btn_PesanProduk
            // 
            btn_PesanProduk.BackColor = Color.LimeGreen;
            btn_PesanProduk.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_PesanProduk.ForeColor = Color.Black;
            btn_PesanProduk.Location = new Point(1136, 281);
            btn_PesanProduk.Name = "btn_PesanProduk";
            btn_PesanProduk.Size = new Size(191, 32);
            btn_PesanProduk.TabIndex = 4;
            btn_PesanProduk.Text = "Pesan Produk";
            btn_PesanProduk.UseVisualStyleBackColor = false;
            btn_PesanProduk.Click += btn_PesanProduk_Click;
            // 
            // DashboardPetani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1367, 1005);
            Controls.Add(btn_PesanProduk);
            Controls.Add(panel3);
            Controls.Add(btn_LihatAlatSewa);
            Controls.Add(btn_LihatProdukTani);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashboardPetani";
            Text = "DashboardPetani";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).EndInit();
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
    }
}