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
            Lbl_OpsiPengiriman = new Label();
            lbl_formbarang = new Label();
            cmbPengiriman = new ComboBox();
            Lbl_MetodePembayaran = new Label();
            Cbx_MetodePembayaran = new ComboBox();
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
            // Lbl_OpsiPengiriman
            // 
            Lbl_OpsiPengiriman.AutoSize = true;
            Lbl_OpsiPengiriman.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_OpsiPengiriman.Location = new Point(12, 107);
            Lbl_OpsiPengiriman.Name = "Lbl_OpsiPengiriman";
            Lbl_OpsiPengiriman.Size = new Size(117, 20);
            Lbl_OpsiPengiriman.TabIndex = 3;
            Lbl_OpsiPengiriman.Text = "Opsi Pengiriman";
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
            // Lbl_MetodePembayaran
            // 
            Lbl_MetodePembayaran.AutoSize = true;
            Lbl_MetodePembayaran.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_MetodePembayaran.Location = new Point(354, 41);
            Lbl_MetodePembayaran.Name = "Lbl_MetodePembayaran";
            Lbl_MetodePembayaran.Size = new Size(146, 20);
            Lbl_MetodePembayaran.TabIndex = 7;
            Lbl_MetodePembayaran.Text = "Metode Pembayaran";
            // 
            // Cbx_MetodePembayaran
            // 
            Cbx_MetodePembayaran.FormattingEnabled = true;
            Cbx_MetodePembayaran.Items.AddRange(new object[] { "Tunai", "Transfer Bank" });
            Cbx_MetodePembayaran.Location = new Point(354, 64);
            Cbx_MetodePembayaran.Name = "Cbx_MetodePembayaran";
            Cbx_MetodePembayaran.Size = new Size(225, 23);
            Cbx_MetodePembayaran.TabIndex = 8;
            // 
            // PopUpPesanan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(623, 231);
            Controls.Add(Cbx_MetodePembayaran);
            Controls.Add(Lbl_MetodePembayaran);
            Controls.Add(cmbPengiriman);
            Controls.Add(lbl_formbarang);
            Controls.Add(Lbl_OpsiPengiriman);
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
        private Label Lbl_OpsiPengiriman;
        private Label lbl_formbarang;
        private ComboBox cmbPengiriman;
        private Label Lbl_MetodePembayaran;
        private ComboBox Cbx_MetodePembayaran;
    }
}