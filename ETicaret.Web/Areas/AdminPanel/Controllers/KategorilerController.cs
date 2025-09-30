using AutoMapper;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class KategorilerController : Controller
    {
        private readonly IKategoriService _kategoriService;
        private readonly IMapper _mapper;

        public KategorilerController(IKategoriService kategoriService, IMapper mapper)
        {
            _kategoriService = kategoriService;
            _mapper = mapper;
        }

        public async Task<IActionResult> KategorilerIndex()
        {
            return View(await _kategoriService.KategoriListesi().ToListAsync());
        }

        public async Task<IActionResult> KategoriEkleIndex()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KategoriEkleIndex(Kategoriler kategori)
        {
            if (ModelState.IsValid)
            {
                kategori.AktifMi = true;
                var sonuc = await _kategoriService.AddAsync(kategori);
                if (sonuc != null)
                {
                    return RedirectToAction("KategorilerIndex");
                }
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Ekleme başarısız</div>";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> KategoriGuncelleIndex(int id)
        {
            var kategoriGetir = await _kategoriService.GetByIdAsync(id);
            return View(kategoriGetir);
        }

        [HttpPost]
        public async Task<IActionResult> KategoriGuncelleIndex(Kategoriler kategori)
        {
            if (ModelState.IsValid)
            {
                await _kategoriService.UpdateAsync(_mapper.Map<Kategoriler>(kategori));
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Güncelleme başarılı</div>";
                return RedirectToAction("KategorilerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-danger\" role=\"alert\">Güncelleme başarısız</div>";
            return RedirectToAction("KategoriGuncelleIndex", kategori.Id);
        }

        [HttpGet]
        public async Task<IActionResult> KategoriSilIndex(int id)
        {
            var kategoriGetir = await _kategoriService.GetByIdAsync(id);
            return View(kategoriGetir);
        }

        [HttpPost, ActionName("KategoriSilIndex")]
        public async Task<IActionResult> KategoriDeleteIndex(int id)
        {
            if (id != 0)
            {
                await _kategoriService.KategoriSilAsync(id);
                TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Kategori Pasif Edildi</div>";
                return RedirectToAction("KategorilerIndex");
            }
            TempData["mesaj"] = "<div class=\"col-md-12 alert alert-success\" role=\"alert\">Kategori Pasif Edilemedi</div>";
            return View();
        }
    }
}
