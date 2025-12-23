using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response; 

namespace HastaneRandevuSistemi
{
    public partial class KayitForm : Form
    {
        private void KayitForm_Load(object sender, EventArgs e)
        {
          
        }
        public KayitForm()
        {
            InitializeComponent();
        }

        private async void btnKaydet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtTc.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurun.");
                return;
            }

            try
            {
                if (Baglanti.client == null) Baglanti.Baglan();
                
                else
                {
                    Hasta yeniHasta = new Hasta
                    {
                        Ad = txtAd.Text,
                        Soyad = txtSoyad.Text,
                        TcKimlikNo = txtTc.Text,
                        Sifre = txtSifre.Text,
                        RandevuGecmisi = "Henüz yok"
                    };

                    FirebaseResponse response = await Baglanti.client.SetAsync("Hastalar/" + txtTc.Text, yeniHasta);

                    MessageBox.Show("Hasta kaydı başarıyla oluşturuldu!");
                }

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
                e.Handled = true;
            }
        }
    }
}