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
            Btn_Petani = new Button();
            panel4 = new Panel();
            label4 = new Label();
            pictureBox6 = new PictureBox();
            panel1 = new Panel();
            label3 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            dgvTransaksi = new DataGridView();
            btnUbahStatusTransaksi = new Label();
            btnUbahStatusPembayaran = new Label();
            label1 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label9 = new Label();
            dtpTanggal = new DateTimePicker();
            label10 = new Label();
            label11 = new Label();
            button1 = new Button();
            txtJumlahTransaksi = new TextBox();
            txtPesananDiantar = new TextBox();
            txtNamaKaryawan = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
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
            // Btn_Petani
            // 
            Btn_Petani.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Petani.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Petani.Location = new Point(943, 274);
            Btn_Petani.Name = "Btn_Petani";
            Btn_Petani.Size = new Size(200, 85);
            Btn_Petani.TabIndex = 39;
            Btn_Petani.UseVisualStyleBackColor = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(49, 106, 14);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(3, 120);
            panel4.Name = "panel4";
            panel4.Size = new Size(241, 55);
            panel4.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(60, 16);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 11;
            label4.Text = "Dashboard";
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.Proifl;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(355, 179);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(162, 166);
            pictureBox6.TabIndex = 45;
            pictureBox6.TabStop = false;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(49, 106, 14);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(280, 26);
            panel1.Name = "panel1";
            panel1.Size = new Size(968, 139);
            panel1.TabIndex = 42;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.FlatStyle = FlatStyle.Flat;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(24, 74);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(546, 21);
            label3.TabIndex = 2;
            label3.Text = "Selamat datang di ruang kerja digital Anda. Mari mulai hari dengan semangat";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Rockwell", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(24, 31);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(213, 31);
            label2.TabIndex = 1;
            label2.Text = "Selamat Datang!";
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(122, 148, 114);
            panel2.Controls.Add(dgvTransaksi);
            panel2.Controls.Add(btnUbahStatusTransaksi);
            panel2.Controls.Add(btnUbahStatusPembayaran);
            panel2.Location = new Point(293, 422);
            panel2.Name = "panel2";
            panel2.Size = new Size(958, 554);
            panel2.TabIndex = 43;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaksi.Location = new Point(22, 64);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.Size = new Size(912, 490);
            dgvTransaksi.TabIndex = 58;
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
            // btnUbahStatusPembayaran
            // 
            btnUbahStatusPembayaran.AutoSize = true;
            btnUbahStatusPembayaran.BackColor = SystemColors.ActiveBorder;
            btnUbahStatusPembayaran.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUbahStatusPembayaran.Location = new Point(497, 15);
            btnUbahStatusPembayaran.Name = "btnUbahStatusPembayaran";
            btnUbahStatusPembayaran.Size = new Size(231, 25);
            btnUbahStatusPembayaran.TabIndex = 57;
            btnUbahStatusPembayaran.Text = "Ubah status Pembayaran";
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
            panel3.Controls.Add(label8);
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 1005);
            panel3.TabIndex = 44;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(49, 106, 14);
            label8.Location = new Point(41, 337);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(147, 21);
            label8.TabIndex = 16;
            label8.Text = "Laporan & Rekap";
            // 
            // pictureBox7
            // 
            pictureBox7.BackgroundImage = Properties.Resources.Group_5;
            pictureBox7.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox7.Location = new Point(23, 925);
            pictureBox7.Name = "pictureBox7";
            pictureBox7.Size = new Size(147, 61);
            pictureBox7.TabIndex = 15;
            pictureBox7.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(49, 106, 14);
            label7.Location = new Point(84, 408);
            label7.Margin = new Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.Size = new Size(58, 21);
            label7.TabIndex = 14;
            label7.Text = "Profil";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(49, 106, 14);
            label6.Location = new Point(19, 271);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(205, 21);
            label6.TabIndex = 13;
            label6.Text = "Manajemen Distribusi";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(49, 106, 14);
            label5.Location = new Point(58, 207);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(117, 21);
            label5.TabIndex = 12;
            label5.Text = "Update Stok";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(584, 179);
            label9.Name = "label9";
            label9.Size = new Size(78, 25);
            label9.TabIndex = 48;
            label9.Text = "Tanggal";
            // 
            // dtpTanggal
            // 
            dtpTanggal.Location = new Point(686, 179);
            dtpTanggal.Name = "dtpTanggal";
            dtpTanggal.Size = new Size(200, 23);
            dtpTanggal.TabIndex = 49;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(677, 243);
            label10.Name = "label10";
            label10.Size = new Size(167, 50);
            label10.TabIndex = 50;
            label10.Text = "Jumlah Transaksi \r\n\r\n";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(963, 246);
            label11.Name = "label11";
            label11.Size = new Size(156, 25);
            label11.TabIndex = 51;
            label11.Text = "Pesanan Diantar";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(217, 217, 217);
            button1.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(659, 274);
            button1.Name = "button1";
            button1.Size = new Size(200, 85);
            button1.TabIndex = 52;
            button1.UseVisualStyleBackColor = false;
            // 
            // txtJumlahTransaksi
            // 
            txtJumlahTransaksi.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtJumlahTransaksi.Location = new Point(708, 300);
            txtJumlahTransaksi.Name = "txtJumlahTransaksi";
            txtJumlahTransaksi.Size = new Size(100, 33);
            txtJumlahTransaksi.TabIndex = 53;
            // 
            // txtPesananDiantar
            // 
            txtPesananDiantar.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtPesananDiantar.Location = new Point(996, 300);
            txtPesananDiantar.Name = "txtPesananDiantar";
            txtPesananDiantar.Size = new Size(100, 33);
            txtPesananDiantar.TabIndex = 54;
            // 
            // txtNamaKaryawan
            // 
            txtNamaKaryawan.Location = new Point(304, 363);
            txtNamaKaryawan.Name = "txtNamaKaryawan";
            txtNamaKaryawan.ReadOnly = true;
            txtNamaKaryawan.Size = new Size(256, 23);
            txtNamaKaryawan.TabIndex = 55;
            // 
            // Dashboard_Karyawan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 985);
            Controls.Add(txtNamaKaryawan);
            Controls.Add(txtPesananDiantar);
            Controls.Add(txtJumlahTransaksi);
            Controls.Add(button1);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(dtpTanggal);
            Controls.Add(label9);
            Controls.Add(Btn_Petani);
            Controls.Add(pictureBox6);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Name = "Dashboard_Karyawan";
            Text = "Dashboard_Karyawan";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Button Btn_Petani;
        private Panel panel4;
        private Label label4;
        private PictureBox pictureBox6;
        private Panel panel1;
        private Label label3;
        private Label label2;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private PictureBox pictureBox7;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label9;
        private DateTimePicker dtpTanggal;
        private Label label10;
        private Label label11;
        private Button button1;
        private Label label8;
        private TextBox txtJumlahTransaksi;
        private TextBox txtPesananDiantar;
        private Label btnUbahStatusTransaksi;
        private DataGridView dgvTransaksi;
        private Label btnUbahStatusPembayaran;
        private TextBox txtNamaKaryawan;
    }
}