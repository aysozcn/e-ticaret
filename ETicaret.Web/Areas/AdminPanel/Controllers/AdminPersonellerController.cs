using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IRepositories;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
	public class AdminPersonellerController : Controller
	{
		private readonly IKullanicilarService _kullaniciService;
		private readonly IPersonellerService _personelService;
		private readonly IMapper _mapper;

		public AdminPersonellerController(IPersonellerService personelService,IMapper mapper, IKullanicilarService kullaniciService)
		{
			_personelService = personelService;
			_kullaniciService = kullaniciService;
			_mapper = mapper;
		}

		public async Task<IActionResult> PersonellerIndex()
		{
			var personeller = await _personelService.GetPersonellerWithKullanicilarAsync();
			return View(personeller);
		}

		public async Task<IActionResult> PersonelKaydetIndex()
		{
			var kullaniciList = await _kullaniciService.GetAllAsyncs();
			var kullaniciDTO=_mapper.Map<List<KullanicilarDTO>>(kullaniciList);
			ViewBag.kullanicilar=kullaniciDTO;
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> PersonelKaydetIndex(Personeller personeller)
		{
			if (ModelState.IsValid)
			{
				var sonuc = await _personelService.AddAsync(personeller);
				if (sonuc!=null)
				{
					return RedirectToAction("PersonellerIndex");
				}
			}
			var kullaniciList = await _personelService.GetAllAsyncs();
			var kullaniciDTO = _mapper.Map<List<KullanicilarDTO>>(kullaniciList);
			ViewBag.kullanicilar = kullaniciDTO;

			return View();

		}
		[HttpGet]
		public async Task<IActionResult> PersonelGuncelleIndex(Personeller personel)
		{
			if (ModelState.IsValid)
			{
				await _personelService.UpdateAsync(_mapper.Map<Personeller>(personel));
				TempData["guncellemeMesaj"] = "<b>Güncelleme başarılı</b>";
				return RedirectToAction("PersonellerIndex");
			}
			TempData["hataMesaji"] = "<b> Güncelleme hata verdi,lütfen kontrol ediniz</b>";
			return RedirectToAction("PersonelGuncelleIndex", personel.Id);
		}


		public IActionResult PersonelSilIndex(int id)
		{
			return View();
		}


		[HttpPost]
		public IActionResult PersonelSilIndex(Urunler urunler)
		{
			return View();
		}

		public async Task KullaniciListesi()
		{
			var kullaniciList = await _kullaniciService.GetAllAsyncs();
			var kullaniciDTO = _mapper.Map<List<KullanicilarDTO>>(kullaniciList);
			ViewBag.kullanicilar = kullaniciDTO;
		}
	}
}
