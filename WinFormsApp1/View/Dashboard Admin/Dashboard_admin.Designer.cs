namespace WinFormsApp1.View.Dashboard_Admin
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
            Btn_Kurir = new Button();
            label9 = new Label();
            pictureBox6 = new PictureBox();
            Btn_Edit = new Button();
            label8 = new Label();
            label3 = new Label();
            panel2 = new Panel();
            pictureBox7 = new PictureBox();
            panel3 = new Panel();
            btn_Profil = new Button();
            btn_TambahKaryawan = new Button();
            btn_CRUDProduk = new Button();
            btn_Dashboard = new Button();
            pictureBox1 = new PictureBox();
            Btn_SeluruhUser = new Button();
            Btn_Petani = new Button();
            Btn_Karyawan = new Button();
            dgv_AllUser = new DataGridView();
            label6 = new Label();
            Lbl_UsernameAtas = new Label();
            panel1 = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).BeginInit();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).BeginInit();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();
            // 
            // Btn_Kurir
            // 
            Btn_Kurir.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Kurir.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Kurir.Location = new Point(458, 265);
            Btn_Kurir.Name = "Btn_Kurir";
            Btn_Kurir.Size = new Size(145, 45);
            Btn_Kurir.TabIndex = 48;
            Btn_Kurir.Text = "Kurir";
            Btn_Kurir.UseVisualStyleBackColor = false;
            Btn_Kurir.Click += Btn_Kurir_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Rockwell", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(24, 31);
            label9.Margin = new Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.Size = new Size(213, 31);
            label9.TabIndex = 1;
            label9.Text = "Selamat Datang!";
            // 
            // pictureBox6
            // 
            pictureBox6.BackgroundImage = Properties.Resources.Proifl;
            pictureBox6.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox6.Location = new Point(6, 6);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(41, 36);
            pictureBox6.TabIndex = 47;
            pictureBox6.TabStop = false;
            // 
            // Btn_Edit
            // 
            Btn_Edit.Anchor = AnchorStyles.Right;
            Btn_Edit.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Edit.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Edit.Location = new Point(880, 265);
            Btn_Edit.Name = "Btn_Edit";
            Btn_Edit.Size = new Size(204, 45);
            Btn_Edit.TabIndex = 43;
            Btn_Edit.Text = "Edit Data";
            Btn_Edit.UseVisualStyleBackColor = false;
            Btn_Edit.Click += Btn_Edit_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.FlatStyle = FlatStyle.Flat;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(24, 74);
            label8.Margin = new Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.Size = new Size(417, 105);
            label8.TabIndex = 2;
            label8.Text = "Pantau user dan  CRUD produk dengan aman dan nyaman.\r\n\r\n\r\n\r\n\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(-2, -1);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(0, 15);
            label3.TabIndex = 41;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel2.BackColor = Color.FromArgb(122, 148, 114);
            panel2.Location = new Point(11, 339);
            panel2.Name = "panel2";
            panel2.Size = new Size(1073, 700);
            panel2.TabIndex = 45;
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
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(168, 197, 152);
            panel3.Controls.Add(btn_Profil);
            panel3.Controls.Add(btn_TambahKaryawan);
            panel3.Controls.Add(btn_CRUDProduk);
            panel3.Controls.Add(btn_Dashboard);
            panel3.Controls.Add(pictureBox7);
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(-1, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(256, 1005);
            panel3.TabIndex = 46;
            // 
            // btn_Profil
            // 
            btn_Profil.FlatAppearance.BorderSize = 0;
            btn_Profil.FlatStyle = FlatStyle.Flat;
            btn_Profil.Font = new Font("Rockwell", 14.25F);
            btn_Profil.ForeColor = Color.FromArgb(49, 106, 14);
            btn_Profil.Location = new Point(0, 365);
            btn_Profil.Name = "btn_Profil";
            btn_Profil.Size = new Size(256, 57);
            btn_Profil.TabIndex = 19;
            btn_Profil.Text = "Profil";
            btn_Profil.UseVisualStyleBackColor = true;
            btn_Profil.Click += btn_Profil_Click;
            // 
            // btn_TambahKaryawan
            // 
            btn_TambahKaryawan.FlatAppearance.BorderSize = 0;
            btn_TambahKaryawan.FlatStyle = FlatStyle.Flat;
            btn_TambahKaryawan.Font = new Font("Rockwell", 14.25F);
            btn_TambahKaryawan.ForeColor = Color.FromArgb(49, 106, 14);
            btn_TambahKaryawan.Location = new Point(0, 302);
            btn_TambahKaryawan.Name = "btn_TambahKaryawan";
            btn_TambahKaryawan.Size = new Size(256, 57);
            btn_TambahKaryawan.TabIndex = 18;
            btn_TambahKaryawan.Text = "Tambah Karyawan";
            btn_TambahKaryawan.UseVisualStyleBackColor = true;
            btn_TambahKaryawan.Click += btn_TambahKaryawan_Click;
            // 
            // btn_CRUDProduk
            // 
            btn_CRUDProduk.FlatAppearance.BorderSize = 0;
            btn_CRUDProduk.FlatStyle = FlatStyle.Flat;
            btn_CRUDProduk.Font = new Font("Rockwell", 14.25F);
            btn_CRUDProduk.ForeColor = Color.FromArgb(49, 106, 14);
            btn_CRUDProduk.Location = new Point(3, 239);
            btn_CRUDProduk.Name = "btn_CRUDProduk";
            btn_CRUDProduk.Size = new Size(256, 57);
            btn_CRUDProduk.TabIndex = 17;
            btn_CRUDProduk.Text = "CRUD Produk";
            btn_CRUDProduk.UseVisualStyleBackColor = true;
            btn_CRUDProduk.Click += btn_CRUDProduk_Click;
            // 
            // btn_Dashboard
            // 
            btn_Dashboard.FlatAppearance.BorderSize = 0;
            btn_Dashboard.FlatStyle = FlatStyle.Flat;
            btn_Dashboard.Font = new Font("Rockwell", 14.25F);
            btn_Dashboard.ForeColor = Color.FromArgb(49, 106, 14);
            btn_Dashboard.Location = new Point(0, 176);
            btn_Dashboard.Name = "btn_Dashboard";
            btn_Dashboard.Size = new Size(256, 57);
            btn_Dashboard.TabIndex = 16;
            btn_Dashboard.Text = "Dashboard";
            btn_Dashboard.UseVisualStyleBackColor = true;
            btn_Dashboard.Click += btn_Dashboard_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.PASTANI_DASHBOARD1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(22, 11);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(246, 76);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Btn_SeluruhUser
            // 
            Btn_SeluruhUser.BackColor = Color.FromArgb(217, 217, 217);
            Btn_SeluruhUser.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_SeluruhUser.ForeColor = Color.Black;
            Btn_SeluruhUser.Location = new Point(5, 265);
            Btn_SeluruhUser.Name = "Btn_SeluruhUser";
            Btn_SeluruhUser.Size = new Size(145, 45);
            Btn_SeluruhUser.TabIndex = 40;
            Btn_SeluruhUser.Text = "Seluruh User";
            Btn_SeluruhUser.UseVisualStyleBackColor = false;
            Btn_SeluruhUser.Click += Btn_SeluruhUser_Click;
            // 
            // Btn_Petani
            // 
            Btn_Petani.BackColor = Color.FromArgb(217, 217, 217);
            Btn_Petani.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Petani.Location = new Point(307, 265);
            Btn_Petani.Name = "Btn_Petani";
            Btn_Petani.Size = new Size(145, 45);
            Btn_Petani.TabIndex = 39;
            Btn_Petani.Text = "Petani";
            Btn_Petani.UseVisualStyleBackColor = false;
            Btn_Petani.Click += Btn_Petani_Click;
            // 
            // Btn_Karyawan
            // 
            Btn_Karyawan.BackColor = Color.FromArgb(49, 106, 14);
            Btn_Karyawan.Font = new Font("Rockwell", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Karyawan.ForeColor = SystemColors.ButtonHighlight;
            Btn_Karyawan.Location = new Point(156, 265);
            Btn_Karyawan.Name = "Btn_Karyawan";
            Btn_Karyawan.Size = new Size(145, 45);
            Btn_Karyawan.TabIndex = 38;
            Btn_Karyawan.Text = "Karyawan";
            Btn_Karyawan.UseVisualStyleBackColor = false;
            Btn_Karyawan.Click += Btn_Karyawan_Click;
            // 
            // dgv_AllUser
            // 
            dgv_AllUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgv_AllUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_AllUser.Location = new Point(24, 350);
            dgv_AllUser.Margin = new Padding(2);
            dgv_AllUser.Name = "dgv_AllUser";
            dgv_AllUser.RowHeadersWidth = 62;
            dgv_AllUser.Size = new Size(1044, 731);
            dgv_AllUser.TabIndex = 37;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(-3, -1);
            label6.Margin = new Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new Size(0, 15);
            label6.TabIndex = 36;
            // 
            // Lbl_UsernameAtas
            // 
            Lbl_UsernameAtas.AutoSize = true;
            Lbl_UsernameAtas.BackColor = Color.Transparent;
            Lbl_UsernameAtas.Font = new Font("Rockwell", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_UsernameAtas.ForeColor = SystemColors.ActiveCaptionText;
            Lbl_UsernameAtas.Location = new Point(44, 12);
            Lbl_UsernameAtas.Margin = new Padding(2, 0, 2, 0);
            Lbl_UsernameAtas.Name = "Lbl_UsernameAtas";
            Lbl_UsernameAtas.Size = new Size(22, 23);
            Lbl_UsernameAtas.TabIndex = 35;
            Lbl_UsernameAtas.Text = "x";
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel1.BackColor = Color.FromArgb(49, 106, 14);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label9);
            panel1.Location = new Point(6, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(1078, 196);
            panel1.TabIndex = 44;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(261, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1107, 1013);
            tabControl1.TabIndex = 49;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(Btn_Kurir);
            tabPage1.Controls.Add(pictureBox6);
            tabPage1.Controls.Add(panel1);
            tabPage1.Controls.Add(Btn_Edit);
            tabPage1.Controls.Add(Lbl_UsernameAtas);
            tabPage1.Controls.Add(dgv_AllUser);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(Btn_Karyawan);
            tabPage1.Controls.Add(Btn_Petani);
            tabPage1.Controls.Add(Btn_SeluruhUser);
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
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1099, 985);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "tabPage2";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // Dashboard_admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1361, 999);
            Controls.Add(tabControl1);
            Controls.Add(label3);
            Controls.Add(panel3);
            Controls.Add(label6);
            Name = "Dashboard_admin";
            Text = "Dashboard_admin";
            FormClosed += Dashboard_admin_FormClosed;
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox7).EndInit();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Btn_Kurir;
        private Label label9;
        private PictureBox pictureBox6;
        private Button Btn_Edit;
        private Label label8;
        private Label label3;
        private Panel panel2;
        private PictureBox pictureBox7;
        private Panel panel3;
        private PictureBox pictureBox1;
        private Button Btn_SeluruhUser;
        private Button Btn_Petani;
        private Button Btn_Karyawan;
        private DataGridView dgv_AllUser;
        private Label label6;
        private Label Lbl_UsernameAtas;
        private Panel panel1;
        private Button btn_Dashboard;
        private Button btn_Profil;
        private Button btn_TambahKaryawan;
        private Button btn_CRUDProduk;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
    }
}