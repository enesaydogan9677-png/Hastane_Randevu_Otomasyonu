using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HastaneRandevuSistemi.Siniflar
{
    public interface IVeritabaniIslemleri
    {
        bool Ekle();     
        bool Sil(); 
        bool Guncelle(); 
    }
}