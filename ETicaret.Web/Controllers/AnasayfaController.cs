using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class AnasayfaController : Controller
    {
        //private readonly ISepetlerService _sepetlerService;
        private readonly IYorumlarService _yorumlarService;
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IGenericRepository<Urunler> _genericRepository;//Bunu Repository tipine dönüştürdüm yani Şuan IGenericRepository olarak gözükğyor fakat GenericRepository olarak çalışacaktır. yani Dependency Injection yaptım 

        //private readonly IGenericRepository<Urunler> _genericRepository;
        
        public AnasayfaController(IGenericRepository<Urunler> genericRepository,  IYorumlarService yorumlarService, IKullanicilarService kullanicilarService)
        {
            _genericRepository = genericRepository;
            _yorumlarService = yorumlarService;
            _kullanicilarService = kullanicilarService;
            //_sepetlerService = sepetService;
        }

        public IActionResult AnasayfaIndex()
        {
            //var getAll=_genericRepository.GetAll();
            return View();
        }

       

        public async Task<IActionResult> DetailIndex()
        {
            var yorumlar = await _yorumlarService.GetYorumlarWithKullanicilarAsync();
            return View(yorumlar);
        }
    }
}
