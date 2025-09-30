using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IFotograflarService : IService<Fotograflar>
    {
        //Task<List<Urunler>> GetFotograflarWithUrunlerAsync();

        //Task<Urunler> GetFotograflarWithUrunlerAsync(int fotograflarId);

        Task<IEnumerable<GetFotograflarWithUrunlerDTO>> GetFotografWithUrunAsync();

        Task<GetFotograflarWithUrunlerDTO> GetFotografWithUrunAsync(int fotografId);

        Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografGuncelleAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi);

        Task<string> FotografSilAsync(int fotografId);

        Task<IEnumerable<Fotograflar>> FotografListesiAsync();

        Task<IEnumerable<Fotograflar>> FotografListesiAsync(bool aktifMi);
    }
}
