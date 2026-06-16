namespace WinFormsApp1.View
{
    partial class PesananMasuk
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
            dgvPesanan = new DataGridView();
            label1 = new Label();
            btnDiterima = new Button();
            btnDItolak = new Button();
            button1 = new Button();
            btnBack = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).BeginInit();
            SuspendLayout();
            // 
            // dgvPesanan
            // 
            dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPesanan.Location = new Point(24, 80);
            dgvPesanan.Name = "dgvPesanan";
            dgvPesanan.Size = new Size(898, 415);
            dgvPesanan.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(224, 224, 224);
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(372, 23);
            label1.Name = "label1";
            label1.Size = new Size(193, 25);
            label1.TabIndex = 1;
            label1.Text = "Detail Pesaan Masuk";
            // 
            // btnDiterima
            // 
            btnDiterima.Location = new Point(731, 51);
            btnDiterima.Name = "btnDiterima";
            btnDiterima.Size = new Size(75, 23);
            btnDiterima.TabIndex = 2;
            btnDiterima.Text = "Diterima";
            btnDiterima.UseVisualStyleBackColor = true;
            // 
            // btnDItolak
            // 
            btnDItolak.Location = new Point(824, 51);
            btnDItolak.Name = "btnDItolak";
            btnDItolak.Size = new Size(75, 23);
            btnDItolak.TabIndex = 3;
            btnDItolak.Text = "Ditolak";
            btnDItolak.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Location = new Point(32, 88);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(255, 128, 128);
            btnBack.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnBack.ForeColor = SystemColors.ActiveCaptionText;
            btnBack.Location = new Point(11, 6);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(75, 23);
            btnBack.TabIndex = 5;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = false;
            // 
            // PesananMasuk
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(951, 507);
            Controls.Add(btnBack);
            Controls.Add(button1);
            Controls.Add(btnDItolak);
            Controls.Add(btnDiterima);
            Controls.Add(label1);
            Controls.Add(dgvPesanan);
            Name = "PesananMasuk";
            Text = "PesananMasuk";
            ((System.ComponentModel.ISupportInitialize)dgvPesanan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvPesanan;
        private Label label1;
        private Button btnDiterima;
        private Button btnDItolak;
        private Button button1;
        private Button btnBack;
    }
}