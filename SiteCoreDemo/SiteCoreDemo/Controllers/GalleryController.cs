using Microsoft.AspNetCore.Mvc;

namespace SiteCoreDemo.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
