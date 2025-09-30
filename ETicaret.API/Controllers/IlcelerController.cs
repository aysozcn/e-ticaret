using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class IlcelerController : Controller
    {
        private readonly IService<Ilceler> _service;

        public IlcelerController(IService<Ilceler> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var ilce = await _service.GetAllAsyncs();
            return Ok(ilce);
        }
    }
}
