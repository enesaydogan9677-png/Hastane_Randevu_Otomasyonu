using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar; // Sýnýflarý tanýttýk
using FireSharp.Response; // Firebase cevaplarý için
using Newtonsoft.Json; // Veriyi iþlemek için

namespace HastaneRandevuSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Baglanti.Baglan(); // Baðlantýyý garantiye alýyoruz
            }
            catch
            {
                // Zaten baðlanmýþsa hata vermesin
            }
        }

        private async void btnGiris_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTc.Text) || string.IsNullOrEmpty(txtSifre.Text))
            {
                MessageBox.Show("Lütfen tüm alanlarý doldurun.");
                return;
            }

            try
            {
                string klasor = ""; // Veritabanýnda hangi klasöre bakacaðýz?

                if (rbDoktor.Checked)
                    klasor = "Doktorlar";
                else
                    klasor = "Hastalar";

                // 1. Firebase'den o TC'ye ait veriyi çek
                FirebaseResponse response = await Baglanti.client.GetAsync(klasor + "/" + txtTc.Text);

                // 2. Eðer kullanýcý yoksa
                if (response.Body == "null")
                {
                    MessageBox.Show("Kullanýcý bulunamadý! TC veya Þifre yanlýþ.");
                    return;
                }

                // 3. Veriyi nesneye çevir (Hangi sýnýf seçiliyse ona göre)
                // Polymorphism burada devreye giriyor gibi düþünebiliriz.
                Kullanici gelenKullanici;

                if (rbDoktor.Checked)
                    gelenKullanici = response.ResultAs<Doktor>();
                else
                    gelenKullanici = response.ResultAs<Hasta>();

                // 4. Þifre Kontrolü
                if (gelenKullanici != null && gelenKullanici.Sifre == txtSifre.Text)
                {

                    // Ýlgili formu aç ve bunu gizle
                    if (rbDoktor.Checked)
                    {
                        DoktorForm drForm = new DoktorForm();
                        drForm.aktifDoktor = (Doktor)gelenKullanici;
                        drForm.Show();
                    }
                    else
                    {
                        HastaForm hstForm = new HastaForm();
                        hstForm.aktifHasta = (Hasta)gelenKullanici;
                        hstForm.Show();
                    }

                    this.Hide(); // Giriþ ekranýný gizle
                }
                else
                {
                    MessageBox.Show("Hatalý Þifre!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bir hata oluþtu: " + ex.Message);
            }
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            // Kayýt formuna yönlendir
            KayitForm kf = new KayitForm();
            kf.Show();
        }

        private void btnAdminGirisi_Click(object sender, EventArgs e)
        {
            string sifre = Microsoft.VisualBasic.Interaction.InputBox("Yönetici Þifresini Giriniz:", "Admin Giriþi", "");

            // Þifre "1234" ise giriþ yapsýn
            if (sifre == "1234")
            {
                AdminForm frm = new AdminForm();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalý þifre!");
            }
        }

        private void txtTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Bu tuþu "yok say", yazma.
            }
        }
    }
}