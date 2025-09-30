using AutoMapper;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class UrunlerController : BaseDefaultController
    {
        private readonly IKategoriService _kategoriService;
        private readonly IUrunlerService _urunService;
        private readonly IMapper _mapper;

        public UrunlerController(IUrunlerService urunlerService, IMapper mapper, IKategoriService kategoriService)
        {
            _urunService = urunlerService;
            _mapper = mapper;
            _kategoriService = kategoriService;
        }


        public async Task<IActionResult> UrunIndex()
        {
            var kategori = await _kategoriService.GetAllAsyncs(); 
            TempData["kategoriler"] = kategori;
            //IGenericRepo=> GenericRepo
            //IService=> Service
            var urunList = await _urunService.GetAllQueryAsync(k => k.AktifMi == true);
            //Yorumlar=> İsa
            //Sepet=>Serkan

            return View(urunList);
        }

        public async Task<ActionResult> KategoriIndex()
        {
            var urunler = await _urunService.GetAllAsyncs();
            TempData["urunler"] = urunler;
            var kategoriList = await _kategoriService.GetAllQueryAsyncs(k => k.Equals(true));

            return View(kategoriList); 
        }

        
    }
}
