using Microsoft.AspNetCore.Mvc;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
