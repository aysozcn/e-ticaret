using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.DTO
{
    public class IlceDTO
    {
        public int IlceKodu { get; set; }
        public int IlKodu { get; set; }
        public string IlceAdi { get; set; }
        public IlDto Iller { get; set; }
    }
}
