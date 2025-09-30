using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class YetkilerController : Controller
    {
        private readonly IService<Yetkiler> _service;
        private readonly IService<YetkiErisim> _yetkiErisimService;
        private readonly IService<ErisimAlanlari> _erisimAlanService;
        private readonly IYetkilerService _yetkiService;
        private readonly IMapper _mapper;

        public YetkilerController(IService<Yetkiler> service, IMapper mapper, IService<YetkiErisim> yetkiErisimService, IYetkilerService yetkilerService, IService<ErisimAlanlari> erisimAlanSevice)
        {
            _service = service;
            _mapper = mapper;
            _yetkiErisimService = yetkiErisimService;
            _yetkiService = yetkilerService;
            _erisimAlanService = erisimAlanSevice;
        }
        [HttpGet]
        public async Task<IActionResult> YetkilerIndex()
        {
            var yetki = await _service.GetAllAsyncs();
            var yetkiDto = _mapper.Map<List<YetkilerDTO>>(yetki);
            return Ok(yetkiDto);
        }
        [HttpPost]
        public async Task<IActionResult> YetkiSave(YetkilerDTO yetkilerDTO)
        {
            var mapYetki = _mapper.Map<Yetkiler>(yetkilerDTO);
            var yetkiSave = await _service.AddAsync(mapYetki);
            var mapAdd = _mapper.Map<YetkilerDTO>(yetkiSave);
            return Ok(mapAdd);
        }
        //[HttpPut("/{yetkiId:int}")] böyle de yapılabilir.
        [HttpPut]
        public async Task<IActionResult> YetkiUpdate(YetkilerUpdateDTO yetkilerUpdateDTO)
        {
            var getYetki = await _service.GetByIdAsync(yetkilerUpdateDTO.Id);
            if (getYetki != null)
            {
                getYetki.YetkiAdi = yetkilerUpdateDTO.YetkiAdi;//BUnu sor mantıksız geldi...
                await _service.UpdateAsync(_mapper.Map<Yetkiler>(getYetki));
                return Ok();

            }
            else
            {
                return NoContent();
            }

        }
        [HttpDelete]
        public async Task<IActionResult> YetkiDelete(int id)
        {
            var getYetki = await _service.GetByIdAsync(id);
            var getYetkiErisim = _yetkiErisimService.GetAllQuery(a => a.YetkiId == id);


            if (getYetki != null || getYetkiErisim != null)
            {
                foreach (var item in getYetkiErisim)
                {
                    if (item != null)
                    {
                        await _yetkiErisimService.RemoveAsync(_mapper.Map<YetkiErisim>(item));
                    }
                }
                await _service.RemoveAsync(_mapper.Map<Yetkiler>(getYetki));
                return Ok();
            }
            else
            {
                return NoContent();
            }

        }

        [HttpGet("YetkilerWithErisimAlaniId/{id:int}")]
        public async Task<IActionResult> YetkilerWithErisimAlaniId(int id)
        {
            var yetkiler = await _yetkiService.GetYetkilerWithErisimAlanIDAsync(id);
            var erisimAlani = await _erisimAlanService.GetByIdAsync(id);
            if (yetkiler != null)
            {
                var yetkiDto = _mapper.Map<List<GetYetkilerWithErisimAlaniDTO>>(yetkiler);
                foreach (var item in yetkiDto)
                {
                    item.ControllerAdi = erisimAlani.ControllerAdi;
                    item.ViewAdi = erisimAlani.ViewAdi;
                }
                return Ok(yetkiDto);

            }
            else
            {
                return NoContent();

            }
        }
        
        [HttpGet("YetkilerGetById/{id:int}")]
        public async Task<IActionResult> YetkilerGetById(int id)
        {
            var yetki = await _service.GetByIdAsync(id);
            if (yetki != null)
            {
                var yetkiDto = _mapper.Map<YetkilerDTO>(yetki);
                return Ok(yetkiDto);

            }
            else
            {
                return NoContent();

            }
        }

    }
}
