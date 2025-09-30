using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class SiparislerController : Controller
    {
        private readonly IService<GetSiparislerWithMusterilerDTO> _service;
        private readonly IMapper _mapper;

        public SiparislerController(IService<GetSiparislerWithMusterilerDTO> service, IMapper mapper) 
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SiparislerIndex()
        {
            var siparisler = await _service.GetAllAsyncs();
            var siparislerDTO = _mapper.Map<List<GetSiparislerWithMusterilerDTO>>(siparisler);
            return Ok(siparislerDTO);
        }

        [HttpPost]
        public async Task<IActionResult> SiparislerSave(GetSiparislerWithMusterilerDTO siparislerDto)
        {
            var siparisSave = await _service.AddAsync(_mapper.Map<GetSiparislerWithMusterilerDTO>(siparislerDto));
            var mapAdd = _mapper.Map<UrunlerDTO>(siparisSave);

            return Ok(mapAdd);
            //*
        }
    }
}
