using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Core.IService
{
    public interface IMusterilerService : IService<Musteriler>
    {
        Task<IEnumerable<GetMusteriWithSiparisDTO>> GetMusteriWithSiparisAsync();
        Task<GetMusteriWithSiparisDTO> GetMusteriWithSiparisAsync(int musteriID);
        Task<IEnumerable<GetMusterilerWithAdresDTO>> GetMusteriWithAdresAsync();
        Task<GetMusterilerWithAdresDTO> GetMusteriWithAdresAsync(int musteriID);
        Task<IEnumerable<GetMusteriWithKullaniciDTO>> GetMusteriWithKullaniciAsync();
        Task<GetMusteriWithKullaniciDTO> GetMusteriWithKullaniciAsync(int musteriID);
        Task<string> MusteriEkleAsync(string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> MusteriGuncelleAsync(int musteriId,string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId);
        Task<string> MusteriSilAsync(int musteriId);
        Task<IEnumerable<Musteriler>> MusteriListesiAsync();
        Task<IEnumerable<Musteriler>> MusteriListesiAsync(bool aktifMi);

    }
}
