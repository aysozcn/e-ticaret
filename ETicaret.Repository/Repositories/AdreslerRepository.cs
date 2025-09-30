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
    public class AdreslerRepository : GenericRepository<Adresler>, IAdreslerRepository
    {

        public AdreslerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {

        }

        public async Task<List<Adresler>> AdreslerListeleAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Sp_AdreslerWithMusteriDto>> AdresVeMusteri()
        {
            var adresListe = await _eTicaretDB.Sp_AdresMusteri();
            return adresListe;
        }

        public async Task<List<Adresler>> GetAdreslerWithIlcelerAsync(int ilceKodu)
        {
            return await _eTicaretDB.Adresler.Include(x => x.Ilce).ThenInclude(ilce => ilce.Iller).Where(a => a.IlceKodu == ilceKodu).ToListAsync();
        }

        public async Task<List<Adresler>> GetAdreslerWithIlcelerAsync()
        {

            return await _eTicaretDB.Adresler.Include(k => k.Ilce).ThenInclude(ilce => ilce.Iller).ToListAsync();

        }

        public async Task<Adresler> GetAdreslerWithMusteriAsync(int musteriId)
        {
            return await _eTicaretDB.Adresler.Include(k => k.Musteriler).Where(x => x.MusteriId == musteriId).FirstOrDefaultAsync();
        }

        public async Task<Adresler> GetAdreslerWithMusteriAsync()
        {
            return await _eTicaretDB.Adresler.Include(k => k.Musteriler).FirstOrDefaultAsync();
        }

        public async Task<Adresler> AdresSilAsync(int id)
        {
            var adresSil = await GetByIdAsync(id);
            if (adresSil != null)
            {
                adresSil.AktifMi = false;
                await _eTicaretDB.SaveChangesAsync();
            }

            return adresSil;
        }
    }
}
