using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Core.IUnitOfWork;
using ETicaret.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaret.Service.Services
{
    public class YetkilerService : Service<Yetkiler>, IYetkilerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<Yetkiler> _repository;
        private readonly IGenericRepository<YetkiErisim> _yetkiErisimRepository;
        readonly IMapper _mapper;

        public YetkilerService(IGenericRepository<Yetkiler> repository, IUnitOfWork unitOfWork, IMapper mapper, IGenericRepository<YetkiErisim> yetkiErisimRepository) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _yetkiErisimRepository = yetkiErisimRepository;
            _mapper = mapper;
        }

        public async Task<List<Yetkiler>> GetYetkilerWithErisimAlanIDAsync(int erisimAlanId)
        {
            var yetkiErisimler = await _yetkiErisimRepository.GetAllQuery(y => y.ErisimAlaniId == erisimAlanId)
                .Include(z => z.Yetkiler)
                .Select(a => a.Yetkiler)
                .ToListAsync();
            return yetkiErisimler;
        }

        public async Task<List<YetkilerDTO>> GetYetkiler()
        {
            var yetkiList = _repository.GetAll();
            var yetkiler = _mapper.Map<List<YetkilerDTO>>(yetkiList);
            return yetkiler;
        }

    }
}
