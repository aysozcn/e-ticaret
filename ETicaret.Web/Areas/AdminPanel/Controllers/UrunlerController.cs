using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Specialized;
using System.ComponentModel;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class UrunlerController : Controller
    {

        private readonly IKategoriService _kategoriService;
        private readonly IUrunlerService _service;
        private readonly IMapper _mapper;
        private readonly IFotograflarService _fotograflarService;


        public UrunlerController(IUrunlerService service, IMapper mapper, IKategoriService kategoriService, IFotograflarService fotograflarService)
        {
            _service = service;
            _mapper = mapper;
            _kategoriService = kategoriService;
            _fotograflarService = fotograflarService;
        }
        public async Task<IActionResult> UrunlerIndex()
        {
            var urunler = await _service.GetUrunlerWithKategoriAsync();
            //var urunlerDTO = _mapper.Map<List<GetUrunlerWithKategoriDTO>>(urunler);
            return View(urunler);
        }

        public async Task<IActionResult> UrunKaydetIndex()
        {
            var kategoriList = await _kategoriService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategoriDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UrunKaydetIndex(Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                var sonuc = await _service.AddAsync(urunler);

                string urunResimGuid = TempData["urunGuid"].ToString();
                //FotoğrafAdı?
                //fotografAciklamasi??,
                //urunId

                if (sonuc != null)
                {

                    return RedirectToAction("UrunlerIndex");
                }
            }

            var kategoriList = await _kategoriService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategoriDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UrunGuncelleIndex(int id)
        {
            var getirUrun = await _service.GetUrunlerWithKategoriAsync(id);
            var kategoriList = await _kategoriService.GetAllAsyncs();

            var kategoriler = kategoriList.ToList();//Tuple'a list göndermek için gerekli
            var urun = getirUrun;//Tuple'a nesne göndermek için gerekli

            var model = new Tuple<List<Kategoriler>, GetUrunlerWithKategoriDTO>//Önce Tuple gidecek nesneler tanımı yapılır
            (
            kategoriler,//nesne tanımından sonra List<Kategoriler>'si kategoriler ile doldur anlamına gelir
           urun// Urunler nesnesini urun ile doldur anlamına gelir

            );//çift model göndermek için kullanıldı.Tuple<> ile içinde 2 model gönderdim. 1. model Kategori list, 2. model nesne Urunler'i gönderdim. 

            return View(model);//UrunGuncelleIndex View sayfasında artık 2 model tanımı olacak. 1. Item1 kategorilerin listesi olacak,2. si ise Item2 olacak bu da Urunleri temsil edecek.
            //Kategori listesini foreach ile bütün değerleri dropdownlist'e atacak, 
            //Urunler nesnesini ise nesne içinde olan değeri alacak
            //View sayfasında inceleyebilirsiniz
        }

        [HttpPost]
        public async Task<IActionResult> UrunGuncelleIndex(Urunler urunler)
        {

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Urunler>(urunler));
                TempData["guncellemeMesaj"] = "<b >Güncelleme başarılı  </b>";//Bu mesaj UrunlerIndex sayfasında gösterilecek
                return RedirectToAction("UrunlerIndex");
            }

            TempData["hataMesaji"] = "<b>Güncelleme hata verdi, lütfen kontrol ediniz </b>";//Bu mesaj UrunGuncelleIndex Get'inde gösterilecek

            return RedirectToAction("UrunGuncelleIndex", urunler.Id);//Eğer hata verirse tekrar UrunGuncelleIndex (Get) methoduna yönlendirdim
            //Fotoğraf ekleme
        }

        public IActionResult UrunSilIndex(int id)
        {
            return View();
        }


        [HttpPost]
        public IActionResult UrunSilIndex(Urunler urunler)
        {
            return View();
        }

        public async Task KategoriListesi()
        {
            var kategoriList = await _kategoriService.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategoriDTO>>(kategoriList);
            ViewBag.kategoriler = kategoriDTO;
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file,int id)
        {
            var uploads = @"C:\UrunResimleri\";
            if (file.Length > 0)
            {
                var createGuid = Guid.NewGuid().ToString();
                string dosyaUzantisi = file.FileName.Split('.')[1];
                string resimAdi = $"urunId={id}_{createGuid.Substring(0,7)}.{dosyaUzantisi}";//urunId1_1vcf-345-3453535-sfsf.png

                var filePath = Path.Combine(uploads, resimAdi);
                ViewData["dosyaYolu"] = filePath.ToString();

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    string kaydet = await _fotograflarService.FotografEkleAsync(resimAdi,file.FileName , 1, id, false, DateTime.Now, DateTime.Now);//DB ye keler

                    await file.CopyToAsync(fileStream);//Localdeki dosyaya 1 kopyasını atar                    
                }
                // Return the file path in JSON format
                return Json(new { success = true, filePath = filePath });
            }
            return Json(new { success = false });
        }


       

        /// <summary>
        /// Resim sayfası. Bir ürün için Resim ekleme ve güncelleme işlemi yapar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<IActionResult> UrunResimleri(int id)
        {
            try
            {
                var getirUrun = await _service.GetByIdAsync(id);

                var getirResimler = await _fotograflarService.GetAllQueryAsync(k => k.UrunId == id);

                if (getirResimler.Count() > 0)
                {
#warning bu kısımda resimlerin listelenmesi sağlanacak
                    //Resimleri olan ürün için resimleri View'e göndermeiz gereklidir?
                    return View(getirUrun);
                }


                ViewBag.resimYok = "Resim yok";
                return View(getirUrun);
            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}
