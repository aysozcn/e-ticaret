using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IYorumlarService : IService<Yorumlar>
    {
        Task<List<GetYorumlarWithKullanicilarDTO>> GetYorumlarWithKullanicilarAsync();
        Task<GetYorumlarWithKullanicilarDTO> GetYorumlarWithKullanicilarAsync(int kullaniciId);
        Task<List<GetYorumlarWithUrunlerDTO>> GetYorumlarWithUrunlerAsync();
        Task<GetYorumlarWithUrunlerDTO> GetYorumlarWithUrunlerAsync(int urunId);

    }
}
