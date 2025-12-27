using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;

namespace HastaneRandevuSistemi
{
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
            this.FormClosing += AdminForm_FormClosing;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            DoktorlariGetir();
        }

        private async void DoktorlariGetir()
        {
            try
            {
                var response = await Baglanti.client.GetAsync("Doktorlar");

                if (response.Body != "null")
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Doktor>>(response.Body);

                    List<Doktor> doktorListesi = new List<Doktor>();
                    foreach (var item in dict.Values)
                    {
                        doktorListesi.Add(item);
                    }

                    dgvDoktorlar.DataSource = doktorListesi;

                    if (dgvDoktorlar.Columns["Sifre"] != null) dgvDoktorlar.Columns["Sifre"].Visible = false;
                }
                else
                {
                    dgvDoktorlar.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Listeleme hatası: " + ex.Message);
            }
        }

        private async void btnDoktorEkle_Click(object sender, EventArgs e)
        {
            if (txtTc.Text.Length != 11)
            {
                MessageBox.Show("TC Kimlik Numarası 11 haneli olmalıdır!");
                return;
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

                await Baglanti.client.SetAsync("Doktorlar/" + txtTc.Text, yeniDoktor);

                MessageBox.Show("Doktor başarıyla eklendi.");
                Temizle();

                DoktorlariGetir();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private async void btnDoktorSil_Click(object sender, EventArgs e)
        {
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
                    string silinecekTc = dgvDoktorlar.CurrentRow.Cells["TcKimlikNo"].Value.ToString();

                    await Baglanti.client.DeleteAsync("Doktorlar/" + silinecekTc);

                    MessageBox.Show("Doktor kaydı silindi.");

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
                e.Handled = true;
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
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