namespace WinFormsApp1.View.Kerjaan_Tiwi
{
    partial class PopUpPesananAlat
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
            cmbPengiriman = new ComboBox();
            Lbl_FormAlat = new Label();
            Lbl_OpsiPengiriman = new Label();
            Btn_Tambah = new Button();
            TbStok = new TextBox();
            label1 = new Label();
            label3 = new Label();
            Dtp_TanggalSewa = new DateTimePicker();
            Btn_Batal = new Button();
            label2 = new Label();
            Cbx_OpsiPengembalian = new ComboBox();
            SuspendLayout();
            // 
            // cmbPengiriman
            // 
            cmbPengiriman.FormattingEnabled = true;
            cmbPengiriman.Items.AddRange(new object[] { "Diantar kurir", "Ambil sendiri" });
            cmbPengiriman.Location = new Point(17, 215);
            cmbPengiriman.Name = "cmbPengiriman";
            cmbPengiriman.Size = new Size(225, 23);
            cmbPengiriman.TabIndex = 12;
            // 
            // Lbl_FormAlat
            // 
            Lbl_FormAlat.AutoSize = true;
            Lbl_FormAlat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_FormAlat.Location = new Point(12, 10);
            Lbl_FormAlat.Name = "Lbl_FormAlat";
            Lbl_FormAlat.Size = new Size(85, 20);
            Lbl_FormAlat.TabIndex = 11;
            Lbl_FormAlat.Text = "Form Alat x";
            // 
            // Lbl_OpsiPengiriman
            // 
            Lbl_OpsiPengiriman.AutoSize = true;
            Lbl_OpsiPengiriman.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Lbl_OpsiPengiriman.Location = new Point(12, 187);
            Lbl_OpsiPengiriman.Name = "Lbl_OpsiPengiriman";
            Lbl_OpsiPengiriman.Size = new Size(117, 20);
            Lbl_OpsiPengiriman.TabIndex = 10;
            Lbl_OpsiPengiriman.Text = "Opsi Pengiriman";
            // 
            // Btn_Tambah
            // 
            Btn_Tambah.Location = new Point(451, 410);
            Btn_Tambah.Name = "Btn_Tambah";
            Btn_Tambah.Size = new Size(95, 35);
            Btn_Tambah.TabIndex = 9;
            Btn_Tambah.Text = "Tambah";
            Btn_Tambah.UseVisualStyleBackColor = true;
            Btn_Tambah.Click += Btn_Tambah_Click;
            // 
            // TbStok
            // 
            TbStok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TbStok.Location = new Point(17, 65);
            TbStok.Name = "TbStok";
            TbStok.Size = new Size(100, 23);
            TbStok.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(154, 20);
            label1.TabIndex = 7;
            label1.Text = "Masukkan jumlah stok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(12, 109);
            label3.Name = "label3";
            label3.Size = new Size(229, 20);
            label3.TabIndex = 13;
            label3.Text = "Masukkan tanggal pengembalian";
            // 
            // Dtp_TanggalSewa
            // 
            Dtp_TanggalSewa.Location = new Point(17, 132);
            Dtp_TanggalSewa.Name = "Dtp_TanggalSewa";
            Dtp_TanggalSewa.Size = new Size(200, 23);
            Dtp_TanggalSewa.TabIndex = 14;
            // 
            // Btn_Batal
            // 
            Btn_Batal.Location = new Point(350, 410);
            Btn_Batal.Name = "Btn_Batal";
            Btn_Batal.Size = new Size(95, 35);
            Btn_Batal.TabIndex = 15;
            Btn_Batal.Text = "Batal";
            Btn_Batal.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(12, 272);
            label2.Name = "label2";
            label2.Size = new Size(137, 20);
            label2.TabIndex = 16;
            label2.Text = "Opsi Pengembalian";
            // 
            // Cbx_OpsiPengembalian
            // 
            Cbx_OpsiPengembalian.FormattingEnabled = true;
            Cbx_OpsiPengembalian.Items.AddRange(new object[] { "Diambil kurir", "Antar sendiri" });
            Cbx_OpsiPengembalian.Location = new Point(17, 295);
            Cbx_OpsiPengembalian.Name = "Cbx_OpsiPengembalian";
            Cbx_OpsiPengembalian.Size = new Size(225, 23);
            Cbx_OpsiPengembalian.TabIndex = 17;
            // 
            // PopUpPesananAlat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(558, 457);
            Controls.Add(Cbx_OpsiPengembalian);
            Controls.Add(label2);
            Controls.Add(Btn_Batal);
            Controls.Add(Dtp_TanggalSewa);
            Controls.Add(label3);
            Controls.Add(cmbPengiriman);
            Controls.Add(Lbl_FormAlat);
            Controls.Add(Lbl_OpsiPengiriman);
            Controls.Add(Btn_Tambah);
            Controls.Add(TbStok);
            Controls.Add(label1);
            Name = "PopUpPesananAlat";
            Text = "PopUpPesananAlat";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbPengiriman;
        private Label Lbl_FormAlat;
        private Label Lbl_OpsiPengiriman;
        private Button Btn_Tambah;
        private TextBox TbStok;
        private Label label1;
        private Label label3;
        private DateTimePicker Dtp_TanggalSewa;
        private Button Btn_Batal;
        private Label label2;
        private ComboBox Cbx_OpsiPengembalian;
    }
}