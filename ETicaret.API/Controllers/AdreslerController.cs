using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class AdreslerController : Controller
    {
        private readonly IService<Adresler> _service;
        private readonly IMapper _mapper;

        public AdreslerController(IService<Adresler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var adres = await _service.GetAllAsyncs();
            var adresDto = _mapper.Map<List<GetAdreslerWithMusteriDTO>>(adres);
            return Ok(adresDto);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AdresEkle(AdreslerAddDTO adresEkle)
        {
            var adresSave = await _service.AddAsync(_mapper.Map<Adresler>(adresEkle));
            var mapAdd = _mapper.Map<AdreslerAddDTO>(adresSave);
            return Ok(mapAdd);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> AdresUpdate(int id, AdreslerUpdateDTO updateDTO)
        {
            var adresGetir = await _service.GetByIdAsync(id);
            if (adresGetir != null)
            {
                _mapper.Map(updateDTO, adresGetir);

                await _service.UpdateAsync(adresGetir);
            }
            else
            {
                return NotFound();
            }
            return Ok(updateDTO);
        }
        [HttpGet("getById")]
        public async Task<IActionResult> IdGetir(int id)
        {
            var adres = await _service.GetByIdAsync(id);
            var adresDto = _mapper.Map<AdreslerUpdateDTO>(adres);
            return Ok(adresDto);
        }

    }
}
