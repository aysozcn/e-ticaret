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
    public class IlService : Service<Iller>, IilService
    {
        private readonly IilRepository _ilRepository;
        private readonly IMapper _mapper;
        public IlService(IGenericRepository<Iller> repository, IUnitOfWork unitOfWork, IilRepository ilRepository, IMapper mapper) : base(repository, unitOfWork)
        {
            _ilRepository = ilRepository;
            _mapper = mapper;
        }


        public async Task<List<Ilceler>> GetIllerWithIlceler(int ilId)
        {
            var ilceler = await _ilRepository.GetIllerWithIlceler(ilId);
            return ilceler;
        }

        public async Task<List<Iller>> IllerListele()
        {
            var iller = await _ilRepository.GetAll().ToListAsync();
            return iller;
        }
    }
}
