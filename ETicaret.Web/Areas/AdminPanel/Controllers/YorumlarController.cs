using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class YorumlarController : Controller
    {
        private readonly IYorumlarService _service;
        private readonly IKullanicilarService _kullanicilarService;
        private readonly IUrunlerService _urunlerService;
        private readonly IMapper _mapper;


        public YorumlarController(IYorumlarService service, IKullanicilarService kullanicilarService, IUrunlerService urunlerService,IMapper mapper)
        {
            _service = service;
            _kullanicilarService = kullanicilarService;
            _urunlerService = urunlerService;
            _mapper = mapper;
        }

        public async Task<IActionResult> YorumlarIndex()
        {
            var yorumlar = await _service.GetYorumlarWithKullanicilarAsync();
            return View(yorumlar);
        }

        public async Task<IActionResult> YorumEkleIndex()
        {
            var yorumList = await _service.GetAllAsyncs();
            var sonuc = _mapper.Map<List<YorumlarDTO>>(yorumList);
            ViewBag.yorumlar = sonuc;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> YorumEkleIndex(Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _service.AddAsync(yorumlar);
                if (sonuc != null)
                {
                    return RedirectToAction("YorumlarIndex");
                }
            }
            var yorumList = await _service.GetAllAsyncs();
            var yorumDTO = _mapper.Map<List<YorumlarDTO>>(yorumList);
            ViewBag.yorumlar = yorumDTO;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> YorumGuncelleIndex(int Id)
        {
            var getirYorumKullanici = await _service.GetYorumlarWithKullanicilarAsync(Id);
            //var getirYorumUrun = await _service.GetYorumlarWithUrunlerAsync(Id);
            var model = getirYorumKullanici;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> YorumGuncelleIndex(Yorumlar yorumlar)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Yorumlar>(yorumlar));
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
                return RedirectToAction("YorumlarIndex");
            }

            TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("YorumlarIndex", yorumlar.Id);
        }

        [HttpGet]
        public async Task<IActionResult> YorumSilIndex(int Id)
        {
            var yorum = await _service.GetByIdAsync(Id);
            return View(yorum);
        }

        [HttpPost, ActionName("YorumSilIndex")]
        public async Task<IActionResult> YorumSilIndex(int Id, bool aktifMi)
        {
            var yorum = await _service.GetByIdAsync(Id);
            if (ModelState.IsValid)
            {
                await _service.RemoveAsync(_mapper.Map<Yorumlar>(yorum));
                TempData["guncellemeMesaj"] = "<b>Silme başarılı</b>";
                return RedirectToAction("YorumlarIndex");
            }
            TempData["hataMesaji"] = "<b>Silme hata verdi, lütfen kontrol ediniz </b>";

            return RedirectToAction("YorumSilIndex", yorum.Id);
        }

        

    }
}
