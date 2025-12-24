namespace HastaneRandevuSistemi.Siniflar
{
    public class Doktor : Kullanici
    {
        public string Brans { get; set; }
       
        public override string BilgiGoster()
        {
            return $"Sn. {Ad} {Soyad} - {Brans}";
        }
        public override bool Ekle() { return true; }
        public override bool Sil() { return true; }
        public override bool Guncelle() { return true; }
    }
}