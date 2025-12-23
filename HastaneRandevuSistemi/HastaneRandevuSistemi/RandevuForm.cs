using System;
using System.Collections.Generic; // List ve Dictionary için gerekli
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
        // Randevuyu alan hastanın bilgisini buraya taşıyacağız
        public Hasta gelenHasta;

        public RandevuForm()
        {
            InitializeComponent();
        }

        // Branş seçilince çalışacak (Doktorları getirir)
        private async void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear(); // Önce temizle

            if (cmbBrans.SelectedIndex == -1) return;

            string secilenBrans = cmbBrans.SelectedItem.ToString();

            try
            {
                // 1. Tüm Doktorları Çek
                FirebaseResponse response = await Baglanti.client.GetAsync("Doktorlar");

                if (response.Body != "null")
                {
                    // Gelen veriyi Sözlük (Dictionary) yapısına çeviriyoruz
                    // Çünkü Firebase veriyi {"TCno": {Bilgiler}, "TCno2": {Bilgiler}} şeklinde tutuyor.
                    var doktorlarListesi = JsonConvert.DeserializeObject<Dictionary<string, Doktor>>(response.Body);

                    // 2. Branşı uyanları listeye ekle
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
                string secilenTarih = dtpTarih.Value.ToString("dd.MM.yyyy");
                string secilenSaat = cmbUygunSaatler.SelectedItem.ToString();

                // 1. Veritabanından o özel slotu bulmamız lazım
                var response = await Baglanti.client.GetAsync("Randevular");
                var dict = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                // LINQ ile aradığımız kriterlere uyan kaydı buluyoruz
                // (Doktor aynı, Tarih aynı, Saat aynı olan kayıt)
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
                    // 2. Kaydı GÜNCELLE (Update)
                    bulunacakRandevu.HastaTc = gelenHasta.TcKimlikNo;
                    bulunacakRandevu.HastaAdi = gelenHasta.Ad + " " + gelenHasta.Soyad;
                    bulunacakRandevu.DoluMu = true; // Artık bu saat doldu!

                    // Firebase'deki eski halinin üzerine yazıyoruz
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
        // Doktor ve Tarih seçili ise Müsait Saatleri Getir
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
                // 1. Doktor Eşleşiyor mu?
                // 2. Tarih Eşleşiyor mu?
                // 3. Randevu BOŞ mu? (DoluMu == false)
                if (item.DoktorAd == secilenDoktor && item.Tarih == secilenTarih && item.DoluMu == false)
                {
                    // Combobox'a sadece saati eklemiyoruz, ID'yi de bilmemiz lazım.
                    // O yüzden basitçe saati ekleyelim, kaydederken tekrar buluruz.
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
                        // Senin mevcut kontrolün (Doktor, Tarih ve Doluluk kontrolü)
                        if (item.DoktorAd == secilenDoktor && item.Tarih == secilenTarih && item.DoluMu == false)
                        {
                            // DİKKAT: Artık doğrudan ComboBox'a eklemiyoruz!
                            // Listeye ekliyoruz ki sonra sıralayabilelim.
                            geciciSaatListesi.Add(item.Saat);
                        }
                    }

                    if (geciciSaatListesi.Count > 0)
                    {
                        geciciSaatListesi = geciciSaatListesi.OrderBy(x => DateTime.Parse(x)).ToList();

                        // 2. Şimdi sıralanmış listeyi tertemiz ComboBox'a dolduruyoruz
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

        // Bunu Doktor seçimi değiştiğinde veya Tarih değiştiğinde çağırabilirsin.
        // Örn: dtpTarih_ValueChanged eventi içine: MusaitSaatleriGetir();
    }
}