using FireSharp.Response;
using System.Threading.Tasks;

namespace HastaneRandevuSistemi.Siniflar
{
    public class Hasta : Kullanici
    {
        public override string BilgiGoster()
        {
            return $"Hasta: {Ad} {Soyad}";
        }

        public async Task<bool> EkleAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(TcKimlikNo)) return false;

                SetResponse response = await Baglanti.client.SetAsync("Hastalar/" + TcKimlikNo, this);

                return response.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch
            {
                return false;
            }
        }
        public override bool Ekle()
        {
            var task = EkleAsync();
            task.Wait();
            return task.Result;
        }
        public override bool Sil() { return true; }
        public override bool Guncelle() { return true; }
    }
}