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
    public class KategorilerService : Service<Kategoriler>, IKategoriService
    {
        private readonly IGenericRepository<Kategoriler> _kategoryRepo;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IKategoriRepository _kategoriRepository;
        public KategorilerService(IGenericRepository<Kategoriler> kategoriRepo, IUnitOfWork unitOfWork, IKategoriRepository kategoriRepository) : base(kategoriRepo, unitOfWork)
        {
            _kategoryRepo = kategoriRepo;
            _unitOfWork = unitOfWork;
            _kategoriRepository = kategoriRepository;
        }

		public Task<string> GetAllQueryAsyncs(Func<object, object> value)
		{
			throw new NotImplementedException();
		}

		public Task<List<Kategoriler>> GetKategorilerWithUrunler()
        {
            throw new NotImplementedException();
        }

        public Task<Kategoriler> GetKategorilerWithUrunler(int kategorilerId)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Kategoriler> KategoriListesi()
        {
            return _kategoryRepo.GetAll();

        }

        public async Task<object> KategoriSilAsync(int id)
        {
            var kategoriGetir = await _kategoriRepository.GetByIdAsync(id);
            if (kategoriGetir != null)
            {
                return await _kategoriRepository.KategoriSilAsync(kategoriGetir.Id);
            }
            return null;
        }
    }
}
