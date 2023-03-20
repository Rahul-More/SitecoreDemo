using Microsoft.AspNetCore.Mvc;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    public class PageDataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
