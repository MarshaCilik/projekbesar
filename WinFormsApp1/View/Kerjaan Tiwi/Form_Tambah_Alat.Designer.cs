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
            panel1 = new Panel();
            label2 = new Label();
            Tb_Denda_Perhari = new TextBox();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            Tb_Stok = new TextBox();
            Tb_Harga = new TextBox();
            Tb_Nama_Alat = new TextBox();
            button1 = new Button();
            button2 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(71, 185);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 22;
            label1.Text = "Nama Alat:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(74, 103, 65);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(141, 51);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(281, 75);
            panel1.TabIndex = 23;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(61, 17);
            label2.Name = "label2";
            label2.Size = new Size(166, 41);
            label2.TabIndex = 0;
            label2.Text = "EDIT ALAT";
            // 
            // Tb_Denda_Perhari
            // 
            Tb_Denda_Perhari.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Denda_Perhari.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Denda_Perhari.Location = new Point(71, 367);
            Tb_Denda_Perhari.Margin = new Padding(3, 4, 3, 4);
            Tb_Denda_Perhari.Name = "Tb_Denda_Perhari";
            Tb_Denda_Perhari.Size = new Size(427, 32);
            Tb_Denda_Perhari.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(72, 343);
            label7.Name = "label7";
            label7.Size = new Size(112, 20);
            label7.TabIndex = 31;
            label7.Text = "Denda Perhari:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(238, 424);
            label4.Name = "label4";
            label4.Size = new Size(53, 25);
            label4.TabIndex = 27;
            label4.Text = "Stok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(71, 261);
            label3.Name = "label3";
            label3.Size = new Size(55, 20);
            label3.TabIndex = 26;
            label3.Text = "Harga:";
            // 
            // Tb_Stok
            // 
            Tb_Stok.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Stok.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Stok.Location = new Point(227, 466);
            Tb_Stok.Margin = new Padding(3, 4, 3, 4);
            Tb_Stok.Name = "Tb_Stok";
            Tb_Stok.Size = new Size(76, 47);
            Tb_Stok.TabIndex = 30;
            // 
            // Tb_Harga
            // 
            Tb_Harga.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Harga.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Harga.Location = new Point(71, 285);
            Tb_Harga.Margin = new Padding(3, 4, 3, 4);
            Tb_Harga.Name = "Tb_Harga";
            Tb_Harga.Size = new Size(427, 32);
            Tb_Harga.TabIndex = 29;
            // 
            // Tb_Nama_Alat
            // 
            Tb_Nama_Alat.BackColor = Color.FromArgb(74, 103, 65);
            Tb_Nama_Alat.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Tb_Nama_Alat.Location = new Point(71, 209);
            Tb_Nama_Alat.Margin = new Padding(3, 4, 3, 4);
            Tb_Nama_Alat.Name = "Tb_Nama_Alat";
            Tb_Nama_Alat.Size = new Size(427, 32);
            Tb_Nama_Alat.TabIndex = 28;
            // 
            // button1
            // 
            button1.BackColor = Color.IndianRed;
            button1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(339, 561);
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
            button2.Location = new Point(72, 561);
            button2.Name = "button2";
            button2.Size = new Size(159, 55);
            button2.TabIndex = 33;
            button2.Text = "Selesai";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form_Tambah_Alat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(559, 667);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(Tb_Denda_Perhari);
            Controls.Add(label7);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(Tb_Stok);
            Controls.Add(Tb_Harga);
            Controls.Add(Tb_Nama_Alat);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form_Tambah_Alat";
            Text = "Form_Tambah_Alat";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label2;
        private TextBox Tb_Denda_Perhari;
        private Label label7;
        private Label label4;
        private Label label3;
        private TextBox Tb_Stok;
        private TextBox Tb_Harga;
        private TextBox Tb_Nama_Alat;
        private Button button1;
        private Button button2;
    }
}