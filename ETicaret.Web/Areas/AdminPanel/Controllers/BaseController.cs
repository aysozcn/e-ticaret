using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class BaseController : Controller
    {

        public IActionResult Index()
        {
            
            return View();
        }
    }
}
