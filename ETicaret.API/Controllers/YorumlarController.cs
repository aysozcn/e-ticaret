using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class YorumlarController : BaseController
    {
        private readonly IService<Yorumlar> _service;
        private readonly IMapper _mapper;

        public YorumlarController(IService<Yorumlar> service,IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> YorumlarIndex()
        {
            var yorumlar = await _service.GetAllAsyncs();
            var yorumlarDTO = _mapper.Map<List<YorumlarDTO>>(yorumlar);
            return Ok(yorumlarDTO);
        }

        [HttpPost]
        public async Task<IActionResult> YorumlarSave(YorumlarDTO yorumlarDTO)
        {
            var yorumSave = await _service.AddAsync(_mapper.Map<Yorumlar>(yorumlarDTO));
            var mapAdd = _mapper.Map<YorumlarDTO>(yorumSave);
            return Ok(mapAdd);
        }

        [HttpPut]
        public async Task<IActionResult> YorumlarUpdate(YorumlarUpdateDTO yorumUpdateDTO)
        {
            var getYorum = _service.GetByIdAsync(yorumUpdateDTO.Id);

            if (getYorum != null)
            {
                await _service.UpdateAsync(_mapper.Map<Yorumlar>(yorumUpdateDTO));
            }
            else
            {
                return NoContent();
            }

            return ResultAPI(yorumUpdateDTO);
        }
    
    }
}
