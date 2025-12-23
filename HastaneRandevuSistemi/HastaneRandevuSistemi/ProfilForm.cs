using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;

namespace HastaneRandevuSistemi
{
    public partial class ProfilForm : Form
    {
        // Düzenlenecek hastanın bilgisini buraya alacağız
        public Hasta gelenHasta;

        public ProfilForm()
        {
            InitializeComponent();
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            // Form açılınca kutuları mevcut bilgilerle doldur
            if (gelenHasta != null)
            {
                txtTc.Text = gelenHasta.TcKimlikNo;
                txtAdSoyad.Text = gelenHasta.Ad + " " + gelenHasta.Soyad;
                txtSifre.Text = gelenHasta.Sifre;
            }
        }

        // HATA BURADAYDI: 'async' kelimesi void'den hemen önce olmalı.
        // Aşağıdaki satırda 'async' yazıyor, bu yüzden artık çalışması lazım.
        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                // Güncellenecek veriyi hazırla (Sadece şifreyi güncelliyoruz)
                var guncelVeri = new
                {
                    Sifre = txtSifre.Text
                };

                // Firebase'de GÜNCELLE
                // Not: Eğer 'UpdateAsync' hata verirse, yerine 'SetAsync' deneyebiliriz.
                // Ama önce bunu dene.
                FirebaseResponse response = await Baglanti.client.UpdateAsync("Hastalar/" + txtTc.Text, guncelVeri);

                MessageBox.Show("Bilgileriniz başarıyla güncellendi!");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Güncelleme hatası: " + ex.Message);
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bu tuşu "yok say", yazma.
            }
        }
    }
}