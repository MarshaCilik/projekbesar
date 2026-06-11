namespace WinFormsApp1
{
    partial class FormRegistrasi
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label10 = new Label();
            TbNomorTelepon = new TextBox();
            label11 = new Label();
            label9 = new Label();
            BtnKonfirmasi = new Button();
            TbPassword = new TextBox();
            label8 = new Label();
            TbUsername = new TextBox();
            label7 = new Label();
            TbKecamatan = new TextBox();
            label6 = new Label();
            TbDesa = new TextBox();
            label5 = new Label();
            TbAlamat = new TextBox();
            label4 = new Label();
            TbEmail = new TextBox();
            label3 = new Label();
            TbNama = new TextBox();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(248, 250, 239);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(TbNomorTelepon);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(BtnKonfirmasi);
            panel1.Controls.Add(TbPassword);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(TbUsername);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(TbKecamatan);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(TbDesa);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(TbAlamat);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TbEmail);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(TbNama);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(372, -6);
            panel1.Name = "panel1";
            panel1.Size = new Size(619, 814);
            panel1.TabIndex = 0;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(102, 88);
            label10.Name = "label10";
            label10.Size = new Size(417, 42);
            label10.TabIndex = 20;
            label10.Text = "Lengkapi informasi di bawah ini untuk memulai perjalanan\r\nAnda bersama PASTANI.";
            // 
            // TbNomorTelepon
            // 
            TbNomorTelepon.Location = new Point(102, 244);
            TbNomorTelepon.Name = "TbNomorTelepon";
            TbNomorTelepon.Size = new Size(390, 23);
            TbNomorTelepon.TabIndex = 19;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.Location = new Point(102, 224);
            label11.Name = "label11";
            label11.Size = new Size(249, 17);
            label11.TabIndex = 18;
            label11.Text = "Nomor Telepon (Contoh : 081234567890)";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.ForeColor = Color.FromArgb(49, 106, 14);
            label9.Location = new Point(203, 693);
            label9.Name = "label9";
            label9.Size = new Size(182, 15);
            label9.TabIndex = 17;
            label9.Text = "Sudah punya akun? Masuk di sini";
            label9.Click += btn_KembaliKeLogin;
            // 
            // BtnKonfirmasi
            // 
            BtnKonfirmasi.BackColor = Color.FromArgb(49, 106, 14);
            BtnKonfirmasi.ForeColor = SystemColors.ButtonHighlight;
            BtnKonfirmasi.Location = new Point(102, 637);
            BtnKonfirmasi.Name = "BtnKonfirmasi";
            BtnKonfirmasi.Size = new Size(390, 36);
            BtnKonfirmasi.TabIndex = 16;
            BtnKonfirmasi.Text = "Konfirmasi";
            BtnKonfirmasi.UseVisualStyleBackColor = false;
            BtnKonfirmasi.Click += BtnKonfirmasi_Click;
            // 
            // TbPassword
            // 
            TbPassword.Location = new Point(102, 531);
            TbPassword.Name = "TbPassword";
            TbPassword.Size = new Size(390, 23);
            TbPassword.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(102, 511);
            label8.Name = "label8";
            label8.Size = new Size(64, 17);
            label8.TabIndex = 14;
            label8.Text = "Password";
            // 
            // TbUsername
            // 
            TbUsername.Location = new Point(102, 467);
            TbUsername.Name = "TbUsername";
            TbUsername.Size = new Size(390, 23);
            TbUsername.TabIndex = 13;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(102, 447);
            label7.Name = "label7";
            label7.Size = new Size(67, 17);
            label7.TabIndex = 12;
            label7.Text = "Username";
            // 
            // TbKecamatan
            // 
            TbKecamatan.Location = new Point(102, 415);
            TbKecamatan.Name = "TbKecamatan";
            TbKecamatan.Size = new Size(390, 23);
            TbKecamatan.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(102, 395);
            label6.Name = "label6";
            label6.Size = new Size(72, 17);
            label6.TabIndex = 10;
            label6.Text = "Kecamatan";
            // 
            // TbDesa
            // 
            TbDesa.Location = new Point(102, 357);
            TbDesa.Name = "TbDesa";
            TbDesa.Size = new Size(390, 23);
            TbDesa.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(102, 337);
            label5.Name = "label5";
            label5.Size = new Size(37, 17);
            label5.TabIndex = 8;
            label5.Text = "Desa";
            // 
            // TbAlamat
            // 
            TbAlamat.Location = new Point(102, 301);
            TbAlamat.Name = "TbAlamat";
            TbAlamat.Size = new Size(390, 23);
            TbAlamat.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(102, 281);
            label4.Name = "label4";
            label4.Size = new Size(48, 17);
            label4.TabIndex = 6;
            label4.Text = "Alamat";
            // 
            // TbEmail
            // 
            TbEmail.Location = new Point(102, 596);
            TbEmail.Name = "TbEmail";
            TbEmail.Size = new Size(390, 23);
            TbEmail.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(102, 576);
            label3.Name = "label3";
            label3.Size = new Size(236, 17);
            label3.TabIndex = 4;
            label3.Text = "Email (Contoh : emailanda@gmail.com)";
            // 
            // TbNama
            // 
            TbNama.Location = new Point(102, 185);
            TbNama.Name = "TbNama";
            TbNama.Size = new Size(390, 23);
            TbNama.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(102, 165);
            label2.Name = "label2";
            label2.Size = new Size(96, 17);
            label2.TabIndex = 2;
            label2.Text = "Nama Lengkap";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 27.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(91, 29);
            label1.Name = "label1";
            label1.Size = new Size(325, 50);
            label1.TabIndex = 0;
            label1.Text = "Daftar Akun Baru";
            // 
            // FormRegistrasi
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.fe3206811ece50e7f67e433999750266b64732d3;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(973, 807);
            Controls.Add(panel1);
            Name = "FormRegistrasi";
            Text = "REGISTRASI";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private TextBox TbPassword;
        private Label label8;
        private TextBox TbUsername;
        private Label label7;
        private TextBox TbKecamatan;
        private Label label6;
        private TextBox TbDesa;
        private Label label5;
        private TextBox TbAlamat;
        private Label label4;
        private TextBox TbEmail;
        private Label label3;
        private TextBox TbNama;
        private Label label9;
        private Button BtnKonfirmasi;
        private TextBox TbNomorTelepon;
        private Label label11;
        private Label label10;
    }
}
