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
    public class ErisimAlanlariRepository : GenericRepository<ErisimAlanlari>, IErisimAlanlariRepository
    {
        public ErisimAlanlariRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

        public async Task<string> ErisimAlaniEkle(string controllerAdi, string viewAdi, string aciklama)
        {
            try
            {
                ErisimAlanlari alanEkle = new ErisimAlanlari();
                alanEkle.ControllerAdi = controllerAdi;
                alanEkle.ViewAdi = viewAdi;
                alanEkle.Aciklama = aciklama;
                alanEkle.AktifMi = true;
                alanEkle.EklenmeTarih = DateTime.Now;
                await AddAsync(alanEkle);
                return "başarılı";

            }
            catch (Exception)
            {
                return "hata";

            }
        }

        public async Task<string> ErisimAlaniGuncelle(int erisimAlaniId, string controllerAdi, string viewAdi, string aciklama, bool aktifMi, DateTime eklemeTarihi)
        {
            var alanGuncelle = await GetByIdAsync(erisimAlaniId);
            try
            {
                alanGuncelle.ControllerAdi = controllerAdi;
                alanGuncelle.ViewAdi = viewAdi;
                alanGuncelle.Aciklama = aciklama;
                alanGuncelle.EklenmeTarih = eklemeTarihi;
                alanGuncelle.AktifMi = aktifMi;
                alanGuncelle.GuncellenmeTarih = DateTime.Now;
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";

            }
        }

        public async Task<List<ErisimAlanlari>> ErisimAlaniListesi()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<ErisimAlanlari>> ErisimAlaniListesi(bool aktifMi)
        {
            return await GetAllQuery(y => y.AktifMi == aktifMi).ToListAsync();
        }

        public async Task<string> ErisimAlaniSil(int erisimAlaniId)
        {
            var alanSil = await GetByIdAsync(erisimAlaniId);
            try
            {
                if (alanSil != null)
                {
                    Remove(alanSil);
                    await _eTicaretDB.SaveChangesAsync();
                    return "başarılı";
                }
                else
                {
                    return "alan bulunamadı";
                }

            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> TopluErisimAlaniEkle(IEnumerable<ErisimAlanlari> erisimAlanlari)
        {
            try
            {
                await AddRangeAsync(erisimAlanlari);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }

        public async Task<string> TopluErisimAlaniSil(IEnumerable<ErisimAlanlari> erisimAlanlari)
        {
            try
            {
                RemoveRange(erisimAlanlari);
                return "başarılı";
            }
            catch (Exception)
            {
                return "hata";
            }
        }
    }
}
