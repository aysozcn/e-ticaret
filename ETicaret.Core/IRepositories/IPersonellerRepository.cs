using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IPersonellerRepository:IGenericRepository<Personeller>
    {
        Task<List<Personeller>> GetPersonellerWithKullanicilarAsync();
        Task<Personeller> GetPersonellerWithKullanicilarAsync(int personellerId);
    }
}
