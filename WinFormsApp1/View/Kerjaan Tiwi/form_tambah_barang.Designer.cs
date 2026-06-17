namespace WinFormsApp1.View
{
    partial class form_tambah_barang
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
            label4 = new Label();
            label3 = new Label();
            Tb_Stok = new TextBox();
            Tb_Harga = new TextBox();
            Tb_Nama_Barang = new TextBox();
            btn_batal_barang = new Button();
            btn_selesai_barang = new Button();
            label5 = new Label();
            Tb_Kategori = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(62, 160);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 11;
            label1.Text = "Nama Barang:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(123, 38);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 56);
            panel1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(31, 10);
            label2.Name = "label2";
            label2.Size = new Size(184, 32);
            label2.TabIndex = 0;
            label2.Text = "DATA BARANG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(203, 385);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 16;
            label4.Text = "Stok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(62, 231);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 15;
            label3.Text = "Harga:";
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(194, 413);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(67, 39);
            Tb_Stok.TabIndex = 19;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(62, 249);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(374, 27);
            Tb_Harga.TabIndex = 18;
            // 
            // Tb_Nama_Barang
            // 
            Tb_Nama_Barang.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Barang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Barang.Location = new Point(62, 178);
            Tb_Nama_Barang.Name = "Tb_Nama_Barang";
            Tb_Nama_Barang.Size = new Size(374, 27);
            Tb_Nama_Barang.TabIndex = 17;
            // 
            // btn_batal_barang
            // 
            btn_batal_barang.BackColor = Color.IndianRed;
            btn_batal_barang.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_batal_barang.Location = new Point(282, 491);
            btn_batal_barang.Margin = new Padding(3, 2, 3, 2);
            btn_batal_barang.Name = "btn_batal_barang";
            btn_batal_barang.Size = new Size(139, 41);
            btn_batal_barang.TabIndex = 34;
            btn_batal_barang.Text = "Batal";
            btn_batal_barang.UseVisualStyleBackColor = false;
            btn_batal_barang.Click += btn_batal_barang_Click;
            // 
            // btn_selesai_barang
            // 
            btn_selesai_barang.BackColor = Color.GreenYellow;
            btn_selesai_barang.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_selesai_barang.Location = new Point(47, 491);
            btn_selesai_barang.Margin = new Padding(3, 2, 3, 2);
            btn_selesai_barang.Name = "btn_selesai_barang";
            btn_selesai_barang.Size = new Size(139, 41);
            btn_selesai_barang.TabIndex = 35;
            btn_selesai_barang.Text = "Selesai";
            btn_selesai_barang.UseVisualStyleBackColor = false;
            btn_selesai_barang.Click += btn_selesai_barang_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(62, 309);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 36;
            label5.Text = "Kategori:";
            // 
            // Tb_Kategori
            // 
            Tb_Kategori.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Kategori.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Kategori.Location = new Point(62, 327);
            Tb_Kategori.Name = "Tb_Kategori";
            Tb_Kategori.Size = new Size(374, 27);
            Tb_Kategori.TabIndex = 37;
            // 
            // form_tambah_barang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 576);
            Controls.Add(label5);
            Controls.Add(Tb_Kategori);
            Controls.Add(btn_selesai_barang);
            Controls.Add(btn_batal_barang);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Barang);
            Name = "form_tambah_barang";
            Text = "form_tambah_barang";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private Label label4;
        private Label label3;
        private TextBox Tb_Stok;
        private TextBox Tb_Harga;
        private TextBox Tb_Nama_Barang;
        private Button btnSelesai_Click;
        private Button button1;
        private Button button2;
        private Button btn_selesai_barang;
        private Button btn_batal_barang;
        private Label label5;
        private TextBox Tb_Kategori;
    }
}