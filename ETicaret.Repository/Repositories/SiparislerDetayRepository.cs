using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Repositories
{
    public class SiparislerDetayRespository : GenericRepository<SiparisDetay>, ISiparislerDetayRepository
    {
        public SiparislerDetayRespository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public Task<List<SiparisDetay>> GetSiparisDetayWithDateAsync(Urunler urunID, DateTime baslangic, DateTime bitis)
        {
            throw new NotImplementedException();
        }
    }
}
