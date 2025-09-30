using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class MusterilerController : Controller
    {
        private readonly IService<Musteriler> _service;
        private readonly IMapper _mapper;

        public MusterilerController(IService<Musteriler> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> MusterilerIndex()
        {
            var musteriler = await _service.GetAllAsyncs();
            var musterilerDTO = _mapper.Map<List<MusterilerDTO>>(musteriler);
            return Ok(musterilerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> MusterilerSave(MusterilerDTO musterilerDTO)
        {
            var musteriSave = await _service.AddAsync(_mapper.Map<Musteriler>(musterilerDTO));
            var mapAdd = _mapper.Map<MusterilerDTO>(musteriSave);
            return Ok(musterilerDTO);
        }

        [HttpPut("MusterilerUpdate")]
        public async Task<IActionResult> MusterilerUpdate(MusterilerUpdateDTO musterilerUpdateDTO)
        {
            var getMusteri = await _service.GetByIdAsync(musterilerUpdateDTO.Id);

            if (getMusteri != null)
            {
                await _service.UpdateAsync(_mapper.Map<Musteriler>(musterilerUpdateDTO));
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> MusterilerRemove(int id)
        {
            var getMusteri = await _service.GetByIdAsync(id);

            if (getMusteri != null)
            {
                await _service.RemoveAsync(getMusteri);
                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("MusteriGetById/{id}")]
        public async Task<IActionResult> MusteriGetById(int id)
        {
            var getMusteri = await _service.GetByIdAsync(id);

            return Ok(getMusteri);
        }

        [HttpGet("GetMusterilerWithSiparis")]
        public async Task<IActionResult> GetMusterilerWithSiparis()
        {
            var musteriler = await _service.GetAllAsyncs();
            var musterilerSiparisDTO = _mapper.Map<List<GetMusteriWithSiparisDTO>>(musteriler);
            return Ok(musterilerSiparisDTO);
        }

        [HttpGet("GetMusterilerWithAdres")]
        public async Task<IActionResult> GetMusterilerWithAdres()
        {
            var musteriler = await _service.GetAllAsyncs();
            var musterilerAdresDTO = _mapper.Map<List<GetMusterilerWithAdresDTO>>(musteriler);
            return Ok(musterilerAdresDTO);
        }

        [HttpGet("GetMusteriWithKullanici")]
        public async Task<IActionResult> GetMusteriWithKullanici()
        {
            var musteriler = await _service.GetAllAsyncs();
            var musterilerKullaniciDTO = _mapper.Map<List<GetMusteriWithKullaniciDTO>>(musteriler);
            return Ok(musterilerKullaniciDTO);
        }
    }
}
