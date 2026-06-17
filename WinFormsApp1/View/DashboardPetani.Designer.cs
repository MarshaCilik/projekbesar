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
            Btn_Keluar = new Button();
            Btn_Profil = new Button();
            Btn_Riwayat = new Button();
            Btn_Pesanan = new Button();
            Btn_Dashboard = new Button();
            pictureBox1 = new PictureBox();
            btn_Logout = new Button();
            npgsqlDataAdapter1 = new Npgsql.NpgsqlDataAdapter();
            imageList1 = new ImageList(components);
            tabPage5 = new TabPage();
            panel15 = new Panel();
            Btn_Simpan = new Button();
            panel14 = new Panel();
            Tb_Desa = new TextBox();
            panel13 = new Panel();
            Tb_Nama = new TextBox();
            Btn_Batal = new Button();
            panel12 = new Panel();
            Tb_NoTelp = new TextBox();
            panel11 = new Panel();
            Tb_Email = new TextBox();
            Lbl_Status = new Label();
            panel8 = new Panel();
            Tb_Username = new TextBox();
            label9 = new Label();
            panel6 = new Panel();
            Tb_Password = new TextBox();
            label8 = new Label();
            panel7 = new Panel();
            Tb_Alamat = new TextBox();
            label7 = new Label();
            panel9 = new Panel();
            Tb_Kecamatan = new TextBox();
            panel10 = new Panel();
            label6 = new Label();
            label11 = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            panel16 = new Panel();
            label14 = new Label();
            pictureBox2 = new PictureBox();
            tabPage4 = new TabPage();
            tabPage3 = new TabPage();
            btn_TerimaPesanan = new Button();
            btn_TransaksiBerlangsung = new Button();
            btn_TagihanDenda = new Button();
            btn_RiwayatTransaksi = new Button();
            panel18 = new Panel();
            dgv_RiwayatDanTagihan = new DataGridView();
            panel17 = new Panel();
            label10 = new Label();
            label12 = new Label();
            tabPage2 = new TabPage();
            Btn_BatalPesanan = new Button();
            Btn_SudahCO = new Button();
            Btn_CheckOut = new Button();
            panel4 = new Panel();
            label2 = new Label();
            Lbl_Pesanan = new Label();
            panel5 = new Panel();
            Dgv_Pesanan = new DataGridView();
            Btn_BelumCO = new Button();
            tabPage1 = new TabPage();
            btn_PesanProduk = new Button();
            panel2 = new Panel();
            label1 = new Label();
            usernameShow = new Label();
            panel3 = new Panel();
            Dgv_BarangTani = new DataGridView();
            btn_LihatProdukTani = new Button();
            btn_LihatAlatSewa = new Button();
            Tc_Petani = new TabControl();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabPage5.SuspendLayout();
            panel15.SuspendLayout();
            panel14.SuspendLayout();
            panel13.SuspendLayout();
            panel12.SuspendLayout();
            panel11.SuspendLayout();
            panel8.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel16.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            tabPage3.SuspendLayout();
            panel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_RiwayatDanTagihan).BeginInit();
            panel17.SuspendLayout();
            tabPage2.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_Pesanan).BeginInit();
            tabPage1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).BeginInit();
            Tc_Petani.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(184, 224, 162);
            panel1.Controls.Add(Btn_Keluar);
            panel1.Controls.Add(Btn_Profil);
            panel1.Controls.Add(Btn_Riwayat);
            panel1.Controls.Add(Btn_Pesanan);
            panel1.Controls.Add(Btn_Dashboard);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(btn_Logout);
            panel1.Location = new Point(-5, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(278, 1013);
            panel1.TabIndex = 0;
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
            // Btn_Profil
            // 
            Btn_Profil.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Profil.FlatAppearance.BorderSize = 0;
            Btn_Profil.FlatStyle = FlatStyle.Flat;
            Btn_Profil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Profil.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Profil.Location = new Point(25, 327);
            Btn_Profil.Name = "Btn_Profil";
            Btn_Profil.Size = new Size(216, 44);
            Btn_Profil.TabIndex = 34;
            Btn_Profil.Text = "Profil";
            Btn_Profil.UseVisualStyleBackColor = false;
            Btn_Profil.Click += Btn_Profil_Click;
            // 
            // Btn_Riwayat
            // 
            Btn_Riwayat.BackColor = Color.FromArgb(184, 224, 162);
            Btn_Riwayat.FlatAppearance.BorderSize = 0;
            Btn_Riwayat.FlatStyle = FlatStyle.Flat;
            Btn_Riwayat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Btn_Riwayat.ForeColor = Color.FromArgb(49, 106, 14);
            Btn_Riwayat.Location = new Point(25, 266);
            Btn_Riwayat.Name = "Btn_Riwayat";
            Btn_Riwayat.Size = new Size(216, 44);
            Btn_Riwayat.TabIndex = 33;
            Btn_Riwayat.Text = "Riwayat dan Tagihan";
            Btn_Riwayat.UseVisualStyleBackColor = false;
            Btn_Riwayat.Click += Btn_Riwayat_Click;
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
            // npgsqlDataAdapter1
            // 
            npgsqlDataAdapter1.DeleteCommand = null;
            npgsqlDataAdapter1.InsertCommand = null;
            npgsqlDataAdapter1.SelectCommand = null;
            npgsqlDataAdapter1.UpdateCommand = null;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth32Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(panel15);
            tabPage5.Controls.Add(panel16);
            tabPage5.Controls.Add(pictureBox2);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(1099, 985);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // panel15
            // 
            panel15.BackColor = Color.FromArgb(122, 148, 114);
            panel15.Controls.Add(Btn_Simpan);
            panel15.Controls.Add(panel14);
            panel15.Controls.Add(panel13);
            panel15.Controls.Add(Btn_Batal);
            panel15.Controls.Add(panel12);
            panel15.Controls.Add(panel11);
            panel15.Controls.Add(Lbl_Status);
            panel15.Controls.Add(panel8);
            panel15.Controls.Add(label9);
            panel15.Controls.Add(panel6);
            panel15.Controls.Add(label8);
            panel15.Controls.Add(panel7);
            panel15.Controls.Add(label7);
            panel15.Controls.Add(panel9);
            panel15.Controls.Add(label6);
            panel15.Controls.Add(label11);
            panel15.Controls.Add(label5);
            panel15.Controls.Add(label3);
            panel15.Controls.Add(label4);
            panel15.Location = new Point(231, 132);
            panel15.Name = "panel15";
            panel15.Size = new Size(827, 819);
            panel15.TabIndex = 45;
            // 
            // Btn_Simpan
            // 
            Btn_Simpan.BackColor = Color.FromArgb(168, 197, 152);
            Btn_Simpan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Simpan.Location = new Point(29, 659);
            Btn_Simpan.Name = "Btn_Simpan";
            Btn_Simpan.Size = new Size(761, 49);
            Btn_Simpan.TabIndex = 41;
            Btn_Simpan.Text = "SIMPAN";
            Btn_Simpan.UseVisualStyleBackColor = false;
            Btn_Simpan.Click += Btn_Simpan_Click;
            // 
            // panel14
            // 
            panel14.BackColor = Color.FromArgb(74, 103, 65);
            panel14.Controls.Add(Tb_Desa);
            panel14.Location = new Point(29, 495);
            panel14.Name = "panel14";
            panel14.Size = new Size(760, 38);
            panel14.TabIndex = 29;
            // 
            // Tb_Desa
            // 
            Tb_Desa.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Desa.BorderStyle = BorderStyle.FixedSingle;
            Tb_Desa.ForeColor = Color.White;
            Tb_Desa.Location = new Point(11, 8);
            Tb_Desa.Name = "Tb_Desa";
            Tb_Desa.Size = new Size(521, 23);
            Tb_Desa.TabIndex = 6;
            // 
            // panel13
            // 
            panel13.BackColor = Color.FromArgb(74, 103, 65);
            panel13.Controls.Add(Tb_Nama);
            panel13.Location = new Point(29, 57);
            panel13.Name = "panel13";
            panel13.Size = new Size(760, 38);
            panel13.TabIndex = 23;
            // 
            // Tb_Nama
            // 
            Tb_Nama.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama.BorderStyle = BorderStyle.FixedSingle;
            Tb_Nama.ForeColor = Color.White;
            Tb_Nama.Location = new Point(12, 7);
            Tb_Nama.Name = "Tb_Nama";
            Tb_Nama.Size = new Size(521, 23);
            Tb_Nama.TabIndex = 0;
            // 
            // Btn_Batal
            // 
            Btn_Batal.BackColor = SystemColors.ButtonHighlight;
            Btn_Batal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Batal.Location = new Point(28, 714);
            Btn_Batal.Name = "Btn_Batal";
            Btn_Batal.Size = new Size(761, 49);
            Btn_Batal.TabIndex = 42;
            Btn_Batal.Text = "BATAL";
            Btn_Batal.UseVisualStyleBackColor = false;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(74, 103, 65);
            panel12.Controls.Add(Tb_NoTelp);
            panel12.Location = new Point(29, 129);
            panel12.Name = "panel12";
            panel12.Size = new Size(760, 38);
            panel12.TabIndex = 24;
            // 
            // Tb_NoTelp
            // 
            Tb_NoTelp.BackColor = Color.FromArgb(74, 103, 65);
            Tb_NoTelp.BorderStyle = BorderStyle.FixedSingle;
            Tb_NoTelp.ForeColor = Color.White;
            Tb_NoTelp.Location = new Point(13, 9);
            Tb_NoTelp.Name = "Tb_NoTelp";
            Tb_NoTelp.Size = new Size(521, 23);
            Tb_NoTelp.TabIndex = 1;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(74, 103, 65);
            panel11.Controls.Add(Tb_Email);
            panel11.Location = new Point(29, 201);
            panel11.Name = "panel11";
            panel11.Size = new Size(760, 38);
            panel11.TabIndex = 25;
            // 
            // Tb_Email
            // 
            Tb_Email.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Email.BorderStyle = BorderStyle.FixedSingle;
            Tb_Email.ForeColor = Color.White;
            Tb_Email.Location = new Point(11, 8);
            Tb_Email.Name = "Tb_Email";
            Tb_Email.Size = new Size(521, 23);
            Tb_Email.TabIndex = 2;
            // 
            // Lbl_Status
            // 
            Lbl_Status.AutoSize = true;
            Lbl_Status.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Status.Location = new Point(30, 632);
            Lbl_Status.Name = "Lbl_Status";
            Lbl_Status.Size = new Size(56, 15);
            Lbl_Status.TabIndex = 39;
            Lbl_Status.Text = "STATUS: ";
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(74, 103, 65);
            panel8.Controls.Add(Tb_Username);
            panel8.Location = new Point(30, 277);
            panel8.Name = "panel8";
            panel8.Size = new Size(760, 38);
            panel8.TabIndex = 26;
            // 
            // Tb_Username
            // 
            Tb_Username.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Username.BorderStyle = BorderStyle.FixedSingle;
            Tb_Username.ForeColor = Color.White;
            Tb_Username.Location = new Point(10, 8);
            Tb_Username.Name = "Tb_Username";
            Tb_Username.Size = new Size(521, 23);
            Tb_Username.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(30, 555);
            label9.Name = "label9";
            label9.Size = new Size(80, 15);
            label9.TabIndex = 38;
            label9.Text = "KECAMATAN:";
            // 
            // panel6
            // 
            panel6.BackColor = Color.FromArgb(74, 103, 65);
            panel6.Controls.Add(Tb_Password);
            panel6.Location = new Point(29, 350);
            panel6.Name = "panel6";
            panel6.Size = new Size(760, 38);
            panel6.TabIndex = 27;
            // 
            // Tb_Password
            // 
            Tb_Password.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Password.BorderStyle = BorderStyle.FixedSingle;
            Tb_Password.ForeColor = Color.White;
            Tb_Password.Location = new Point(10, 8);
            Tb_Password.Name = "Tb_Password";
            Tb_Password.Size = new Size(521, 23);
            Tb_Password.TabIndex = 4;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(30, 477);
            label8.Name = "label8";
            label8.Size = new Size(40, 15);
            label8.TabIndex = 37;
            label8.Text = "DESA:";
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(74, 103, 65);
            panel7.Controls.Add(Tb_Alamat);
            panel7.Location = new Point(30, 422);
            panel7.Name = "panel7";
            panel7.Size = new Size(760, 38);
            panel7.TabIndex = 28;
            // 
            // Tb_Alamat
            // 
            Tb_Alamat.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Alamat.BorderStyle = BorderStyle.FixedSingle;
            Tb_Alamat.ForeColor = Color.White;
            Tb_Alamat.Location = new Point(11, 9);
            Tb_Alamat.Name = "Tb_Alamat";
            Tb_Alamat.Size = new Size(521, 23);
            Tb_Alamat.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(30, 404);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 36;
            label7.Text = "ALAMAT(JALAN):";
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(74, 103, 65);
            panel9.Controls.Add(Tb_Kecamatan);
            panel9.Controls.Add(panel10);
            panel9.Location = new Point(29, 573);
            panel9.Name = "panel9";
            panel9.Size = new Size(760, 38);
            panel9.TabIndex = 30;
            // 
            // Tb_Kecamatan
            // 
            Tb_Kecamatan.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kecamatan.BorderStyle = BorderStyle.FixedSingle;
            Tb_Kecamatan.ForeColor = Color.White;
            Tb_Kecamatan.Location = new Point(12, 7);
            Tb_Kecamatan.Name = "Tb_Kecamatan";
            Tb_Kecamatan.Size = new Size(521, 23);
            Tb_Kecamatan.TabIndex = 7;
            // 
            // panel10
            // 
            panel10.Location = new Point(0, 83);
            panel10.Name = "panel10";
            panel10.Size = new Size(203, 38);
            panel10.TabIndex = 20;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(29, 332);
            label6.Name = "label6";
            label6.Size = new Size(76, 15);
            label6.TabIndex = 35;
            label6.Text = "PASSWORD:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(29, 39);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 31;
            label11.Text = "NAMA:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(29, 259);
            label5.Name = "label5";
            label5.Size = new Size(74, 15);
            label5.TabIndex = 34;
            label5.Text = "USERNAME:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(29, 111);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 32;
            label3.Text = "NO. TELP:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(30, 183);
            label4.Name = "label4";
            label4.Size = new Size(45, 15);
            label4.TabIndex = 33;
            label4.Text = "EMAIL:";
            // 
            // panel16
            // 
            panel16.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel16.BackColor = Color.FromArgb(49, 106, 14);
            panel16.Controls.Add(label14);
            panel16.Location = new Point(28, 12);
            panel16.Name = "panel16";
            panel16.Size = new Size(1044, 87);
            panel16.TabIndex = 44;
            // 
            // label14
            // 
            label14.Anchor = AnchorStyles.Top;
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = SystemColors.ButtonFace;
            label14.Location = new Point(419, 15);
            label14.Name = "label14";
            label14.Size = new Size(206, 47);
            label14.TabIndex = 1;
            label14.Text = "Profil Anda";
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.Profil;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(41, 132);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(153, 132);
            pictureBox2.TabIndex = 43;
            pictureBox2.TabStop = false;
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
            // tabPage3
            // 
            tabPage3.Controls.Add(btn_TerimaPesanan);
            tabPage3.Controls.Add(btn_TransaksiBerlangsung);
            tabPage3.Controls.Add(btn_TagihanDenda);
            tabPage3.Controls.Add(btn_RiwayatTransaksi);
            tabPage3.Controls.Add(panel18);
            tabPage3.Controls.Add(panel17);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1099, 985);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // btn_TerimaPesanan
            // 
            btn_TerimaPesanan.BackColor = Color.LightGray;
            btn_TerimaPesanan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_TerimaPesanan.ForeColor = Color.Black;
            btn_TerimaPesanan.Location = new Point(923, 274);
            btn_TerimaPesanan.Name = "btn_TerimaPesanan";
            btn_TerimaPesanan.Size = new Size(149, 32);
            btn_TerimaPesanan.TabIndex = 14;
            btn_TerimaPesanan.Text = "Terima Pesanan";
            btn_TerimaPesanan.UseVisualStyleBackColor = false;
            // 
            // btn_TransaksiBerlangsung
            // 
            btn_TransaksiBerlangsung.BackColor = Color.LightGray;
            btn_TransaksiBerlangsung.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_TransaksiBerlangsung.ForeColor = Color.Black;
            btn_TransaksiBerlangsung.Location = new Point(14, 274);
            btn_TransaksiBerlangsung.Name = "btn_TransaksiBerlangsung";
            btn_TransaksiBerlangsung.Size = new Size(149, 32);
            btn_TransaksiBerlangsung.TabIndex = 13;
            btn_TransaksiBerlangsung.Text = "Transaksi Berlangsung";
            btn_TransaksiBerlangsung.UseVisualStyleBackColor = false;
            btn_TransaksiBerlangsung.Click += btn_TransaksiBerlangsung_Click_1;
            // 
            // btn_TagihanDenda
            // 
            btn_TagihanDenda.BackColor = Color.LightGray;
            btn_TagihanDenda.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_TagihanDenda.ForeColor = Color.Black;
            btn_TagihanDenda.Location = new Point(169, 274);
            btn_TagihanDenda.Name = "btn_TagihanDenda";
            btn_TagihanDenda.Size = new Size(149, 32);
            btn_TagihanDenda.TabIndex = 12;
            btn_TagihanDenda.Text = "Tagihan Denda";
            btn_TagihanDenda.UseVisualStyleBackColor = false;
            btn_TagihanDenda.Click += btn_TagihanDenda_Click_1;
            // 
            // btn_RiwayatTransaksi
            // 
            btn_RiwayatTransaksi.BackColor = Color.LightGray;
            btn_RiwayatTransaksi.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_RiwayatTransaksi.ForeColor = Color.Black;
            btn_RiwayatTransaksi.Location = new Point(324, 274);
            btn_RiwayatTransaksi.Name = "btn_RiwayatTransaksi";
            btn_RiwayatTransaksi.Size = new Size(149, 32);
            btn_RiwayatTransaksi.TabIndex = 11;
            btn_RiwayatTransaksi.Text = "Riwayat Transaksi";
            btn_RiwayatTransaksi.UseVisualStyleBackColor = false;
            btn_RiwayatTransaksi.Click += btn_RiwayatTransaksi_Click_1;
            // 
            // panel18
            // 
            panel18.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel18.BackColor = Color.FromArgb(122, 148, 114);
            panel18.Controls.Add(dgv_RiwayatDanTagihan);
            panel18.Location = new Point(11, 312);
            panel18.Name = "panel18";
            panel18.Size = new Size(1061, 653);
            panel18.TabIndex = 9;
            // 
            // dgv_RiwayatDanTagihan
            // 
            dgv_RiwayatDanTagihan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgv_RiwayatDanTagihan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_RiwayatDanTagihan.Location = new Point(14, 17);
            dgv_RiwayatDanTagihan.Name = "dgv_RiwayatDanTagihan";
            dgv_RiwayatDanTagihan.Size = new Size(1031, 621);
            dgv_RiwayatDanTagihan.TabIndex = 1;
            // 
            // panel17
            // 
            panel17.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel17.BackColor = Color.FromArgb(49, 106, 14);
            panel17.Controls.Add(label10);
            panel17.Controls.Add(label12);
            panel17.Location = new Point(11, 16);
            panel17.Name = "panel17";
            panel17.Size = new Size(1061, 220);
            panel17.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.ForeColor = Color.White;
            label10.Location = new Point(12, 167);
            label10.Name = "label10";
            label10.Size = new Size(334, 15);
            label10.TabIndex = 2;
            label10.Text = "* Pesanan tidak dapat dibatalkan setelah pesanan di checkout ";
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top;
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ButtonFace;
            label12.Location = new Point(269, 14);
            label12.Name = "label12";
            label12.Size = new Size(525, 47);
            label12.TabIndex = 1;
            label12.Text = "Riwayat dan Tagihan Transaksi";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(Btn_BatalPesanan);
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
            // Btn_BatalPesanan
            // 
            Btn_BatalPesanan.Anchor = AnchorStyles.Right;
            Btn_BatalPesanan.BackColor = Color.LightGray;
            Btn_BatalPesanan.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_BatalPesanan.ForeColor = Color.Black;
            Btn_BatalPesanan.Location = new Point(729, 266);
            Btn_BatalPesanan.Name = "Btn_BatalPesanan";
            Btn_BatalPesanan.Size = new Size(130, 32);
            Btn_BatalPesanan.TabIndex = 11;
            Btn_BatalPesanan.Text = "Batalkan Pesanan";
            Btn_BatalPesanan.UseVisualStyleBackColor = false;
            Btn_BatalPesanan.Click += Btn_BatalPesanan_Click;
            // 
            // Btn_SudahCO
            // 
            Btn_SudahCO.BackColor = Color.LightGray;
            Btn_SudahCO.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_SudahCO.ForeColor = Color.Black;
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
            Btn_CheckOut.Anchor = AnchorStyles.Right;
            Btn_CheckOut.BackColor = Color.LimeGreen;
            Btn_CheckOut.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_CheckOut.ForeColor = Color.Black;
            Btn_CheckOut.Location = new Point(865, 266);
            Btn_CheckOut.Name = "Btn_CheckOut";
            Btn_CheckOut.Size = new Size(191, 32);
            Btn_CheckOut.TabIndex = 9;
            Btn_CheckOut.Text = "Check Out";
            Btn_CheckOut.UseVisualStyleBackColor = false;
            Btn_CheckOut.Click += Btn_CheckOut_Click;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(49, 106, 14);
            panel4.Controls.Add(label2);
            panel4.Controls.Add(Lbl_Pesanan);
            panel4.Location = new Point(11, 16);
            panel4.Name = "panel4";
            panel4.Size = new Size(1061, 100);
            panel4.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(13, 70);
            label2.Name = "label2";
            label2.Size = new Size(334, 15);
            label2.TabIndex = 2;
            label2.Text = "* Pesanan tidak dapat dibatalkan setelah pesanan di checkout ";
            // 
            // Lbl_Pesanan
            // 
            Lbl_Pesanan.Anchor = AnchorStyles.Top;
            Lbl_Pesanan.AutoSize = true;
            Lbl_Pesanan.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Pesanan.ForeColor = SystemColors.ButtonFace;
            Lbl_Pesanan.Location = new Point(340, 13);
            Lbl_Pesanan.Name = "Lbl_Pesanan";
            Lbl_Pesanan.Size = new Size(382, 47);
            Lbl_Pesanan.TabIndex = 1;
            Lbl_Pesanan.Text = "Berikut Pesanan Anda";
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.FromArgb(122, 148, 114);
            panel5.Controls.Add(Dgv_Pesanan);
            panel5.Location = new Point(11, 317);
            panel5.Name = "panel5";
            panel5.Size = new Size(1061, 653);
            panel5.TabIndex = 8;
            // 
            // Dgv_Pesanan
            // 
            Dgv_Pesanan.Anchor = AnchorStyles.Left | AnchorStyles.Right;
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
            // Tc_Petani
            // 
            Tc_Petani.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            Tc_Petani.Controls.Add(tabPage1);
            Tc_Petani.Controls.Add(tabPage2);
            Tc_Petani.Controls.Add(tabPage3);
            Tc_Petani.Controls.Add(tabPage4);
            Tc_Petani.Controls.Add(tabPage5);
            Tc_Petani.ItemSize = new Size(61, 20);
            Tc_Petani.Location = new Point(279, -4);
            Tc_Petani.Name = "Tc_Petani";
            Tc_Petani.SelectedIndex = 0;
            Tc_Petani.Size = new Size(1107, 1013);
            Tc_Petani.TabIndex = 5;
            // 
            // DashboardPetani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1367, 976);
            Controls.Add(Tc_Petani);
            Controls.Add(panel1);
            Name = "DashboardPetani";
            Text = "DashboardPetani";
            WindowState = FormWindowState.Maximized;
            FormClosed += DashboardPetani_FormClosed;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabPage5.ResumeLayout(false);
            panel15.ResumeLayout(false);
            panel15.PerformLayout();
            panel14.ResumeLayout(false);
            panel14.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            tabPage3.ResumeLayout(false);
            panel18.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_RiwayatDanTagihan).EndInit();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv_Pesanan).EndInit();
            tabPage1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).EndInit();
            Tc_Petani.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btn_Logout;
        private Npgsql.NpgsqlDataAdapter npgsqlDataAdapter1;
        private PictureBox pictureBox1;
        private ImageList imageList1;
        private Button Btn_Pesanan;
        private Button Btn_Dashboard;
        private Button Btn_Profil;
        private Button Btn_Riwayat;
        private Button Btn_Keluar;
        private TabPage tabPage5;
        private Panel panel15;
        private Button Btn_Simpan;
        private Panel panel14;
        private TextBox Tb_Desa;
        private Panel panel13;
        private TextBox Tb_Nama;
        private Button Btn_Batal;
        private Panel panel12;
        private TextBox Tb_NoTelp;
        private Panel panel11;
        private TextBox Tb_Email;
        private Label Lbl_Status;
        private Panel panel8;
        private TextBox Tb_Username;
        private Label label9;
        private Panel panel6;
        private TextBox Tb_Password;
        private Label label8;
        private Panel panel7;
        private TextBox Tb_Alamat;
        private Label label7;
        private Panel panel9;
        private TextBox Tb_Kecamatan;
        private Panel panel10;
        private Label label6;
        private Label label11;
        private Label label5;
        private Label label3;
        private Label label4;
        private Panel panel16;
        private Label label14;
        private PictureBox pictureBox2;
        private TabPage tabPage4;
        private TabPage tabPage3;
        private Panel panel18;
        private DataGridView dgv_RiwayatDanTagihan;
        private Panel panel17;
        private Label label10;
        private Label label12;
        private TabPage tabPage2;
        private Button Btn_BatalPesanan;
        private Button Btn_SudahCO;
        private Button Btn_CheckOut;
        private Panel panel4;
        private Label label2;
        private Label Lbl_Pesanan;
        private Panel panel5;
        private DataGridView Dgv_Pesanan;
        private Button Btn_BelumCO;
        private TabPage tabPage1;
        private Button btn_PesanProduk;
        private Panel panel2;
        private Label label1;
        private Label usernameShow;
        private Panel panel3;
        private DataGridView Dgv_BarangTani;
        private Button btn_LihatProdukTani;
        private Button btn_LihatAlatSewa;
        private TabControl Tc_Petani;
        private Button btn_TransaksiBerlangsung;
        private Button btn_TagihanDenda;
        private Button btn_RiwayatTransaksi;
    }
}