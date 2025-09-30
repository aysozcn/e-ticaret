using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IAdreslerService : IService<Adresler>
    {
        Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithMusteriAsync(int musteriId);
        Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithMusteriAsync();

        Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithIlceAsync(int ilceId);
        Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithIlceAsync();

        Task<List<Sp_AdreslerWithMusteriDto>> AdresVeMusteri();

        Task<object> AdresSilAsync(int id);

    }
}
