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
    public class ErisimAlanlariService : Service<ErisimAlanlari>, IErisimAlanlariService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<ErisimAlanlari> _repository;
        private readonly IGenericRepository<YetkiErisim> _yetkiErisimRepository;
        readonly IMapper _mapper;


        public ErisimAlanlariService(IGenericRepository<ErisimAlanlari> repository, IMapper mapper, IUnitOfWork unitOfWork, IGenericRepository<YetkiErisim> yetkiErisimRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _yetkiErisimRepository = yetkiErisimRepository;
            _mapper = mapper;
        }

        public  async Task<List<ErisimAlanlariDTO>> GetErisimAlani()
        {

            var erisimList =await _repository.GetAll().ToListAsync();
            var erisimAlanlari =  _mapper.Map<List<ErisimAlanlariDTO>>(erisimList);
            return  erisimAlanlari;

        }

        public async Task<List<ErisimAlanlari>> GetErisimAlanlariWithYetkiIdAsync(int yetkiId)
        {
            var yetkiErisimler = await _yetkiErisimRepository.GetAllQuery(y => y.YetkiId == yetkiId)
                .Include(z => z.ErisimAlanlari)
                .Select(k => k.ErisimAlanlari)
                .ToListAsync();

            return yetkiErisimler;
        }
    }
}
