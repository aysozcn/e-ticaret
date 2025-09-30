using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IErisimAlanlariRepository : IGenericRepository<ErisimAlanlari>
    {
        Task<string> ErisimAlaniEkle(string controllerAdi, string viewAdi, string aciklama);
        Task<string> TopluErisimAlaniEkle(IEnumerable<ErisimAlanlari> erisimAlanlari);
        Task<string> ErisimAlaniGuncelle(int erisimAlaniId, string controllerAdi, string viewAdi, string aciklama, bool aktifMi, DateTime eklemeTarihi);
        Task<string> ErisimAlaniSil(int erisimAlaniId);
        Task<string> TopluErisimAlaniSil(IEnumerable<ErisimAlanlari> erisimAlanlari);
        Task<List<ErisimAlanlari>> ErisimAlaniListesi();
        Task<List<ErisimAlanlari>> ErisimAlaniListesi(bool aktifMi);
    }
}
