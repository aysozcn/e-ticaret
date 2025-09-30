using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface ISepetlerRepository:IGenericRepository<Sepetler>
    {
        Task<List<Sepetler>> GetSepetlerWithKullanicilarAsync();
        Task<Sepetler> GetSepetlerWithKullanicilarAsync(int sepetlerId);
    }
}
