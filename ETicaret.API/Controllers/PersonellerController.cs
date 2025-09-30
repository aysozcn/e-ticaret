using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
	[ApiController]
	[Route("api/[Controller]")]
	public class PersonellerController : Controller
	{
		private readonly IService<Personeller> _service;
		private readonly IMapper _mapper;

		public PersonellerController(IService<Personeller> service,IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[HttpGet]
		public async Task<IActionResult> PersonelIndex()
		{
			var personel = await _service.GetAllAsyncs();
			var personelDto=_mapper.Map<List<Personeller>>(personel);
			return View(personel);
		}

		/// <summary>
		/// Kayıt işlemi yapar
		/// </summary>
		/// <param name="PersonellerDto"></param>
		/// <returns></returns>
		[HttpPost]
		public async Task<IActionResult> PersonellerSave(PersonellerDTO PersonellerDto)
		{
			var personelSave = await _service.AddAsync(_mapper.Map<Personeller>(PersonellerDto));
			var mapAdd=_mapper.Map<PersonellerDTO>(personelSave);
			return Ok(mapAdd);
		}

		[HttpPut("id")]
		public async Task<IActionResult> PersonelUpdate(int id, PersonellerUpdateDTO personelupdateDto)
		{
			var getPersonel = await _service.GetByIdAsync(id);
			if (getPersonel == null)
			{
				return NotFound();
			}
			
			else
			{
				_mapper.Map(personelupdateDto, getPersonel);
				return Ok(_mapper.Map<PersonellerDTO>(getPersonel));

			}

		}
		[HttpDelete("id")]
		public async Task<IActionResult> PersonelSil(int id)
		{
			var getPersonel = await _service.GetByIdAsync(id);
			if (getPersonel == null)
			{
				return NotFound();
			}
			else
			{
				await _service.RemoveAsync(getPersonel);
				return NoContent();
			}
		}
	}
}
