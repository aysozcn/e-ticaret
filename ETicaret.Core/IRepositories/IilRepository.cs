using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IilRepository : IGenericRepository<Iller>
    {
        Task<List<Iller>> IllerListele();
        Task<List<Ilceler>> GetIllerWithIlceler(int ilId);

    }
}
