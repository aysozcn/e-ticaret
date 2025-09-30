using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IRepositories
{
    public interface IMusterilerRepository : IGenericRepository<Musteriler>
    {
        Task<List<Musteriler>> GetMusteriWithSiparisAsync();
        Task<Musteriler> GetMusteriWithSiparisAsync(int musteriID);
        Task<List<Musteriler>> GetMusteriWithAdresAsync();
        Task<Musteriler> GetMusteriWithAdresAsync(int musteriID);
        Task<List<Musteriler>> GetMusteriWithKullaniciAsync();
        Task<Musteriler> GetMusteriWithKullaniciAsync(int musteriID);
        Task<string> MusteriEkleAsync(string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> MusteriGuncelleAsync(int musteriId ,string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> MusteriSilAsync(int musteriId);
        Task<List<Musteriler>> MusteriListesiAsync();
        Task<List<Musteriler>> MusteriListesiAsync(bool aktifMi);
    }
}
