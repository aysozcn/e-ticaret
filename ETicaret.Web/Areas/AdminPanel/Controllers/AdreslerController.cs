using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdreslerController : Controller
    {
        private readonly IilService _ilService;
        private readonly IAdreslerService _adreslerService;
        private readonly IMapper _mapper;

        public AdreslerController(IAdreslerService adreslerService, IMapper mapper, IilService ilService)
        {
            _adreslerService = adreslerService;
            _ilService = ilService;
            _mapper = mapper;
        }

        public async Task<IActionResult> AdreslerIndex()
        {
            var adresMusteri = await _adreslerService.AdresVeMusteri();

            //var adresVeMusteri = await _adreslerService.GetAdreslerWithMusteriAsync();

            return View(adresMusteri);
        }


        public async Task<IActionResult> AdresKaydetIndex()
        {
            var iller = await _ilService.IllerListele();

            TempData["iller"] = iller;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdresKaydetIndex(Adresler adresler)
        {
            if (ModelState.IsValid)
            {
                adresler.MusteriId = 2;
                adresler.AktifMi = true;
                var sonuc = await _adreslerService.AddAsync(adresler);
                if (sonuc != null)
                {
                    return RedirectToAction("AdreslerIndex");
                }
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Ekleme başarısız</div>";
            return View();
        }

        public async Task<IActionResult> AdresGuncelleIndex(int id)
        {
            var adresGetir = await _adreslerService.GetByIdAsync(id);
            var iller = await _ilService.IllerListele();

            var illerList = iller.ToList();
            var adres = adresGetir;

            var secilenIlKodu = adres.IlKodu;

            var ilceler = await _ilService.GetIllerWithIlceler(secilenIlKodu);

            var ilcelerList = ilceler.ToList();

            var secilenIlceKodu = adres.IlceKodu;

            var model = new Tuple<List<Iller>, List<Ilceler>, Adresler, int?, int?>(illerList, ilcelerList, adres, secilenIlKodu, secilenIlceKodu);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AdresGuncelleIndex(Adresler adres)
        {
            if (ModelState.IsValid)
            {

                await _adreslerService.UpdateAsync(_mapper.Map<Adresler>(adres));
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Güncelleme başarılı</div>";
                return RedirectToAction("AdreslerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Güncelleme başarısız</div>";
            return RedirectToAction("AdresGuncelleIndex", adres.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdresSilIndex(int id)
        {
            var adresGetir = await _adreslerService.GetByIdAsync(id);
            return View(adresGetir);
        }

        [HttpPost,ActionName("AdresSilIndex")]
        public async Task<IActionResult> AdresDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _adreslerService.AdresSilAsync(id);
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Adres Pasif Edildi</div>";
                return RedirectToAction("AdreslerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Adres Pasif Edilemedi</div>";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> GetIlveIlce(int ilId)
        {
            var ilceler = await _ilService.GetIllerWithIlceler(ilId);
            var ilceList = ilceler.Select(i => new
            {
                Value = i.IlceKodu,
                Text = i.IlceAdi
            });
            return Json(ilceList);
        }



    }
}
