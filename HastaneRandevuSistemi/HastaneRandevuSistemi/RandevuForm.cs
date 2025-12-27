using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Linq;

namespace HastaneRandevuSistemi
{
    public partial class RandevuForm : Form
    {
        private void RandevuForm_Load(object sender, EventArgs e)
        {

        }
        public Hasta gelenHasta;

        public RandevuForm()
        {
            InitializeComponent();
        }

        private async void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear(); 

            if (cmbBrans.SelectedIndex == -1) return;

            string secilenBrans = cmbBrans.SelectedItem.ToString();

            try
            {
                FirebaseResponse response = await Baglanti.client.GetAsync("Doktorlar");

                if (response.Body != "null")
                {
                    var doktorlarListesi = JsonConvert.DeserializeObject<Dictionary<string, Doktor>>(response.Body);

                    foreach (var item in doktorlarListesi)
                    {
                        Doktor dr = item.Value;
                        if (dr.Brans == secilenBrans)
                        {
                            cmbDoktor.Items.Add(dr.Ad + " " + dr.Soyad);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Doktor listesi çekilemedi: " + ex.Message);
            }
        }

        private async void btnOnayla_Click(object sender, EventArgs e)
        {
            if (cmbUygunSaatler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen listeden bir saat seçiniz.");
                return;
            }

            try
            {
                string secilenDoktor = cmbDoktor.SelectedItem.ToString();
                string secilenBrans = cmbBrans.Text;
                string secilenTarih = dtpTarih.Value.ToString("dd.MM.yyyy");
                string secilenSaat = cmbUygunSaatler.SelectedItem.ToString();
                

                var response = await Baglanti.client.GetAsync("Randevular");
                var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                Randevu bulunacakRandevu = null;

                foreach (var item in dict.Values)
                {                                     

                    if (item.DoktorAd == secilenDoktor && item.Tarih == secilenTarih && item.Saat == secilenSaat)
                    {
                        bulunacakRandevu = item;
                        break;
                    }
                }

                if (bulunacakRandevu != null)
                {
                    bulunacakRandevu.HastaTc = gelenHasta.TcKimlikNo;
                    bulunacakRandevu.Brans = secilenBrans;
                    bulunacakRandevu.HastaAdi = gelenHasta.Ad + " " + gelenHasta.Soyad;
                    bulunacakRandevu.DoluMu = true;
                    

                    await Baglanti.client.UpdateAsync("Randevular/" + bulunacakRandevu.RandevuId, bulunacakRandevu);

                    MessageBox.Show($"Randevunuz {secilenSaat} saati için başarıyla oluşturuldu!");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hata: Seçilen randevu saati sistemde bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Randevu alınırken hata oluştu: " + ex.Message);
            }
        }
        private async void MusaitSaatleriGetir()
        {
            cmbUygunSaatler.Items.Clear();

            if (cmbDoktor.SelectedIndex == -1) return;

            string secilenDoktor = cmbDoktor.SelectedItem.ToString();
            string secilenTarih = dtpTarih.Value.ToString("dd.MM.yyyy");

            var response = await Baglanti.client.GetAsync("Randevular");
            if (response.Body == "null") return;

            var dict = JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

            foreach (var item in dict.Values)
            {
                if (item.DoktorAd == secilenDoktor && item.Tarih == secilenTarih && item.DoluMu == false)
                {
                    cmbUygunSaatler.Items.Add(item.Saat);
                }
            }

            if (cmbUygunSaatler.Items.Count == 0)
                MessageBox.Show("Bu tarihte boş randevu bulunamadı.");
        }

        private async void btnGetir_Click(object sender, EventArgs e)
        {
            cmbUygunSaatler.Items.Clear();
            cmbUygunSaatler.Text = "";

            if (cmbDoktor.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen önce bir doktor seçin.");
                return;
            }

            string secilenDoktor = cmbDoktor.SelectedItem.ToString();
            string secilenTarih = dtpTarih.Value.ToString("dd.MM.yyyy");

            try
            {
                var response = await Baglanti.client.GetAsync("Randevular");

                if (response.Body != "null")
                {
                    var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                    int sayac = 0;

                    List<string> geciciSaatListesi = new List<string>();

                    foreach (var item in dict.Values)
                    {
                        if (item.DoktorAd == secilenDoktor && item.Tarih == secilenTarih && item.DoluMu == false)
                        {
                            geciciSaatListesi.Add(item.Saat);
                        }
                    }

                    if (geciciSaatListesi.Count > 0)
                    {
                        geciciSaatListesi = geciciSaatListesi.OrderBy(x => DateTime.Parse(x)).ToList();

                        cmbUygunSaatler.Items.Clear();
                        foreach (var saat in geciciSaatListesi)
                        {
                            cmbUygunSaatler.Items.Add(saat);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bu tarihte boş randevu bulunamadı.");
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

    }
}