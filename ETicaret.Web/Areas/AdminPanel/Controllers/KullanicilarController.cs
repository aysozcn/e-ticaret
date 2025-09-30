using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class KullanicilarController : Controller
    {
        private readonly IKullanicilarService _kullaniciService;
        private readonly IYetkilerService _YetkiService;
        private readonly IMapper _mapper;

        public KullanicilarController(IKullanicilarService kullaniciService, IYetkilerService yetkiService, IMapper mapper)
        {
            _kullaniciService = kullaniciService;
            _YetkiService = yetkiService;
            _mapper = mapper;
        }

        public async Task<IActionResult> KullanicilarIndex()
        {
            var kullanicilar = await _kullaniciService.GetKullanicilarWithYetkilerAsync();

            var kullanicilarDTO= _mapper.Map<List<GetKullanicilarWithYetkilerDTO>>(kullanicilar);
            return View(kullanicilarDTO);
        }

        public async Task<IActionResult> KullaniciKaydetIndex()
        {
            var yetkiList = await _YetkiService.GetAllAsyncs();
            var yetkiDTO = _mapper.Map<List<YetkilerDTO>>(yetkiList.ToList());
            ViewBag.yetkiler = yetkiDTO;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> KullaniciKaydetIndex(Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _kullaniciService.AddAsync(kullanicilar);
                if (sonuc != null)
                {
                    return RedirectToAction("KullanicilarIndex");
                }
            }
           
            var yetkiList = await _YetkiService.GetAllAsyncs();
            var yetkiDTO = _mapper.Map<List<YetkilerDTO>>(yetkiList.ToList());
            ViewBag.yetkiler = yetkiDTO;
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> KullaniciGuncelleIndex(int id)
        {
			var getirKullanici = await _kullaniciService.GetKullanicilarWithYetkilerAsync(id);//??
			var yetkiList = await _YetkiService.GetAllAsyncs();

			var yetkiler = yetkiList.ToList();//Tuple'a list göndermek için gerekli
			var kullanici = getirKullanici;//Tuple'a nesne göndermek için gerekli

            var model = new Tuple<List<Yetkiler>, GetKullanicilarWithYetkilerDTO>(yetkiler,kullanici);

			return View(model);//UrunGuncelleIndex View sayfasında artık 2 model tanımı olacak. 1. Item1 kategorilerin listesi olacak,2. si ise Item2 olacak bu da Urunleri temsil edecek.
		}

        [HttpPost]
        public async Task<IActionResult> KullaniciGuncelleIndex(Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                await _kullaniciService.UpdateAsync(_mapper.Map<Kullanicilar>(kullanicilar));
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("KullanicilarIndex");
            }
            TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz</b>";
            return RedirectToAction("KullanicilarIndex", kullanicilar.Id);
        }

        public IActionResult KullaniciSilIndex(int id)
        {
            return View();
        }
        [HttpPost]
        public IActionResult KulllaniciSilIndex(Kullanicilar kullanicilar)
        {
            return View();
        }

        public async Task YetkiListesi()
        {
            var yetkiList = await _YetkiService.GetAllAsyncs();
            var yetkiDTO=_mapper.Map<List<YetkilerDTO>>(yetkiList);
            ViewBag.yetkiler = yetkiDTO;
        }

    }
}
