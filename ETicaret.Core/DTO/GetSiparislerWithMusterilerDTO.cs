using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class GetSiparislerWithMusterilerDTO : BaseListDTO
    {
        public int ToplamUrunAdet { get; set; }
        public string ToplamFiyat { get; set; }
        public int MusteriID { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
    }
}
