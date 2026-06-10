namespace WinFormsApp1.View
{
    partial class Dashboard_admin
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
            label2 = new Label();
            label3 = new Label();
            dgv_AllUser = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(0, 25);
            label1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Rockwell", 20F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(318, 80);
            label2.Name = "label2";
            label2.Size = new Size(318, 46);
            label2.TabIndex = 1;
            label2.Text = "Selamat Datang!";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(318, 139);
            label3.Name = "label3";
            label3.Size = new Size(642, 160);
            label3.TabIndex = 2;
            label3.Text = "Pantau user dan  CRUD produk dengan aman dan nyaman.\r\n\r\n\r\n\r\n\r\n";
            // 
            // dgv_AllUser
            // 
            dgv_AllUser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_AllUser.Location = new Point(293, 359);
            dgv_AllUser.Name = "dgv_AllUser";
            dgv_AllUser.RowHeadersWidth = 62;
            dgv_AllUser.Size = new Size(934, 610);
            dgv_AllUser.TabIndex = 3;
            // 
            // Dashboard_admin
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Group_1__2_;
            ClientSize = new Size(1277, 1024);
            Controls.Add(dgv_AllUser);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Dashboard_admin";
            Text = "Dashboard_admin";
            ((System.ComponentModel.ISupportInitialize)dgv_AllUser).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgv_AllUser;
    }
}