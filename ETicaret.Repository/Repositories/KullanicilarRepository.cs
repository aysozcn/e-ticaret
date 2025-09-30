using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Repository.Repositories
{
	public class KullanicilarRepository : GenericRepository<Kullanicilar>, IKullanicilarRepository
	{
		AppDbContext _db;
		public KullanicilarRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
		{
			_db = eTicaretDB;
		}

		public async Task<Kullanicilar> Giris(string kullaniciAdi, string sifre)
		{
			var kullaniciList = Find(k => k.Adi == kullaniciAdi && k.KullaniciSifre == sifre);
			var kullanici = kullaniciList.FirstOrDefault(); // İlk eşleşen kullanıcıyı al

			return kullanici;
		}

		public async Task<List<Kullanicilar>> GetKullanicilarWithYetkilerAsync()
        {
			return await _eTicaretDB.Kullanicilar.Include(k => k.Yetkiler).ToListAsync();
        }

        public async Task<Kullanicilar> GetKullanicilarWithYetkilerAsync(int kullanicilarId)
        {
            return await _eTicaretDB.Kullanicilar.Where(k=>k.Id== kullanicilarId).FirstOrDefaultAsync();	
        }

        public async Task<string> KullaniciEkle(string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, int YetkiId)
		{
			try
			{
				Kullanicilar kullaniciEkle = new Kullanicilar();
				kullaniciEkle.Adi = Adi;
				kullaniciEkle.Soyadi = Soyadi;
				kullaniciEkle.KullaniciResim = Resim;
				kullaniciEkle.KullaniciEmail = KullaniciEmail;
				kullaniciEkle.KullaniciSifre = KullaniciSifre;
				kullaniciEkle.PersonelMi = PersonelMi;
				kullaniciEkle.YetkiId = YetkiId;
				await AddAsync(kullaniciEkle);

				return "Ekleme Başarılı";
			}
			catch (Exception)
			{

				return "Ekleme işlemi esnasında hata oluştu";
			}
			
		}

		public async Task<string> KullaniciGuncelle(int KullanicilarId, string Adi, string Soyadi, string Resim, string KullaniciEmail, string KullaniciSifre, bool PersonelMi, bool aktifMi, DateTime EklenmeTarihi, int YetkiId)
		{
			var kullaniciGuncelle = await GetByIdAsync(KullanicilarId);
			try
			{
				kullaniciGuncelle.Adi = Adi;
				kullaniciGuncelle.Soyadi = Soyadi;
				kullaniciGuncelle.KullaniciResim = Resim;
				kullaniciGuncelle.KullaniciEmail = KullaniciEmail;
				kullaniciGuncelle.KullaniciSifre = KullaniciSifre;
				kullaniciGuncelle.PersonelMi = PersonelMi;
				kullaniciGuncelle.AktifMi = aktifMi;
				kullaniciGuncelle.EklenmeTarih = EklenmeTarihi;
				kullaniciGuncelle.GuncellenmeTarih = DateTime.Now;
				kullaniciGuncelle.YetkiId = YetkiId;
				return "Güncelleme işlemi başarılı";

			}
			catch (Exception)
			{

				return "Güncelleme işlemi esnasında hata oluştu";
			}
		}

		public async Task<List<Kullanicilar>> KullaniciListesi()
		{
				return await GetAll().ToListAsync();
		}

		public async Task<List<Kullanicilar>> KullaniciListesi(bool aktifMi)
		{
			return await GetAllQuery(k=>k.AktifMi==aktifMi).ToListAsync();
		}

		public async Task<string> KullaniciSil(int KullanicilarId)
		{
			var kullaniciSil =await GetByIdAsync(KullanicilarId);

			try
			{
				if (kullaniciSil!=null)
				{
					Remove(kullaniciSil);
				    await _eTicaretDB.SaveChangesAsync();
					return "Silme işlemi başarılı";

				}
				else
				{
					return "Kullanıcı bulunamadı";
				}
			}
			catch (Exception)
			{

				return "Silme işlemi esnasında hata oluştu";
			}
			
		}

		public async Task<string> TopluKullaniciEkle(IEnumerable<Kullanicilar> kullanicilar)
		{
			try
			{
				await AddRangeAsync(kullanicilar);
				return "Toplu ekleme başarılı";
			}
			catch (Exception)
			{

				return "Toplu ekleme işlemi esnasında hata oluştu";
			}
		}

		public  async Task<string> TopluKullaniciSil(IEnumerable<Kullanicilar> kullanicilar)
		{
			try
			{
				 RemoveRange(kullanicilar);
				 return  "Toplu silme işlemi başarılı";
			}
			catch (Exception)
			{

				return "Toplu silme işlemi esnasında hata oluştu";
			}
		}

		public async Task<Kullanicilar> KullaniciGetir(int kullaniciId)
		{
			var getir = Find(k => k.Id==kullaniciId);
			var sonuc = getir.FirstOrDefault(); // İlk eşleşen kullanıcıyı al
			return sonuc;
		}
	}
}
