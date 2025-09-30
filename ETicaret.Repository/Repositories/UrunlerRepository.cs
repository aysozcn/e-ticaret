using ETicaret.Core.DTO;
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
    public class UrunlerRepository : GenericRepository<Urunler>, IUrunlerRepository
    {

        public UrunlerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
                
        }

        public async Task<List<Urunler>> GetUrunlerWithKategoriAsync()
        {
            return  await _eTicaretDB.Urunler.Include(k => k.Kategoriler).ToListAsync();
            //Eager Loading=>
            //
        }

        public async Task<Urunler> GetUrunlerWithKategoriAsync(int urunlerId)
        {
            return await _eTicaretDB.Urunler.Where(k=>k.Id==urunlerId).Include(k => k.Kategoriler).FirstOrDefaultAsync();

        }


    }
}
