using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IErisimAlanlariService : IService<ErisimAlanlari>
    {
        Task<List<ErisimAlanlari>> GetErisimAlanlariWithYetkiIdAsync(int yetkiId);
        Task<List<ErisimAlanlariDTO>> GetErisimAlani();

    }
}
