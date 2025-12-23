namespace HastaneRandevuSistemi
{
    partial class ProfilForm
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
            txtTc = new TextBox();
            txtAdSoyad = new TextBox();
            txtSifre = new TextBox();
            btnGuncelle = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            SuspendLayout();
            // 
            // txtTc
            // 
            txtTc.Location = new Point(521, 63);
            txtTc.MaxLength = 11;
            txtTc.Name = "txtTc";
            txtTc.ReadOnly = true;
            txtTc.Size = new Size(100, 23);
            txtTc.TabIndex = 0;
            txtTc.KeyPress += txtTc_KeyPress;
            // 
            // txtAdSoyad
            // 
            txtAdSoyad.Location = new Point(521, 124);
            txtAdSoyad.Name = "txtAdSoyad";
            txtAdSoyad.Size = new Size(100, 23);
            txtAdSoyad.TabIndex = 1;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(521, 180);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(100, 23);
            txtSifre.TabIndex = 2;
            // 
            // btnGuncelle
            // 
            btnGuncelle.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGuncelle.Location = new Point(521, 245);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(100, 32);
            btnGuncelle.TabIndex = 3;
            btnGuncelle.Text = "Güncelle";
            btnGuncelle.UseVisualStyleBackColor = true;
            btnGuncelle.Click += btnGuncelle_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(381, 68);
            label1.Name = "label1";
            label1.Size = new Size(76, 18);
            label1.TabIndex = 4;
            label1.Text = "TC Kimlik";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(381, 129);
            label2.Name = "label2";
            label2.Size = new Size(94, 18);
            label2.TabIndex = 5;
            label2.Text = "İsim Soyisim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(381, 185);
            label3.Name = "label3";
            label3.Size = new Size(42, 18);
            label3.TabIndex = 6;
            label3.Text = "Şifre";
            // 
            // ProfilForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_22_170944;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnGuncelle);
            Controls.Add(txtSifre);
            Controls.Add(txtAdSoyad);
            Controls.Add(txtTc);
            DoubleBuffered = true;
            Name = "ProfilForm";
            Text = "ProfilForm";
            Load += ProfilForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTc;
        private TextBox txtAdSoyad;
        private TextBox txtSifre;
        private Button btnGuncelle;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}