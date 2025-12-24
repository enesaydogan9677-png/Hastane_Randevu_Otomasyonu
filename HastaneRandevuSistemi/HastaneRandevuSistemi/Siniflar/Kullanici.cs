using System;

namespace HastaneRandevuSistemi.Siniflar
{
    public abstract class Kullanici : IVeritabaniIslemleri
    {
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
        public virtual string BilgiGoster()
        {
            return $"{Ad} {Soyad} - {TcKimlikNo}";
        }

        public abstract bool Ekle();
        public abstract bool Sil();
        public abstract bool Guncelle();
    }
}