namespace WinFormsApp1.View
{
    partial class UpdateStok
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
            btnBatal2 = new Button();
            btnSimpan2 = new Button();
            panel21 = new Panel();
            txtStok = new TextBox();
            button17 = new Button();
            txtNamaBarang = new TextBox();
            button16 = new Button();
            panel20 = new Panel();
            label28 = new Label();
            panel21.SuspendLayout();
            panel20.SuspendLayout();
            SuspendLayout();
            // 
            // btnBatal2
            // 
            btnBatal2.BackColor = Color.FromArgb(255, 192, 192);
            btnBatal2.Location = new Point(297, 301);
            btnBatal2.Name = "btnBatal2";
            btnBatal2.Size = new Size(120, 43);
            btnBatal2.TabIndex = 105;
            btnBatal2.Text = "Batal";
            btnBatal2.UseVisualStyleBackColor = false;
            // 
            // btnSimpan2
            // 
            btnSimpan2.BackColor = Color.FromArgb(192, 255, 192);
            btnSimpan2.Location = new Point(59, 301);
            btnSimpan2.Name = "btnSimpan2";
            btnSimpan2.Size = new Size(120, 43);
            btnSimpan2.TabIndex = 104;
            btnSimpan2.Text = "Simpan";
            btnSimpan2.UseVisualStyleBackColor = false;
            // 
            // panel21
            // 
            panel21.BackColor = Color.FromArgb(49, 106, 14);
            panel21.Controls.Add(txtStok);
            panel21.Location = new Point(180, 222);
            panel21.Name = "panel21";
            panel21.Size = new Size(117, 52);
            panel21.TabIndex = 103;
            // 
            // txtStok
            // 
            txtStok.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtStok.Location = new Point(19, 16);
            txtStok.Name = "txtStok";
            txtStok.Size = new Size(81, 23);
            txtStok.TabIndex = 97;
            // 
            // button17
            // 
            button17.BackColor = Color.White;
            button17.FlatAppearance.BorderSize = 0;
            button17.FlatStyle = FlatStyle.Flat;
            button17.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button17.ForeColor = Color.FromArgb(49, 106, 14);
            button17.Location = new Point(194, 178);
            button17.Name = "button17";
            button17.Size = new Size(88, 29);
            button17.TabIndex = 102;
            button17.Text = "Stok";
            button17.UseVisualStyleBackColor = false;
            // 
            // txtNamaBarang
            // 
            txtNamaBarang.Location = new Point(51, 138);
            txtNamaBarang.Name = "txtNamaBarang";
            txtNamaBarang.Size = new Size(366, 23);
            txtNamaBarang.TabIndex = 101;
            // 
            // button16
            // 
            button16.BackColor = Color.White;
            button16.FlatAppearance.BorderSize = 0;
            button16.FlatStyle = FlatStyle.Flat;
            button16.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button16.ForeColor = Color.FromArgb(49, 106, 14);
            button16.Location = new Point(51, 103);
            button16.Name = "button16";
            button16.Size = new Size(212, 29);
            button16.TabIndex = 99;
            button16.Text = "Nama Produk/Alat sewa";
            button16.UseVisualStyleBackColor = false;
            // 
            // panel20
            // 
            panel20.BackColor = Color.FromArgb(49, 106, 14);
            panel20.Controls.Add(label28);
            panel20.Location = new Point(51, 25);
            panel20.Name = "panel20";
            panel20.Size = new Size(374, 52);
            panel20.TabIndex = 100;
            // 
            // label28
            // 
            label28.AutoSize = true;
            label28.BackColor = Color.FromArgb(49, 106, 14);
            label28.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.ForeColor = Color.White;
            label28.Location = new Point(72, 14);
            label28.Name = "label28";
            label28.Size = new Size(238, 25);
            label28.TabIndex = 95;
            label28.Text = "Update Stok Produk/Alat";
            // 
            // UpdateStok
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(487, 390);
            Controls.Add(btnBatal2);
            Controls.Add(btnSimpan2);
            Controls.Add(panel21);
            Controls.Add(button17);
            Controls.Add(txtNamaBarang);
            Controls.Add(button16);
            Controls.Add(panel20);
            Name = "UpdateStok";
            Text = "UpdateStok";
            panel21.ResumeLayout(false);
            panel21.PerformLayout();
            panel20.ResumeLayout(false);
            panel20.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBatal2;
        private Button btnSimpan2;
        private Panel panel21;
        private TextBox txtStok;
        private Button button17;
        private TextBox txtNamaBarang;
        private Button button16;
        private Panel panel20;
        private Label label28;
    }
}