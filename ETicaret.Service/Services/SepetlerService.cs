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
    public class SepetlerService : Service<Sepetler>, ISepetlerService
    {
        readonly ISepetlerRepository _sepetRepo;
        readonly IMapper _mapper;
        public SepetlerService(IGenericRepository<Sepetler> repository, IUnitOfWork unitOfWork,ISepetlerRepository sepetRepo,IMapper mapper) : base(repository, unitOfWork)
        {
            _sepetRepo = sepetRepo;
            _mapper=mapper;
        }

        public async Task<List<GetSepetlerWithKullanicilarDTO>> GetSepetlerWithKullanicilarAsync()
        {
            var sepetVeKullaniciList = await _sepetRepo.GetSepetlerWithKullanicilarAsync();
            var sepetVeKullaniciDTO = _mapper.Map<List<GetSepetlerWithKullanicilarDTO>>(sepetVeKullaniciList);
            return sepetVeKullaniciDTO;
        }

        public async Task<GetSepetlerWithKullanicilarDTO> GetSepetlerWithKullanicilarAsync(int sepetlerId)
        {
            var sepetVeKullanici = await _sepetRepo.GetSepetlerWithKullanicilarAsync(sepetlerId);
            var sepetVeKullaniciDTO = _mapper.Map<GetSepetlerWithKullanicilarDTO>(sepetVeKullanici);
            return sepetVeKullaniciDTO;
        }

        public Task<Sepetler> GetSepetlerWithKullanicilarAsync(Sepetler sepet)
        {
            throw new NotImplementedException();
        }

        public Task<GetSepetlerWithKullanicilarDTO> GetSepetlerKullanicilar()
        {
            throw new NotImplementedException();
        }
    }

}
