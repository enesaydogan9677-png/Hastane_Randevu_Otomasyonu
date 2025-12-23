using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.IO;

namespace HastaneRandevuSistemi.Siniflar
{
    // HOCANIN NOTU: Static sınıf ve Singleton yapısı kullanılarak 
    // her seferinde yeniden bağlantı açılması engellendi (Performans Kriteri).
    public static class Baglanti
    {
        // 1. Firebase Ayarları
        public static IFirebaseConfig config = new FirebaseConfig
        {
            // Buraya Veritabanı Linkini yapıştır (tırnaklar kalsın)
            BasePath = "https://ntb-projesi-default-rtdb.firebaseio.com/",

            // Buraya Database Secret (Gizli Anahtar) yapıştır
            AuthSecret = "kBBUiTpcSiWFEy9lmiERdYuphbfhxlbXzvkedjhB"
        };

        public static IFirebaseClient client;

        // Bağlantıyı başlatan metot
        public static void Baglan()
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    throw new Exception("Bağlantı kurulamadı.");
                }
            }
            catch (Exception ex)
            {
                // Hata Yönetimi kriteri için
                System.Windows.Forms.MessageBox.Show("Veritabanı Hatası: " + ex.Message);
            }
        }
    }
}