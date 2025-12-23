using System;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;

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
                Baglanti.Baglan();
            }
            catch
            {
                
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
                string klasor = "";

                if (rbDoktor.Checked)
                    klasor = "Doktorlar";
                else
                    klasor = "Hastalar";

                FirebaseResponse response = await Baglanti.client.GetAsync(klasor + "/" + txtTc.Text);

                if (response.Body == "null")
                {
                    MessageBox.Show("Kullanýcý bulunamadý! TC veya Þifre yanlýþ.");
                    return;
                }

                Kullanici gelenKullanici;

                if (rbDoktor.Checked)
                    gelenKullanici = response.ResultAs<Doktor>();
                else
                    gelenKullanici = response.ResultAs<Hasta>();

                if (gelenKullanici != null && gelenKullanici.Sifre == txtSifre.Text)
                {

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

                    this.Hide();
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
            KayitForm kf = new KayitForm();
            kf.Show();
        }

        private void btnAdminGirisi_Click(object sender, EventArgs e)
        {
            string sifre = Microsoft.VisualBasic.Interaction.InputBox("Yönetici Þifresini Giriniz:", "Admin Giriþi", "");

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
                e.Handled = true;
            }
        }
    }
}