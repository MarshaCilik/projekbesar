namespace WinFormsApp1.View
{
    partial class Dashboard_admin
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgv_AllUser = new DataGridView();
            Lbl_UsernameAtas = new Label();
            Btn_Karyawan = new Button();
            Btn_Petani = new Button();
            Btn_SeluruhUser = new Button();
            Btn_Edit = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            pictureBox7 = new PictureBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            pictureBox5 = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox3 = new PictureBox();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            label4 = new Label();
            pictureBox6 = new PictureBox();
            Btn_Kurir = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 15);
            label1.TabIndex = 0;
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
            label3.Size = new Size(417, 105);
            label3.TabIndex = 2;
            label3.Text = "Pantau user dan  CRUD produk dengan aman dan nyaman.\r\n\r\n\r\n\r\n\r\n";
            // 
            // dgv_AllUser
            // 
            dgv_AllUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_AllUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_AllUser.Location = new Point(294, 357);
            dgv_AllUser.Margin = new Padding(2);
            dgv_AllUser.Name = "dgv_AllUser";
            dgv_AllUser.RowHeadersWidth = 62;
            dgv_AllUser.Size = new Size(930, 612);
            dgv_AllUser.TabIndex = 3;
            // 
            // Lbl_UsernameAtas
            // 
            Lbl_UsernameAtas.AutoSize = true;
            Lbl_UsernameAtas.BackColor = Color.Transparent;
            Lbl_UsernameAtas.Font = new Font("Rockwell", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_UsernameAtas.ForeColor = SystemColors.ActiveCaptionText;
            Lbl_UsernameAtas.Location = new Point(326, 26);
            Lbl_UsernameAtas.Margin = new Padding(2, 0, 2, 0);
            Lbl_UsernameAtas.Name = "Lbl_UsernameAtas";
            Lbl_UsernameAtas.Size = new Size(22, 23);
            Lbl_UsernameAtas.TabIndex = 4;
            Lbl_UsernameAtas.Text = "x";
            // 
            // Btn_Karyawan
            // 
            Btn_Karyawan.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Karyawan.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Karyawan.Location = new Point(426, 272);
            Btn_Karyawan.Name = "Btn_Karyawan";
            Btn_Karyawan.Size = new Size(145, 45);
            Btn_Karyawan.TabIndex = 5;
            Btn_Karyawan.Text = "Karyawan";
            Btn_Karyawan.UseVisualStyleBackColor = false;
            Btn_Karyawan.Click += Btn_Karyawan_Click;
            // 
            // Btn_Petani
            // 
            Btn_Petani.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Petani.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Petani.Location = new Point(577, 272);
            Btn_Petani.Name = "Btn_Petani";
            Btn_Petani.Size = new Size(145, 45);
            Btn_Petani.TabIndex = 6;
            Btn_Petani.Text = "Petani";
            Btn_Petani.UseVisualStyleBackColor = false;
            Btn_Petani.Click += Btn_Petani_Click;
            // 
            // Btn_SeluruhUser
            // 
            Btn_SeluruhUser.BackColor = Color.FromArgb(49, 106, 14);
            Btn_SeluruhUser.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_SeluruhUser.ForeColor = Color.White;
            Btn_SeluruhUser.Location = new Point(275, 272);
            Btn_SeluruhUser.Name = "Btn_SeluruhUser";
            Btn_SeluruhUser.Size = new Size(145, 45);
            Btn_SeluruhUser.TabIndex = 7;
            Btn_SeluruhUser.Text = "Seluruh User";
            Btn_SeluruhUser.UseVisualStyleBackColor = false;
            // 
            // Btn_Edit
            // 
            Btn_Edit.Anchor = AnchorStyles.Right;
            Btn_Edit.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Edit.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Edit.Location = new Point(1034, 272);
            Btn_Edit.Name = "Btn_Edit";
            Btn_Edit.Size = new Size(204, 45);
            Btn_Edit.TabIndex = 8;
            Btn_Edit.Text = "Edit Data";
            Btn_Edit.UseVisualStyleBackColor = false;
            Btn_Edit.Click += Btn_Edit_Click;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(49, 106, 14);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(280, 55);
            panel1.Name = "panel1";
            panel1.Size = new Size(955, 196);
            panel1.TabIndex = 9;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(122, 148, 114);
            panel2.Location = new Point(280, 344);
            panel2.Name = "panel2";
            panel2.Size = new Size(958, 643);
            panel2.TabIndex = 10;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(168, 197, 152);
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(pictureBox5);
            panel3.Controls.Add(pictureBox4);
            panel3.Controls.Add(pictureBox3);
            panel3.Controls.Add(pictureBox2);
            panel3.Controls.Add(pictureBox1);
            panel3.Controls.Add(panel4);
            panel3.Location = new Point(1, 1);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 1005);
            panel3.TabIndex = 10;
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
            label7.Location = new Point(68, 350);
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
            label6.Location = new Point(65, 271);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(172, 21);
            label6.TabIndex = 13;
            label6.Text = "Tambah Karyawan";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(49, 106, 14);
            label5.Location = new Point(65, 205);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(131, 21);
            label5.TabIndex = 12;
            label5.Text = "CRUD Produk";
            label5.Click += label5_Click;
            // 
            // pictureBox5
            // 
            pictureBox5.BackgroundImage = Properties.Resources.Proifl;
            pictureBox5.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox5.Location = new Point(11, 343);
            pictureBox5.Name = "pictureBox5";
            pictureBox5.Size = new Size(41, 36);
            pictureBox5.TabIndex = 4;
            pictureBox5.TabStop = false;
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.TambahKaryawan;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(11, 267);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(41, 36);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.CRUDProduk1;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(11, 197);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(41, 36);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackgroundImage = Properties.Resources.BerandaIcon1;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(11, 128);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(41, 36);
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
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
            pictureBox6.Location = new Point(280, 13);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(41, 36);
            pictureBox6.TabIndex = 15;
            pictureBox6.TabStop = false;
            // 
            // Btn_Kurir
            // 
            Btn_Kurir.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Kurir.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Kurir.Location = new Point(728, 272);
            Btn_Kurir.Name = "Btn_Kurir";
            Btn_Kurir.Size = new Size(145, 45);
            Btn_Kurir.TabIndex = 34;
            Btn_Kurir.Text = "Kurir";
            Btn_Kurir.UseVisualStyleBackColor = false;
            Btn_Kurir.Click += Btn_Kurir_Click;
            // 
            // Dashboard_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1247, 999);
            Controls.Add(Btn_Kurir);
            Controls.Add(pictureBox6);
            Controls.Add(Btn_Edit);
            Controls.Add(Btn_SeluruhUser);
            Controls.Add(Btn_Petani);
            Controls.Add(Btn_Karyawan);
            Controls.Add(Lbl_UsernameAtas);
            Controls.Add(dgv_AllUser);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            DoubleBuffered = true;
            Margin = new Padding(2);
            Name = "Dashboard_admin";
            Text = "Dashboard_admin";
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgv_AllUser;
        private Label Lbl_UsernameAtas;
        private Button Btn_Karyawan;
        private Button Btn_Petani;
        private Button Btn_SeluruhUser;
        private Button Btn_Edit;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private PictureBox pictureBox1;
        private PictureBox pictureBox3;
        private PictureBox pictureBox2;
        private PictureBox pictureBox5;
        private PictureBox pictureBox4;
        private Panel panel4;
        private Label label4;
        private Label label7;
        private Label label6;
        private Label label5;
        private PictureBox pictureBox6;
        private PictureBox pictureBox7;
        private Button Btn_Kurir;
    }
}