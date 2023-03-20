using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SiteCoreDemo.Areas.Admin.Models;
using SiteCoreDemo.Models;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    [Authorize]
    [Route("Admin")]
    public class GalleryController : Controller
    {
        private SitecoredbContext db = new SitecoredbContext();
        public IActionResult Index()
        {
            var list = db.galleryList.OrderByDescending(i => i.Created_Date).ToList();
            return View(list);
        }
        public ActionResult Create()
        {
            var dd = new GalleryViewModel();
            Gallery cc = new Gallery()
            {
                Category = "",
                Name = "",
                EventDate = DateTime.Now,
                Created_Date = DateTime.Now,
                IsEnabled = true
            };
            return View(dd);
        }
        [HttpPost]
        public ActionResult Create(GalleryViewModel c, FormCollection formCollection)
        {
            var dat = formCollection["Gallery.EventDate"];
            string Largeimg = common.UploadImages(c.FileImage, $"{c.Gallery.Category}/Large");
            string Smallimg = common.UploadImagesWithSize(c.FileImage, $"{c.Gallery.Category}/Small", 480);

            Gallery gallery = new Gallery()
            {
                Category = c.Gallery.Category,
                IsEnabled = c.Gallery.IsEnabled,
                PreferenceNo = c.Gallery.PreferenceNo,
                Name = c.FileImage.FileName,
                LargeImageUrl = Largeimg,
                SmallImageUrl = Smallimg,
                EventDate = DateTime.ParseExact(dat, "dd-MM-yyyy", null),
                Created_Date = DateTime.Now
            };
            try
            {
                db.galleryList.Add(gallery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(c);
            }

        }
        public ActionResult Delete(int id = 0)
        {
            Gallery gallery = db.galleryList.Find(id);
            if (gallery == null)
            {
                return View();
            }
            return View(gallery);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallery gallery = db.galleryList.Find(id);
            db.galleryList.Remove(gallery);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
