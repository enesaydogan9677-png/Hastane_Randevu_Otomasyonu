namespace HastaneRandevuSistemi
{
    partial class KayitForm
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
            txtAd = new TextBox();
            txtSoyad = new TextBox();
            txtTc = new TextBox();
            txtSifre = new TextBox();
            btnKaydet = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();
            // 
            // txtAd
            // 
            txtAd.Location = new Point(418, 69);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(100, 23);
            txtAd.TabIndex = 0;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(418, 119);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(100, 23);
            txtSoyad.TabIndex = 1;
            // 
            // txtTc
            // 
            txtTc.Location = new Point(418, 168);
            txtTc.MaxLength = 11;
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(100, 23);
            txtTc.TabIndex = 2;
            txtTc.TextChanged += txtTc_TextChanged;
            txtTc.KeyPress += txtTc_KeyPress;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(418, 212);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(100, 23);
            txtSifre.TabIndex = 3;
            // 
            // btnKaydet
            // 
            btnKaydet.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnKaydet.Location = new Point(418, 278);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(109, 31);
            btnKaydet.TabIndex = 7;
            btnKaydet.Text = "Kayıt Ol";
            btnKaydet.UseVisualStyleBackColor = true;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(335, 77);
            label1.Name = "label1";
            label1.Size = new Size(36, 18);
            label1.TabIndex = 8;
            label1.Text = "İsim";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(335, 127);
            label2.Name = "label2";
            label2.Size = new Size(62, 18);
            label2.TabIndex = 9;
            label2.Text = "Soyisim";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(335, 173);
            label3.Name = "label3";
            label3.Size = new Size(53, 18);
            label3.TabIndex = 10;
            label3.Text = "TC No";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(335, 216);
            label4.Name = "label4";
            label4.Size = new Size(44, 19);
            label4.TabIndex = 11;
            label4.Text = "Şifre";
            // 
            // KayitForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ScrollBar;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_22_170944;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnKaydet);
            Controls.Add(txtSifre);
            Controls.Add(txtTc);
            Controls.Add(txtSoyad);
            Controls.Add(txtAd);
            DoubleBuffered = true;
            Name = "KayitForm";
            Text = "KayitForm";
            Load += KayitForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtAd;
        private TextBox txtSoyad;
        private TextBox txtTc;
        private TextBox txtSifre;
        private Button btnKaydet;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}