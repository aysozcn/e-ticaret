using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IYetkilerService : IService<Yetkiler>
    {
        Task<List<Yetkiler>> GetYetkilerWithErisimAlanIDAsync(int erisimAlanId);
        Task<List<YetkilerDTO>> GetYetkiler();
    }
}
