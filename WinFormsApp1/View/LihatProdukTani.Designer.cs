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
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).BeginInit();
            SuspendLayout();
            // 
            // Dgv_BarangTani
            // 
            Dgv_BarangTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_BarangTani.Location = new Point(27, 180);
            Dgv_BarangTani.Name = "Dgv_BarangTani";
            Dgv_BarangTani.Size = new Size(996, 380);
            Dgv_BarangTani.TabIndex = 0;
            // 
            // LihatProdukTani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 628);
            Controls.Add(Dgv_BarangTani);
            Name = "LihatProdukTani";
            RightToLeftLayout = true;
            Text = "Lihat Stok Barang Tani";
            ((System.ComponentModel.ISupportInitialize)Dgv_BarangTani).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_BarangTani;
    }
}