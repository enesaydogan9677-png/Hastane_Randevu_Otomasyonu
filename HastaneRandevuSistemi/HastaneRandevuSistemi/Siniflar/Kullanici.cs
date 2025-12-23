using System;

namespace HastaneRandevuSistemi.Siniflar
{
    // HOCANIN NOTU: Soyutlama (Abstraction) ve Kapsülleme (Encapsulation) burada yapılıyor.
    public abstract class Kullanici : IVeritabaniIslemleri
    {
        // Kapsülleme: Değişkenler private, erişim property ile.
        private string _tcKimlikNo;
        private string _sifre;

        public string Ad { get; set; }
        public string Soyad { get; set; }

        public string TcKimlikNo
        {
            get { return _tcKimlikNo; }
            set { _tcKimlikNo = value; }
        }

        public string Sifre
        {
            get { return _sifre; }
            set { _sifre = value; }
        }

        // HOCANIN NOTU: Polimorfizm (Çok Biçimlilik) için 'virtual' metot.
        // Bu metot Doktor ve Hasta sınıflarında ezilecek (override).
        public virtual string BilgiGoster()
        {
            return $"{Ad} {Soyad} - {TcKimlikNo}";
        }

        // Interface metodlarını miras alan sınıflara (Doktor/Hasta) zorunlu kılıyoruz.
        public abstract bool Ekle();
        public abstract bool Sil();
        public abstract bool Guncelle();
    }
}