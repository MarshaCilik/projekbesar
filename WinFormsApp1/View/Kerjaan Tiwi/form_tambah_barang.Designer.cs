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
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(71, 213);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 11;
            label1.Text = "Nama Barang:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(141, 51);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 75);
            panel1.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(43, 16);
            label2.Name = "label2";
            label2.Size = new Size(218, 41);
            label2.TabIndex = 0;
            label2.Text = "EDIT BARANG";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(249, 408);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 16;
            label4.Text = "Stok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(71, 308);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 15;
            label3.Text = "Harga:";
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(239, 445);
            Tb_Stok.Margin = new Padding(3, 4, 3, 4);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(76, 47);
            Tb_Stok.TabIndex = 19;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(71, 332);
            Tb_Harga.Margin = new Padding(3, 4, 3, 4);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(427, 32);
            Tb_Harga.TabIndex = 18;
            // 
            // Tb_Nama_Barang
            // 
            Tb_Nama_Barang.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Barang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Barang.Location = new Point(71, 237);
            Tb_Nama_Barang.Margin = new Padding(3, 4, 3, 4);
            Tb_Nama_Barang.Name = "Tb_Nama_Barang";
            Tb_Nama_Barang.Size = new Size(427, 32);
            Tb_Nama_Barang.TabIndex = 17;
            // 
            // btn_batal_barang
            // 
            btn_batal_barang.BackColor = Color.IndianRed;
            btn_batal_barang.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_batal_barang.Location = new Point(339, 550);
            btn_batal_barang.Name = "btn_batal_barang";
            btn_batal_barang.Size = new Size(159, 55);
            btn_batal_barang.TabIndex = 34;
            btn_batal_barang.Text = "Batal";
            btn_batal_barang.UseVisualStyleBackColor = false;
            btn_batal_barang.Click += btn_batal_barang_Click;
            // 
            // btn_selesai_barang
            // 
            btn_selesai_barang.BackColor = Color.GreenYellow;
            btn_selesai_barang.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_selesai_barang.Location = new Point(71, 550);
            btn_selesai_barang.Name = "btn_selesai_barang";
            btn_selesai_barang.Size = new Size(159, 55);
            btn_selesai_barang.TabIndex = 35;
            btn_selesai_barang.Text = "Selesai";
            btn_selesai_barang.UseVisualStyleBackColor = false;
            btn_selesai_barang.Click += btn_selesai_barang_Click;
            // 
            // form_tambah_barang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 667);
            Controls.Add(btn_selesai_barang);
            Controls.Add(btn_batal_barang);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Barang);
            Margin = new Padding(3, 4, 3, 4);
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
    }
}