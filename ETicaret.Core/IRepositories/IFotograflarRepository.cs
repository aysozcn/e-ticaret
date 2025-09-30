using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IFotograflarRepository : IGenericRepository<Fotograflar>
    {
        //Task<List<Fotograflar>> GetFotograflarWithUrunlerAsync();

        //Task<Fotograflar> GetFotograflarWithUrunlerAsync(int fotograflarId);

        //

        //Task<int> FotografSayisi(int fotografId);

        //Task<string> FotografEkle(string fotografYolu, string fotografAciklamasi, byte? fotografSirasi, int urunId, bool aktifMi, DateTime eklenmeTarihi);

        //Task<string> FotografGuncelle(int fotografId, string fotografYolu, string fotografAciklamasi, byte? fotografSirasi, int urunId, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellemeTarihi);

        //Task<string> FotografSil(int fotografId);

        //Task<List<Fotograflar>> FotografListesi();

        //Task<List<Fotograflar>> FotografListesi(bool aktifMi);

        Task<List<Fotograflar>> GetFotografWithUrunAsync();

        Task<Fotograflar> GetFotografWithUrunAsync(int fotografId);

        Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografGuncelleAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografSilAsync(int fotografId);

        Task<List<Fotograflar>> FotografListesiAsync();

        Task<List<Fotograflar>> FotografListesiAsync(bool aktifMi);
    }
}
