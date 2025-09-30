using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.AdminPanel.Controllers
{
    public class SiparislerController : Controller
    {
        public IActionResult SiparislerIndex()
        {
            return View();
        }
    }
}
