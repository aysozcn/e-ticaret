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
    public class FotograflarRepository : GenericRepository<Fotograflar>, IFotograflarRepository
    {
        public FotograflarRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {

        }

        public async Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            try
            {
                Fotograflar fotograf = new();
                fotograf.FotografYolu = fotografYolu;
                fotograf.FotografAciklamasi = fotografAciklamasi;
                fotograf.FotografSirasi = fotografSirasi;
                fotograf.UrunId = urunId;
                fotograf.AktifMi = aktifMi;
                fotograf.EklenmeTarih = eklemeTarihi;
                fotograf.GuncellenmeTarih = guncellemeTarihi;

                await AddAsync(fotograf);

                return "Ekleme başarılı.";
            }
            catch (Exception)
            {
                return "Ekleme esnasında hata oluştu.";
            }
        }

        public async Task<string> FotografGuncelleAsync(int fotografId, string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            var fotografBul = await GetByIdAsync(fotografId);

            try
            {
                fotografBul.FotografYolu = fotografYolu;
                fotografBul.FotografAciklamasi = fotografAciklamasi;
                fotografBul.FotografSirasi = fotografSirasi;
                fotografBul.UrunId = urunId;
                fotografBul.AktifMi = aktifMi;
                fotografBul.EklenmeTarih = eklemeTarihi;
                fotografBul.GuncellenmeTarih = guncellemeTarihi;

                return "Güncelleme başarılı.";
            }
            catch (Exception)
            {
                return "Güncelleme esnasında hata oluştu.";
            }
        }

        public async Task<List<Fotograflar>> FotografListesiAsync()
        {
            return await GetAll().ToListAsync();
        }

        public async Task<List<Fotograflar>> FotografListesiAsync(bool aktifMi)
        {
            return await GetAllQuery(f => f.AktifMi == aktifMi).ToListAsync();
        }

        public async Task<string> FotografSilAsync(int fotografId)
        {
            var fotografSil = await GetByIdAsync(fotografId);

            try
            {
                fotografSil.AktifMi = false;

                return "Silme başarılı.";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu.";
            }
        }

        public async Task<List<Fotograflar>> GetFotografWithUrunAsync()
        {
            return await _eTicaretDB.Fotograflar.Include(f => f.Urunler).ToListAsync();
        }

        public async Task<Fotograflar> GetFotografWithUrunAsync(int fotografId)
        {
            return await GetAllQuery(f => f.Id == fotografId).Include(f => f.Urunler).FirstOrDefaultAsync();
        }

        //public async Task<string> FotografEkle(string fotografYolu, string fotografAciklamasi, byte? fotografSirasi, int urunId, bool aktifMi, DateTime eklenmeTarihi)
        //{
        //    try
        //    {
        //        Fotograflar fotografEkle = new();
        //        fotografEkle.FotografYolu = fotografYolu;
        //        fotografEkle.FotografAciklamasi = fotografAciklamasi;
        //        fotografEkle.FotografSirasi = fotografSirasi;
        //        fotografEkle.UrunId = urunId;
        //        fotografEkle.AktifMi = aktifMi;
        //        fotografEkle.EklenmeTarih = eklenmeTarihi;
        //        await AddAsync(fotografEkle);

        //        return "İşlem başarıyla gerçekleştirildi.";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Hata oluştu:\n{ex}";
        //    }
        //}

        //public async Task<string> FotografGuncelle(int fotografId, string fotografYolu, string fotografAciklamasi, byte? fotografSirasi, int urunId, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellemeTarihi)
        //{
        //    var fotografGuncelle = await GetByIdAsync(fotografId);

        //    try
        //    {
        //        fotografGuncelle.FotografYolu = fotografYolu;
        //        fotografGuncelle.FotografAciklamasi = fotografAciklamasi;
        //        fotografGuncelle.FotografSirasi = fotografSirasi;
        //        fotografGuncelle.UrunId = urunId;
        //        fotografGuncelle.AktifMi = aktifMi;
        //        fotografGuncelle.EklenmeTarih = eklenmeTarihi;
        //        fotografGuncelle.GuncellenmeTarih = guncellemeTarihi;

        //        return "İşlem başarıyla gerçekleştirildi.";
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Hata oluştu:\n{ex}";
        //    }
        //}

        //public async Task<List<Fotograflar>> FotografListesi()
        //{
        //    return await GetAll().ToListAsync();
        //}

        //public async Task<List<Fotograflar>> FotografListesi(bool aktifMi)
        //{
        //    return await GetAllQuery(f => f.AktifMi == aktifMi).ToListAsync();
        //}

        //public async Task<int> FotografSayisi(int fotografId)
        //{
        //    return await GetAllQuery(f => f.Id == fotografId).CountAsync();
        //}

        //public async Task<string> FotografSil(int fotografId)
        //{
        //    var fotografSil = await GetByIdAsync(fotografId);

        //    try
        //    {
        //        if (fotografSil != null)
        //        {
        //            Remove(fotografSil);
        //            await _eTicaretDB.SaveChangesAsync();

        //            return "İşlem başarıyla gerçekleştirildi.";
        //        }
        //        else
        //        {
        //            return "Fotoğraf bulunamadı.";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return $"Hata oluştu:\n{ex}";
        //    }
        //}


    }
}
