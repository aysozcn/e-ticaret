using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SiparislerDetayController : Controller
    {
        private readonly IService<SiparisDetay> _service;

        public SiparislerDetayController(IService<SiparisDetay> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var siparisDetay = await _service.GetAllAsyncs();
            return Ok(siparisDetay);
        }
    }
}
