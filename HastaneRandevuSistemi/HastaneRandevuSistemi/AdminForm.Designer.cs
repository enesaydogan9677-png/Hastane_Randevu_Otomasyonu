namespace HastaneRandevuSistemi
{
    partial class AdminForm
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
            groupBox1 = new GroupBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            btnDoktorEkle = new Button();
            cmbBrans = new ComboBox();
            txtSifre = new TextBox();
            txtTc = new TextBox();
            txtSoyad = new TextBox();
            txtAd = new TextBox();
            dgvDoktorlar = new DataGridView();
            btnDoktorSil = new Button();
            label6 = new Label();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(btnDoktorEkle);
            groupBox1.Controls.Add(cmbBrans);
            groupBox1.Controls.Add(txtSifre);
            groupBox1.Controls.Add(txtTc);
            groupBox1.Controls.Add(txtSoyad);
            groupBox1.Controls.Add(txtAd);
            groupBox1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            groupBox1.Location = new Point(12, 22);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(425, 348);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "➕ Doktor Ekle  ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(225, 47);
            label5.Name = "label5";
            label5.Size = new Size(50, 18);
            label5.TabIndex = 10;
            label5.Text = "Branş";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 223);
            label4.Name = "label4";
            label4.Size = new Size(42, 18);
            label4.TabIndex = 9;
            label4.Text = "Şifre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(14, 159);
            label3.Name = "label3";
            label3.Size = new Size(76, 18);
            label3.TabIndex = 8;
            label3.Text = "TC Kimlik";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(14, 101);
            label2.Name = "label2";
            label2.Size = new Size(62, 18);
            label2.TabIndex = 7;
            label2.Text = "Soyisim";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 47);
            label1.Name = "label1";
            label1.Size = new Size(36, 18);
            label1.TabIndex = 6;
            label1.Text = "İsim";
            // 
            // btnDoktorEkle
            // 
            btnDoktorEkle.Location = new Point(296, 191);
            btnDoktorEkle.Name = "btnDoktorEkle";
            btnDoktorEkle.Size = new Size(106, 50);
            btnDoktorEkle.TabIndex = 5;
            btnDoktorEkle.Text = "Yeni Doktor Ekle";
            btnDoktorEkle.UseVisualStyleBackColor = true;
            btnDoktorEkle.Click += btnDoktorEkle_Click;
            // 
            // cmbBrans
            // 
            cmbBrans.FormattingEnabled = true;
            cmbBrans.Items.AddRange(new object[] { "Ağız ve Diş", "Cildiye", "Dahiliye ", "Fizik Tedavi ", "Göğüs Hastalıkları", "Göz Hastalıkları", "Kardiyoloji", "Nöroloji", "Radyoloji", "Onkoloji" });
            cmbBrans.Location = new Point(281, 44);
            cmbBrans.Name = "cmbBrans";
            cmbBrans.Size = new Size(121, 26);
            cmbBrans.TabIndex = 4;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(96, 220);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(100, 25);
            txtSifre.TabIndex = 3;
            // 
            // txtTc
            // 
            txtTc.Location = new Point(96, 156);
            txtTc.MaxLength = 11;
            txtTc.Name = "txtTc";
            txtTc.Size = new Size(100, 25);
            txtTc.TabIndex = 2;
            txtTc.KeyPress += txtTc_KeyPress;
            // 
            // txtSoyad
            // 
            txtSoyad.Location = new Point(96, 98);
            txtSoyad.Name = "txtSoyad";
            txtSoyad.Size = new Size(100, 25);
            txtSoyad.TabIndex = 1;
            // 
            // txtAd
            // 
            txtAd.Location = new Point(96, 47);
            txtAd.Name = "txtAd";
            txtAd.Size = new Size(100, 25);
            txtAd.TabIndex = 0;
            // 
            // dgvDoktorlar
            // 
            dgvDoktorlar.BackgroundColor = Color.White;
            dgvDoktorlar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDoktorlar.Location = new Point(468, 47);
            dgvDoktorlar.MultiSelect = false;
            dgvDoktorlar.Name = "dgvDoktorlar";
            dgvDoktorlar.ReadOnly = true;
            dgvDoktorlar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDoktorlar.Size = new Size(300, 323);
            dgvDoktorlar.TabIndex = 1;
            // 
            // btnDoktorSil
            // 
            btnDoktorSil.BackColor = Color.Red;
            btnDoktorSil.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDoktorSil.ForeColor = Color.White;
            btnDoktorSil.Location = new Point(637, 387);
            btnDoktorSil.Name = "btnDoktorSil";
            btnDoktorSil.Size = new Size(131, 36);
            btnDoktorSil.TabIndex = 2;
            btnDoktorSil.Text = " Doktoru Sil";
            btnDoktorSil.UseVisualStyleBackColor = false;
            btnDoktorSil.Click += btnDoktorSil_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Arial Black", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(468, 22);
            label6.Name = "label6";
            label6.Size = new Size(259, 22);
            label6.TabIndex = 3;
            label6.Text = "Silmek İçin Doktor Seçiniz. 🗑️";
            // 
            // AdminForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_23_113457;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label6);
            Controls.Add(btnDoktorSil);
            Controls.Add(dgvDoktorlar);
            Controls.Add(groupBox1);
            DoubleBuffered = true;
            Name = "AdminForm";
            Text = "AdminForm";
            Load += AdminForm_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDoktorlar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox txtSifre;
        private TextBox txtTc;
        private TextBox txtSoyad;
        private TextBox txtAd;
        private Button btnDoktorEkle;
        private ComboBox cmbBrans;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private DataGridView dgvDoktorlar;
        private Button btnDoktorSil;
        private Label label6;
    }
}