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
    public class PersonellerRepository : GenericRepository<Personeller>, IPersonellerRepository
    {
        public PersonellerRepository(AppDbContext eTicaretDB) : base(eTicaretDB)
        {
        }

		public async Task<List<Personeller>> GetPersonellerWithKullanicilarAsync()
		{
			return await _eTicaretDB.Personeller.Include(k => k.Kullanicilar).ToListAsync();
		}

		public async Task<Personeller> GetPersonellerWithKullanicilarAsync(int personellerId)
		{
			return await _eTicaretDB.Personeller.Where(k => k.Id == personellerId).Include(k => k.Kullanicilar).FirstOrDefaultAsync();
		}

		public async Task<string> PersonelEkle(string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, int personelBilgiId, int kullaniciId)
		{
			try
			{
				Personeller personelEkle = new Personeller();
				personelEkle.PersonelAdi = PersonelAdi;
				personelEkle.PersonelSoyadi = PersonelSoyadi;
				personelEkle.Cinsiyet = Cinsiyet;
				personelEkle.PersonelMaasi = Maas;
				personelEkle.MaasOdemeTarihi = MaasOdemeTarih;
				personelEkle.MedeniHali = MedeniHali;
				personelEkle.CalistigiFirma = CalistigiFirma;
				personelEkle.PersonelHakkinda = Hakkinda;
				personelEkle.YasadigiSehir = yasadigiSehir;
				personelEkle.PersonelKullaniciBilgileriId = personelBilgiId;
				personelEkle.KullaniciId = kullaniciId;
				await AddAsync(personelEkle);

				return  "Personel ekleme işlemi başarılı";
			}
			catch (Exception)
			{

				return "Personel ekleme işlemi esnasında hata oluştu";
			}
		}

		public async Task<string> PersonelGuncelle(int PersonellerId, string PersonelAdi, string PersonelSoyadi, string Cinsiyet, decimal Maas, DateTime MaasOdemeTarih, bool MedeniHali, string CalistigiFirma, string Hakkinda, string yasadigiSehir, bool aktifMi, DateTime EklenmeTarihi, int personelBilgiId, int kullaniciId)
		{
			var personelGuncelle =await GetByIdAsync(PersonellerId);
			try
			{

				personelGuncelle.PersonelAdi = PersonelAdi;
				personelGuncelle.PersonelSoyadi = PersonelSoyadi;
				personelGuncelle.Cinsiyet = Cinsiyet;
				personelGuncelle.PersonelMaasi = Maas;
				personelGuncelle.MaasOdemeTarihi = MaasOdemeTarih;
				personelGuncelle.GuncellenmeTarih = DateTime.Now;
				personelGuncelle.MedeniHali = MedeniHali;
				personelGuncelle.CalistigiFirma = CalistigiFirma;
				personelGuncelle.PersonelHakkinda = Hakkinda;
				personelGuncelle.YasadigiSehir = yasadigiSehir;
				personelGuncelle.AktifMi = aktifMi;
				personelGuncelle.EklenmeTarih = EklenmeTarihi;
				personelGuncelle.PersonelKullaniciBilgileriId = personelBilgiId;
				personelGuncelle.KullaniciId = kullaniciId;

				return  "Personel güncelleme işlemi başarılı"; 
			}
			catch (Exception)
			{

				return "Personel güncelleme işlemi esnasında hata oluştu";
			}
		}

		public async Task<List<Personeller>> Personelistesi()
		{
			return await GetAll().ToListAsync();
		}

		public async Task<List<Personeller>> PersonelListesi(bool aktifMi)
		{
			return await GetAllQuery(p => p.AktifMi == aktifMi).ToListAsync();
		}

		public async Task<string> PersonelSil(int PersonellerId)
		{
			var personelSil=await GetByIdAsync(PersonellerId);
			try
			{
				if (personelSil!=null)
				{
					Remove(personelSil);
					await _eTicaretDB.SaveChangesAsync();
					return "Silme işlemi başarılı";
				}
				else
				{
					return "Böyle bir personel bulunamadı";
				}

			}
			catch (Exception)
			{

				return "Silme işlemi esnasında hata oluştu";
			}
		}

		public async Task<string> TopluPersonelEkle(IEnumerable<Personeller> personeller)
		{
			try
			{
				await AddRangeAsync(personeller);
				return "Toplu ekleme işlmei başarılı";
			}
			catch (Exception)
			{

				return "Toplu ekleme esnasında hata oluştu";
			}
		}

		public async Task<string> TopluPersonelSil(IEnumerable<Personeller> personeller)
		{
			try
			{
				 RemoveRange(personeller);
				return "Toplu silme işlemi başarılı";
			}
			catch (Exception)
			{

				return "Toplu silme işlemi esnasında hata oluştu";
			}
		}
	}
}
