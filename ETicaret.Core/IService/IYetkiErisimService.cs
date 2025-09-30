using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IYetkiErisimService : IService<YetkiErisim>
    {
        Task<string> YetkiErisimEkle(int erisimAlaniId, int yetkiId, string aciklama);
        Task<string> YetkiErisimSil(int erisimAlaniId, int yetkiId);
        Task<List<YetkiErisim>> YetkiErisimleri();
    }
}
