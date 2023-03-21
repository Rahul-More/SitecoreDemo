using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCoreDemo.Areas.Admin.Models;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    public class PageDataController : Controller
    {
        private SitecoredbContext db = new SitecoredbContext();
        public IActionResult Index()
        {
            return View(db.pageDataList.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(PagesData pagesdata)
        {
            if (ModelState.IsValid)
            {
                db.pageDataList.Add(pagesdata);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pagesdata);
        }
        public ActionResult Edit(int id = 0)
        {
            PagesData pagesdata = db.pageDataList.Find(id);
            if (pagesdata == null)
            {
                return View();
            }
            return View(pagesdata);
        }
        [HttpPost]
        public ActionResult Edit(PagesData pagesdata)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pagesdata).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pagesdata);
        }
        public ActionResult Delete(int id = 0)
        {
            PagesData pagesdata = db.pageDataList.Find(id);
            if (pagesdata == null)
            {
                return View();
            }
            return View(pagesdata);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            PagesData pagesdata = db.pageDataList.Find(id);
            db.pageDataList.Remove(pagesdata);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
