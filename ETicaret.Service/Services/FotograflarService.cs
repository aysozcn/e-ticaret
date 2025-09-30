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
    public class FotograflarService : Service<Fotograflar>, IFotograflarService
    {
        private readonly IFotograflarRepository _fotograflarRepository;
        private readonly IMapper _mapper;

        public FotograflarService(IGenericRepository<Fotograflar> repository, IUnitOfWork unitOfWork, IFotograflarRepository fotograflarRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _fotograflarRepository = fotograflarRepository;
            _mapper = mapper;
        }

        public async Task<string> FotografEkleAsync(string fotografYolu, string fotografAciklamasi, byte fotografSirasi, int urunId, bool aktifMi, DateTime eklemeTarihi, DateTime guncellemeTarihi)
        {
            try
            {
                Fotograflar fotograf = new Fotograflar();
                fotograf.FotografYolu = fotografYolu;
                fotograf.FotografAciklamasi = fotografAciklamasi;
                fotograf.FotografSirasi = fotografSirasi;
                fotograf.UrunId = urunId;
                fotograf.AktifMi = aktifMi;
                fotograf.EklenmeTarih = eklemeTarihi;
                fotograf.GuncellenmeTarih = guncellemeTarihi;

                await AddAsync(fotograf);

                return "RESİM EKLEME BAŞARILI";
            }
            catch (Exception ex)
            {
                return "Ekleme esnasında hata oluştu."+ex;
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

        public async Task<IEnumerable<Fotograflar>> FotografListesiAsync()
        {
            return await GetAllAsyncs();
        }

        public async Task<IEnumerable<Fotograflar>> FotografListesiAsync(bool aktifMi)
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

        public async Task<IEnumerable<GetFotograflarWithUrunlerDTO>> GetFotografWithUrunAsync()
        {
            var fotografWithUrun = await _fotograflarRepository.GetFotografWithUrunAsync();
            var fotografUrunDTO = _mapper.Map<List<GetFotograflarWithUrunlerDTO>>(fotografWithUrun);

            return fotografUrunDTO;
        }

        public async Task<GetFotograflarWithUrunlerDTO> GetFotografWithUrunAsync(int fotografId)
        {
            var fotografWithUrun = await _fotograflarRepository.GetFotografWithUrunAsync(fotografId);
            var fotografUrunDTO = _mapper.Map<GetFotograflarWithUrunlerDTO>(fotografWithUrun);

            return fotografUrunDTO;
        }
    }
}

//public FotograflarService(IGenericRepository<Fotograflar> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
//{
//}

//public Task<List<Urunler>> GetFotograflarWithUrunlerAsync()
//{
//    throw new NotImplementedException();
//}

//public Task<Urunler> GetFotograflarWithUrunlerAsync(int fotograflarId)
//{
//    throw new NotImplementedException();
//}