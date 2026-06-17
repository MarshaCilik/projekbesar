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
using WinFormsApp1.Models.User;
using WinFormsApp1.View;
using WinFormsApp1.View.Kerjaan_Tiwi;

namespace WinFormsApp1.View
{
    partial class Dashboard_Karyawan
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
            pictureBox1 = new PictureBox();
            label1 = new Label();
            panel3 = new Panel();
            btnProfil = new Button();
            btnLaporan = new Button();
            btnDistribusi = new Button();
            btnUpdateStok = new Button();
            btnDashboardKaryawan = new Button();
            Logout = new PictureBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtJumlahPesanan = new TextBox();
            Lbl_DetailPesanan = new Label();
            label29 = new Label();
            button20 = new Button();
            txtNamaKaryawan1 = new TextBox();
            txtJumlahDiantar = new TextBox();
            txtJumlahTransaksi = new TextBox();
            button2 = new Button();
            label12 = new Label();
            label13 = new Label();
            dtpDashboard = new DateTimePicker();
            label14 = new Label();
            button3 = new Button();
            pictureBox2 = new PictureBox();
            panel5 = new Panel();
            label15 = new Label();
            label16 = new Label();
            panel6 = new Panel();
            btnSewaSelesai = new Button();
            btnTransaksi = new Button();
            btnPembayaran = new Button();
            btnRefresh1 = new Button();
            txtCariID = new MaskedTextBox();
            dgvDashboard = new DataGridView();
            tabPage2 = new TabPage();
            panel13 = new Panel();
            btnUpdate = new Button();
            btnRefresh2 = new Button();
            txtCariNamaBarang2 = new MaskedTextBox();
            btnAlatSewa2 = new Button();
            btnProduk1 = new Button();
            dgvUpdateStok = new DataGridView();
            txtNamaKaryawan2 = new TextBox();
            label27 = new Label();
            pictureBox5 = new PictureBox();
            button13 = new Button();
            tabPage3 = new TabPage();
            panel1 = new Panel();
            btnRefresh3 = new Button();
            txtCariID3 = new MaskedTextBox();
            btnKirim = new Button();
            dgvDistribusi = new DataGridView();
            txtNamaKaryawan3 = new TextBox();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            button9 = new Button();
            tabPage4 = new TabPage();
            tcLaporan = new TabControl();
            tabPage6 = new TabPage();
            panel2 = new Panel();
            dgvTransaksi = new DataGridView();
            panel23 = new Panel();
            Lbl_JumlahTransaksi = new Label();
            Lbl_Pemasukan = new Label();
            label31 = new Label();
            label30 = new Label();
            btn_Refresh41 = new Button();
            txt_CariID41 = new TextBox();
            btn_Filter41 = new Button();
            label4 = new Label();
            dtp_KeTanggal = new DateTimePicker();
            label3 = new Label();
            dtp_DariTanggal = new DateTimePicker();
            label2 = new Label();
            tabPage7 = new TabPage();
            btnAlat42 = new Button();
            btnProduk42 = new Button();
            Lbl_Stok = new Label();
            dgvStok = new DataGridView();
            tabPage8 = new TabPage();
            btnLunas = new Button();
            txtCariNamaDenda = new TextBox();
            label11 = new Label();
            dgvDenda = new DataGridView();
            btnLaporanDenda = new Button();
            txtNamaKaryawan4 = new TextBox();
            label10 = new Label();
            btnLaporanTransaksi = new Button();
            pictureBox6 = new PictureBox();
            button8 = new Button();
            btnLaporanStok = new Button();
            tabPage5 = new TabPage();
            pictureBox4 = new PictureBox();
            panel4 = new Panel();
            label6 = new Label();
            panel7 = new Panel();
            btnBatal = new Button();
            btnSimpan = new Button();
            btnEdit = new Button();
            label24 = new Label();
            chkStatusAktif = new CheckBox();
            label7 = new Label();
            label8 = new Label();
            label9 = new Label();
            label19 = new Label();
            panel9 = new Panel();
            txtNama = new TextBox();
            label20 = new Label();
            label21 = new Label();
            label22 = new Label();
            label23 = new Label();
            label25 = new Label();
            panel8 = new Panel();
            txtUsername = new TextBox();
            panel10 = new Panel();
            txtDesa = new TextBox();
            panel11 = new Panel();
            txtAlamat = new TextBox();
            panel12 = new Panel();
            txtKecamatan = new TextBox();
            panel15 = new Panel();
            panel16 = new Panel();
            txtPassword = new TextBox();
            panel17 = new Panel();
            txtNoTelp = new TextBox();
            panel18 = new Panel();
            txtEmail = new TextBox();
            panel19 = new Panel();
            label26 = new Label();
            btnUbahStatusTransaksi = new Label();
            ((ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            ((ISupportInitialize)Logout).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            ((ISupportInitialize)pictureBox2).BeginInit();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((ISupportInitialize)dgvDashboard).BeginInit();
            tabPage2.SuspendLayout();
            panel13.SuspendLayout();
            ((ISupportInitialize)dgvUpdateStok).BeginInit();
            ((ISupportInitialize)pictureBox5).BeginInit();
            tabPage3.SuspendLayout();
            panel1.SuspendLayout();
            ((ISupportInitialize)dgvDistribusi).BeginInit();
            ((ISupportInitialize)pictureBox3).BeginInit();
            tabPage4.SuspendLayout();
            tcLaporan.SuspendLayout();
            tabPage6.SuspendLayout();
            panel2.SuspendLayout();
            ((ISupportInitialize)dgvTransaksi).BeginInit();
            panel23.SuspendLayout();
            tabPage7.SuspendLayout();
            ((ISupportInitialize)dgvStok).BeginInit();
            tabPage8.SuspendLayout();
            ((ISupportInitialize)dgvDenda).BeginInit();
            ((ISupportInitialize)pictureBox6).BeginInit();
            tabPage5.SuspendLayout();
            ((ISupportInitialize)pictureBox4).BeginInit();
            panel4.SuspendLayout();
            panel7.SuspendLayout();
            panel9.SuspendLayout();
            panel8.SuspendLayout();
            panel10.SuspendLayout();
            panel11.SuspendLayout();
            panel12.SuspendLayout();
            panel16.SuspendLayout();
            panel17.SuspendLayout();
            panel18.SuspendLayout();
            panel19.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.PASTANI_DASHBOARD1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(27, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 76);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(13, -11);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 35;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(168, 197, 152);
            panel3.Controls.Add(btnProfil);
            panel3.Controls.Add(btnLaporan);
            panel3.Controls.Add(btnDistribusi);
            panel3.Controls.Add(btnUpdateStok);
            panel3.Controls.Add(btnDashboardKaryawan);
            panel3.Controls.Add(Logout);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 1005);
            panel3.TabIndex = 44;
            // 
            // btnProfil
            // 
            btnProfil.BackColor = Color.FromArgb(168, 197, 152);
            btnProfil.FlatAppearance.BorderSize = 0;
            btnProfil.FlatStyle = FlatStyle.Flat;
            btnProfil.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProfil.ForeColor = Color.FromArgb(49, 106, 14);
            btnProfil.Location = new Point(0, 333);
            btnProfil.Name = "btnProfil";
            btnProfil.Size = new Size(250, 50);
            btnProfil.TabIndex = 21;
            btnProfil.Text = "Profil";
            btnProfil.UseVisualStyleBackColor = false;
            btnProfil.Click += button7_Click;
            // 
            // btnLaporan
            // 
            btnLaporan.BackColor = Color.FromArgb(168, 197, 152);
            btnLaporan.FlatAppearance.BorderSize = 0;
            btnLaporan.FlatStyle = FlatStyle.Flat;
            btnLaporan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLaporan.ForeColor = Color.FromArgb(49, 106, 14);
            btnLaporan.Location = new Point(3, 277);
            btnLaporan.Name = "btnLaporan";
            btnLaporan.Size = new Size(250, 50);
            btnLaporan.TabIndex = 20;
            btnLaporan.Text = "Laporan dan Rekap";
            btnLaporan.UseVisualStyleBackColor = false;
            btnLaporan.Click += btnLaporan_Click;
            // 
            // btnDistribusi
            // 
            btnDistribusi.BackColor = Color.FromArgb(168, 197, 152);
            btnDistribusi.FlatAppearance.BorderSize = 0;
            btnDistribusi.FlatStyle = FlatStyle.Flat;
            btnDistribusi.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDistribusi.ForeColor = Color.FromArgb(49, 106, 14);
            btnDistribusi.Location = new Point(3, 221);
            btnDistribusi.Name = "btnDistribusi";
            btnDistribusi.Size = new Size(250, 50);
            btnDistribusi.TabIndex = 19;
            btnDistribusi.Text = "Manajemen Distribusi";
            btnDistribusi.UseVisualStyleBackColor = false;
            // 
            // btnUpdateStok
            // 
            btnUpdateStok.BackColor = Color.FromArgb(168, 197, 152);
            btnUpdateStok.FlatAppearance.BorderSize = 0;
            btnUpdateStok.FlatStyle = FlatStyle.Flat;
            btnUpdateStok.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdateStok.ForeColor = Color.FromArgb(49, 106, 14);
            btnUpdateStok.Location = new Point(3, 175);
            btnUpdateStok.Name = "btnUpdateStok";
            btnUpdateStok.Size = new Size(250, 50);
            btnUpdateStok.TabIndex = 18;
            btnUpdateStok.Text = "Update Stok";
            btnUpdateStok.UseVisualStyleBackColor = false;
            // 
            // btnDashboardKaryawan
            // 
            btnDashboardKaryawan.BackColor = Color.FromArgb(49, 106, 14);
            btnDashboardKaryawan.FlatAppearance.BorderSize = 0;
            btnDashboardKaryawan.FlatStyle = FlatStyle.Flat;
            btnDashboardKaryawan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDashboardKaryawan.ForeColor = SystemColors.ButtonHighlight;
            btnDashboardKaryawan.Location = new Point(3, 119);
            btnDashboardKaryawan.Name = "btnDashboardKaryawan";
            btnDashboardKaryawan.Size = new Size(250, 50);
            btnDashboardKaryawan.TabIndex = 17;
            btnDashboardKaryawan.Text = "Dashboard";
            btnDashboardKaryawan.UseVisualStyleBackColor = false;
            // 
            // Logout
            // 
            Logout.BackgroundImage = Properties.Resources.Group_5;
            Logout.BackgroundImageLayout = ImageLayout.Zoom;
            Logout.Location = new Point(12, 939);
            Logout.Name = "Logout";
            Logout.Size = new Size(107, 46);
            Logout.TabIndex = 15;
            Logout.TabStop = false;
            Logout.Click += Logout_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(263, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1003, 986);
            tabControl1.TabIndex = 56;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtJumlahPesanan);
            tabPage1.Controls.Add(Lbl_DetailPesanan);
            tabPage1.Controls.Add(label29);
            tabPage1.Controls.Add(button20);
            tabPage1.Controls.Add(txtNamaKaryawan1);
            tabPage1.Controls.Add(txtJumlahDiantar);
            tabPage1.Controls.Add(txtJumlahTransaksi);
            tabPage1.Controls.Add(button2);
            tabPage1.Controls.Add(label12);
            tabPage1.Controls.Add(label13);
            tabPage1.Controls.Add(dtpDashboard);
            tabPage1.Controls.Add(label14);
            tabPage1.Controls.Add(button3);
            tabPage1.Controls.Add(pictureBox2);
            tabPage1.Controls.Add(panel5);
            tabPage1.Controls.Add(panel6);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(995, 958);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "tabPage1";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtJumlahPesanan
            // 
            txtJumlahPesanan.Font = new Font("Segoe UI", 36F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtJumlahPesanan.Location = new Point(736, 187);
            txtJumlahPesanan.Name = "txtJumlahPesanan";
            txtJumlahPesanan.Size = new Size(128, 71);
            txtJumlahPesanan.TabIndex = 71;
            // 
            // Lbl_DetailPesanan
            // 
            Lbl_DetailPesanan.AutoSize = true;
            Lbl_DetailPesanan.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_DetailPesanan.Location = new Point(736, 287);
            Lbl_DetailPesanan.Name = "Lbl_DetailPesanan";
            Lbl_DetailPesanan.Size = new Size(143, 13);
            Lbl_DetailPesanan.TabIndex = 70;
            Lbl_DetailPesanan.Text = "Ketuk untuk melihat detail";
            Lbl_DetailPesanan.Click += Lbl_DetailPesanan_Click;
            // 
            // label29
            // 
            label29.AutoSize = true;
            label29.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label29.Location = new Point(736, 119);
            label29.Name = "label29";
            label29.Size = new Size(128, 21);
            label29.TabIndex = 69;
            label29.Text = "Pesanan Masuk";
            // 
            // button20
            // 
            button20.BackColor = Color.FromArgb(217, 217, 217);
            button20.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button20.Location = new Point(707, 158);
            button20.Name = "button20";
            button20.Size = new Size(190, 127);
            button20.TabIndex = 68;
            button20.UseVisualStyleBackColor = false;
            // 
            // txtNamaKaryawan1
            // 
            txtNamaKaryawan1.Location = new Point(27, 287);
            txtNamaKaryawan1.Name = "txtNamaKaryawan1";
            txtNamaKaryawan1.ReadOnly = true;
            txtNamaKaryawan1.Size = new Size(256, 23);
            txtNamaKaryawan1.TabIndex = 67;
            // 
            // txtJumlahDiantar
            // 
            txtJumlahDiantar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtJumlahDiantar.Location = new Point(524, 232);
            txtJumlahDiantar.Name = "txtJumlahDiantar";
            txtJumlahDiantar.Size = new Size(100, 33);
            txtJumlahDiantar.TabIndex = 66;
            // 
            // txtJumlahTransaksi
            // 
            txtJumlahTransaksi.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtJumlahTransaksi.Location = new Point(344, 232);
            txtJumlahTransaksi.Name = "txtJumlahTransaksi";
            txtJumlahTransaksi.Size = new Size(100, 33);
            txtJumlahTransaksi.TabIndex = 65;
            txtJumlahTransaksi.TextChanged += txtJumlahTransaksi_TextChanged;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(217, 217, 217);
            button2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.Location = new Point(318, 211);
            button2.Name = "button2";
            button2.Size = new Size(153, 74);
            button2.TabIndex = 64;
            button2.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.Location = new Point(507, 187);
            label12.Name = "label12";
            label12.Size = new Size(135, 21);
            label12.TabIndex = 63;
            label12.Text = "Pesanan Diantar";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(318, 183);
            label13.Name = "label13";
            label13.Size = new Size(144, 42);
            label13.TabIndex = 62;
            label13.Text = "Jumlah Transaksi \r\n\r\n";
            // 
            // dtpDashboard
            // 
            dtpDashboard.Location = new Point(385, 119);
            dtpDashboard.Name = "dtpDashboard";
            dtpDashboard.Size = new Size(200, 23);
            dtpDashboard.TabIndex = 61;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.Location = new Point(301, 117);
            label14.Name = "label14";
            label14.Size = new Size(78, 25);
            label14.TabIndex = 60;
            label14.Text = "Tanggal";
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(217, 217, 217);
            button3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.Location = new Point(502, 211);
            button3.Name = "button3";
            button3.Size = new Size(147, 74);
            button3.TabIndex = 56;
            button3.UseVisualStyleBackColor = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.Proifl;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(78, 104);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(162, 166);
            pictureBox2.TabIndex = 59;
            pictureBox2.TabStop = false;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel5.BackColor = Color.FromArgb(49, 106, 14);
            panel5.Controls.Add(label15);
            panel5.Controls.Add(label16);
            panel5.Location = new Point(3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(982, 93);
            panel5.TabIndex = 57;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.BackColor = Color.Transparent;
            label15.FlatStyle = FlatStyle.Flat;
            label15.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = SystemColors.ButtonHighlight;
            label15.Location = new Point(24, 49);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(546, 21);
            label15.TabIndex = 2;
            label15.Text = "Selamat datang di ruang kerja digital Anda. Mari mulai hari dengan semangat";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.BackColor = Color.Transparent;
            label16.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = SystemColors.ButtonHighlight;
            label16.Location = new Point(24, 18);
            label16.Margin = new Padding(2, 0, 2, 0);
            label16.Name = "label16";
            label16.Size = new Size(216, 31);
            label16.TabIndex = 1;
            label16.Text = "Selamat Datang!";
            // 
            // panel6
            // 
            panel6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel6.BackColor = Color.FromArgb(122, 148, 114);
            panel6.Controls.Add(btnSewaSelesai);
            panel6.Controls.Add(btnTransaksi);
            panel6.Controls.Add(btnPembayaran);
            panel6.Controls.Add(btnRefresh1);
            panel6.Controls.Add(txtCariID);
            panel6.Controls.Add(dgvDashboard);
            panel6.Location = new Point(16, 332);
            panel6.Name = "panel6";
            panel6.Size = new Size(958, 651);
            panel6.TabIndex = 58;
            // 
            // btnSewaSelesai
            // 
            btnSewaSelesai.Location = new Point(11, 45);
            btnSewaSelesai.Name = "btnSewaSelesai";
            btnSewaSelesai.Size = new Size(132, 23);
            btnSewaSelesai.TabIndex = 104;
            btnSewaSelesai.Text = "Sewa Selesai";
            btnSewaSelesai.UseVisualStyleBackColor = true;
            // 
            // btnTransaksi
            // 
            btnTransaksi.Anchor = AnchorStyles.Right;
            btnTransaksi.BackColor = Color.FromArgb(168, 197, 152);
            btnTransaksi.BackgroundImageLayout = ImageLayout.None;
            btnTransaksi.Location = new Point(751, 12);
            btnTransaksi.Name = "btnTransaksi";
            btnTransaksi.Size = new Size(172, 34);
            btnTransaksi.TabIndex = 100;
            btnTransaksi.Text = "Ubah Status Transaksi";
            btnTransaksi.UseVisualStyleBackColor = false;
            // 
            // btnPembayaran
            // 
            btnPembayaran.Anchor = AnchorStyles.Right;
            btnPembayaran.BackColor = Color.FromArgb(168, 197, 152);
            btnPembayaran.Location = new Point(587, 12);
            btnPembayaran.Name = "btnPembayaran";
            btnPembayaran.Size = new Size(158, 35);
            btnPembayaran.TabIndex = 99;
            btnPembayaran.Text = "Ubah Status Pembayaran";
            btnPembayaran.UseVisualStyleBackColor = false;
            // 
            // btnRefresh1
            // 
            btnRefresh1.Location = new Point(382, 12);
            btnRefresh1.Name = "btnRefresh1";
            btnRefresh1.Size = new Size(73, 23);
            btnRefresh1.TabIndex = 98;
            btnRefresh1.Text = "Refresh";
            btnRefresh1.UseVisualStyleBackColor = true;
            // 
            // txtCariID
            // 
            txtCariID.Location = new Point(11, 13);
            txtCariID.Name = "txtCariID";
            txtCariID.Size = new Size(361, 23);
            txtCariID.TabIndex = 96;
            txtCariID.Text = "Cari ID Transaksi";
            // 
            // dgvDashboard
            // 
            dgvDashboard.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvDashboard.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvDashboard.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDashboard.Location = new Point(11, 74);
            dgvDashboard.Name = "dgvDashboard";
            dgvDashboard.Size = new Size(923, 556);
            dgvDashboard.TabIndex = 58;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(panel13);
            tabPage2.Controls.Add(txtNamaKaryawan2);
            tabPage2.Controls.Add(label27);
            tabPage2.Controls.Add(pictureBox5);
            tabPage2.Controls.Add(button13);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(995, 958);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            panel13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel13.BackColor = Color.FromArgb(122, 148, 114);
            panel13.Controls.Add(btnUpdate);
            panel13.Controls.Add(btnRefresh2);
            panel13.Controls.Add(txtCariNamaBarang2);
            panel13.Controls.Add(btnAlatSewa2);
            panel13.Controls.Add(btnProduk1);
            panel13.Controls.Add(dgvUpdateStok);
            panel13.Location = new Point(6, 113);
            panel13.Name = "panel13";
            panel13.Size = new Size(979, 839);
            panel13.TabIndex = 94;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.Right;
            btnUpdate.Location = new Point(820, 33);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(140, 42);
            btnUpdate.TabIndex = 96;
            btnUpdate.Text = "Update Stok";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnRefresh2
            // 
            btnRefresh2.Location = new Point(377, 52);
            btnRefresh2.Name = "btnRefresh2";
            btnRefresh2.Size = new Size(79, 23);
            btnRefresh2.TabIndex = 95;
            btnRefresh2.Text = "Refresh";
            btnRefresh2.UseVisualStyleBackColor = true;
            // 
            // txtCariNamaBarang2
            // 
            txtCariNamaBarang2.Location = new Point(10, 52);
            txtCariNamaBarang2.Name = "txtCariNamaBarang2";
            txtCariNamaBarang2.Size = new Size(361, 23);
            txtCariNamaBarang2.TabIndex = 62;
            txtCariNamaBarang2.Text = "Cari Nama Produk/Alat";
            // 
            // btnAlatSewa2
            // 
            btnAlatSewa2.ForeColor = Color.FromArgb(49, 106, 14);
            btnAlatSewa2.Location = new Point(109, 6);
            btnAlatSewa2.Name = "btnAlatSewa2";
            btnAlatSewa2.Size = new Size(92, 34);
            btnAlatSewa2.TabIndex = 60;
            btnAlatSewa2.Text = "Alat Sewa";
            btnAlatSewa2.UseVisualStyleBackColor = true;
            // 
            // btnProduk1
            // 
            btnProduk1.BackColor = Color.FromArgb(49, 106, 14);
            btnProduk1.ForeColor = Color.White;
            btnProduk1.Location = new Point(10, 6);
            btnProduk1.Name = "btnProduk1";
            btnProduk1.Size = new Size(93, 34);
            btnProduk1.TabIndex = 59;
            btnProduk1.Text = "Produk";
            btnProduk1.UseVisualStyleBackColor = false;
            // 
            // dgvUpdateStok
            // 
            dgvUpdateStok.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvUpdateStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvUpdateStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUpdateStok.Location = new Point(3, 94);
            dgvUpdateStok.Name = "dgvUpdateStok";
            dgvUpdateStok.Size = new Size(973, 751);
            dgvUpdateStok.TabIndex = 58;
            dgvUpdateStok.CellContentClick += dgvUpdateStok_CellContentClick;
            // 
            // txtNamaKaryawan2
            // 
            txtNamaKaryawan2.Location = new Point(75, 11);
            txtNamaKaryawan2.Name = "txtNamaKaryawan2";
            txtNamaKaryawan2.ReadOnly = true;
            txtNamaKaryawan2.Size = new Size(256, 23);
            txtNamaKaryawan2.TabIndex = 93;
            // 
            // label27
            // 
            label27.Anchor = AnchorStyles.None;
            label27.AutoSize = true;
            label27.BackColor = Color.FromArgb(49, 106, 14);
            label27.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label27.ForeColor = Color.White;
            label27.Location = new Point(437, 63);
            label27.Name = "label27";
            label27.Size = new Size(123, 25);
            label27.TabIndex = 91;
            label27.Text = "Update Stok";
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.Proifl;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(37, 6);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(32, 32);
            pictureBox5.TabIndex = 90;
            pictureBox5.TabStop = false;
            // 
            // button13
            // 
            button13.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button13.BackColor = Color.FromArgb(49, 106, 14);
            button13.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button13.Location = new Point(6, 45);
            button13.Name = "button13";
            button13.Size = new Size(983, 62);
            button13.TabIndex = 92;
            button13.UseVisualStyleBackColor = false;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(panel1);
            tabPage3.Controls.Add(txtNamaKaryawan3);
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(pictureBox3);
            tabPage3.Controls.Add(button9);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(995, 958);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "tabPage3";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(122, 148, 114);
            panel1.Controls.Add(btnRefresh3);
            panel1.Controls.Add(txtCariID3);
            panel1.Controls.Add(btnKirim);
            panel1.Controls.Add(dgvDistribusi);
            panel1.Location = new Point(6, 123);
            panel1.Name = "panel1";
            panel1.Size = new Size(979, 839);
            panel1.TabIndex = 89;
            // 
            // btnRefresh3
            // 
            btnRefresh3.Location = new Point(376, 25);
            btnRefresh3.Name = "btnRefresh3";
            btnRefresh3.Size = new Size(118, 23);
            btnRefresh3.TabIndex = 98;
            btnRefresh3.Text = "Refresh";
            btnRefresh3.UseVisualStyleBackColor = true;
            // 
            // txtCariID3
            // 
            txtCariID3.Location = new Point(9, 26);
            txtCariID3.Name = "txtCariID3";
            txtCariID3.Size = new Size(361, 23);
            txtCariID3.TabIndex = 96;
            txtCariID3.Text = "Cari ID Transaksi";
            // 
            // btnKirim
            // 
            btnKirim.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnKirim.BackColor = Color.FromArgb(49, 106, 14);
            btnKirim.Cursor = Cursors.Hand;
            btnKirim.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnKirim.ForeColor = Color.White;
            btnKirim.Location = new Point(786, 25);
            btnKirim.Name = "btnKirim";
            btnKirim.Size = new Size(180, 35);
            btnKirim.TabIndex = 99;
            btnKirim.Text = "Kirim / Update Status";
            btnKirim.UseVisualStyleBackColor = false;
            // 
            // dgvDistribusi
            // 
            dgvDistribusi.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvDistribusi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvDistribusi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDistribusi.Location = new Point(3, 71);
            dgvDistribusi.Name = "dgvDistribusi";
            dgvDistribusi.Size = new Size(973, 761);
            dgvDistribusi.TabIndex = 58;
            // 
            // txtNamaKaryawan3
            // 
            txtNamaKaryawan3.Location = new Point(75, 21);
            txtNamaKaryawan3.Name = "txtNamaKaryawan3";
            txtNamaKaryawan3.ReadOnly = true;
            txtNamaKaryawan3.Size = new Size(256, 23);
            txtNamaKaryawan3.TabIndex = 87;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.None;
            label5.AutoSize = true;
            label5.BackColor = Color.FromArgb(49, 106, 14);
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(378, 73);
            label5.Name = "label5";
            label5.Size = new Size(205, 25);
            label5.TabIndex = 85;
            label5.Text = "Manajemen Distribusi";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.Proifl;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(37, 16);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(32, 32);
            pictureBox3.TabIndex = 84;
            pictureBox3.TabStop = false;
            // 
            // button9
            // 
            button9.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button9.BackColor = Color.FromArgb(49, 106, 14);
            button9.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button9.Location = new Point(6, 55);
            button9.Name = "button9";
            button9.Size = new Size(983, 62);
            button9.TabIndex = 86;
            button9.UseVisualStyleBackColor = false;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(tcLaporan);
            tabPage4.Controls.Add(btnLaporanDenda);
            tabPage4.Controls.Add(txtNamaKaryawan4);
            tabPage4.Controls.Add(label10);
            tabPage4.Controls.Add(btnLaporanTransaksi);
            tabPage4.Controls.Add(pictureBox6);
            tabPage4.Controls.Add(button8);
            tabPage4.Controls.Add(btnLaporanStok);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(995, 958);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "tabPage4";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // tcLaporan
            // 
            tcLaporan.Controls.Add(tabPage6);
            tcLaporan.Controls.Add(tabPage7);
            tcLaporan.Controls.Add(tabPage8);
            tcLaporan.Location = new Point(3, 165);
            tcLaporan.Name = "tcLaporan";
            tcLaporan.SelectedIndex = 0;
            tcLaporan.Size = new Size(984, 797);
            tcLaporan.TabIndex = 87;
            // 
            // tabPage6
            // 
            tabPage6.Controls.Add(panel2);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(976, 769);
            tabPage6.TabIndex = 0;
            tabPage6.Text = "tabPage6";
            tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(122, 148, 114);
            panel2.Controls.Add(dgvTransaksi);
            panel2.Controls.Add(panel23);
            panel2.Controls.Add(btn_Refresh41);
            panel2.Controls.Add(txt_CariID41);
            panel2.Controls.Add(btn_Filter41);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(dtp_KeTanggal);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(dtp_DariTanggal);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(8, 6);
            panel2.Name = "panel2";
            panel2.Size = new Size(978, 777);
            panel2.TabIndex = 78;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvTransaksi.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvTransaksi.BackgroundColor = SystemColors.ButtonHighlight;
            dgvTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaksi.Location = new Point(74, 206);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.Size = new Size(846, 437);
            dgvTransaksi.TabIndex = 96;
            // 
            // panel23
            // 
            panel23.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel23.BackColor = Color.FromArgb(192, 255, 192);
            panel23.Controls.Add(Lbl_JumlahTransaksi);
            panel23.Controls.Add(Lbl_Pemasukan);
            panel23.Controls.Add(label31);
            panel23.Controls.Add(label30);
            panel23.Location = new Point(74, 649);
            panel23.Name = "panel23";
            panel23.Size = new Size(846, 111);
            panel23.TabIndex = 95;
            // 
            // Lbl_JumlahTransaksi
            // 
            Lbl_JumlahTransaksi.AutoSize = true;
            Lbl_JumlahTransaksi.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_JumlahTransaksi.Location = new Point(37, 63);
            Lbl_JumlahTransaksi.Name = "Lbl_JumlahTransaksi";
            Lbl_JumlahTransaksi.Size = new Size(154, 32);
            Lbl_JumlahTransaksi.TabIndex = 3;
            Lbl_JumlahTransaksi.Text = "50 Transaksi";
            // 
            // Lbl_Pemasukan
            // 
            Lbl_Pemasukan.AutoSize = true;
            Lbl_Pemasukan.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Pemasukan.Location = new Point(654, 63);
            Lbl_Pemasukan.Name = "Lbl_Pemasukan";
            Lbl_Pemasukan.Size = new Size(143, 32);
            Lbl_Pemasukan.TabIndex = 2;
            Lbl_Pemasukan.Text = "Rp 100.000";
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label31.Location = new Point(642, 27);
            label31.Name = "label31";
            label31.Size = new Size(155, 25);
            label31.TabIndex = 1;
            label31.Text = "Total Pemasukan";
            // 
            // label30
            // 
            label30.AutoSize = true;
            label30.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(44, 27);
            label30.Name = "label30";
            label30.Size = new Size(135, 25);
            label30.TabIndex = 0;
            label30.Text = "Total Transaksi";
            // 
            // btn_Refresh41
            // 
            btn_Refresh41.Anchor = AnchorStyles.Right;
            btn_Refresh41.Location = new Point(802, 167);
            btn_Refresh41.Name = "btn_Refresh41";
            btn_Refresh41.Size = new Size(118, 23);
            btn_Refresh41.TabIndex = 93;
            btn_Refresh41.Text = "Refresh";
            btn_Refresh41.UseVisualStyleBackColor = true;
            // 
            // txt_CariID41
            // 
            txt_CariID41.Location = new Point(74, 177);
            txt_CariID41.Name = "txt_CariID41";
            txt_CariID41.Size = new Size(267, 23);
            txt_CariID41.TabIndex = 92;
            txt_CariID41.Text = "Cari Berdasarkan Id";
            // 
            // btn_Filter41
            // 
            btn_Filter41.Anchor = AnchorStyles.Right;
            btn_Filter41.Location = new Point(664, 167);
            btn_Filter41.Name = "btn_Filter41";
            btn_Filter41.Size = new Size(118, 23);
            btn_Filter41.TabIndex = 91;
            btn_Filter41.Text = "Terapkan Filter";
            btn_Filter41.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(302, 112);
            label4.Name = "label4";
            label4.Size = new Size(76, 17);
            label4.TabIndex = 90;
            label4.Text = "Ke Tanggal";
            // 
            // dtp_KeTanggal
            // 
            dtp_KeTanggal.Location = new Point(302, 132);
            dtp_KeTanggal.Name = "dtp_KeTanggal";
            dtp_KeTanggal.Size = new Size(200, 23);
            dtp_KeTanggal.TabIndex = 89;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(74, 112);
            label3.Name = "label3";
            label3.Size = new Size(91, 17);
            label3.TabIndex = 87;
            label3.Text = "Dari Tanggal:";
            // 
            // dtp_DariTanggal
            // 
            dtp_DariTanggal.Location = new Point(74, 132);
            dtp_DariTanggal.Name = "dtp_DariTanggal";
            dtp_DariTanggal.Size = new Size(200, 23);
            dtp_DariTanggal.TabIndex = 88;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(49, 106, 14);
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(346, 38);
            label2.Name = "label2";
            label2.Size = new Size(273, 40);
            label2.TabIndex = 87;
            label2.Text = "Laporan Transaksi ";
            // 
            // tabPage7
            // 
            tabPage7.Controls.Add(btnAlat42);
            tabPage7.Controls.Add(btnProduk42);
            tabPage7.Controls.Add(Lbl_Stok);
            tabPage7.Controls.Add(dgvStok);
            tabPage7.Location = new Point(4, 24);
            tabPage7.Name = "tabPage7";
            tabPage7.Padding = new Padding(3);
            tabPage7.Size = new Size(976, 769);
            tabPage7.TabIndex = 1;
            tabPage7.Text = "tabPage7";
            tabPage7.UseVisualStyleBackColor = true;
            // 
            // btnAlat42
            // 
            btnAlat42.Location = new Point(111, 66);
            btnAlat42.Name = "btnAlat42";
            btnAlat42.Size = new Size(75, 23);
            btnAlat42.TabIndex = 62;
            btnAlat42.Text = "Alat Sewa";
            btnAlat42.UseVisualStyleBackColor = true;
            // 
            // btnProduk42
            // 
            btnProduk42.Location = new Point(21, 66);
            btnProduk42.Name = "btnProduk42";
            btnProduk42.Size = new Size(75, 23);
            btnProduk42.TabIndex = 61;
            btnProduk42.Text = "Produk";
            btnProduk42.UseVisualStyleBackColor = true;
            // 
            // Lbl_Stok
            // 
            Lbl_Stok.Anchor = AnchorStyles.None;
            Lbl_Stok.AutoSize = true;
            Lbl_Stok.BackColor = Color.FromArgb(49, 106, 14);
            Lbl_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Lbl_Stok.ForeColor = Color.White;
            Lbl_Stok.Location = new Point(395, 23);
            Lbl_Stok.Name = "Lbl_Stok";
            Lbl_Stok.Size = new Size(163, 32);
            Lbl_Stok.TabIndex = 60;
            Lbl_Stok.Text = "Laporan Stok";
            // 
            // dgvStok
            // 
            dgvStok.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvStok.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStok.Location = new Point(17, 97);
            dgvStok.Name = "dgvStok";
            dgvStok.Size = new Size(948, 745);
            dgvStok.TabIndex = 59;
            // 
            // tabPage8
            // 
            tabPage8.Controls.Add(btnLunas);
            tabPage8.Controls.Add(txtCariNamaDenda);
            tabPage8.Controls.Add(label11);
            tabPage8.Controls.Add(dgvDenda);
            tabPage8.Location = new Point(4, 24);
            tabPage8.Name = "tabPage8";
            tabPage8.Padding = new Padding(3);
            tabPage8.Size = new Size(976, 769);
            tabPage8.TabIndex = 2;
            tabPage8.Text = "tabPage8";
            tabPage8.UseVisualStyleBackColor = true;
            // 
            // btnLunas
            // 
            btnLunas.Anchor = AnchorStyles.Right;
            btnLunas.Location = new Point(868, 67);
            btnLunas.Name = "btnLunas";
            btnLunas.Size = new Size(86, 38);
            btnLunas.TabIndex = 63;
            btnLunas.Text = "Lunas";
            btnLunas.UseVisualStyleBackColor = true;
            // 
            // txtCariNamaDenda
            // 
            txtCariNamaDenda.Location = new Point(15, 76);
            txtCariNamaDenda.Name = "txtCariNamaDenda";
            txtCariNamaDenda.Size = new Size(328, 23);
            txtCariNamaDenda.TabIndex = 62;
            txtCariNamaDenda.Text = "Cari Nama Petani";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.None;
            label11.AutoSize = true;
            label11.BackColor = Color.FromArgb(49, 106, 14);
            label11.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(386, 23);
            label11.Name = "label11";
            label11.Size = new Size(188, 32);
            label11.TabIndex = 61;
            label11.Text = "Laporan Denda";
            // 
            // dgvDenda
            // 
            dgvDenda.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            dgvDenda.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvDenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDenda.Location = new Point(6, 112);
            dgvDenda.Name = "dgvDenda";
            dgvDenda.Size = new Size(964, 717);
            dgvDenda.TabIndex = 60;
            // 
            // btnLaporanDenda
            // 
            btnLaporanDenda.BackColor = SystemColors.ButtonFace;
            btnLaporanDenda.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanDenda.ForeColor = Color.FromArgb(49, 106, 14);
            btnLaporanDenda.Location = new Point(339, 129);
            btnLaporanDenda.Name = "btnLaporanDenda";
            btnLaporanDenda.Size = new Size(137, 39);
            btnLaporanDenda.TabIndex = 86;
            btnLaporanDenda.Text = "Denda";
            btnLaporanDenda.UseVisualStyleBackColor = false;
            // 
            // txtNamaKaryawan4
            // 
            txtNamaKaryawan4.Location = new Point(62, 25);
            txtNamaKaryawan4.Name = "txtNamaKaryawan4";
            txtNamaKaryawan4.ReadOnly = true;
            txtNamaKaryawan4.Size = new Size(256, 23);
            txtNamaKaryawan4.TabIndex = 83;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.None;
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(49, 106, 14);
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(393, 77);
            label10.Name = "label10";
            label10.Size = new Size(185, 25);
            label10.TabIndex = 80;
            label10.Text = "Laporan dan Rekap";
            // 
            // btnLaporanTransaksi
            // 
            btnLaporanTransaksi.BackColor = Color.FromArgb(49, 106, 14);
            btnLaporanTransaksi.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanTransaksi.ForeColor = Color.FromArgb(49, 106, 14);
            btnLaporanTransaksi.Location = new Point(32, 129);
            btnLaporanTransaksi.Name = "btnLaporanTransaksi";
            btnLaporanTransaksi.Size = new Size(137, 39);
            btnLaporanTransaksi.TabIndex = 77;
            btnLaporanTransaksi.Text = "Transaksi";
            btnLaporanTransaksi.UseVisualStyleBackColor = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.Proifl;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(24, 20);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(32, 32);
            pictureBox6.TabIndex = 79;
            pictureBox6.TabStop = false;
            // 
            // button8
            // 
            button8.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button8.BackColor = Color.FromArgb(49, 106, 14);
            button8.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button8.Location = new Point(7, 59);
            button8.Name = "button8";
            button8.Size = new Size(976, 62);
            button8.TabIndex = 82;
            button8.UseVisualStyleBackColor = false;
            // 
            // btnLaporanStok
            // 
            btnLaporanStok.BackColor = SystemColors.ButtonFace;
            btnLaporanStok.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanStok.ForeColor = Color.FromArgb(49, 106, 14);
            btnLaporanStok.Location = new Point(185, 129);
            btnLaporanStok.Name = "btnLaporanStok";
            btnLaporanStok.Size = new Size(137, 39);
            btnLaporanStok.TabIndex = 85;
            btnLaporanStok.Text = "Stok";
            btnLaporanStok.UseVisualStyleBackColor = false;
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(pictureBox4);
            tabPage5.Controls.Add(panel4);
            tabPage5.Controls.Add(panel7);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(995, 958);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "tabPage5";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.Proifl;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(46, 135);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(162, 166);
            pictureBox4.TabIndex = 64;
            pictureBox4.TabStop = false;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.BackColor = Color.FromArgb(49, 106, 14);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(13, 3);
            panel4.Name = "panel4";
            panel4.Size = new Size(968, 71);
            panel4.TabIndex = 62;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Microsoft Sans Serif", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(386, 23);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(196, 31);
            label6.TabIndex = 1;
            label6.Text = "PROFIL ANDA";
            // 
            // panel7
            // 
            panel7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panel7.BackColor = Color.FromArgb(122, 148, 114);
            panel7.Controls.Add(btnBatal);
            panel7.Controls.Add(btnSimpan);
            panel7.Controls.Add(btnEdit);
            panel7.Controls.Add(label24);
            panel7.Controls.Add(chkStatusAktif);
            panel7.Controls.Add(label7);
            panel7.Controls.Add(label8);
            panel7.Controls.Add(label9);
            panel7.Controls.Add(label19);
            panel7.Controls.Add(panel9);
            panel7.Controls.Add(label20);
            panel7.Controls.Add(label21);
            panel7.Controls.Add(label22);
            panel7.Controls.Add(label23);
            panel7.Controls.Add(label25);
            panel7.Controls.Add(panel8);
            panel7.Controls.Add(panel10);
            panel7.Controls.Add(panel11);
            panel7.Controls.Add(panel12);
            panel7.Controls.Add(panel16);
            panel7.Controls.Add(panel17);
            panel7.Controls.Add(panel18);
            panel7.Controls.Add(panel19);
            panel7.Controls.Add(btnUbahStatusTransaksi);
            panel7.Location = new Point(271, 135);
            panel7.Name = "panel7";
            panel7.Size = new Size(689, 755);
            panel7.TabIndex = 63;
            // 
            // btnBatal
            // 
            btnBatal.BackColor = Color.FromArgb(255, 192, 192);
            btnBatal.Location = new Point(438, 657);
            btnBatal.Name = "btnBatal";
            btnBatal.Size = new Size(120, 43);
            btnBatal.TabIndex = 81;
            btnBatal.Text = "Batal";
            btnBatal.UseVisualStyleBackColor = false;
            // 
            // btnSimpan
            // 
            btnSimpan.BackColor = Color.FromArgb(192, 255, 192);
            btnSimpan.Location = new Point(118, 657);
            btnSimpan.Name = "btnSimpan";
            btnSimpan.Size = new Size(120, 43);
            btnSimpan.TabIndex = 62;
            btnSimpan.Text = "Simpan";
            btnSimpan.UseVisualStyleBackColor = false;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(625, 349);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(51, 31);
            btnEdit.TabIndex = 2;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.Location = new Point(70, 40);
            label24.Name = "label24";
            label24.Size = new Size(46, 15);
            label24.TabIndex = 80;
            label24.Text = "NAMA:";
            // 
            // chkStatusAktif
            // 
            chkStatusAktif.AutoSize = true;
            chkStatusAktif.Enabled = false;
            chkStatusAktif.Location = new Point(128, 617);
            chkStatusAktif.Name = "chkStatusAktif";
            chkStatusAktif.Size = new Size(57, 19);
            chkStatusAktif.TabIndex = 75;
            chkStatusAktif.Text = "AKTIF";
            chkStatusAktif.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(69, 618);
            label7.Name = "label7";
            label7.Size = new Size(53, 15);
            label7.TabIndex = 74;
            label7.Text = "STATUS:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(70, 536);
            label8.Name = "label8";
            label8.Size = new Size(80, 15);
            label8.TabIndex = 73;
            label8.Text = "KECAMATAN:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(70, 465);
            label9.Name = "label9";
            label9.Size = new Size(40, 15);
            label9.TabIndex = 72;
            label9.Text = "DESA:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(70, 395);
            label19.Name = "label19";
            label19.Size = new Size(101, 15);
            label19.TabIndex = 71;
            label19.Text = "ALAMAT(JALAN):";
            // 
            // panel9
            // 
            panel9.BackColor = Color.FromArgb(74, 103, 65);
            panel9.Controls.Add(txtNama);
            panel9.Location = new Point(69, 58);
            panel9.Name = "panel9";
            panel9.Size = new Size(549, 38);
            panel9.TabIndex = 58;
            // 
            // txtNama
            // 
            txtNama.BackColor = Color.FromArgb(74, 103, 65);
            txtNama.BorderStyle = BorderStyle.FixedSingle;
            txtNama.Location = new Point(14, 8);
            txtNama.Name = "txtNama";
            txtNama.ReadOnly = true;
            txtNama.Size = new Size(521, 23);
            txtNama.TabIndex = 0;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label20.Location = new Point(69, 327);
            label20.Name = "label20";
            label20.Size = new Size(76, 15);
            label20.TabIndex = 70;
            label20.Text = "PASSWORD:";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.Location = new Point(69, 258);
            label21.Name = "label21";
            label21.Size = new Size(74, 15);
            label21.TabIndex = 69;
            label21.Text = "USERNAME:";
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.Location = new Point(69, 178);
            label22.Name = "label22";
            label22.Size = new Size(45, 15);
            label22.TabIndex = 68;
            label22.Text = "EMAIL:";
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.Location = new Point(70, 115);
            label23.Name = "label23";
            label23.Size = new Size(60, 15);
            label23.TabIndex = 67;
            label23.Text = "NO. TELP:";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label25.Location = new Point(69, -12);
            label25.Name = "label25";
            label25.Size = new Size(46, 15);
            label25.TabIndex = 66;
            label25.Text = "NAMA:";
            // 
            // panel8
            // 
            panel8.BackColor = Color.FromArgb(74, 103, 65);
            panel8.Controls.Add(txtUsername);
            panel8.Location = new Point(69, 276);
            panel8.Name = "panel8";
            panel8.Size = new Size(549, 38);
            panel8.TabIndex = 61;
            // 
            // txtUsername
            // 
            txtUsername.BackColor = Color.FromArgb(74, 103, 65);
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Location = new Point(10, 8);
            txtUsername.Name = "txtUsername";
            txtUsername.ReadOnly = true;
            txtUsername.Size = new Size(521, 23);
            txtUsername.TabIndex = 3;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(74, 103, 65);
            panel10.Controls.Add(txtDesa);
            panel10.Location = new Point(69, 483);
            panel10.Name = "panel10";
            panel10.Size = new Size(549, 38);
            panel10.TabIndex = 64;
            // 
            // txtDesa
            // 
            txtDesa.BackColor = Color.FromArgb(74, 103, 65);
            txtDesa.BorderStyle = BorderStyle.FixedSingle;
            txtDesa.Location = new Point(11, 8);
            txtDesa.Name = "txtDesa";
            txtDesa.ReadOnly = true;
            txtDesa.Size = new Size(521, 23);
            txtDesa.TabIndex = 6;
            // 
            // panel11
            // 
            panel11.BackColor = Color.FromArgb(74, 103, 65);
            panel11.Controls.Add(txtAlamat);
            panel11.Location = new Point(69, 413);
            panel11.Name = "panel11";
            panel11.Size = new Size(549, 38);
            panel11.TabIndex = 63;
            // 
            // txtAlamat
            // 
            txtAlamat.BackColor = Color.FromArgb(74, 103, 65);
            txtAlamat.BorderStyle = BorderStyle.FixedSingle;
            txtAlamat.Location = new Point(11, 9);
            txtAlamat.Name = "txtAlamat";
            txtAlamat.ReadOnly = true;
            txtAlamat.Size = new Size(521, 23);
            txtAlamat.TabIndex = 5;
            // 
            // panel12
            // 
            panel12.BackColor = Color.FromArgb(74, 103, 65);
            panel12.Controls.Add(txtKecamatan);
            panel12.Controls.Add(panel15);
            panel12.Location = new Point(70, 554);
            panel12.Name = "panel12";
            panel12.Size = new Size(549, 38);
            panel12.TabIndex = 65;
            // 
            // txtKecamatan
            // 
            txtKecamatan.BackColor = Color.FromArgb(74, 103, 65);
            txtKecamatan.BorderStyle = BorderStyle.FixedSingle;
            txtKecamatan.Location = new Point(12, 7);
            txtKecamatan.Name = "txtKecamatan";
            txtKecamatan.ReadOnly = true;
            txtKecamatan.Size = new Size(521, 23);
            txtKecamatan.TabIndex = 7;
            // 
            // panel15
            // 
            panel15.Location = new Point(0, 83);
            panel15.Name = "panel15";
            panel15.Size = new Size(203, 38);
            panel15.TabIndex = 20;
            // 
            // panel16
            // 
            panel16.BackColor = Color.FromArgb(74, 103, 65);
            panel16.Controls.Add(txtPassword);
            panel16.Location = new Point(70, 345);
            panel16.Name = "panel16";
            panel16.Size = new Size(549, 38);
            panel16.TabIndex = 62;
            // 
            // txtPassword
            // 
            txtPassword.BackColor = Color.FromArgb(74, 103, 65);
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Location = new Point(10, 8);
            txtPassword.Name = "txtPassword";
            txtPassword.ReadOnly = true;
            txtPassword.Size = new Size(521, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // panel17
            // 
            panel17.BackColor = Color.FromArgb(74, 103, 65);
            panel17.Controls.Add(txtNoTelp);
            panel17.Location = new Point(69, 128);
            panel17.Name = "panel17";
            panel17.Size = new Size(549, 38);
            panel17.TabIndex = 59;
            // 
            // txtNoTelp
            // 
            txtNoTelp.BackColor = Color.FromArgb(74, 103, 65);
            txtNoTelp.BorderStyle = BorderStyle.FixedSingle;
            txtNoTelp.Location = new Point(13, 9);
            txtNoTelp.Name = "txtNoTelp";
            txtNoTelp.ReadOnly = true;
            txtNoTelp.Size = new Size(521, 23);
            txtNoTelp.TabIndex = 1;
            // 
            // panel18
            // 
            panel18.BackColor = Color.FromArgb(74, 103, 65);
            panel18.Controls.Add(txtEmail);
            panel18.Location = new Point(70, 196);
            panel18.Name = "panel18";
            panel18.Size = new Size(549, 38);
            panel18.TabIndex = 60;
            // 
            // txtEmail
            // 
            txtEmail.BackColor = Color.FromArgb(74, 103, 65);
            txtEmail.BorderStyle = BorderStyle.FixedSingle;
            txtEmail.Location = new Point(11, 8);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(521, 23);
            txtEmail.TabIndex = 2;
            // 
            // panel19
            // 
            panel19.BackColor = Color.FromArgb(74, 103, 65);
            panel19.Controls.Add(label26);
            panel19.Location = new Point(148, -105);
            panel19.Name = "panel19";
            panel19.Size = new Size(397, 70);
            panel19.TabIndex = 57;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Font = new Font("Microsoft Sans Serif", 20.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label26.ForeColor = SystemColors.ButtonFace;
            label26.Location = new Point(48, 19);
            label26.Name = "label26";
            label26.Size = new Size(262, 31);
            label26.TabIndex = 0;
            label26.Text = "DATA KARYAWAN";
            // 
            // btnUbahStatusTransaksi
            // 
            btnUbahStatusTransaksi.AutoSize = true;
            btnUbahStatusTransaksi.BackColor = SystemColors.ActiveBorder;
            btnUbahStatusTransaksi.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUbahStatusTransaksi.Location = new Point(734, 15);
            btnUbahStatusTransaksi.Name = "btnUbahStatusTransaksi";
            btnUbahStatusTransaksi.Size = new Size(200, 25);
            btnUbahStatusTransaksi.TabIndex = 56;
            btnUbahStatusTransaksi.Text = "Ubah status transaksi";
            // 
            // Dashboard_Karyawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 985);
            Controls.Add(tabControl1);
            Controls.Add(label1);
            Controls.Add(panel3);
            Name = "Dashboard_Karyawan";
            Text = "Dashboard_Karyawan";
            FormClosed += Dashboard_Karyawan_FormClosed;
            ((ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            ((ISupportInitialize)Logout).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((ISupportInitialize)pictureBox2).EndInit();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            ((ISupportInitialize)dgvDashboard).EndInit();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel13.ResumeLayout(false);
            panel13.PerformLayout();
            ((ISupportInitialize)dgvUpdateStok).EndInit();
            ((ISupportInitialize)pictureBox5).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((ISupportInitialize)dgvDistribusi).EndInit();
            ((ISupportInitialize)pictureBox3).EndInit();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tcLaporan.ResumeLayout(false);
            tabPage6.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((ISupportInitialize)dgvTransaksi).EndInit();
            panel23.ResumeLayout(false);
            panel23.PerformLayout();
            tabPage7.ResumeLayout(false);
            tabPage7.PerformLayout();
            ((ISupportInitialize)dgvStok).EndInit();
            tabPage8.ResumeLayout(false);
            tabPage8.PerformLayout();
            ((ISupportInitialize)dgvDenda).EndInit();
            ((ISupportInitialize)pictureBox6).EndInit();
            tabPage5.ResumeLayout(false);
            ((ISupportInitialize)pictureBox4).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel9.ResumeLayout(false);
            panel9.PerformLayout();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            panel12.ResumeLayout(false);
            panel12.PerformLayout();
            panel16.ResumeLayout(false);
            panel16.PerformLayout();
            panel17.ResumeLayout(false);
            panel17.PerformLayout();
            panel18.ResumeLayout(false);
            panel18.PerformLayout();
            panel19.ResumeLayout(false);
            panel19.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label label1;
        private Panel panel3;
        private PictureBox Logout;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private TabPage tabPage5;
        private TextBox txtNamaKaryawan1;
        private TextBox txtJumlahDiantar;
        private TextBox txtJumlahTransaksi;
        private Button button2;
        private Label label12;
        private Label label13;
        private DateTimePicker dtpDashboard;
        private Label label14;
        private Button button3;
        private PictureBox pictureBox2;
        private Panel panel5;
        private Label label15;
        private Label label16;
        private Label label17;
        private Label label18;
        private Button btnUpdateStok;
        private Button btnDashboardKaryawan;
        private Button btnDistribusi;
        private Button btnProfil;
        private Button btnLaporan;
        private Panel panel1;
        private DataGridView dgvDistribusi;
        private TextBox txtNamaKaryawan3;
        private Label label5;
        private PictureBox pictureBox3;
        private Button button9;
        private Button btnLaporanDenda;
        private TextBox txtNamaKaryawan4;
        private Label label10;
        private Button btnLaporanTransaksi;
        private PictureBox pictureBox6;
        private Panel panel2;
        private Button button8;
        private Button btnLaporanStok;
        private PictureBox pictureBox4;
        private Panel panel4;
        private Label label6;
        private Panel panel7;
        private Button btnBatal;
        private Button btnSimpan;
        private Button btnEdit;
        private Label label24;
        private CheckBox chkStatusAktif;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label19;
        private Panel panel9;
        private TextBox txtNama;
        private Label label20;
        private Label label21;
        private Label label22;
        private Label label23;
        private Label label25;
        private Panel panel8;
        private TextBox txtUsername;
        private Panel panel10;
        private TextBox txtDesa;
        private Panel panel11;
        private TextBox txtAlamat;
        private Panel panel12;
        private TextBox txtKecamatan;
        private Panel panel15;
        private Panel panel16;
        private TextBox txtPassword;
        private Panel panel17;
        private TextBox txtNoTelp;
        private Panel panel18;
        private TextBox txtEmail;
        private Panel panel19;
        private Label label26;
        private Label btnUbahStatusTransaksi;
        private Panel panel13;
        private Button btnProduk1;
        private DataGridView dgvUpdateStok;
        private TextBox txtNamaKaryawan2;
        private Label label27;
        private PictureBox pictureBox5;
        private Button button13;
        private Button btnAlatSewa2;
        private TextBox txtJumlahPesanan;
        private Label Lbl_DetailPesanan;
        private Label label29;
        private Button button20;
        private DataGridView dgvDenda;
        private DataGridView dgvStok;
        private Label label2;
        private DateTimePicker dtp_DariTanggal;
        private TextBox txt_CariID41;
        private Button btn_Filter41;
        private Label label4;
        private DateTimePicker dtp_KeTanggal;
        private Label label3;
        private Button btn_Refresh41;
        private Panel panel23;
        private Label label30;
        private Label Lbl_JumlahTransaksi;
        private Label Lbl_Pemasukan;
        private Label label31;
        private TabControl tcLaporan;
        private TabPage tabPage6;
        private TabPage tabPage7;
        private TabPage tabPage8;
        private Label Lbl_Stok;
        private TextBox txtCariNamaDenda;
        private Label label11;
        private MaskedTextBox txtCariNamaBarang2;
        private Button btnRefresh2;
        private Button btnRefresh3;
        private MaskedTextBox txtCariID3;
        private Button btnProduk42;
        private Panel panel6;
        private Button btnTransaksi;
        private Button btnPembayaran;
        private Button btnRefresh1;
        private MaskedTextBox txtCariID;
        private DataGridView dgvDashboard;
        private DataGridView dgvTransaksi;
        private Button btnUpdate;
        private Button btnSewaSelesai;
        private Button btnAlat42;
        private Button btnLunas;
        private Button btnKirim;
    }
}