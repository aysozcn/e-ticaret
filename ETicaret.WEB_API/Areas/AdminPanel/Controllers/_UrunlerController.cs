using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.IService;
using ETicaret.WEB_API.Areas.AdminPanel.APIService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.WEB_API.Areas.AdminPanel.Controllers
{
    public class _UrunlerController : Controller
    {
        

        private readonly UrunlerAPIService _urunlerAPIService;
        private readonly KategorilerAPIService _kategorilerAPIService;

        public _UrunlerController( UrunlerAPIService urunlerAPIService,KategorilerAPIService kategorilerAPIService)
        {
            _urunlerAPIService = urunlerAPIService;
            _kategorilerAPIService = kategorilerAPIService; 
           
        }

        public async Task<IActionResult> _UrunlerIndex()
        {
            var urunList = await _urunlerAPIService.UrunlerWithKategori();
            return View(urunList);
        }

        public async Task<IActionResult> _UrunlerKaydet()
        {
            // var kategoriList = "";//API Kategori
            var kategoriList = await _kategorilerAPIService.GetAll();
            ViewBag.kategoriler = kategoriList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> _UrunlerKaydet(UrunlerDTO urunlerDTO)
      {

            var urunList = await _urunlerAPIService.UrunKaydet(urunlerDTO);
            return RedirectToAction("_UrunlerKaydet","_Urunler","AdminPanel");
        }
    }
}
