using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.ETicaretDatabase
{
    public class ErisimAlanlari:BaseEntity
    {
        //ErisimAlanlari=> Sayfaları tutan tablo
        public string ControllerAdi { get; set; }
        public string ViewAdi { get; set; }
        public string Aciklama { get; set; }
        //public int YetkiErisimId { get; set; }
        public ICollection<YetkiErisim> YetkiErisimleri { get; set; }
        //false=>15 saniye=>false yok ise 8 saniye
        
    }
}
