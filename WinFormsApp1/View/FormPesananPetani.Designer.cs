namespace WinFormsApp1.View
{
    partial class FormPesananPetani
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
            Dgv_PesananTani = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Dgv_PesananTani).BeginInit();
            SuspendLayout();
            // 
            // Dgv_PesananTani
            // 
            Dgv_PesananTani.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Dgv_PesananTani.Location = new Point(11, 90);
            Dgv_PesananTani.Name = "Dgv_PesananTani";
            Dgv_PesananTani.Size = new Size(602, 274);
            Dgv_PesananTani.TabIndex = 0;
            // 
            // FormPesananPetani
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Dgv_PesananTani);
            Name = "FormPesananPetani";
            Text = "Pesanan Anda";
            ((System.ComponentModel.ISupportInitialize)Dgv_PesananTani).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView Dgv_PesananTani;
    }
}