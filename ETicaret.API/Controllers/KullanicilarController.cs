using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace ETicaret.API.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class KullanicilarController : Controller
	{
		private readonly IService<Kullanicilar> _service;
		private readonly IMapper _mapper;

		public KullanicilarController(IService<Kullanicilar> service,IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}
		[HttpGet]
		public async Task<IActionResult> KullaniciIndex()
		{
			var kullanici =await _service.GetAllAsyncs();
			var kullaniciDTO=_mapper.Map<List<KullanicilarDTO>>(kullanici);
			return Ok(kullanici);
		}

	    
		[HttpPost]
		public async Task<IActionResult> KullanicilarSave(KullanicilarDTO kullanicilarDto)
		{
			var kullaniciSave = await _service.AddAsync(_mapper.Map<Kullanicilar>(kullanicilarDto));
			var mapAdd = _mapper.Map<KullanicilarDTO>(kullaniciSave);
			return Ok(mapAdd);
		}

		/// <summary>
		/// Burada güncellenecek olan kullanıcının id`sini ve güncelleme verileri olan KullanicilarUpdateDTO parametresini aldım.GetByIdAsync metodu ile de id, ye göre güncellenecek kullanıcı bulunur,ardından _mapper.Map ile DTO`dan aldığım verileri varolan kullanıcı nesnesine atanır ve güncelleme işlemi yapılır
		/// </summary>
		/// <param name="kullanicilarDto"></param>
		/// <returns></returns>
		[HttpPut("id")]
		public async Task<IActionResult> KullaniciUpdate(int id,KullanicilarUpdateDTO kullaniciupdateDto)
		{
			var getKullanici =await _service.GetByIdAsync(id);
			if (getKullanici==null)
			{
				return NotFound();
			}
			//await _service.UpdateAsync(_mapper.Map<Kullanicilar>(kullaniciupdateDto));
			else
			{
				_mapper.Map(kullaniciupdateDto, getKullanici);
				return Ok(_mapper.Map<KullanicilarDTO>(getKullanici));
				
			}
			
		}

		/// <summary>
		/// KullaniciSil metodu ile silinecek olan kullanıcının id`sini alır ve GetByIdAsync ile de id verip kullanıcı id ile bulurum ve DeleteAsync metodu ile de kullanıcı silinir.
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		[HttpDelete("id")]
		public async Task<IActionResult> KullaniciSil(int id)
		{
			var getKullanici=await _service.GetByIdAsync(id);
			if (getKullanici==null)
			{
				return NotFound();
			}
			else
			{
				await _service.RemoveAsync(getKullanici);
				return NoContent();
			}
		}
	}
}
