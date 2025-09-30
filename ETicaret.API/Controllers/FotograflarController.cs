using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using ETicaret.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class FotograflarController : Controller
    {
        private readonly IService<Fotograflar> _service;
        private readonly IMapper _mapper;

        public FotograflarController(IService<Fotograflar> service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<IActionResult> FotograflarIndex()
        {
            var fotograf = await _service.GetAllAsyncs();
            return Ok(fotograf);
        }

        [HttpPost]
        public async Task<IActionResult> FotografKaydet(FotograflarDTO fotografEkleDTO)
        {
            var fotografKaydet = await _service.AddAsync(_mapper.Map<Fotograflar>(fotografEkleDTO));

            var mapEkle = _mapper.Map<FotograflarDTO>(fotografKaydet);

            return Ok(fotografEkleDTO);
        }

        [HttpPut("FotograflarGuncelle")]
        public async Task<IActionResult> FotografGuncelle(FotografGuncelleDTO fotografGuncelleDTO)
        {
            var fotografGuncelle = await _service.GetByIdAsync(fotografGuncelleDTO.Id);

            if (fotografGuncelle != null)
            {
                await _service.UpdateAsync(_mapper.Map<Fotograflar>(fotografGuncelleDTO));
                return Ok();
            }
            else
            {
                return NoContent();
            }

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> FotografSil(int id)
        {
            var fotografSil = await _service.GetByIdAsync(id);

            if (fotografSil != null)
            {
                await _service.RemoveAsync(fotografSil);

                return Ok();
            }
            else
            {
                return NoContent();
            }
        }

        [HttpGet("FotografGetById/{id}")]
        public async Task<IActionResult> FotografGetById(int id)
        {
            var getFotograf = await _service.GetByIdAsync(id);

            return Ok(getFotograf);
        }

        [HttpGet("GetFotograflarWithUrunler")]
        public async Task<IActionResult> GetFotograflarWithUrunler()
        {
            var fotograflar = await _service.GetAllAsyncs();

            var fotograflarDTO = _mapper.Map<List<GetFotograflarWithUrunlerDTO>>(fotograflar);

            return Ok(fotograflarDTO);
        }
    }
}
