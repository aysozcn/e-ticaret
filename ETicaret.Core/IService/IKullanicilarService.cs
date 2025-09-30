using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IKullanicilarService:IService<Kullanicilar>
    {
       
        Task<List<GetKullanicilarWithYetkilerDTO>> GetKullanicilarWithYetkilerAsync();
        Task<GetKullanicilarWithYetkilerDTO> GetKullanicilarWithYetkilerAsync(int kullaniciId);
        Task<Kullanicilar> getKullanicilarWithYetkilerAsync(Kullanicilar yetkiler);

        
    }
}
