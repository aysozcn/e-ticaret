using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IAdreslerRepository : IGenericRepository<Adresler>
    {
        Task<List<Adresler>> AdreslerListeleAsync();
        Task<List<Adresler>> GetAdreslerWithIlcelerAsync(int ılceKodu);
        Task<List<Adresler>> GetAdreslerWithIlcelerAsync();
        Task<Adresler> GetAdreslerWithMusteriAsync();
        Task<Adresler> GetAdreslerWithMusteriAsync(int musteriId);
        Task<List<Sp_AdreslerWithMusteriDto>> AdresVeMusteri();

        Task<Adresler> AdresSilAsync(int id);



    }

}
