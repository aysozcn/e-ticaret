using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface ISepetlerService:IService<Sepetler>
    {
        Task<List<GetSepetlerWithKullanicilarDTO>> GetSepetlerWithKullanicilarAsync();

        Task<GetSepetlerWithKullanicilarDTO> GetSepetlerWithKullanicilarAsync(int sepetlerId);

        Task<Sepetler> GetSepetlerWithKullanicilarAsync(Sepetler sepet);
    }
}
