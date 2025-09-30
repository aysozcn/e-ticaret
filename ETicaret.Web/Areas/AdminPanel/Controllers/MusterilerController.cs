using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class MusterilerController : Controller
    {
        private readonly IMusterilerService _musterilerService;
        private readonly IAdreslerService _adreslerService;
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IMapper _mapper;


        public MusterilerController(IMusterilerService musterilerService, IMapper mapper, IAdreslerService adreslerService, IKullanicilarService kullanicilarService)
        {
            _musterilerService = musterilerService;
            _adreslerService = adreslerService;
            _kullanicilarService = kullanicilarService;
            _mapper = mapper;
        }

        public async Task<IActionResult> MusterilerIndex()
        {
            var musteriler = await _musterilerService.GetAllAsyncs();
            return View(musteriler);
        }

        [HttpGet]
        public IActionResult MusteriEkleIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> MusteriEkleIndex(Musteriler musteri)
        {
            musteri.EklenmeTarih = DateTime.Now;
            musteri.AktifMi = false;
            var sonuc = await _musterilerService.AddAsync(musteri);

            if (sonuc != null)
            {
                return RedirectToAction("MusterilerIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> MusteriGuncelleIndex(int Id)
        {
            var musteri = await _musterilerService.GetByIdAsync(Id);
            return View(musteri);
        }

        [HttpPost]
        public async Task<IActionResult> MusteriGuncelleIndex(Musteriler musteri)
        {
            if (ModelState.IsValid)
            {
                musteri.GuncellenmeTarih = DateTime.Now;
                await _musterilerService.UpdateAsync(_mapper.Map<Musteriler>(musteri));
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("MusterilerIndex");
            }

            TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("MusteriGuncelleIndex", musteri.Id);
        }

        [HttpGet]
        public async Task<IActionResult> MusteriSilIndex(int Id)
        {
            var musteri = await _musterilerService.GetByIdAsync(Id);
            return View(musteri);
        }


        [HttpPost, ActionName("MusteriSilIndex")]
        public async Task<IActionResult> MusteriDeleteIndex(int Id)
        {
            var musteri = await _musterilerService.GetByIdAsync(Id);
            if (ModelState.IsValid)
            {
                await _musterilerService.RemoveAsync(_mapper.Map<Musteriler>(musteri));
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("MusterilerIndex");
            }

            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("MusteriSilIndex", musteri.Id);
        }
    }
}
