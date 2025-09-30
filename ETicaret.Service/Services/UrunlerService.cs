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
    public class UrunlerService : Service<Urunler>, IUrunlerService
    {
      
        readonly IUrunlerRepository _urunlerRepository;
        readonly IMapper _mapper;

        public UrunlerService(IGenericRepository<Urunler> repository, IUnitOfWork unitOfWork, IUrunlerRepository urunlerRepository,IMapper mapper) : base(repository, unitOfWork)
        {
            
            _urunlerRepository= urunlerRepository;
            _mapper=mapper;
        }

        public async Task<List<GetUrunlerWithKategoriDTO>> GetUrunlerWithKategoriAsync()
        {
            var urunVeKategoriList=await   _urunlerRepository.GetUrunlerWithKategoriAsync();
            var urunVeKategoriDTO = _mapper.Map<List<GetUrunlerWithKategoriDTO>>(urunVeKategoriList);
            return urunVeKategoriDTO;
        }

        public async Task<GetUrunlerWithKategoriDTO> GetUrunlerWithKategoriAsync(int urunlerId)
        {
            var urunVeKategori = await _urunlerRepository.GetUrunlerWithKategoriAsync(urunlerId);
            var urunVeKategoriDTO = _mapper.Map<GetUrunlerWithKategoriDTO>(urunVeKategori);
            return urunVeKategoriDTO;
        }

        public Task<Urunler> GetUrunlerWithKategoriAsync(Urunler kategori)
        {
            throw new NotImplementedException();
        }

        public Task<GetUrunlerWithKategoriDTO> GetUrunlerKategoriler()
        {
            throw new NotImplementedException();
        }

    }
}
