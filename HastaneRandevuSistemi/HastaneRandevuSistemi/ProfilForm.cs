using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;

namespace HastaneRandevuSistemi
{
    public partial class ProfilForm : Form
    {
        public Hasta gelenHasta;

        public ProfilForm()
        {
            InitializeComponent();
        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            if (gelenHasta != null)
            {
                txtTc.Text = gelenHasta.TcKimlikNo;
                txtAdSoyad.Text = gelenHasta.Ad + " " + gelenHasta.Soyad;
                txtSifre.Text = gelenHasta.Sifre;
            }
        }

        private async void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                var guncelVeri = new
                {
                    Sifre = txtSifre.Text
                };

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
                e.Handled = true;
            }
        }
    }
}