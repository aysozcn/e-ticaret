using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class YetkiErisim 
    {
        public int ErisimAlaniId { get; set; }
        public int YetkiId { get; set; }
        public string YetkiAdi {  get; set; }
        public string Aciklama { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public Yetkiler Yetkiler { get; set; }
        public ErisimAlanlari ErisimAlanlari { get; set; }
    }
}
