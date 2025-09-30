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
    public class YorumlarRepository : GenericRepository<Yorumlar>, IYorumlarRepository
    {
        public YorumlarRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {

        }

        public async Task<List<Yorumlar>> GetYorumlarWithKullanicilarAsync()
        {
            return await _eTicaretDB.Yorumlar.Include(k => k.Kullanicilar).ToListAsync();
        }
        public async Task<Yorumlar> GetYorumlarWithKullanicilarAsync(int yorumId)
        {
            return await _eTicaretDB.Yorumlar.Where(k => k.Id == yorumId).Include(k => k.Kullanicilar).FirstOrDefaultAsync();
        }

        public async Task<List<Yorumlar>> GetYorumlarWithUrunlerAsync()
        {
            return await _eTicaretDB.Yorumlar.Include(k => k.Urunler).ToListAsync();
        }
        public async Task<Yorumlar> GetYorumlarWithUrunlerAsync(int yorumId)
        {
            return await _eTicaretDB.Yorumlar.Where(k => k.Id == yorumId).Include(k => k.Urunler).FirstOrDefaultAsync();
        }

        
    }
}
