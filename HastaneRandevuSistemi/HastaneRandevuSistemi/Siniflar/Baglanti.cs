using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.IO;

namespace HastaneRandevuSistemi.Siniflar
{
    public static class Baglanti
    {
        public static IFirebaseConfig config = new FirebaseConfig
        {
            BasePath = "https://ntb-projesi-default-rtdb.firebaseio.com/",

            AuthSecret = "kBBUiTpcSiWFEy9lmiERdYuphbfhxlbXzvkedjhB"
        };

        public static IFirebaseClient client;

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
                System.Windows.Forms.MessageBox.Show("Veritabanı Hatası: " + ex.Message);
            }
        }
    }
}