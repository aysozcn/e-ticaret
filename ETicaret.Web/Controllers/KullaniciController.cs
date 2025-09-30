using AutoMapper;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using ETicaret.Repository;
using ETicaret.Repository.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class KullaniciController :Controller
    {
       
       private readonly IKullanicilarRepository _kullaniciRepo;
        private IMapper _mapper;
       
        public KullaniciController(IKullanicilarRepository kullaniciRepo, IMapper mapper)
        {
           
            _kullaniciRepo = kullaniciRepo;
            _mapper = mapper;
          
           
        }

        public IActionResult GirisIndex()
        {

            if (ModelState.IsValid)
            {

                //Microsoft.AspNetCore.Session
                ViewBag.menuList = "Menü List";//

                var userName = HttpContext.Session.GetString("userName");
                var userYetki = HttpContext.Session.GetString("userYetki");

                ViewBag.Username = userName;
                ViewBag.UserYetki = userYetki;
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GirisIndex(string kullaniciAdi,string sifre)
        {
            var kullaniciGiris =await _kullaniciRepo.Giris(kullaniciAdi, sifre);

            if (kullaniciGiris!=null)
            {
                string AdSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
                string yetki = kullaniciGiris.Yetkiler?.Id.ToString();
                if (yetki!=null)
                {
					HttpContext.Session.SetString("userName", AdSoyad);
					HttpContext.Session.SetString("userYetki", yetki);
					string kullaniciAdSoyad = kullaniciGiris.Adi + " " + kullaniciGiris.Soyadi;
					TempData["userAdiSoyadi"] = kullaniciAdSoyad;
					TempData["kullaniciId"] = kullaniciGiris.KullaniciId;
				}
               

                if (TempData["Id"]!=null)
                {
                    return RedirectToAction("UrunIndex", "Urunler", new { id = TempData["Id"] });

                }
                return RedirectToAction("AnasayfaIndex", "Anasayfa");
            }
            return View();
        }
        public IActionResult LoginLink()
        {
            return View();
        }
        public IActionResult KullaniciCikis()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("GirisIndex");
        }
    }
}
