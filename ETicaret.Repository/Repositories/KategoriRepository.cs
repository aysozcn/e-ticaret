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
    public class KategoriRepository : GenericRepository<Kategoriler>, IKategoriRepository
    {
        public KategoriRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public async Task<string> KategoriEkleAsync(string kategoriAdi, string aciklama)
        {
            try
            {
                Kategoriler kategoriler = new Kategoriler();
                kategoriler.KategoriAdi = kategoriAdi;
                kategoriler.Aciklama = aciklama;
                await AddAsync(kategoriler);
                return "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                return "İşlem sırasında hata " + ex + "oluştu";
            }
        }

        public async Task<string> KategoriGuncelleAsync(int id, string kategoriAdi, string aciklama)
        {
            var kategoriGuncelle = await GetByIdAsync(id);
            try
            {
                kategoriGuncelle.KategoriAdi = kategoriAdi;
                kategoriGuncelle.Aciklama = aciklama;
                return "İşlem Başarılı";
            }
            catch (Exception ex)
            {
                return "İşlem sırasında hata " + ex + "oluştu";
            }
        }

        public async Task<List<Kategoriler>> KategoriListeleAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<Kategoriler> KategoriSilAsync(int id)
        {
            var kategoriSil = await GetByIdAsync(id);
            if (kategoriSil != null)
            {
                kategoriSil.AktifMi = false;
                await _eTicaretDB.SaveChangesAsync(); 
            }

            return kategoriSil;
        }
    }
}
