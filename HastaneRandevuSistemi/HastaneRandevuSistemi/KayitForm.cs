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
            Hasta yeniHasta = new Hasta();
            yeniHasta.Ad = txtAd.Text;
            yeniHasta.Soyad = txtSoyad.Text;
            yeniHasta.TcKimlikNo = txtTc.Text;
            yeniHasta.Sifre = txtSifre.Text;

            if (yeniHasta.Ekle())
            {
                MessageBox.Show("Kayıt Başarılı!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Kayıt sırasında hata oluştu.");
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