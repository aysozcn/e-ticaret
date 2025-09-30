using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Urunler : BaseEntity
    {
        public string UrunAdi { get; set; }
        public string Aciklama { get; set; }
        public int UrunStok { get; set; }
        public decimal UrunFiyat { get; set; }//85
        public int KategoriId { get; set; }
        //public int SepetId { get; set; }
        public Kategoriler Kategoriler { get; set; }
        //public Sepetler Sepetler { get; set; }
        public ICollection<Yorumlar> Yorumlar { get; set; }
        public ICollection<Fotograflar> Fotograflar { get; set; }
        public ICollection<SiparisDetay> SiparisDetay { get; set; }

    }
}
