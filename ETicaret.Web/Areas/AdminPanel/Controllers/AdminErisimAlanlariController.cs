using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminErisimAlanlariController : Controller
    {
        private readonly IErisimAlanlariService _erisimAlanlariService;
        private readonly IYetkiErisimService _yetkiErisimService;
        private readonly IMapper _mapper;
        public AdminErisimAlanlariController(IErisimAlanlariService erisimAlanlariService, IYetkiErisimService yetkiErisimService, IMapper mapper)
        {
            _erisimAlanlariService = erisimAlanlariService;
            _mapper = mapper;
            _yetkiErisimService = yetkiErisimService;
        }
        [HttpGet]

        public async Task<IActionResult> AdminErisimAlanlariIndex()
        {
            var erisimAlanlari = await _erisimAlanlariService.GetAllAsyncs();
            return View(erisimAlanlari);
        }

        public async Task<IActionResult> AdminErisimAlanlariEkleIndex()
        {
            var erisimAlani = await _erisimAlanlariService.GetAllAsyncs();
            ViewBag.erisimAlanlari = erisimAlani;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AdminErisimAlanlariEkleIndex(ErisimAlanlari erisimAlanlari)
        {
            erisimAlanlari.AktifMi = true;
            erisimAlanlari.EklenmeTarih = DateTime.Now;
            var sonuc = await _erisimAlanlariService.AddAsync(erisimAlanlari);
            if (sonuc != null)
            {
                return RedirectToAction("AdminErisimAlanlariIndex");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AdminErisimAlanlariGuncelleIndex(int id)
        {
            var getErisimAlani = await _erisimAlanlariService.GetByIdAsync(id);


            return View(getErisimAlani);
        }

        [HttpPost]
        public async Task<IActionResult> AdminErisimAlanlariGuncelleIndex(ErisimAlanlari erisimA)
        {
            if (ModelState.IsValid)
            {
                erisimA.GuncellenmeTarih = DateTime.Now;
                erisimA.AktifMi = true;
                await _erisimAlanlariService.UpdateAsync(erisimA);
                return RedirectToAction("AdminErisimAlanlariIndex");
            }

            return RedirectToAction("AdminErisimAlanlariGuncelleIndex", erisimA.Id);
        }

        [HttpGet]
        public async Task<IActionResult> AdminErisimAlanlariSilIndex(int Id)
        {
            var erisimAlani = await _erisimAlanlariService.GetByIdAsync(Id);
            return View(erisimAlani);
        }
        [HttpPost, ActionName("AdminErisimAlanlariSilIndex")]
        public async Task<IActionResult> ErisimAlaniDelete(int Id, bool aktifMi)
        {
            var erisimAlani = await _erisimAlanlariService.GetByIdAsync(Id);
            if (ModelState.IsValid)
            {
                var yetkiErisim = _yetkiErisimService.GetAllQuery(k => k.ErisimAlaniId == Id);
                if (yetkiErisim != null)
                {
                    await _yetkiErisimService.RemoveRangeAsync(yetkiErisim);
                }
                await _erisimAlanlariService.RemoveAsync(erisimAlani);
                return RedirectToAction("AdminErisimAlanlariIndex");

            }
            return RedirectToAction("AdminErisimAlanlariSilIndex", erisimAlani.Id);
        }
    }
}
