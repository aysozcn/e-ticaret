using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class Kategoriler:BaseEntity
    {

        public string KategoriAdi{ get; set; }
        public string Aciklama { get; set; }
        //Referans değerlerde nullable 
        public ICollection<Urunler> Urunler { get; set; }


    }
}
