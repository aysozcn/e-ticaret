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
    public class ILRepository : GenericRepository<Iller>, IilRepository
    {
        public ILRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public async Task<List<Ilceler>> GetIllerWithIlceler(int ilId)
        {
            var ilceler = await _eTicaretDB.Iller.Where(il => il.IlKodu == ilId).SelectMany(il => il.Ilceler).ToListAsync();
            return ilceler;
        }

        public async Task<List<Iller>> IllerListele()
        {
            return await GetAll().ToListAsync();
        }

    }
}
