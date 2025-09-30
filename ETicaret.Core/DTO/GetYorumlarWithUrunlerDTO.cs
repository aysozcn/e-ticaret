using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class GetYorumlarWithUrunlerDTO
    {
        public string Yorum { get; set; }
        public int YorumUstId { get; set; }
        public int UrunId { get; set; }
        public int KategoriId { get; set; }
    }
}
