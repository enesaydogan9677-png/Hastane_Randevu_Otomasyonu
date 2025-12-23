namespace HastaneRandevuSistemi.Siniflar
{
    public class Hasta : Kullanici
    {
        public string Cinsiyet { get; set; }
        public string RandevuGecmisi { get; set; }

        public override string BilgiGoster()
        {
            return $"Hasta: {Ad} {Soyad}";
        }

        public override bool Ekle() { return true; }
        public override bool Sil() { return true; }
        public override bool Guncelle() { return true; }
    }
}