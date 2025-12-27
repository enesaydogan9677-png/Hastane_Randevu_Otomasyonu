using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Linq;

namespace HastaneRandevuSistemi
{
    public partial class DoktorForm : Form
    {
        public Doktor aktifDoktor;

        public DoktorForm()
        {
            InitializeComponent();
        }

        private void DoktorForm_Load(object sender, EventArgs e)
        {
            if (aktifDoktor != null)
            {
                lblBilgi.Text = $"Sn. Dr. {aktifDoktor.Ad} {aktifDoktor.Soyad} Hoşgeldiniz.";
                RandevulariGetir();
            }
        }

        private async void RandevulariGetir()
        {
            try
            {
                FirebaseResponse response = await Baglanti.client.GetAsync("Randevular");

                if (response.Body != "null")
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                    string doktorIsimSoyisim = aktifDoktor.Ad + " " + aktifDoktor.Soyad;

                    var doktorunRandevulari = dict.Values
                                                  .Where(r => r.DoktorAd == doktorIsimSoyisim)
                                                  .ToList();

                    dgvRandevular.DataSource = null;
                    dgvRandevular.DataSource = doktorunRandevulari;

                    if (dgvRandevular.Rows.Count > 0)
                    {
                        dgvRandevular.Columns["DoktorAd"].Visible = false;
                        dgvRandevular.Columns["RandevuId"].Visible = false;
                    }
                }
                else
                {
                    dgvRandevular.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void btnYenile_Click(object sender, EventArgs e)
        {
            RandevulariGetir();
        }

        private void DoktorForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btnSlotOlustur_Click(object sender, EventArgs e)
        {
            if (clbSaatler.CheckedItems.Count == 0)
            {
                MessageBox.Show("Lütfen en az bir saat seçiniz.");
                return;
            }

            string tarih = dtpTarih.Value.ToString("dd.MM.yyyy");
            string doktorAdSoyad = aktifDoktor.Ad + " " + aktifDoktor.Soyad;

            try
            {
                foreach (string seciliSaat in clbSaatler.CheckedItems)
                {
                    string id = Guid.NewGuid().ToString().Substring(0, 8);

                    Randevu yeniSlot = new Randevu
                    {
                        RandevuId = id,
                        DoktorAd = doktorAdSoyad,
                        Tarih = tarih,
                        Saat = seciliSaat,
                        DoluMu = false,
                        HastaTc = "",
                        HastaAdi = ""
                    };

                    await Baglanti.client.SetAsync("Randevular/" + id, yeniSlot);
                }

                MessageBox.Show("Seçilen saatler başarıyla açıldı!");

                for (int i = 0; i < clbSaatler.Items.Count; i++)
                    clbSaatler.SetItemChecked(i, false);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void clbSaatler_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private async void btnMuayeneEt_Click(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen muayenesi biten hastayı listeden seçiniz.");
                return;
            }

            DialogResult cevap = MessageBox.Show("Bu hastanın muayenesini tamamladınız mı? Kayıt silinecek.",
                                                 "Muayene Onayı",
                                                 MessageBoxButtons.YesNo,
                                                 MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    string id = dgvRandevular.CurrentRow.Cells["RandevuId"].Value.ToString();

                    await Baglanti.client.DeleteAsync("Randevular/" + id);

                    MessageBox.Show("Muayene kaydı tamamlandı ve listeden düşüldü.");

                    RandevulariGetir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }

        private void DoktorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 girisEkrani = (Form1)Application.OpenForms["Form1"];

            if (girisEkrani != null)
            {
                girisEkrani.Show();
            }
            else
            {
                Form1 yeniGiris = new Form1();
                yeniGiris.Show();
            }
        }
    }
}