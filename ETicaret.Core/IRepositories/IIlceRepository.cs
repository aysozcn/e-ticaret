using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IIlceRepository : IGenericRepository<Ilceler>
    {
        Task<List<Ilceler>> IlceListeleAsync();
    }
}
