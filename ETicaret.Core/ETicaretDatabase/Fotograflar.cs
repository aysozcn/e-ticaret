using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Fotograflar : BaseEntity
    {
        public string FotografYolu { get; set; }
        //public string FotografAdi{ get; set; }

        public string FotografAciklamasi { get; set; }

        public byte? FotografSirasi { get; set; }

        public int UrunId { get; set; }

        public Urunler Urunler { get; set; }
    }
}
