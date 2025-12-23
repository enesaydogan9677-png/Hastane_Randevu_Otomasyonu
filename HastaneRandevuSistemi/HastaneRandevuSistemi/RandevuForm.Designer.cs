namespace HastaneRandevuSistemi
{
    partial class RandevuForm
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
            cmbBrans = new ComboBox();
            cmbDoktor = new ComboBox();
            dtpTarih = new DateTimePicker();
            btnOnayla = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            cmbUygunSaatler = new ComboBox();
            btnGetir = new Button();
            label4 = new Label();
            SuspendLayout();
            // 
            // cmbBrans
            // 
            cmbBrans.FormattingEnabled = true;
            cmbBrans.Items.AddRange(new object[] { "Ağız ve Diş", "Cildiye", "Dahiliye ", "Fizik Tedavi ", "Göğüs Hastalıkları", "Göz Hastalıkları", "Kardiyoloji", "Nöroloji", "Radyoloji", "Onkoloji" });
            cmbBrans.Location = new Point(180, 36);
            cmbBrans.Name = "cmbBrans";
            cmbBrans.Size = new Size(121, 23);
            cmbBrans.TabIndex = 0;
            cmbBrans.SelectedIndexChanged += cmbBrans_SelectedIndexChanged;
            // 
            // cmbDoktor
            // 
            cmbDoktor.FormattingEnabled = true;
            cmbDoktor.Location = new Point(180, 95);
            cmbDoktor.Name = "cmbDoktor";
            cmbDoktor.Size = new Size(121, 23);
            cmbDoktor.TabIndex = 1;
            // 
            // dtpTarih
            // 
            dtpTarih.CalendarFont = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            dtpTarih.Location = new Point(180, 165);
            dtpTarih.Name = "dtpTarih";
            dtpTarih.Size = new Size(200, 23);
            dtpTarih.TabIndex = 2;
            // 
            // btnOnayla
            // 
            btnOnayla.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnOnayla.Location = new Point(351, 290);
            btnOnayla.Name = "btnOnayla";
            btnOnayla.Size = new Size(151, 49);
            btnOnayla.TabIndex = 3;
            btnOnayla.Text = "Ranevu Oluştur";
            btnOnayla.UseVisualStyleBackColor = true;
            btnOnayla.Click += btnOnayla_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(94, 44);
            label1.Name = "label1";
            label1.Size = new Size(50, 18);
            label1.TabIndex = 4;
            label1.Text = "Branş";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(94, 103);
            label2.Name = "label2";
            label2.Size = new Size(56, 18);
            label2.TabIndex = 5;
            label2.Text = "Doktor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(106, 170);
            label3.Name = "label3";
            label3.Size = new Size(44, 18);
            label3.TabIndex = 6;
            label3.Text = "Tarih";
            // 
            // cmbUygunSaatler
            // 
            cmbUygunSaatler.FormattingEnabled = true;
            cmbUygunSaatler.Location = new Point(180, 290);
            cmbUygunSaatler.Name = "cmbUygunSaatler";
            cmbUygunSaatler.Size = new Size(121, 23);
            cmbUygunSaatler.TabIndex = 7;
            // 
            // btnGetir
            // 
            btnGetir.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGetir.Location = new Point(180, 223);
            btnGetir.Name = "btnGetir";
            btnGetir.Size = new Size(85, 38);
            btnGetir.TabIndex = 8;
            btnGetir.Text = "Sorgula";
            btnGetir.UseVisualStyleBackColor = true;
            btnGetir.Click += btnGetir_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Arial", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(99, 290);
            label4.Name = "label4";
            label4.Size = new Size(39, 18);
            label4.TabIndex = 9;
            label4.Text = "Saat";
            // 
            // RandevuForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaption;
            BackgroundImage = Properties.Resources.Ekran_görüntüsü_2025_12_23_113904;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(btnGetir);
            Controls.Add(cmbUygunSaatler);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnOnayla);
            Controls.Add(dtpTarih);
            Controls.Add(cmbDoktor);
            Controls.Add(cmbBrans);
            DoubleBuffered = true;
            Name = "RandevuForm";
            Text = "RandevuForm";
            Load += RandevuForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cmbBrans;
        private ComboBox cmbDoktor;
        private DateTimePicker dtpTarih;
        private Button btnOnayla;
        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cmbUygunSaatler;
        private Button btnGetir;
        private Label label4;
    }
}