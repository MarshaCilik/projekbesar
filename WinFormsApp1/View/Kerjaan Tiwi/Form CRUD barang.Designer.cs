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
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(135, 36);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 75);
            panel1.TabIndex = 0;
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(65, 199);
            label1.Name = "label1";
            label1.Size = new Size(109, 20);
            label1.TabIndex = 0;
            label1.Text = "Nama Barang:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(65, 293);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 6;
            label3.Text = "Harga:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(249, 381);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 7;
            label4.Text = "Stok";
            // 
            // Tb_Nama_Barang
            // 
            Tb_Nama_Barang.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Barang.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Barang.Location = new Point(65, 223);
            Tb_Nama_Barang.Margin = new Padding(3, 4, 3, 4);
            Tb_Nama_Barang.Name = "Tb_Nama_Barang";
            Tb_Nama_Barang.Size = new Size(427, 32);
            Tb_Nama_Barang.TabIndex = 8;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(65, 317);
            Tb_Harga.Margin = new Padding(3, 4, 3, 4);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(427, 32);
            Tb_Harga.TabIndex = 9;
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(233, 431);
            Tb_Stok.Margin = new Padding(3, 4, 3, 4);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(76, 47);
            Tb_Stok.TabIndex = 10;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Black;
            button1.Location = new Point(333, 547);
            button1.Name = "button1";
            button1.Size = new Size(159, 55);
            button1.TabIndex = 10;
            button1.Text = "Batal";
            button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            button2.BackColor = Color.YellowGreen;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.Black;
            button2.Location = new Point(65, 547);
            button2.Name = "button2";
            button2.Size = new Size(159, 55);
            button2.TabIndex = 11;
            button2.Text = "Selesai";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form_Edit_barang
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 667);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Barang);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label1);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button button1;
        private Button button2;
    }
}