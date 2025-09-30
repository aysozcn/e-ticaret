using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Sepetler:BaseEntity
    {
        public string UrunAdi{ get; set; }
        public int UrunAdet { get; set; }
        public decimal UrunFiyati { get; set; }
        public string OdemeSekli { get; set; }
        public decimal ToplamOdeme { get; set; }
        public int urunId { get; set; }
        public string KargoAdresi { get; set; }
        public string KartNumarasi { get; set; }
        public string SiparisDurumu { get; set; }
        public string MusteriNot { get; set; }
        public int kullanicilarId { get; set; }
        public ICollection<Urunler> Urunler { get; set; }
        public ICollection<Siparisler> Siparisler { get; set; }
        public Kullanicilar kullanicilar { get; set; }

    }
}
