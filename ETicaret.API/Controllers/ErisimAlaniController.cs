using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ErisimAlaniController : Controller
    {
        private readonly IService<ErisimAlanlari> _service;
        private readonly IMapper _mapper;
        private readonly IService<YetkiErisim> _yetkiErisimService;
        private readonly IService<Yetkiler> _yetkiService;
        private readonly IErisimAlanlariService _erisimService;


        public ErisimAlaniController(IService<ErisimAlanlari> service, IMapper mapper, IService<YetkiErisim> yetkiErisimService, IErisimAlanlariService erisimService, IService<Yetkiler> yetkiService)
        {
            _service = service;
            _mapper = mapper;
            _yetkiErisimService = yetkiErisimService;
            _erisimService = erisimService;
            _yetkiService = yetkiService;
        }
        [HttpGet]
        public async Task<IActionResult> ErisimAlaniIndex()
        {
            var erisimAlani = await _service.GetAllAsyncs();
            var erisimDTO = _mapper.Map<List<ErisimAlanlariDTO>>(erisimAlani);
            return Ok(erisimDTO);
        }
        [HttpPost]
        public async Task<IActionResult> ErisimSave(ErisimAlanlariDTO erisimDTO)
        {
            var mapErisim = _mapper.Map<ErisimAlanlari>(erisimDTO);
            var erisimSave = await _service.AddAsync(mapErisim);
            var mapAdd = _mapper.Map<ErisimAlanlariDTO>(erisimSave);
            return Ok(mapAdd);
        }
        [HttpPut]
        public async Task<IActionResult> ErisimUpdate(ErisimAlanlariUpdateDTO erisimUpdateDTO)
        {
            var getErisim = await _service.GetByIdAsync(erisimUpdateDTO.Id);
            if (getErisim != null)
            {
                await _service.UpdateAsync(_mapper.Map<ErisimAlanlari>(erisimUpdateDTO));
                return Ok();

            }
            else
            {
                return NoContent();
            }

        }
        [HttpDelete]
        public async Task<IActionResult> ErisimDelete(int id)
        {
            var getErisim = await _service.GetByIdAsync(id);
            var getYetkiErisim = _yetkiErisimService.GetAllQuery(a => a.ErisimAlaniId == id);


            if (getErisim != null || getYetkiErisim != null)
            {
                foreach (var item in getYetkiErisim)
                {
                    if (item != null)
                    {
                        await _yetkiErisimService.RemoveAsync(_mapper.Map<YetkiErisim>(item));
                    }
                }
                await _service.RemoveAsync(_mapper.Map<ErisimAlanlari>(getErisim));
                return Ok();
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("ErisimlerWithYetkiID/{id:int}")]
        public async Task<IActionResult> ErisimlerWithYetkiID(int id)
        {
            var erisimler = await _erisimService.GetErisimAlanlariWithYetkiIdAsync(id);
            var yetki = await _yetkiService.GetByIdAsync(id);
            if (erisimler != null)
            {
                var erisimDto = _mapper.Map<List<GetErisimAlanlariWithYetkiDTO>>(erisimler);
                foreach (var item in erisimDto)
                {
                    item.YetkiAdi = yetki.YetkiAdi;
                }
                return Ok(erisimDto);

            }
            else
            {
                return NoContent();

            }
        }

        [HttpGet("ErisimAlaniGetById/{id:int}")]

        public async Task<IActionResult> ErisimAlaniGetById(int id)
        {
            var erisim = await _service.GetByIdAsync(id);
            if (erisim != null)
            {
                var erisimDto = _mapper.Map<ErisimAlanlariDTO>(erisim);
                return Ok(erisimDto);

            }
            else
            {
                return NoContent();

            }
        }
    }
}
