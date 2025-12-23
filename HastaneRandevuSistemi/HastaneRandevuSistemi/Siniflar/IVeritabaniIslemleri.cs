using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuSistemi.Siniflar
{
    // HOCANIN NOTU: Bu Interface, projedeki standart veritabanı işlemlerini belirler.
    // Abstract ve Interface kullanımı buradan puan getirecek.
    public interface IVeritabaniIslemleri
    {
        bool Ekle();      // Kayıt ekleme
        bool Sil();       // Kayıt silme
        bool Guncelle();  // Bilgi güncelleme
    }
}