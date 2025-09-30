using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class GetYorumlarWithKullanicilarDTO:BaseListDTO
    {
        public string Yorum { get; set; }
        public int YorumUstId { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string KullaniciEmail { get; set; }
        public int UrunId { get; set; }
        public UrunlerDTO Urunler { get; set; }
        public KullanicilarDTO Kullanicilar { get; set; }

    }
}
