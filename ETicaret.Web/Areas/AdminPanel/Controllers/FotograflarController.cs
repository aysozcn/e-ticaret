using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class FotograflarController : Controller
    {
        private readonly IUrunlerService _urunlerService;
        private readonly IFotograflarService _fotograflarService;
        private readonly IMapper _mapper;

        public FotograflarController(IUrunlerService urunler, IFotograflarService service, IMapper mapper)
        {
            _urunlerService = urunler;
            _fotograflarService = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> FotograflarIndex()
        {
            var fotograflar = await _fotograflarService.GetFotografWithUrunAsync();
            return View(fotograflar);
        }

        public async Task<IActionResult> FotografEkleIndex()
        {
            var urunlerList = await _urunlerService.GetAllAsyncs();
            var urunlerDTO = _mapper.Map<List<UrunlerUpdateDTO>>(urunlerList);
            ViewBag.urunler = urunlerDTO;

            var fotograflar = await _fotograflarService.GetAllAsyncs();
            var fotograflarDTO = _mapper.Map<List<FotografGuncelleDTO>>(fotograflar);
            ViewBag.fotograflar = fotograflarDTO;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FotografEkleIndex(Fotograflar fotograf)
        {
            fotograf.EklenmeTarih = DateTime.Now;
            fotograf.AktifMi = true;
            var sonuc = await _fotograflarService.AddAsync(fotograf);

            if (sonuc != null)
            {
                return RedirectToAction("FotograflarIndex");
            }

            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> Upload(IFormFile file)
        //{
        //    var uploads = @"C:\UrunResimleri\";
        //    if (file.Length > 0)
        //    {
        //        var filePath = Path.Combine(uploads, file.FileName);

        //        ViewData["dosyaYolu"] = filePath.ToString();

        //        using (var fileStream = new FileStream(filePath, FileMode.Create))
        //        {
        //            await file.CopyToAsync(fileStream);
        //        }

        //        // Return the file path in JSON format
        //        return Json(new { success = true, filePath = filePath });
        //    }

        //    return Json(new { success = false });
        //}

        public async Task<IActionResult> FotografGuncelleIndex(int id)
        {
            var getirFotograf = await _fotograflarService.GetFotografWithUrunAsync(id);
            var urunList = await _urunlerService.GetAllAsyncs();

            var urunler = urunList.ToList();
            var fotograf = getirFotograf;

            var model = new Tuple<List<Urunler>, GetFotograflarWithUrunlerDTO>(urunler, fotograf);

            var fotograflar = await _fotograflarService.GetAllAsyncs();
            var fotograflarDTO = _mapper.Map<List<FotografGuncelleDTO>>(fotograflar);
            ViewBag.fotograflar = fotograflarDTO;

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> FotografGuncelleIndex(Fotograflar fotograf)
        {
            if (ModelState.IsValid)
            {
                fotograf.GuncellenmeTarih = DateTime.Now;
                await _fotograflarService.UpdateAsync(_mapper.Map<Fotograflar>(fotograf));
                TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı.</b>";
                return RedirectToAction("FotograflarIndex");
            }

            TempData["hataMesaj"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz.</b>";

            return RedirectToAction("FotografGuncelleIndex", fotograf.Id);
        }

        public async Task<IActionResult> FotografSilIndex(int id)
        {
            var fotograf = await _fotograflarService.GetByIdAsync(id);

            return View(fotograf);
        }

        [HttpPost, ActionName("FotografSilIndex")]
        public async Task<IActionResult> FotografSilIndex(int id, bool aktifMi)
        {
            var fotograf = await _fotograflarService.GetByIdAsync(id);

            if (ModelState.IsValid)
            {
                await _fotograflarService.RemoveAsync(_mapper.Map<Fotograflar>(fotograf));
                TempData["guncellemeMesaj"] = "<b>Silme başarılı.</b>";

                return RedirectToAction("FotograflarIndex");
            }

            TempData["hataMesaj"] = "<b>Silme hata verdi, lütfen kontrol ediniz.</b>";

            return RedirectToAction("FotografSilIndex", fotograf.Id);
        }


    }
}
