using AutoMapper;
using ETicaret.Core.DTO;
using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class KategorilerController : BaseController
    {

        private readonly IService<Kategoriler> _service;
        private readonly IMapper _mapper;

        public KategorilerController(IService<Kategoriler> service,IMapper mapper)
        {
            _service=service;
            _mapper=mapper;
        }

        //[HttpGet]
        //public async  Task<IActionResult> KategoriIndex()
        //{
        //    var kategori= await _service.GetAllAsyncs();   

        //    return Ok(kategori);
        //}


        [HttpGet]
        public async Task<IActionResult> KategoriIndex()
        {
            var kategoriler = await _service.GetAllAsyncs();
            var kategoriDTO = _mapper.Map<List<KategoriDTO>>(kategoriler);
            return ResultAPI(kategoriDTO);
        }

    }
}
