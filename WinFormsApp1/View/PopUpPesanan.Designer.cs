namespace WinFormsApp1.View
{
    partial class PopUpPesanan
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
            TbStok = new TextBox();
            Btn_Tambah = new Button();
            label2 = new Label();
            lbl_formbarang = new Label();
            cmbPengiriman = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 41);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 0;
            label1.Text = "Masukkan jumlah stok";
            // 
            // TbStok
            // 
            TbStok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbStok.Location = new Point(17, 64);
            TbStok.Name = "TbStok";
            TbStok.Size = new Size(100, 23);
            TbStok.TabIndex = 1;
            // 
            // Btn_Tambah
            // 
            Btn_Tambah.Location = new Point(451, 184);
            Btn_Tambah.Name = "Btn_Tambah";
            Btn_Tambah.Size = new Size(95, 35);
            Btn_Tambah.TabIndex = 2;
            Btn_Tambah.Text = "Tambah";
            Btn_Tambah.UseVisualStyleBackColor = true;
            Btn_Tambah.Click += Btn_Tambah_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 107);
            label2.Name = "label2";
            label2.Size = new Size(117, 20);
            label2.TabIndex = 3;
            label2.Text = "Opsi Pengiriman";
            // 
            // lbl_formbarang
            // 
            lbl_formbarang.AutoSize = true;
            lbl_formbarang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_formbarang.Location = new Point(12, 9);
            lbl_formbarang.Name = "lbl_formbarang";
            lbl_formbarang.Size = new Size(105, 20);
            lbl_formbarang.TabIndex = 5;
            lbl_formbarang.Text = "Form Barang x";
            // 
            // cmbPengiriman
            // 
            cmbPengiriman.FormattingEnabled = true;
            cmbPengiriman.Items.AddRange(new object[] { "Diantar kurir", "Ambil sendiri" });
            cmbPengiriman.Location = new Point(17, 135);
            cmbPengiriman.Name = "cmbPengiriman";
            cmbPengiriman.Size = new Size(225, 23);
            cmbPengiriman.TabIndex = 6;
            // 
            // PopUpPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 231);
            Controls.Add(cmbPengiriman);
            Controls.Add(lbl_formbarang);
            Controls.Add(label2);
            Controls.Add(Btn_Tambah);
            Controls.Add(TbStok);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "PopUpPesanan";
            Text = "PopUpStokToPesanan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox TbStok;
        private Button Btn_Tambah;
        private Label label2;
        private Label lbl_formbarang;
        private ComboBox cmbPengiriman;
    }
}