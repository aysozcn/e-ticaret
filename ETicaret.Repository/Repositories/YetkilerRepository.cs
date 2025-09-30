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
    public class YetkilerRepository : GenericRepository<Yetkiler>, IYetkilerRepository
    {
        public YetkilerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public async Task<string> YetkiEkle(string yetkiAdi )
        {
            try
            {
                Yetkiler yetkiEkle = new Yetkiler();
                yetkiEkle.YetkiAdi = yetkiAdi;
               
                yetkiEkle.AktifMi = true;
                yetkiEkle.EklenmeTarih = DateTime.Now;
                await AddAsync(yetkiEkle);
                return "başarılı";

            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> YetkiGuncelle(int yetkiId, string yetkiAdi, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            var yetkiGuncelle = await GetByIdAsync(yetkiId);
            try
            {
                yetkiGuncelle.YetkiAdi = yetkiAdi;
                yetkiGuncelle.AktifMi = aktifMi;
                yetkiGuncelle.EklenmeTarih = eklemeTarihi;
                yetkiGuncelle.GuncellenmeTarih = DateTime.Now;
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<List<Yetkiler>> YetkiListesi()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Yetkiler>> YetkiListesi(bool aktifMi)
        {
            return await GetAllQuery(y => y.AktifMi == aktifMi).ToListAsync();
        }

        public async Task<int> YetkiSayisi(int yetkiId)
        {
            return await GetAllQuery(y => y.Id == yetkiId).CountAsync();
        }

        public async Task<string> YetkiSil(int yetkiId)
        {
            var yetkiSil = await GetByIdAsync(yetkiId);
            try
            {
                if (yetkiSil != null)
                {
                    Remove(yetkiSil);
                    await _eTicaretDB.SaveChangesAsync();
                    return "başarılı";
                }
                else
                {
                    return "yetki bulunamadı";
                }

            }
            catch (Exception)
            {
                return "hata";
            }
        }
    }
}
