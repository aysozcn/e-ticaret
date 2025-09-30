using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
    public class YorumlarService : Service<Yorumlar>, IYorumlarService
    {
        readonly IYorumlarRepository _yorumlarRepository;
        readonly IMapper _mapper;

        public YorumlarService(IGenericRepository<Yorumlar> repository, IUnitOfWork unitOfWork, IYorumlarRepository yorumlarRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _yorumlarRepository = yorumlarRepository;
            _mapper = mapper;
        }

        public async Task<List<GetYorumlarWithKullanicilarDTO>> GetYorumlarWithKullanicilarAsync()
        {
            var yorumVeKullaniciList = await _yorumlarRepository.GetYorumlarWithKullanicilarAsync();
            var yorumVeKullaniciDTO = _mapper.Map<List<GetYorumlarWithKullanicilarDTO>>(yorumVeKullaniciList);
            return yorumVeKullaniciDTO;
        }

        public async Task<GetYorumlarWithKullanicilarDTO> GetYorumlarWithKullanicilarAsync(int yorumId)
        {
            var yorumVeKullanici = await _yorumlarRepository.GetYorumlarWithKullanicilarAsync(yorumId);
            var urunVeKullaniciDTO = _mapper.Map<GetYorumlarWithKullanicilarDTO>(yorumVeKullanici);
            return urunVeKullaniciDTO;
        }

        public async Task<List<GetYorumlarWithUrunlerDTO>> GetYorumlarWithUrunlerAsync()
        {
            var yorumUrunList = await _yorumlarRepository.GetYorumlarWithUrunlerAsync();
            var yorumUrunDTO = _mapper.Map<List<GetYorumlarWithUrunlerDTO>>(yorumUrunList);
            return yorumUrunDTO;
        }

        public async Task<GetYorumlarWithUrunlerDTO> GetYorumlarWithUrunlerAsync(int urunId)
        {
            var yorumUrun = await _yorumlarRepository.GetYorumlarWithUrunlerAsync(urunId);
            var yorumUrunDTO = _mapper.Map<GetYorumlarWithUrunlerDTO>(yorumUrun);
            return yorumUrunDTO;
        }
    }
}
