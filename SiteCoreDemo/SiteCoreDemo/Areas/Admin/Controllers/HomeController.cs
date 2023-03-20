using Microsoft.AspNetCore.Mvc;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
