using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class SiparisDetay
    {
        // Ethem
        public int SiparisDetayId { get; set; }
        public int SiparisId { get; set; }
        public int UrunId { get; set; }
        public int UrunAdet { get; set; }
        public decimal BirimFiyat { get; set; }//85=>75->80=> 1
        public Siparisler Siparisler { get; set; }
        public Urunler Urunler { get; set; }
    }
}
