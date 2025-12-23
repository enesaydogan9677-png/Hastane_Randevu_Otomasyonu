using System;

namespace HastaneRandevuSistemi.Siniflar
{
    public class Randevu
    {
        public string RandevuId { get; set; }
        public string HastaTc { get; set; }
        public string HastaAdi { get; set; }
        public string DoktorAd { get; set; }
        public string Tarih { get; set; }
        public string Saat { get; set; } // Saati artık ayrı tutalım, yönetmesi kolay olsun
        public bool DoluMu { get; set; } // YENİ: Randevu alındı mı?
    }
}