using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class SepetlerDTO:BaseDTO
    {
        public int UrunAdet { get; set; }
        public decimal ToplamFiyat { get; set; }
        public string OdemeSekli { get; set; }
        public decimal OdemeMiktari { get; set; }
        public int urunId { get; set; }
        public string KargoAdresi { get; set; }
        public string indirimKodu { get; set; }
        public string SiparisDurumu { get; set; }
        public string MusteriNot { get; set; }
        public int kullaniciId { get; set; }
        public string KullaniciAdiSoyadi { get; set; }
    }
}
