using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response; // Firebase cevapları için

namespace HastaneRandevuSistemi
{
    public partial class KayitForm : Form
    {
        private void KayitForm_Load(object sender, EventArgs e)
        {
            // Burası şimdilik boş kalabilir, hatayı gidermek için ekledik.
        }
        public KayitForm()
        {
            InitializeComponent();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            // 1. Boş alan kontrolü
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtTc.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.");
                return;
            }

            try
            {
                // Firebase bağlantısını kontrol et
                if (Baglanti.client == null) Baglanti.Baglan();

                // 2. Seçime göre kayıt işlemi
                
                else
                {
                    // HASTA KAYDI
                    Hasta yeniHasta = new Hasta
                    {
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TcKimlikNo = txtTc.Text,
                        Sifre = txtSifre.Text,
                        RandevuGecmisi = "Henüz yok"
                    };

                    // Firebase'e "Hastalar" başlığı altına TC no ile kaydet
                    FirebaseResponse response = await Baglanti.client.SetAsync("Hastalar/" + txtTc.Text, yeniHasta);

                    MessageBox.Show("Hasta kaydı başarıyla oluşturuldu!");
                }

                // Kayıt bitince bu formu kapat
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kayıt sırasında hata oluştu: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {

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