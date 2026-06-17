namespace WinFormsApp1.View.Dashboard_Admin
{
    partial class EditDataKurir
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
            panel1 = new Panel();
            label1 = new Label();
            panel2 = new Panel();
            Tb_Nama = new TextBox();
            panel3 = new Panel();
            Tb_NoTelp = new TextBox();
            panel7 = new Panel();
            Tb_Alamat = new TextBox();
            Btn_Simpan = new Button();
            Btn_Batal = new Button();
            label7 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel7.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(119, 33);
            panel1.Name = "panel1";
            panel1.Size = new Size(397, 70);
            panel1.TabIndex = 43;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Elephant", 20.2499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(84, 16);
            label1.Name = "label1";
            label1.Size = new Size(231, 35);
            label1.TabIndex = 0;
            label1.Text = "DATA KURIR";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(74, 103, 65);
            panel2.Controls.Add(Tb_Nama);
            panel2.Location = new Point(40, 144);
            panel2.Name = "panel2";
            panel2.Size = new Size(549, 38);
            panel2.TabIndex = 44;
            // 
            // Tb_Nama
            // 
            Tb_Nama.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama.BorderStyle = BorderStyle.FixedSingle;
            Tb_Nama.ForeColor = Color.White;
            Tb_Nama.Location = new Point(12, 7);
            Tb_Nama.Name = "Tb_Nama";
            Tb_Nama.Size = new Size(521, 23);
            Tb_Nama.TabIndex = 0;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(74, 103, 65);
            panel3.Controls.Add(Tb_NoTelp);
            panel3.Location = new Point(40, 216);
            panel3.Name = "panel3";
            panel3.Size = new Size(549, 38);
            panel3.TabIndex = 45;
            // 
            // Tb_NoTelp
            // 
            Tb_NoTelp.BackColor = Color.FromArgb(74, 103, 65);
            Tb_NoTelp.BorderStyle = BorderStyle.FixedSingle;
            Tb_NoTelp.ForeColor = Color.White;
            Tb_NoTelp.Location = new Point(13, 9);
            Tb_NoTelp.Name = "Tb_NoTelp";
            Tb_NoTelp.Size = new Size(521, 23);
            Tb_NoTelp.TabIndex = 1;
            // 
            // panel7
            // 
            panel7.BackColor = Color.FromArgb(74, 103, 65);
            panel7.Controls.Add(Tb_Alamat);
            panel7.Location = new Point(39, 290);
            panel7.Name = "panel7";
            panel7.Size = new Size(549, 38);
            panel7.TabIndex = 49;
            // 
            // Tb_Alamat
            // 
            Tb_Alamat.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Alamat.BorderStyle = BorderStyle.FixedSingle;
            Tb_Alamat.ForeColor = Color.White;
            Tb_Alamat.Location = new Point(11, 9);
            Tb_Alamat.Name = "Tb_Alamat";
            Tb_Alamat.Size = new Size(521, 23);
            Tb_Alamat.TabIndex = 5;
            // 
            // Btn_Simpan
            // 
            Btn_Simpan.BackColor = Color.FromArgb(168, 197, 152);
            Btn_Simpan.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Simpan.Location = new Point(38, 388);
            Btn_Simpan.Name = "Btn_Simpan";
            Btn_Simpan.Size = new Size(550, 49);
            Btn_Simpan.TabIndex = 62;
            Btn_Simpan.Text = "SIMPAN";
            Btn_Simpan.UseVisualStyleBackColor = false;
            Btn_Simpan.Click += Btn_Simpan_Click;
            // 
            // Btn_Batal
            // 
            Btn_Batal.BackColor = SystemColors.ButtonHighlight;
            Btn_Batal.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Btn_Batal.Location = new Point(37, 443);
            Btn_Batal.Name = "Btn_Batal";
            Btn_Batal.Size = new Size(550, 49);
            Btn_Batal.TabIndex = 63;
            Btn_Batal.Text = "BATAL";
            Btn_Batal.UseVisualStyleBackColor = false;
            Btn_Batal.Click += Btn_Batal_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(39, 272);
            label7.Name = "label7";
            label7.Size = new Size(101, 15);
            label7.TabIndex = 57;
            label7.Text = "ALAMAT(JALAN):";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(40, 198);
            label3.Name = "label3";
            label3.Size = new Size(60, 15);
            label3.TabIndex = 53;
            label3.Text = "NO. TELP:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(40, 126);
            label2.Name = "label2";
            label2.Size = new Size(46, 15);
            label2.TabIndex = 52;
            label2.Text = "NAMA:";
            // 
            // EditDataKurir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(629, 559);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(panel3);
            Controls.Add(panel7);
            Controls.Add(Btn_Simpan);
            Controls.Add(Btn_Batal);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label2);
            Name = "EditDataKurir";
            Text = "EditDataKurir";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private TextBox Tb_Nama;
        private Panel panel3;
        private TextBox Tb_NoTelp;
        private Panel panel7;
        private TextBox Tb_Alamat;
        private Button Btn_Simpan;
        private Button Btn_Batal;
        private Label label7;
        private Label label3;
        private Label label2;
    }
}