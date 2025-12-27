namespace HastaneRandevuSistemi
{
    partial class DoktorForm
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
            lblBilgi = new Label();
            dgvRandevular = new DataGridView();
            btnYenile = new Button();
            dtpTarih = new DateTimePicker();
            clbSaatler = new CheckedListBox();
            btnSlotOlustur = new Button();
            btnMuayeneEt = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            SuspendLayout();
            // 
            // lblBilgi
            // 
            lblBilgi.AutoSize = true;
            lblBilgi.BackColor = Color.White;
            lblBilgi.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBilgi.Location = new Point(56, 19);
            lblBilgi.Name = "lblBilgi";
            lblBilgi.Size = new Size(194, 18);
            lblBilgi.TabIndex = 0;
            lblBilgi.Text = "Sn. Dr. [İsim] - Hoşgeldiniz";
            // 
            // dgvRandevular
            // 
            dgvRandevular.BackgroundColor = Color.White;
            dgvRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRandevular.Location = new Point(56, 61);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.Size = new Size(527, 354);
            dgvRandevular.TabIndex = 1;
            // 
            // btnYenile
            // 
            btnYenile.BackColor = SystemColors.GradientActiveCaption;
            btnYenile.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnYenile.Location = new Point(56, 448);
            btnYenile.Name = "btnYenile";
            btnYenile.Size = new Size(122, 47);
            btnYenile.TabIndex = 2;
            btnYenile.Text = "🔄 Listeyi Yenile";
            btnYenile.UseVisualStyleBackColor = false;
            // 
            // dtpTarih
            // 
            dtpTarih.CalendarFont = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpTarih.Location = new Point(698, 111);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(188, 23);
            dtpTarih.TabIndex = 3;
            // 
            // clbSaatler
            // 
            clbSaatler.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 162);
            clbSaatler.FormattingEnabled = true;
            clbSaatler.Items.AddRange(new object[] { "08:00", "09:00", "10:00", "11:00", "13:00", "14:00", "15:00", "16:00" });
            clbSaatler.Location = new Point(698, 232);
            clbSaatler.Name = "clbSaatler";
            clbSaatler.Size = new Size(138, 148);
            clbSaatler.TabIndex = 4;
            clbSaatler.SelectedIndexChanged += clbSaatler_SelectedIndexChanged;
            // 
            // btnSlotOlustur
            // 
            btnSlotOlustur.BackColor = Color.PaleGreen;
            btnSlotOlustur.Font = new Font("Arial Narrow", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnSlotOlustur.Location = new Point(698, 447);
            btnSlotOlustur.Name = "btnSlotOlustur";
            btnSlotOlustur.Size = new Size(138, 46);
            btnSlotOlustur.TabIndex = 5;
            btnSlotOlustur.Text = "💾 Yeni Randevu Aç";
            btnSlotOlustur.UseVisualStyleBackColor = false;
            btnSlotOlustur.Click += btnSlotOlustur_Click;
            // 
            // btnMuayeneEt
            // 
            btnMuayeneEt.BackColor = Color.RosyBrown;
            btnMuayeneEt.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnMuayeneEt.Location = new Point(434, 446);
            btnMuayeneEt.Name = "btnMuayeneEt";
            btnMuayeneEt.Size = new Size(149, 47);
            btnMuayeneEt.TabIndex = 6;
            btnMuayeneEt.Text = "✅ Muayene Tamamlandı";
            btnMuayeneEt.UseVisualStyleBackColor = false;
            btnMuayeneEt.Click += btnMuayeneEt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(698, 90);
            label1.Name = "label1";
            label1.Size = new Size(100, 18);
            label1.TabIndex = 7;
            label1.Text = "Tarih Seçiniz";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(698, 211);
            label2.Name = "label2";
            label2.Size = new Size(95, 18);
            label2.TabIndex = 8;
            label2.Text = "Saat Seçiniz";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(698, 61);
            label3.Name = "label3";
            label3.Size = new Size(204, 18);
            label3.TabIndex = 9;
            label3.Text = "Yeni Randevu Eklemek İçin;";
            // 
            // DoktorForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.GradientInactiveCaption;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_22_180627;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(925, 541);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnMuayeneEt);
            Controls.Add(btnSlotOlustur);
            Controls.Add(clbSaatler);
            Controls.Add(dtpTarih);
            Controls.Add(btnYenile);
            Controls.Add(dgvRandevular);
            Controls.Add(lblBilgi);
            DoubleBuffered = true;
            Name = "DoktorForm";
            Text = "DoktorForm";
            FormClosing += DoktorForm_FormClosing;
            Load += DoktorForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBilgi;
        private DataGridView dgvRandevular;
        private Button btnYenile;
        private DateTimePicker dtpTarih;
        private CheckedListBox clbSaatler;
        private Button btnSlotOlustur;
        private Button btnMuayeneEt;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}