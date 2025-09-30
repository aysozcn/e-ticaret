using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Controllers
{
    public class KullaniciGirisController : Controller
    {
        public IActionResult Index()
        {
            if (ModelState.IsValid)
            {

            }
            return View();
        }
    }
}
