namespace WinFormsApp1
{
    partial class LihatProdukTani
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
            Dgv_BarangTani = new DataGridView();
            Btn_TambahPesanan = new Button();
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).BeginInit();
            SuspendLayout();
            // 
            // Dgv_BarangTani
            // 
            Dgv_BarangTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_BarangTani.Location = new Point(27, 143);
            Dgv_BarangTani.Name = "Dgv_BarangTani";
            Dgv_BarangTani.Size = new Size(996, 417);
            Dgv_BarangTani.TabIndex = 0;
            // 
            // Btn_TambahPesanan
            // 
            Btn_TambahPesanan.BackColor = Color.LimeGreen;
            Btn_TambahPesanan.ForeColor = SystemColors.ActiveCaptionText;
            Btn_TambahPesanan.Location = new Point(906, 88);
            Btn_TambahPesanan.Name = "Btn_TambahPesanan";
            Btn_TambahPesanan.Size = new Size(117, 39);
            Btn_TambahPesanan.TabIndex = 1;
            Btn_TambahPesanan.Text = "Tambah Pesanan";
            Btn_TambahPesanan.UseVisualStyleBackColor = false;
            Btn_TambahPesanan.Click += Btn_TambahPesanan_Click;
            // 
            // LihatProdukTani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 628);
            Controls.Add(Btn_TambahPesanan);
            Controls.Add(Dgv_BarangTani);
            Name = "LihatProdukTani";
            RightToLeftLayout = true;
            Text = "Lihat Stok Barang Tani";
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_BarangTani;
        private Button Btn_TambahPesanan;
    }
}