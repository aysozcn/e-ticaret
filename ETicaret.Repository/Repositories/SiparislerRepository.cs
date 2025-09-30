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
    public class SiparislerRespository : GenericRepository<Siparisler>, ISiparislerRepository
    {
        public SiparislerRespository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        // Siparişlerde sipariş tarihi yoktu sonradan eklendi
        public async Task<List<Siparisler>> GetSiparislerMadeTodayAsync(DateTime siparisTarihi)
        {
            return await _eTicaretDB.Siparisler.Include(m => m.EklenmeTarih).ToListAsync();
        }

        public async Task<List<Siparisler>> GetSiparislerWithMusterilerAsync(Musteriler musteriID)
        {
            return await _eTicaretDB.Siparisler.Include(m => m.Musteriler).ToListAsync();
        }

        public async Task<List<Siparisler>> GetSiparislerWithKullanicilarAsync(Kullanicilar kullaniciID)
        {
            return await _eTicaretDB.Siparisler.Include(m => m.Kullanicilar).ToListAsync();
        }

        public void AddSiparis(Siparisler newSiparis)
        {
            throw new NotImplementedException();
        }
    }
}
