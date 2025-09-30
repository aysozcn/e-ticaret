using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class SiparislerDTO:BaseDTO
    {
        public int KullaniciId { get; set; }
        public int UrunId { get; set; }
        public DateTime SiparisTarihi { get; set; }
        public int ToplamUrunAdet { get; set; }



    }
}
