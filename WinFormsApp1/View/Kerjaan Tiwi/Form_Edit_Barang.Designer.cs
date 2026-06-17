namespace WinFormsApp1.View
{
    partial class Form_Edit_barang
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
            label2 = new Label();
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            Tb_Nama_Barang = new TextBox();
            Tb_Harga = new TextBox();
            Tb_Stok = new TextBox();
            btn_batal_edit = new Button();
            btn_selesai_edit = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(118, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(246, 56);
            panel1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(29, 9);
            label2.Name = "label2";
            label2.Size = new Size(184, 32);
            label2.TabIndex = 0;
            label2.Text = "DATA BARANG";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(57, 149);
            label1.Name = "label1";
            label1.Size = new Size(84, 15);
            label1.TabIndex = 0;
            label1.Text = "Nama Barang:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(57, 220);
            label3.Name = "label3";
            label3.Size = new Size(43, 15);
            label3.TabIndex = 6;
            label3.Text = "Harga:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(217, 365);
            label4.Name = "label4";
            label4.Size = new Size(40, 20);
            label4.TabIndex = 7;
            label4.Text = "Stok";
            // 
            // Tb_Nama_Barang
            // 
            Tb_Nama_Barang.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Barang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Barang.Location = new Point(57, 167);
            Tb_Nama_Barang.Name = "Tb_Nama_Barang";
            Tb_Nama_Barang.Size = new Size(374, 27);
            Tb_Nama_Barang.TabIndex = 8;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(57, 238);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(374, 27);
            Tb_Harga.TabIndex = 9;
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(203, 402);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(67, 39);
            Tb_Stok.TabIndex = 10;
            // 
            // btn_batal_edit
            // 
            btn_batal_edit.BackColor = Color.IndianRed;
            btn_batal_edit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_batal_edit.ForeColor = Color.Black;
            btn_batal_edit.Location = new Point(290, 489);
            btn_batal_edit.Margin = new Padding(3, 2, 3, 2);
            btn_batal_edit.Name = "btn_batal_edit";
            btn_batal_edit.Size = new Size(139, 41);
            btn_batal_edit.TabIndex = 10;
            btn_batal_edit.Text = "Batal";
            btn_batal_edit.UseVisualStyleBackColor = false;
            // 
            // btn_selesai_edit
            // 
            btn_selesai_edit.BackColor = Color.YellowGreen;
            btn_selesai_edit.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_selesai_edit.ForeColor = Color.Black;
            btn_selesai_edit.Location = new Point(56, 489);
            btn_selesai_edit.Margin = new Padding(3, 2, 3, 2);
            btn_selesai_edit.Name = "btn_selesai_edit";
            btn_selesai_edit.Size = new Size(139, 41);
            btn_selesai_edit.TabIndex = 11;
            btn_selesai_edit.Text = "Selesai";
            btn_selesai_edit.UseVisualStyleBackColor = false;
            btn_selesai_edit.Click += btn_selesai_edit_Click;
            // 
            // Form_Edit_barang
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(489, 566);
            Controls.Add(btn_selesai_edit);
            Controls.Add(btn_batal_edit);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Barang);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Form_Edit_barang";
            Text = "Form_Edit_barang";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Label label3;
        private Label label4;
        private TextBox Tb_Nama_Barang;
        private TextBox Tb_Harga;
        private TextBox Tb_Stok;
        private Button btn_batal_edit;
        private Button btn_selesai_edit;
    }
}