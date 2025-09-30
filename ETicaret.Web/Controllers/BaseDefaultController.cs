using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class BaseDefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
