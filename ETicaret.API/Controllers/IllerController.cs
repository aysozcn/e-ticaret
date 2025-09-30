using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class IllerController : Controller
    {
        private IService<Iller> _service;

        public IllerController(IService<Iller> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var il = await _service.GetAllAsyncs(); 
            return Ok(il);
        }
    }
}
