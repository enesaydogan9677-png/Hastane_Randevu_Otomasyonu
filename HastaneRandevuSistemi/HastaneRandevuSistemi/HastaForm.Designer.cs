namespace HastaneRandevuSistemi
{
    partial class HastaForm
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
            btnRandevuAl = new Button();
            btnIptal = new Button();
            btnGuncelle = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).BeginInit();
            SuspendLayout();
            // 
            // lblBilgi
            // 
            lblBilgi.AutoSize = true;
            lblBilgi.BackColor = Color.White;
            lblBilgi.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblBilgi.Location = new Point(63, 29);
            lblBilgi.Name = "lblBilgi";
            lblBilgi.Size = new Size(228, 18);
            lblBilgi.TabIndex = 0;
            lblBilgi.Text = "Sn. [Kullanıcı Adı] - Hoşgeldiniz";
            // 
            // dgvRandevular
            // 
            dgvRandevular.BackgroundColor = Color.White;
            dgvRandevular.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRandevular.Location = new Point(63, 84);
            dgvRandevular.Name = "dgvRandevular";
            dgvRandevular.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRandevular.Size = new Size(728, 285);
            dgvRandevular.TabIndex = 1;
            // 
            // btnRandevuAl
            // 
            btnRandevuAl.BackColor = Color.LightGreen;
            btnRandevuAl.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnRandevuAl.Location = new Point(63, 389);
            btnRandevuAl.Name = "btnRandevuAl";
            btnRandevuAl.Size = new Size(161, 65);
            btnRandevuAl.TabIndex = 2;
            btnRandevuAl.Text = "➕ Yeni Randevu Al";
            btnRandevuAl.UseVisualStyleBackColor = false;
            btnRandevuAl.Click += btnRandevuAl_Click;
            // 
            // btnIptal
            // 
            btnIptal.BackColor = Color.IndianRed;
            btnIptal.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnIptal.Location = new Point(374, 389);
            btnIptal.Name = "btnIptal";
            btnIptal.Size = new Size(155, 65);
            btnIptal.TabIndex = 3;
            btnIptal.Text = "❌ Seçili Randevuyu İptal Et";
            btnIptal.UseVisualStyleBackColor = false;
            btnIptal.Click += btnIptal_Click;
            // 
            // btnGuncelle
            // 
            btnGuncelle.BackColor = Color.Turquoise;
            btnGuncelle.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGuncelle.Location = new Point(669, 389);
            btnGuncelle.Name = "btnGuncelle";
            btnGuncelle.Size = new Size(122, 65);
            btnGuncelle.TabIndex = 4;
            btnGuncelle.Text = "Profili Güncelle";
            btnGuncelle.UseVisualStyleBackColor = false;
            btnGuncelle.Click += v_Click;
            // 
            // HastaForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_22_180359;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(854, 506);
            Controls.Add(btnGuncelle);
            Controls.Add(btnIptal);
            Controls.Add(btnRandevuAl);
            Controls.Add(dgvRandevular);
            Controls.Add(lblBilgi);
            DoubleBuffered = true;
            Name = "HastaForm";
            Text = "HastaForm";
            Load += HastaForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvRandevular).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBilgi;
        private DataGridView dgvRandevular;
        private Button btnRandevuAl;
        private Button btnIptal;
        private Button btnGuncelle;
    }
}