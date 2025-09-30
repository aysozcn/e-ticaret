using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class SayfaBulunamadiController : Controller
    {
        public IActionResult Page404Index()
        {
            return View();
        }
    }
}
