namespace WinFormsApp1.View
{
    partial class Laporan___Rekap
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
            txtNamaKaryawan = new TextBox();
            button1 = new Button();
            label11 = new Label();
            label10 = new Label();
            btnLaporanTransaksi = new Button();
            pictureBox6 = new PictureBox();
            panel2 = new Panel();
            dgvKeuangan = new DataGridView();
            dgvDenda = new DataGridView();
            dgvStok = new DataGridView();
            dgvTransaksi = new DataGridView();
            label5 = new Label();
            label1 = new Label();
            label7 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            label8 = new Label();
            pictureBox7 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            label4 = new Label();
            panel5 = new Panel();
            label12 = new Label();
            label2 = new Label();
            btnLaporanStok = new Button();
            btnLaporanDenda = new Button();
            label3 = new Label();
            btnLaporanKeuangan = new Button();
            label13 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvStok).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtNamaKaryawan
            // 
            txtNamaKaryawan.Location = new Point(334, 17);
            txtNamaKaryawan.Name = "txtNamaKaryawan";
            txtNamaKaryawan.ReadOnly = true;
            txtNamaKaryawan.Size = new Size(256, 23);
            txtNamaKaryawan.TabIndex = 69;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(49, 106, 14);
            button1.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.Location = new Point(279, 68);
            button1.Name = "button1";
            button1.Size = new Size(954, 62);
            button1.TabIndex = 66;
            button1.UseVisualStyleBackColor = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(495, 144);
            label11.Name = "label11";
            label11.Size = new Size(44, 21);
            label11.TabIndex = 65;
            label11.Text = "Stok";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.FromArgb(49, 106, 14);
            label10.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(665, 86);
            label10.Name = "label10";
            label10.Size = new Size(185, 25);
            label10.TabIndex = 64;
            label10.Text = "Laporan dan Rekap";
            // 
            // btnLaporanTransaksi
            // 
            btnLaporanTransaksi.BackColor = Color.FromArgb(49, 106, 14);
            btnLaporanTransaksi.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanTransaksi.Location = new Point(308, 136);
            btnLaporanTransaksi.Name = "btnLaporanTransaksi";
            btnLaporanTransaksi.Size = new Size(137, 39);
            btnLaporanTransaksi.TabIndex = 57;
            btnLaporanTransaksi.UseVisualStyleBackColor = false;
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.Proifl;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(299, 12);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(32, 32);
            pictureBox6.TabIndex = 61;
            pictureBox6.TabStop = false;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(122, 148, 114);
            panel2.Controls.Add(dgvKeuangan);
            panel2.Controls.Add(dgvDenda);
            panel2.Controls.Add(dgvStok);
            panel2.Controls.Add(dgvTransaksi);
            panel2.Location = new Point(279, 194);
            panel2.Name = "panel2";
            panel2.Size = new Size(978, 777);
            panel2.TabIndex = 59;
            // 
            // dgvKeuangan
            // 
            dgvKeuangan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKeuangan.Location = new Point(15, 9);
            dgvKeuangan.Name = "dgvKeuangan";
            dgvKeuangan.Size = new Size(948, 768);
            dgvKeuangan.TabIndex = 61;
            // 
            // dgvDenda
            // 
            dgvDenda.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDenda.Location = new Point(14, 9);
            dgvDenda.Name = "dgvDenda";
            dgvDenda.Size = new Size(948, 768);
            dgvDenda.TabIndex = 60;
            // 
            // dgvStok
            // 
            dgvStok.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStok.Location = new Point(15, 4);
            dgvStok.Name = "dgvStok";
            dgvStok.Size = new Size(948, 768);
            dgvStok.TabIndex = 59;
            // 
            // dgvTransaksi
            // 
            dgvTransaksi.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransaksi.Location = new Point(14, 9);
            dgvTransaksi.Name = "dgvTransaksi";
            dgvTransaksi.Size = new Size(948, 768);
            dgvTransaksi.TabIndex = 58;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, -16);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 56;
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
            panel3.Controls.Add(panel5);
            panel3.Location = new Point(0, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 1005);
            panel3.TabIndex = 60;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.FromArgb(49, 106, 14);
            label8.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
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
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
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
            label4.ForeColor = Color.FromArgb(49, 106, 14);
            label4.Location = new Point(60, 16);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(107, 21);
            label4.TabIndex = 11;
            label4.Text = "Dashboard";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(49, 106, 14);
            panel5.Controls.Add(label12);
            panel5.Location = new Point(5, 321);
            panel5.Name = "panel5";
            panel5.Size = new Size(241, 55);
            panel5.TabIndex = 12;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(60, 16);
            label12.Margin = new Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.Size = new Size(0, 21);
            label12.TabIndex = 11;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(49, 106, 14);
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(334, 145);
            label2.Name = "label2";
            label2.Size = new Size(80, 21);
            label2.TabIndex = 70;
            label2.Text = "Transaksi";
            // 
            // btnLaporanStok
            // 
            btnLaporanStok.BackColor = SystemColors.ButtonFace;
            btnLaporanStok.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanStok.Location = new Point(453, 136);
            btnLaporanStok.Name = "btnLaporanStok";
            btnLaporanStok.Size = new Size(137, 39);
            btnLaporanStok.TabIndex = 71;
            btnLaporanStok.UseVisualStyleBackColor = false;
            // 
            // btnLaporanDenda
            // 
            btnLaporanDenda.BackColor = SystemColors.ButtonFace;
            btnLaporanDenda.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanDenda.Location = new Point(600, 137);
            btnLaporanDenda.Name = "btnLaporanDenda";
            btnLaporanDenda.Size = new Size(137, 39);
            btnLaporanDenda.TabIndex = 72;
            btnLaporanDenda.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(640, 147);
            label3.Name = "label3";
            label3.Size = new Size(60, 21);
            label3.TabIndex = 73;
            label3.Text = "Denda";
            // 
            // btnLaporanKeuangan
            // 
            btnLaporanKeuangan.BackColor = SystemColors.ButtonFace;
            btnLaporanKeuangan.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLaporanKeuangan.Location = new Point(751, 136);
            btnLaporanKeuangan.Name = "btnLaporanKeuangan";
            btnLaporanKeuangan.Size = new Size(137, 39);
            btnLaporanKeuangan.TabIndex = 74;
            btnLaporanKeuangan.UseVisualStyleBackColor = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.Location = new Point(777, 146);
            label13.Name = "label13";
            label13.Size = new Size(87, 21);
            label13.TabIndex = 76;
            label13.Text = "Keuangan";
            // 
            // Laporan___Rekap
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 985);
            Controls.Add(label13);
            Controls.Add(btnLaporanKeuangan);
            Controls.Add(label3);
            Controls.Add(btnLaporanDenda);
            Controls.Add(label2);
            Controls.Add(txtNamaKaryawan);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(btnLaporanTransaksi);
            Controls.Add(pictureBox6);
            Controls.Add(panel2);
            Controls.Add(label1);
            Controls.Add(panel3);
            Controls.Add(button1);
            Controls.Add(btnLaporanStok);
            Name = "Laporan___Rekap";
            Text = "Laporan___Rekap";
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvKeuangan).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvStok).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTransaksi).EndInit();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNamaKaryawan;
        private Button button1;
        private Label label11;
        private Label label10;
        private Button btnLaporanTransaksi;
        private PictureBox pictureBox6;
        private Panel panel2;
        private DataGridView dgvTransaksi;
        private Label label5;
        private Label label1;
        private Label label7;
        private Label label6;
        private Panel panel3;
        private Panel panel5;
        private Label label12;
        private Label label8;
        private PictureBox pictureBox7;
        private PictureBox pictureBox1;
        private Panel panel4;
        private Label label4;
        private Label label2;
        private Button btnLaporanStok;
        private Button btnLaporanDenda;
        private Label label3;
        private Button btnLaporanKeuangan;
        private Label label13;
        private DataGridView dgvDenda;
        private DataGridView dgvStok;
        private DataGridView dgvKeuangan;
    }
}