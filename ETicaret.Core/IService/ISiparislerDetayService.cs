using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    internal interface ISiparislerDetayService : IService<SiparisDetay>
    {
        //Bir ürün için belli tarihler arasında yapılan iparişleri
        Task<List<SiparisDetay>> GetSiparisDetayWithDateAsync(Urunler urunID, DateTime baslangic, DateTime bitis);
    }
}
