using System;
using System.Collections.Generic; // List ve Dictionary için
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Linq; // Filtreleme için gerekli

namespace HastaneRandevuSistemi
{
    public partial class HastaForm : Form
    {
        public Hasta aktifHasta;

        public HastaForm()
        {
            InitializeComponent();
        }

        private void HastaForm_Load(object sender, EventArgs e)
        {
            if (aktifHasta != null)
            {
                lblBilgi.Text = $"Sn. {aktifHasta.Ad} {aktifHasta.Soyad} - Hoşgeldiniz";
                // Form açılır açılmaz listeyi getir
                RandevulariListele();
            }
        }

        // BU METOT YENİ EKLENDİ
        private async void RandevulariListele()
        {
            try
            {
                // 1. Firebase'den tüm randevuları iste
                FirebaseResponse response = await Baglanti.client.GetAsync("Randevular");

                if (response.Body != "null")
                {
                    // 2. Gelen veriyi Sözlüğe çevir (ID -> Randevu Nesnesi)
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                    // 3. Listeyi temizle ki üst üste binmesin
                    dgvRandevular.DataSource = null;
                    dgvRandevular.Rows.Clear();

                    // 4. Sadece BU hastaya ait olanları filtrele
                    // (Linq sorgusu kullanıyoruz: Where şartı)
                    var hastaninRandevulari = dict.Values
                                                  .Where(r => r.HastaTc == aktifHasta.TcKimlikNo)
                                                  .ToList();

                    // 5. Tabloya (DataGridView) bağla
                    if (hastaninRandevulari.Count > 0)
                    {
                        dgvRandevular.DataSource = hastaninRandevulari;

                        // Tabloda görünmesini istemediğimiz kolonları gizleyebiliriz
                        dgvRandevular.Columns["RandevuId"].Visible = false; // ID'yi gizle
                        dgvRandevular.Columns["HastaTc"].Visible = false;   // Zaten kendi TC'si
                        dgvRandevular.Columns["HastaAdi"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // Randevu yoksa veya hata varsa sessiz kalabilir veya mesaj verebiliriz
                // MessageBox.Show("Liste hatası: " + ex.Message);
            }
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            RandevuForm frm = new RandevuForm();
            frm.gelenHasta = aktifHasta;
            frm.ShowDialog(); // Form açılır, kapanana kadar kod burada bekler

            // Randevu alıp kapattıktan sonra listeyi yenile
            RandevulariListele();
        }

        private void HastaForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private async void btnIptal_Click(object sender, EventArgs e)
        {
            if (dgvRandevular.SelectedRows.Count == 0)
            {
                MessageBox.Show("Lütfen iptal etmek istediğiniz randevuyu tablodan seçin.");
                return;
            }

            // 2. Kullanıcıdan onay al (Yanlışlıkla silmesin, Hoca bunu sever: Hata Yönetimi)
            DialogResult onay = MessageBox.Show("Bu randevuyu iptal etmek istediğinize emin misiniz?",
                                                "İptal İşlemi",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    // 3. Tabloda seçili olan satırdan 'RandevuId' değerini al
                    // (Bu sütunu 'RandevulariListele' metodunda gizlemiştik ama veri orada duruyor)
                    string id = dgvRandevular.CurrentRow.Cells["RandevuId"].Value.ToString();

                    // 4. Firebase'den SİL (DeleteAsync)
                    // Randevular/KarmasikID yolunu siliyoruz
                    await Baglanti.client.DeleteAsync("Randevular/" + id);

                    MessageBox.Show("Randevu iptal edildi.");

                    // 5. Tabloyu yenile ki silinen satır ekrandan gitsin
                    RandevulariListele();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme işleminde hata oluştu: " + ex.Message);
                }
            }
        }

        private void v_Click(object sender, EventArgs e)
        {
            ProfilForm frm = new ProfilForm();
            frm.gelenHasta = aktifHasta; // Hastanın bilgisini gönderiyoruz
            frm.ShowDialog();
        }
    }
}