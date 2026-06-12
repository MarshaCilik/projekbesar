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
            panel6 = new Panel();
            label6 = new Label();
            panel5 = new Panel();
            label5 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            Tb_Denda_Perhari = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            Tb_Stok = new TextBox();
            Tb_Harga = new TextBox();
            Tb_Nama_Alat = new TextBox();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
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
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(label6);
            panel6.Location = new Point(297, 421);
            panel6.Name = "panel6";
            panel6.Size = new Size(139, 41);
            panel6.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(45, 10);
            label6.Name = "label6";
            label6.Size = new Size(45, 20);
            label6.TabIndex = 9;
            label6.Text = "Batal";
            // 
            // panel5
            // 
            panel5.BackColor = Color.FromArgb(168, 197, 152);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(52, 421);
            panel5.Name = "panel5";
            panel5.Size = new Size(139, 41);
            panel5.TabIndex = 24;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(39, 12);
            label5.Name = "label5";
            label5.Size = new Size(61, 20);
            label5.TabIndex = 8;
            label5.Text = "Simpan";
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
            label2.Size = new Size(133, 32);
            label2.TabIndex = 0;
            label2.Text = "EDIT ALAT";
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
            label4.Location = new Point(222, 317);
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
            Tb_Stok.Location = new Point(208, 350);
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
            // Form_Tambah_Alat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 500);
            Controls.Add(label1);
            Controls.Add(panel6);
            Controls.Add(panel5);
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
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel6;
        private Label label6;
        private Panel panel5;
        private Label label5;
        private Panel panel1;
        private Label label2;
        private TextBox Tb_Denda_Perhari;
        private Label label7;
        private Label label4;
        private Label label3;
        private TextBox Tb_Stok;
        private TextBox Tb_Harga;
        private TextBox Tb_Nama_Alat;
    }
}