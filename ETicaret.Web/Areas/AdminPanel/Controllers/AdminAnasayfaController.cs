using AutoMapper;
using ETicaret.Core.IRepositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class AdminAnasayfaController : Controller
    {
        private readonly IKullanicilarRepository _kullaniciRepo;
        private readonly IMapper _mapper;

		public AdminAnasayfaController(IKullanicilarRepository kullaniciRepo, IMapper mapper)
		{
			_kullaniciRepo = kullaniciRepo;
			_mapper = mapper;
		}

		public async Task<IActionResult> AdminAnasayfaIndex(int? id=null)
        {
            if (id!=null)
            {
                var kullanici = await _kullaniciRepo.KullaniciGetir((int)id);
                HttpContext.Session.SetString("kullaniciYetki", kullanici.Yetkiler?.Id.ToString());
            }
            return View();
        }

        public IActionResult AdminPartial()
        {
            return View();
        }
    }
}
