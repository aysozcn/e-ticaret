using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IYorumlarRepository : IGenericRepository<Yorumlar>
    {
        Task<List<Yorumlar>> GetYorumlarWithUrunlerAsync();
        Task<Yorumlar> GetYorumlarWithUrunlerAsync(int urunId);
        Task<List<Yorumlar>> GetYorumlarWithKullanicilarAsync();
        Task<Yorumlar> GetYorumlarWithKullanicilarAsync(int kullaniciId);
    }
}
