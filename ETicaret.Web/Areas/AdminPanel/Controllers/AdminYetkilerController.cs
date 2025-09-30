using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using ETicaret.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminYetkilerController : Controller
    {
        private readonly IYetkilerService _yetkilerService;
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IYetkiErisimService _yetkiErisimService;
        private readonly IMapper _mapper;
        public AdminYetkilerController(IYetkilerService yetkilerService, IMapper mapper, IErisimAlanlariService erisimAlanlariService, IYetkiErisimService yetkiErisimService)
        {
            _yetkilerService = yetkilerService;
            _mapper = mapper;
            _erisimAlanlariService = erisimAlanlariService;
            _yetkiErisimService = yetkiErisimService;
        }

        public async Task<IActionResult> AdminYetkilerIndex()
        {
            var yetkiler = await _yetkilerService.GetYetkiler();

            ViewData["erisimAlani"] = await _erisimAlanlariService.GetErisimAlani();

            return View(yetkiler);
        }

        public async Task<IActionResult> AdminYetkilerKaydetIndex()
        {
            var yetkiler = await _yetkilerService.GetYetkiler();

            ViewData["erisimAlani"] = await _erisimAlanlariService.GetErisimAlani();
            ViewData["yetkiErisim"] = await _yetkiErisimService.GetAllAsyncs();

            return View(yetkiler);
        }
        [HttpPost]
        public async Task<IActionResult> AdminYetkilerKaydetIndex(Yetkiler yetkileritem, int[] selectedSayfalar)
        {
            var yetkiler = await _yetkilerService.GetYetkiler();
            var erisimAlanlari = await _erisimAlanlariService.GetErisimAlani();
            var yetkiErisim = await _yetkiErisimService.GetAllAsyncs();
            YetkiErisim yeniYetkiErisim = new YetkiErisim();
            if (ModelState.IsValid)
            {
                var sonuc = await _yetkilerService.AddAsync(yetkileritem);
                if (sonuc != null)
                {
                    foreach (var item in selectedSayfalar)
                    {
                        yeniYetkiErisim.YetkiId = yetkileritem.Id;
                        yeniYetkiErisim.ErisimAlaniId = item;
                        yeniYetkiErisim.Aciklama = yetkileritem.YetkiAdi;
                        var sonuc2 = await _yetkiErisimService.AddAsync(yeniYetkiErisim);
                    }
                    return RedirectToAction("AdminYetkilerIndex");
                }
            }


            ViewData["erisimAlani"] = erisimAlanlari;
            ViewData["yetkiErisim"] = yetkiErisim;

            return View();
        }
        [HttpGet]
        public async Task<IActionResult> AdminYetkilerGuncelleIndex(int yetkiId)
        {
            var yetkiBul = await _yetkilerService.GetByIdAsync(yetkiId);
            ViewData["erisimAlani"] = await _erisimAlanlariService.GetErisimAlani();
            ViewData["yetkiErisim"] = _yetkiErisimService.GetAllQuery(k => k.YetkiId == yetkiId).ToList();



            return View(yetkiBul);

        }
        [HttpPost]
        public async Task<IActionResult> AdminYetkilerGuncelleIndex(Yetkiler yetkiler, YetkiErisim yetkiErisim1, int[] selectedSayfalar)
        {
            //ilk selectedSayfalar
            //TempData["yetileri"]
            if (ModelState.IsValid)
            {
                await _yetkilerService.UpdateAsync(_mapper.Map<Yetkiler>(yetkiler));

                var karsilastirmaSayfalari = await _yetkiErisimService.GetAllQueryAsync(k => k.YetkiId == yetkiler.Id);
                if (karsilastirmaSayfalari != null && karsilastirmaSayfalari.Any())
                {
                    var silinecekSayfalar = karsilastirmaSayfalari.Where(item => !selectedSayfalar.Contains(item.ErisimAlaniId)).ToList();
                    if (silinecekSayfalar != null)
                    {
                        await _yetkiErisimService.RemoveRangeAsync(_mapper.Map<List<YetkiErisim>>(silinecekSayfalar));
                    }
                }


                foreach (var item in selectedSayfalar)
                {
                    var erisimVarMi = _yetkiErisimService.GetAllQuery(y => y.YetkiId == yetkiler.Id && y.ErisimAlaniId == item).FirstOrDefault();

                    if (erisimVarMi == null)
                    {
                        yetkiErisim1.YetkiId = yetkiler.Id;
                        yetkiErisim1.ErisimAlaniId = item;
                        yetkiErisim1.Aciklama = yetkiler.YetkiAdi;
                        await _yetkiErisimService.AddAsync(yetkiErisim1);
                    }
                }
                return RedirectToAction("AdminYetkilerIndex");
            }
            return RedirectToAction("AdminYetkilerGuncelleIndex", yetkiler.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdminYetkilerSilIndex(int id)
        {
            var yetki = await _yetkilerService.GetByIdAsync(id);
            return View(yetki);
        }

        [HttpPost, ActionName("AdminYetkilerSilIndex")]
        public async Task<IActionResult> YetkiDelete(int Id, bool aktifMi)
        {
            var yetki = await _yetkilerService.GetByIdAsync(Id);

            var yetkiErisim = await _yetkiErisimService.GetAllQueryAsync(y => y.YetkiId == Id);
            if (ModelState.IsValid)
            {
                await _yetkiErisimService.RemoveRangeAsync(_mapper.Map<List<YetkiErisim>>(yetkiErisim));

                await _yetkilerService.RemoveAsync(_mapper.Map<Yetkiler>(yetki));

                TempData["mesaj"] = "<b>Silindi</b>";
                return RedirectToAction("AdminYetkilerIndex");
            }

            TempData["hataMesaj"] = "<b>Silme Hatası</b>";

            return RedirectToAction("AdminYetkilerIndex", yetki.Id);
        }
    }
}
