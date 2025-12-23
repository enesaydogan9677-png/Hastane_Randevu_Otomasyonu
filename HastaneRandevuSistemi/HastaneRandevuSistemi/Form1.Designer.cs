namespace HastaneRandevuSistemi
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTc = new TextBox();
            txtSifre = new TextBox();
            rbDoktor = new RadioButton();
            rbHasta = new RadioButton();
            btnGiris = new Button();
            btnKayitOl = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnAdminGirisi = new Button();
            SuspendLayout();
            // 
            // txtTc
            // 
            txtTc.Location = new Point(334, 169);
            txtTc.MaxLength = 11;
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(100, 23);
            txtTc.TabIndex = 0;
            txtTc.KeyPress += txtTc_KeyPress;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(334, 216);
            txtSifre.Name = "txtSifre";
            txtSifre.PasswordChar = '*';
            txtSifre.Size = new Size(100, 23);
            txtSifre.TabIndex = 1;
            // 
            // rbDoktor
            // 
            rbDoktor.AutoSize = true;
            rbDoktor.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbDoktor.Location = new Point(398, 130);
            rbDoktor.Name = "rbDoktor";
            rbDoktor.Size = new Size(99, 20);
            rbDoktor.TabIndex = 2;
            rbDoktor.Text = "Doktor Giriş";
            rbDoktor.UseVisualStyleBackColor = true;
            // 
            // rbHasta
            // 
            rbHasta.AutoSize = true;
            rbHasta.Checked = true;
            rbHasta.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            rbHasta.Location = new Point(280, 130);
            rbHasta.Name = "rbHasta";
            rbHasta.Size = new Size(93, 20);
            rbHasta.TabIndex = 3;
            rbHasta.TabStop = true;
            rbHasta.Text = "Hasta Giriş";
            rbHasta.UseVisualStyleBackColor = true;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.Location = new Point(334, 256);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(100, 23);
            btnGiris.TabIndex = 4;
            btnGiris.Text = "Giriş Yap";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // btnKayitOl
            // 
            btnKayitOl.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKayitOl.Location = new Point(503, 304);
            btnKayitOl.Name = "btnKayitOl";
            btnKayitOl.Size = new Size(100, 29);
            btnKayitOl.TabIndex = 5;
            btnKayitOl.Text = "Kayıt Ol";
            btnKayitOl.UseVisualStyleBackColor = true;
            btnKayitOl.Click += btnKayitOl_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(248, 172);
            label1.Name = "label1";
            label1.Size = new Size(76, 18);
            label1.TabIndex = 6;
            label1.Text = "TC Kimlik";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(248, 218);
            label2.Name = "label2";
            label2.Size = new Size(42, 18);
            label2.TabIndex = 7;
            label2.Text = "Şifre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(334, 310);
            label3.Name = "label3";
            label3.Size = new Size(145, 16);
            label3.TabIndex = 8;
            label3.Text = "Kayıtlı Değil misiniz ?";
            // 
            // btnAdminGirisi
            // 
            btnAdminGirisi.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnAdminGirisi.Location = new Point(618, 12);
            btnAdminGirisi.Name = "btnAdminGirisi";
            btnAdminGirisi.Size = new Size(102, 23);
            btnAdminGirisi.TabIndex = 9;
            btnAdminGirisi.Text = "Admin Giriş";
            btnAdminGirisi.UseVisualStyleBackColor = true;
            btnAdminGirisi.Click += btnAdminGirisi_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_22_165915;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(732, 379);
            Controls.Add(btnAdminGirisi);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnKayitOl);
            Controls.Add(btnGiris);
            Controls.Add(rbHasta);
            Controls.Add(rbDoktor);
            Controls.Add(txtSifre);
            Controls.Add(txtTc);
            DoubleBuffered = true;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTc;
        private TextBox txtSifre;
        private RadioButton rbDoktor;
        private RadioButton rbHasta;
        private Button btnGiris;
        private Button btnKayitOl;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnAdminGirisi;
    }
}
