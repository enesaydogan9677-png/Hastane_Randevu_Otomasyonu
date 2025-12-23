using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Linq; // Filtreleme için

namespace HastaneRandevuSistemi
{
    public partial class DoktorForm : Form
    {
        // Giriş yapan doktorun bilgisi burada tutulacak
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
                // 1. Tüm randevuları çek
                FirebaseResponse response = await Baglanti.client.GetAsync("Randevular");

                if (response.Body != "null")
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                    // Veritabanında doktor ismi "Ad Soyad" şeklinde kayıtlı.
                    // Bizim elimizdeki de ayrı ayrı Ad ve Soyad. Birleştirip aratıyoruz.
                    string doktorIsimSoyisim = aktifDoktor.Ad + " " + aktifDoktor.Soyad;

                    // 2. Sadece BU doktora ait olanları filtrele
                    var doktorunRandevulari = dict.Values
                                                  .Where(r => r.DoktorAd == doktorIsimSoyisim)
                                                  .ToList();

                    dgvRandevular.DataSource = null;
                    dgvRandevular.DataSource = doktorunRandevulari;

                    // Tabloda gereksiz kolonları gizle
                    if (dgvRandevular.Rows.Count > 0)
                    {
                        dgvRandevular.Columns["DoktorAd"].Visible = false; // Zaten kendisi
                        dgvRandevular.Columns["RandevuId"].Visible = false;
                    }
                }
                else
                {
                    // Hiç randevu yoksa tabloyu temizle
                    dgvRandevular.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                // MessageBox.Show("Hata: " + ex.Message);
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
                    // Benzersiz ID oluştur
                    string id = Guid.NewGuid().ToString().Substring(0, 8);

                    Randevu yeniSlot = new Randevu
                    {
                        RandevuId = id,
                        DoktorAd = doktorAdSoyad,
                        Tarih = tarih,
                        Saat = seciliSaat,
                        DoluMu = false, // Henüz kimse almadı
                        HastaTc = "",   // Boş
                        HastaAdi = ""   // Boş
                    };

                    // Firebase'e kaydet
                    await Baglanti.client.SetAsync("Randevular/" + id, yeniSlot);
                }

                MessageBox.Show("Seçilen saatler başarıyla açıldı!");

                // Seçimleri temizle
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
                    // 2. Seçili satırdan ID'yi al
                    // (Tablonda 'RandevuId' sütununun olduğundan emin ol, gizli olsa bile verisi gelir)
                    string id = dgvRandevular.CurrentRow.Cells["RandevuId"].Value.ToString();

                    // 3. Firebase'den SİL (DeleteAsync)
                    await Baglanti.client.DeleteAsync("Randevular/" + id);

                    MessageBox.Show("Muayene kaydı tamamlandı ve listeden düşüldü.");

                    // 4. Listeyi yenile ki doktor silineni görmesin
                    RandevulariGetir(); // Senin listeleme metodunun adı neyse onu çağır
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata oluştu: " + ex.Message);
                }
            }
        }
    }
}