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
    public class YetkiErisimlerRepository : GenericRepository<YetkiErisim>, IYetkiErisimlerRepository
    {
        public YetkiErisimlerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public async Task<string> YetkiErisimEkle(int erisimAlaniId, int yetkiId, string aciklama)
        {
            try
            {
                YetkiErisim erisimEkle = new YetkiErisim();
                erisimEkle.YetkiId = yetkiId;
                erisimEkle.ErisimAlaniId = erisimAlaniId;
                erisimEkle.Aciklama = aciklama;
                erisimEkle.EklenmeTarihi = DateTime.Now;
                await AddAsync(erisimEkle);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }


        public async Task<List<YetkiErisim>> YetkiErisimListesi()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<string> YetkiErisimSil(int erisimAlaniId, int yetkiId)
        {
            var yetkiSil = await GetFirst(y =>
            y.ErisimAlaniId == erisimAlaniId &&
            y.YetkiId == yetkiId);

            //var a = await GetAllQuery(y =>
            //y.ErisimAlaniId == erisimAlaniId &&
            //y.YetkiId == yetkiId).FirstOrDefaultAsync();
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
