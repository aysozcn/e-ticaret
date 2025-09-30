using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using ETicaret.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
    public class AdreslerService : Service<Adresler>, IAdreslerService
    {
        private readonly IAdreslerRepository _adreslerRepository;
        private readonly IMapper _mapper;
        public AdreslerService(IGenericRepository<Adresler> repository, IUnitOfWork unitOfWork, IAdreslerRepository adreslerRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _adreslerRepository = adreslerRepository;
            _mapper = mapper;
        }

        public async Task<List<Sp_AdreslerWithMusteriDto>> AdresVeMusteri()
        {
            var adresVeMusteri = await _adreslerRepository.AdresVeMusteri();
            return adresVeMusteri;
        }

        public async Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithIlceAsync(int ilceId)
        {
            var adresIlVeIlce = await _adreslerRepository.GetAdreslerWithIlcelerAsync(ilceId);
            var adresIlVeIlceDTO = _mapper.Map<List<GetAdreslerWithMusteriDTO>>(adresIlVeIlce);
            return adresIlVeIlceDTO;

        }

        public async Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithIlceAsync()
        {
            var adresIlVeIlce = await _adreslerRepository.GetAdreslerWithIlcelerAsync();
            var adresIlVeIlceDTO = _mapper.Map<List<GetAdreslerWithMusteriDTO>>(adresIlVeIlce);
            return adresIlVeIlceDTO;
        }

        public async Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithMusteriAsync(int musteriId)
        {
            var adresVeMusteri = await _adreslerRepository.GetAdreslerWithMusteriAsync(musteriId);
            var adresVeMusteriDTO = _mapper.Map<List<GetAdreslerWithMusteriDTO>>(adresVeMusteri);
            return adresVeMusteriDTO;
        }

        public async Task<List<GetAdreslerWithMusteriDTO>> GetAdreslerWithMusteriAsync()
        {
            var adresVeMusteri = await _adreslerRepository.GetAdreslerWithMusteriAsync();
            var adresVeMusteriDTO = _mapper.Map<List<GetAdreslerWithMusteriDTO>>(adresVeMusteri);
            return adresVeMusteriDTO;
        }

        public async Task<object> AdresSilAsync(int id)
        {
            var adresGetir = await _adreslerRepository.GetByIdAsync(id);
            if (adresGetir != null)
            {
                return await _adreslerRepository.AdresSilAsync(adresGetir.Id);
            }
            return null;
        }
    }
}
