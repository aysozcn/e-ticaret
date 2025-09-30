using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using ETicaret.Repository.UntiOfWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
	public class KullanicilarService : Service<Kullanicilar>, IKullanicilarService
	{
        readonly IKullanicilarRepository _kullaniciRepo;
        readonly IMapper _mapper;

        public KullanicilarService(IGenericRepository<Kullanicilar> repository, IUnitOfWork unitOfWork,IKullanicilarRepository kullaniciRepo,IMapper mapper) : base(repository, unitOfWork)
        {
            _kullaniciRepo = kullaniciRepo;
            _mapper = mapper;
        }
        public async Task<List<GetKullanicilarWithYetkilerDTO>> GetKullanicilarWithYetkilerAsync()
        {
            var kullaniciYetkiList = await _kullaniciRepo.GetKullanicilarWithYetkilerAsync();
            var kullaniciVeYetkiDTO =_mapper.Map<List<GetKullanicilarWithYetkilerDTO>>(kullaniciYetkiList);
            return kullaniciVeYetkiDTO;
        }

        public async Task<GetKullanicilarWithYetkilerDTO> GetKullanicilarWithYetkilerAsync(int kullaniciId)
        {
            var kullaniciVeYetki = await _kullaniciRepo.GetKullanicilarWithYetkilerAsync(kullaniciId);
            var kullaniciVeYetkiDTO=_mapper.Map<GetKullanicilarWithYetkilerDTO>(kullaniciVeYetki);//??
            return kullaniciVeYetkiDTO;
        }

        public Task<Kullanicilar> getKullanicilarWithYetkilerAsync(Kullanicilar yetkiler)
        {
            throw new NotImplementedException();
        }
        public Task<GetKullanicilarWithYetkilerDTO> GetKullanicilarYetkiler()
        {
			throw new NotImplementedException();
		}
    }
}
