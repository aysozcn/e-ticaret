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
	public class PersonellerService : Service<Personeller>, IPersonellerService
	{
		readonly IPersonellerRepository _personelRepo;
		readonly IMapper _mapper;
		public PersonellerService(IGenericRepository<Personeller> repository, IUnitOfWork unitOfWork,IPersonellerRepository personelRepo, IMapper mapper) : base(repository, unitOfWork)
		{
			_personelRepo = personelRepo;
			_mapper = mapper;
		}

		public async Task<List<GetPersonellerWithKullanicilarDTO>> GetPersonellerWithKullanicilarAsync()
		{
			var personelVeKullaniciList=await _personelRepo.GetPersonellerWithKullanicilarAsync();
			var personelVeKullaniciDTO=_mapper.Map<List<GetPersonellerWithKullanicilarDTO>>(personelVeKullaniciList);
			return personelVeKullaniciDTO;
		}

		public async Task<GetPersonellerWithKullanicilarDTO> GetPersonellerWithKullanicilarAsync(int persoenllerId)
		{
			var personelVeKullanici = await _personelRepo.GetPersonellerWithKullanicilarAsync(persoenllerId);
			var personelVeKullaniciDTO = _mapper.Map<GetPersonellerWithKullanicilarDTO>(personelVeKullanici);
			return personelVeKullaniciDTO;
		}

		public Task<Personeller> GetPersonellerWithKullanicilarAsync(Personeller personel)
		{
			throw new NotImplementedException();
		}
		public Task<GetPersonellerWithKullanicilarDTO> GetPersonelKullanici()
		{
			throw new NotImplementedException();
		}
	}
}
