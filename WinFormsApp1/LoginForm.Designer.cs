namespace WinFormsApp1
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            panel1 = new Panel();
            btn_BuatAkun = new Button();
            button1 = new Button();
            TbPassword = new TextBox();
            label4 = new Label();
            TbUsername = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btn_BuatAkun);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(TbPassword);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TbUsername);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(182, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(549, 490);
            panel1.TabIndex = 0;
            // 
            // btn_BuatAkun
            // 
            btn_BuatAkun.BackColor = Color.Transparent;
            btn_BuatAkun.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_BuatAkun.Location = new Point(104, 397);
            btn_BuatAkun.Name = "btn_BuatAkun";
            btn_BuatAkun.Size = new Size(359, 42);
            btn_BuatAkun.TabIndex = 8;
            btn_BuatAkun.Text = "BUAT AKUN";
            btn_BuatAkun.UseVisualStyleBackColor = false;
            btn_BuatAkun.Click += btn_BuatAkun_Click;
            // 
            // button1
            // 
            button1.BackColor = SystemColors.GradientActiveCaption;
            button1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(104, 349);
            button1.Name = "button1";
            button1.Size = new Size(359, 42);
            button1.TabIndex = 7;
            button1.Text = "LOGIN";
            button1.UseVisualStyleBackColor = false;
            button1.Click += btnLogin_Click;
            // 
            // TbPassword
            // 
            TbPassword.Location = new Point(104, 279);
            TbPassword.Name = "TbPassword";
            TbPassword.Size = new Size(359, 23);
            TbPassword.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(104, 256);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 5;
            label4.Text = "Password";
            // 
            // TbUsername
            // 
            TbUsername.Location = new Point(104, 219);
            TbUsername.Name = "TbUsername";
            TbUsername.Size = new Size(359, 23);
            TbUsername.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(104, 196);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 3;
            label3.Text = "Username";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(230, 144);
            label2.Name = "label2";
            label2.Size = new Size(98, 32);
            label2.TabIndex = 2;
            label2.Text = "PETANI";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(186, 19);
            label1.Name = "label1";
            label1.Size = new Size(194, 32);
            label1.TabIndex = 1;
            label1.Text = "LOGIN SEBAGAI";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(211, 39);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(140, 102);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.pngtree_background_blur_rice_field_blur_sunrise_photo_image_20947706;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(924, 514);
            Controls.Add(panel1);
            Name = "LoginForm";
            Text = "LoginForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox TbPassword;
        private Label label4;
        private TextBox TbUsername;
        private Label label3;
        private Button button1;
        private Button btn_BuatAkun;
    }
}