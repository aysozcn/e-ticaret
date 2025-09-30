using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Repositories
{
    public class IlceRepoistory : GenericRepository<Ilceler>, IIlceRepository
    {
        //private readonly AppDbContext _eTicaretDB;
        public IlceRepoistory(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
            
        }

        public async Task<List<Ilceler>> IlceListeleAsync()
        {
            return await GetAll().ToListAsync();
        }

    }
}
