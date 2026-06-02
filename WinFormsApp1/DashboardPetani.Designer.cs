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
            dashboard = new Label();
            pictureBox2 = new PictureBox();
            usernameShow = new Label();
            pictureBox1 = new PictureBox();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            btn_LihatProdukTani = new Button();
            label2 = new Label();
            pictureBox3 = new PictureBox();
            panel4 = new Panel();
            btn_LihatAlatSewa = new Button();
            label3 = new Label();
            pictureBox4 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_Logout);
            panel1.Controls.Add(dashboard);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(usernameShow);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(-5, -4);
            panel1.Name = "panel1";
            panel1.Size = new Size(319, 624);
            panel1.TabIndex = 0;
            // 
            // btn_Logout
            // 
            btn_Logout.BackColor = Color.Red;
            btn_Logout.Location = new Point(193, 539);
            btn_Logout.Name = "btn_Logout";
            btn_Logout.Size = new Size(93, 39);
            btn_Logout.TabIndex = 4;
            btn_Logout.Text = "Logout";
            btn_Logout.UseVisualStyleBackColor = false;
            btn_Logout.Click += btn_Logout_Click;
            // 
            // dashboard
            // 
            dashboard.AutoSize = true;
            dashboard.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dashboard.Location = new Point(69, 133);
            dashboard.Name = "dashboard";
            dashboard.Size = new Size(109, 25);
            dashboard.TabIndex = 3;
            dashboard.Text = "Dashboard";
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.BackgroundImage = Properties.Resources.dashboard;
            pictureBox2.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox2.Location = new Point(19, 123);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(46, 41);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // usernameShow
            // 
            usernameShow.AutoSize = true;
            usernameShow.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            usernameShow.Location = new Point(100, 28);
            usernameShow.Name = "usernameShow";
            usernameShow.Size = new Size(186, 32);
            usernameShow.TabIndex = 1;
            usernameShow.Text = "UsernamePetani";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = Properties.Resources.petanilogo1;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(0, -6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(104, 110);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            panel2.Controls.Add(label1);
            panel2.Location = new Point(332, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(826, 88);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 21.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(26, 22);
            label1.Name = "label1";
            label1.Size = new Size(299, 40);
            label1.TabIndex = 0;
            label1.Text = "Total Pengeluaran : Rp";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Transparent;
            panel3.BackgroundImage = Properties.Resources.card;
            panel3.BackgroundImageLayout = ImageLayout.Stretch;
            panel3.Controls.Add(btn_LihatProdukTani);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(pictureBox3);
            panel3.Location = new Point(358, 129);
            panel3.Name = "panel3";
            panel3.Size = new Size(381, 445);
            panel3.TabIndex = 2;
            // 
            // btn_LihatProdukTani
            // 
            btn_LihatProdukTani.BackColor = SystemColors.MenuHighlight;
            btn_LihatProdukTani.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_LihatProdukTani.Location = new Point(14, 302);
            btn_LihatProdukTani.Name = "btn_LihatProdukTani";
            btn_LihatProdukTani.Size = new Size(347, 62);
            btn_LihatProdukTani.TabIndex = 1;
            btn_LihatProdukTani.Text = "Lihat Sekarang";
            btn_LihatProdukTani.UseVisualStyleBackColor = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(79, 32);
            label2.Name = "label2";
            label2.Size = new Size(218, 47);
            label2.TabIndex = 0;
            label2.Text = "Produk Tani";
            // 
            // pictureBox3
            // 
            pictureBox3.BackgroundImage = Properties.Resources.logo_produk_tani;
            pictureBox3.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox3.Location = new Point(97, 65);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(183, 248);
            pictureBox3.TabIndex = 2;
            pictureBox3.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.Transparent;
            panel4.BackgroundImage = Properties.Resources.card;
            panel4.BackgroundImageLayout = ImageLayout.Stretch;
            panel4.Controls.Add(btn_LihatAlatSewa);
            panel4.Controls.Add(label3);
            panel4.Controls.Add(pictureBox4);
            panel4.Location = new Point(762, 129);
            panel4.Name = "panel4";
            panel4.Size = new Size(381, 445);
            panel4.TabIndex = 3;
            // 
            // btn_LihatAlatSewa
            // 
            btn_LihatAlatSewa.BackColor = SystemColors.MenuHighlight;
            btn_LihatAlatSewa.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_LihatAlatSewa.Location = new Point(16, 302);
            btn_LihatAlatSewa.Name = "btn_LihatAlatSewa";
            btn_LihatAlatSewa.Size = new Size(347, 62);
            btn_LihatAlatSewa.TabIndex = 2;
            btn_LihatAlatSewa.Text = "Lihat Sekarang";
            btn_LihatAlatSewa.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(107, 32);
            label3.Name = "label3";
            label3.Size = new Size(184, 47);
            label3.TabIndex = 1;
            label3.Text = "Alat Sewa";
            // 
            // pictureBox4
            // 
            pictureBox4.BackgroundImage = Properties.Resources.alat_sewa;
            pictureBox4.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox4.Location = new Point(107, 65);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(183, 248);
            pictureBox4.TabIndex = 3;
            pictureBox4.TabStop = false;
            // 
            // DashboardPetani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pngtree_background_blur_rice_field_blur_sunrise_photo_image_20947706;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1179, 605);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Name = "DashboardPetani";
            Text = "DashboardPetani";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Panel panel2;
        private Label label1;
        private Panel panel3;
        private Button btn_LihatProdukTani;
        private Label label2;
        private Panel panel4;
        private Label label3;
        private Label usernameShow;
        private Button btn_LihatAlatSewa;
        private Label dashboard;
        private PictureBox pictureBox2;
        private Button btn_Logout;
        private PictureBox pictureBox3;
        private PictureBox pictureBox4;
    }
}