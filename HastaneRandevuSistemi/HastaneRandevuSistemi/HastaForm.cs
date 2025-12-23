using System;
using System.Collections.Generic;
using System.Windows.Forms;
using HastaneRandevuSistemi.Siniflar;
using FireSharp.Response;
using Newtonsoft.Json;
using System.Linq;

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
                RandevulariListele();
            }
        }

        private async void RandevulariListele()
        {
            try
            {
                FirebaseResponse response = await Baglanti.client.GetAsync("Randevular");

                if (response.Body != "null")
                {
                    var dict = JsonConvert.DeserializeObject<Dictionary<string, Randevu>>(response.Body);

                    dgvRandevular.DataSource = null;
                    dgvRandevular.Rows.Clear();

                    var hastaninRandevulari = dict.Values
                                                  .Where(r => r.HastaTc == aktifHasta.TcKimlikNo)
                                                  .ToList();

                    if (hastaninRandevulari.Count > 0)
                    {
                        dgvRandevular.DataSource = hastaninRandevulari;

                        dgvRandevular.Columns["RandevuId"].Visible = false;
                        dgvRandevular.Columns["HastaTc"].Visible = false;  
                        dgvRandevular.Columns["HastaAdi"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
               
            }
        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            RandevuForm frm = new RandevuForm();
            frm.gelenHasta = aktifHasta;
            frm.ShowDialog();
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

            DialogResult onay = MessageBox.Show("Bu randevuyu iptal etmek istediğinize emin misiniz?",
                                                "İptal İşlemi",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (onay == DialogResult.Yes)
            {
                try
                {
                    string id = dgvRandevular.CurrentRow.Cells["RandevuId"].Value.ToString();

                    await Baglanti.client.DeleteAsync("Randevular/" + id);

                    MessageBox.Show("Randevu iptal edildi.");

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
            frm.gelenHasta = aktifHasta; 
            frm.ShowDialog();
        }
    }
}