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
    public class MusterilerRepository : GenericRepository<Musteriler>, IMusterilerRepository
    {
        public MusterilerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {

        }

        public async Task<List<Musteriler>> GetMusteriWithAdresAsync()
        {
            return await _eTicaretDB.Musteriler.Include(m => m.Adresler).ToListAsync();
        }

        public async Task<Musteriler> GetMusteriWithAdresAsync(int musteriID)
        {
            return await GetAllQuery(m => m.Id == musteriID).Include(m => m.Adresler).FirstOrDefaultAsync();
        }

        public async Task<List<Musteriler>> GetMusteriWithKullaniciAsync()
        {
            return await _eTicaretDB.Musteriler.Include(m => m.Kullanicilar).ToListAsync();
        }

        public async Task<Musteriler> GetMusteriWithKullaniciAsync(int musteriID)
        {
            return await GetAllQuery(m => m.Id == musteriID).Include(m => m.Kullanicilar).FirstOrDefaultAsync();
        }

        public async Task<List<Musteriler>> GetMusteriWithSiparisAsync()
        {
            return await _eTicaretDB.Musteriler.Include(m => m.Siparisler).ToListAsync();
        }

        public async Task<Musteriler> GetMusteriWithSiparisAsync(int musteriID)
        {
            return await GetAllQuery(m => m.Id == musteriID).Include(m => m.Siparisler).FirstOrDefaultAsync();
        }

        public async Task<List<Musteriler>> MusteriListesiAsync()
        {
            return await _eTicaretDB.Musteriler.ToListAsync();
        }

        public async Task<List<Musteriler>> MusteriListesiAsync(bool aktifMi)
        {
            return await GetAllQuery(m => m.AktifMi == aktifMi).ToListAsync();
        }

        public async Task<string> MusteriEkleAsync(string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId)
        {
            try
            {
                Musteriler musteri = new Musteriler();
                musteri.Adi = adi;
                musteri.Soyadi = soyadi;
                musteri.Cinsiyet = cinsiyet;
                musteri.Telefonu = telefon;
                musteri.Meslek = meslek;
                musteri.DogumTarihi = dogumTarihi;
                musteri.AktifMi = aktifMi;
                musteri.EklenmeTarih = eklenmeTarihi;
                musteri.GuncellenmeTarih = guncellenmeTarihi;
                musteri.KullaniciId = kullaniciId;

                await AddAsync(musteri);

                return "Ekleme başarılı";
            }
            catch (Exception)
            {
                return "Ekleme esnasında hata oluştu";
            };
        }

        public async Task<string> MusteriGuncelleAsync(int musteriId, string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId)
        {
            var musteriBul = await GetByIdAsync(musteriId);

            try
            {
                musteriBul.Adi = adi;
                musteriBul.Soyadi = soyadi;
                musteriBul.Cinsiyet = cinsiyet;
                musteriBul.Telefonu = telefon;
                musteriBul.Meslek = meslek;
                musteriBul.DogumTarihi = dogumTarihi;
                musteriBul.AktifMi = aktifMi;
                musteriBul.EklenmeTarih = eklenmeTarihi;
                musteriBul.GuncellenmeTarih = guncellenmeTarihi;
                musteriBul.KullaniciId = kullaniciId;

                return "Güncelleme başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme esnasında hata oluştu";
            }
        }

        public async Task<string> MusteriSilAsync(int musteriId)
        {
            var musteriSil = await GetByIdAsync(musteriId);

            try
            {
                musteriSil.AktifMi = false;

                return "Silme başarılı";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }
    }
}
