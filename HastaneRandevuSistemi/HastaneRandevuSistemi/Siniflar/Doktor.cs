namespace HastaneRandevuSistemi.Siniflar
{
    // HOCANIN NOTU: Kalıtım (Inheritance) - Kullanici sınıfından miras alındı.
    public class Doktor : Kullanici
    {
        public string Brans { get; set; } // Örn: Göz, Dahiliye
       

        // Polimorfizm: Ana sınıftaki metodu kendimize göre değiştiriyoruz.
        public override string BilgiGoster()
        {
            return $"Sn. {Ad} {Soyad} - {Brans}";
        }

        // Interface gereklilikleri (Şimdilik boş, veritabanı bağlayınca dolduracağız)
        public override bool Ekle() { return true; }
        public override bool Sil() { return true; }
        public override bool Guncelle() { return true; }
    }
}