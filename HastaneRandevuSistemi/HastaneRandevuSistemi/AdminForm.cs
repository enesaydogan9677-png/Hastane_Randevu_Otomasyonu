using System;
using System.Collections.Generic; // Listeler için gerekli
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json; // Veriyi okumak için gerekli

namespace HastaneRandevuSistemi
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            // Form açılınca doktorları listele
            DoktorlariGetir();
        }

        // --- 1. LİSTELEME METODU ---
        private async void DoktorlariGetir()
        {
            try
            {
                var response = await Baglanti.client.GetAsync("Doktorlar");

                if (response.Body != "null")
                {
                    // Gelen veriyi Sözlük (Dictionary) formatında alıyoruz
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Doktor>>(response.Body);

                    // Sözlükteki değerleri (Doktor nesnelerini) bir listeye çevirip tabloya veriyoruz
                    List<Doktor> doktorListesi = new List<Doktor>();
                    foreach (var item in dict.Values)
                    {
                        doktorListesi.Add(item);
                    }

                    dgvDoktorlar.DataSource = doktorListesi;

                    // Tablo başlıklarını düzenleyelim (İsteğe bağlı)
                    if (dgvDoktorlar.Columns["Sifre"] != null) dgvDoktorlar.Columns["Sifre"].Visible = false; // Şifre görünmesin
                }
                else
                {
                    dgvDoktorlar.DataSource = null; // Hiç doktor yoksa tabloyu boşalt
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        // --- 2. EKLEME BUTONU ---
        private async void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            if (txtTc.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalıdır!");
                return; // İşlemi durdur, aşağıya inme
            }
            if (string.IsNullOrEmpty(txtAd.Text) || string.IsNullOrEmpty(txtSoyad.Text) ||
                string.IsNullOrEmpty(txtTc.Text) || string.IsNullOrEmpty(txtSifre.Text) || cmbBrans.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return;
            }

            try
            {
                Doktor yeniDoktor = new Doktor
                {
                    Ad = txtAd.Text,
                    Soyad = txtSoyad.Text,
                    TcKimlikNo = txtTc.Text,
                    Sifre = txtSifre.Text,
                    Brans = cmbBrans.SelectedItem.ToString()
                };

                // Firebase'e Kaydet (TC kimlik no anahtar olarak kullanılır)
                await Baglanti.client.SetAsync("Doktorlar/" + txtTc.Text, yeniDoktor);

                MessageBox.Show("Doktor başarıyla eklendi.");
                Temizle();

                // Listeyi yenile ki yeni doktoru görelim
                DoktorlariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        // --- 3. SİLME BUTONU (YENİ) ---
        private async void btnDoktorSil_Click(object sender, EventArgs e)
        {
            // Seçili satır var mı?
            if (dgvDoktorlar.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen silinecek doktoru tablodan seçiniz.");
                return;
            }

            DialogResult cevap = MessageBox.Show("Seçili doktoru silmek istediğinize emin misiniz?", "Silme Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    // Seçili satırdaki doktorun TC'sini al (Çünkü veritabanında TC ile kayıtlı)
                    // Not: Tablodaki sütun adının "TcKimlikNo" olduğundan emin ol (Doktor sınıfındaki property adı)
                    string silinecekTc = dgvDoktorlar.CurrentRow.Cells["TcKimlikNo"].Value.ToString();

                    // Firebase'den sil
                    await Baglanti.client.DeleteAsync("Doktorlar/" + silinecekTc);

                    MessageBox.Show("Doktor kaydı silindi.");

                    // Listeyi yenile
                    DoktorlariGetir();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme hatası: " + ex.Message);
                }
            }
        }

        void Temizle()
        {
            txtAd.Clear(); txtSoyad.Clear(); txtTc.Clear(); txtSifre.Clear(); cmbBrans.SelectedIndex = -1;
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