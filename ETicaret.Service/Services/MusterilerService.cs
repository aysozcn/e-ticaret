using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
    public class MusterilerService : Service<Musteriler>, IMusterilerService
    {
        private readonly IMusterilerRepository _musterilerRepository;
        private readonly IMapper _mapper;

        public MusterilerService(IGenericRepository<Musteriler> repository, IUnitOfWork unitOfWork, IMusterilerRepository musterilerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _musterilerRepository = musterilerRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetMusterilerWithAdresDTO>> GetMusteriWithAdresAsync()
        {
            var musteriWithAdres = await _musterilerRepository.GetMusteriWithAdresAsync();
            var musteriAdresDTO = _mapper.Map<List<GetMusterilerWithAdresDTO>>(musteriWithAdres);
            return musteriAdresDTO;
        }

        public async Task<GetMusterilerWithAdresDTO> GetMusteriWithAdresAsync(int musteriID)
        {
            var musteriWithAdres = await _musterilerRepository.GetMusteriWithAdresAsync(musteriID);
            var musteriAdresDTO = _mapper.Map<GetMusterilerWithAdresDTO>(musteriWithAdres);
            return musteriAdresDTO;
        }

        public async Task<IEnumerable<GetMusteriWithKullaniciDTO>> GetMusteriWithKullaniciAsync()
        {
            var musteriWithKullanici = await _musterilerRepository.GetMusteriWithKullaniciAsync();
            var musteriKullaniciDTO = _mapper.Map<List<GetMusteriWithKullaniciDTO>>(musteriWithKullanici);
            return musteriKullaniciDTO;
        }

        public async Task<GetMusteriWithKullaniciDTO> GetMusteriWithKullaniciAsync(int musteriID)
        {
            var musteriWithKullanici = await _musterilerRepository.GetMusteriWithKullaniciAsync(musteriID);
            var musteriKullaniciDTO = _mapper.Map<GetMusteriWithKullaniciDTO>(musteriWithKullanici);
            return musteriKullaniciDTO;
        }

        public async Task<IEnumerable<GetMusteriWithSiparisDTO>> GetMusteriWithSiparisAsync()
        {
            var musteriWithSiparis = await _musterilerRepository.GetMusteriWithSiparisAsync();
            var musteriSiparisDTO = _mapper.Map<List<GetMusteriWithSiparisDTO>>(musteriWithSiparis);
            return musteriSiparisDTO;
        }

        public async Task<GetMusteriWithSiparisDTO> GetMusteriWithSiparisAsync(int musteriID)
        {
            var musteriWithSiparis = await _musterilerRepository.GetMusteriWithSiparisAsync(musteriID);
            var musteriSiparisDTO = _mapper.Map<GetMusteriWithSiparisDTO>(musteriWithSiparis);
            return musteriSiparisDTO;
        }

        public async Task<IEnumerable<Musteriler>> MusteriListesiAsync()
        {
            return await GetAllAsyncs();
        }

        public async Task<IEnumerable<Musteriler>> MusteriListesiAsync(bool aktifMi)
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

        public async Task<string> MusteriGuncelleAsync(int musteriId ,string adi, string soyadi, string cinsiyet, string telefon, string meslek, DateTime dogumTarihi, bool aktifMi, DateTime eklenmeTarihi, DateTime guncellenmeTarihi, int kullaniciId)
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

                return "Silme esnasında hata oluştu";
            }
            catch (Exception)
            {
                return "Silme esnasında hata oluştu";
            }
        }
    }
}
