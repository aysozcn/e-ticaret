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
    public class YetkiErisimService : Service<YetkiErisim>, IYetkiErisimService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<YetkiErisim> _repository;

        public YetkiErisimService(IGenericRepository<YetkiErisim> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public Task<string> YetkiErisimEkle(int erisimAlaniId, int yetkiId, string aciklama)
        {
            throw new NotImplementedException();
        }

        public Task<List<YetkiErisim>> YetkiErisimleri()
        {
            var yetkiErisimList = _repository.GetAll();

            return (Task<List<YetkiErisim>>)yetkiErisimList;
        }

        public Task<string> YetkiErisimSil(int erisimAlaniId, int yetkiId)
        {
            throw new NotImplementedException();
        }
    }
}
