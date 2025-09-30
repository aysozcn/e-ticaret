using ETicaret.Core.ETicaretDatabase;
using ETicaret.Core.IService;
using Microsoft.AspNetCore.Mvc;

namespace ETicaret.API.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class YetkiErisimController : Controller
    {
        private readonly IService<YetkiErisim> _service;

        public YetkiErisimController(IService<YetkiErisim> service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> YetkiErisimIndex()
        {
            var yetkiErisim = await _service.GetAllAsyncs();
            return Ok(yetkiErisim);
        }
    }
}
