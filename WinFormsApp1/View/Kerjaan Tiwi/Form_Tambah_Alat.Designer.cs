namespace WinFormsApp1.View
{
    partial class Form_Tambah_Alat
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
            panel1 = new Panel();
            label2 = new Label();
            Tb_Denda_Perhari = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            Tb_Stok = new TextBox();
            Tb_Harga = new TextBox();
            Tb_Nama_Alat = new TextBox();
            btn_batal_alat = new Button();
            btn_selesai_alat = new Button();
            Tb_Kategori = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 139);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 22;
            label1.Text = "Nama Alat:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(123, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 56);
            panel1.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(53, 13);
            label2.Name = "label2";
            label2.Size = new Size(142, 32);
            label2.TabIndex = 0;
            label2.Text = "DATA ALAT";
            // 
            // Tb_Denda_Perhari
            // 
            Tb_Denda_Perhari.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Denda_Perhari.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Denda_Perhari.Location = new Point(62, 275);
            Tb_Denda_Perhari.Name = "Tb_Denda_Perhari";
            Tb_Denda_Perhari.Size = new Size(374, 27);
            Tb_Denda_Perhari.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(63, 257);
            label7.Name = "label7";
            label7.Size = new Size(89, 15);
            label7.TabIndex = 31;
            label7.Text = "Denda Perhari:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(218, 397);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 27;
            label4.Text = "Stok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 196);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 26;
            label3.Text = "Harga:";
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(207, 434);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(67, 39);
            Tb_Stok.TabIndex = 30;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(62, 214);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(374, 27);
            Tb_Harga.TabIndex = 29;
            // 
            // Tb_Nama_Alat
            // 
            Tb_Nama_Alat.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Alat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Alat.Location = new Point(62, 157);
            Tb_Nama_Alat.Name = "Tb_Nama_Alat";
            Tb_Nama_Alat.Size = new Size(374, 27);
            Tb_Nama_Alat.TabIndex = 28;
            // 
            // btn_batal_alat
            // 
            btn_batal_alat.BackColor = Color.IndianRed;
            btn_batal_alat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_batal_alat.Location = new Point(290, 499);
            btn_batal_alat.Margin = new Padding(3, 2, 3, 2);
            btn_batal_alat.Name = "btn_batal_alat";
            btn_batal_alat.Size = new Size(139, 41);
            btn_batal_alat.TabIndex = 10;
            btn_batal_alat.Text = "Batal";
            btn_batal_alat.UseVisualStyleBackColor = false;
            btn_batal_alat.Click += btn_batal_alat_Click;
            // 
            // btn_selesai_alat
            // 
            btn_selesai_alat.BackColor = Color.YellowGreen;
            btn_selesai_alat.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_selesai_alat.Location = new Point(56, 499);
            btn_selesai_alat.Margin = new Padding(3, 2, 3, 2);
            btn_selesai_alat.Name = "btn_selesai_alat";
            btn_selesai_alat.Size = new Size(139, 41);
            btn_selesai_alat.TabIndex = 33;
            btn_selesai_alat.Text = "Selesai";
            btn_selesai_alat.UseVisualStyleBackColor = false;
            btn_selesai_alat.Click += btn_selesai_alat_Click;
            // 
            // Tb_Kategori
            // 
            Tb_Kategori.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kategori.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Kategori.Location = new Point(62, 347);
            Tb_Kategori.Name = "Tb_Kategori";
            Tb_Kategori.Size = new Size(374, 27);
            Tb_Kategori.TabIndex = 35;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(63, 329);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 34;
            label5.Text = "Kategori:";
            // 
            // Form_Tambah_Alat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 551);
            Controls.Add(Tb_Kategori);
            Controls.Add(label5);
            Controls.Add(btn_selesai_alat);
            Controls.Add(btn_batal_alat);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(Tb_Denda_Perhari);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Alat);
            Name = "Form_Tambah_Alat";
            Text = "Form_Tambah_Alat";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox Tb_Denda_Perhari;
        private Label label7;
        private Label label4;
        private Label label3;
        private TextBox Tb_Stok;
        private TextBox Tb_Harga;
        private TextBox Tb_Nama_Alat;
        private Button btn_batal_alat;
        private Button btn_selesai_alat;
        private TextBox Tb_Kategori;
        private Label label5;
    }
}