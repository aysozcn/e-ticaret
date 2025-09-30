using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IYetkilerRepository : IGenericRepository<Yetkiler>
    {
        Task<int> YetkiSayisi(int yetkiId);
        Task<string> YetkiEkle(string yetkiAdi);
        Task<string> YetkiGuncelle(int yetkiId, string yetkiAdi, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);
        Task<string> YetkiSil(int yetkiId);
        Task<List<Yetkiler>> YetkiListesi();
        Task<List<Yetkiler>> YetkiListesi(bool aktifMi);
    }
}
