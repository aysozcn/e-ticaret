using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IKategoriService : IService<Kategoriler>
    {
		Task<string> GetAllQueryAsyncs(Func<object, object> value);
		Task<List<Kategoriler>> GetKategorilerWithUrunler();
        Task<Kategoriler> GetKategorilerWithUrunler(int kategorilerId);
        IQueryable<Kategoriler> KategoriListesi();
        Task<object> KategoriSilAsync(int id);
    }
}
