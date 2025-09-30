using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Ilceler
    {
        public int IlceKodu { get; set; }
        public int IlKodu { get; set; }
        public string  IlceAdi{ get; set; }        
        //[ForeignKey("IlKodu")]
        public Iller Iller{ get; set; }
        public ICollection<Adresler> Adresler { get; set; }
    }
}
