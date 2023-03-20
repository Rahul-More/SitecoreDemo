using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCoreDemo.Areas.Admin.Models;
using SiteCoreDemo.Models;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    [Authorize]
    [Route("Admin")]
    public class ConferencesController : Controller
    {
        private SitecoredbContext db = new SitecoredbContext();
        public IActionResult Index()
        {
            return View(db.conferencesList.ToList());
        }
        public ActionResult Create()
        {
            var dd = new ConferenceViewModel();
            Conferences cc = new Conferences()
            {
                Name = "",
                ImageURL = "",
                EventDate = DateTime.Now,
                Created_Date = DateTime.Now

            };
            dd.Main = cc;
            return View(dd);
        }
        [HttpPost]
        public ActionResult Create(ConferenceViewModel c, FormCollection formCollection)
        {
            var dat = formCollection["Main.EventDate"];
            string img = common.UploadImages(c.ImageFile, null);
            string pdf = common.UploadImages(c.PdfFile, null);
            Conferences conferences = new Conferences()
            {
                Name = c.Main.Name,
                Description = c.Main.Description,
                DetailURL = pdf.Trim('~'),
                ImageURL = img.Trim('~'),
                EventDate = DateTime.ParseExact(dat, "dd-MM-yyyy", null),
                Created_Date = DateTime.Now
            };
            try
            {
                conferences.Created_Date = DateTime.Now;
                db.conferencesList.Add(conferences);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View(c);
            }


        }

        public ActionResult Edit(int id = 0)
        {
            Conferences conferences = db.conferencesList.Find(id);
            if (conferences == null)
            {
                return View();
            }
            ConferenceViewModel page = new ConferenceViewModel();
            page.Main = conferences;
            return View(page);
        }
        [HttpPost]
        public ActionResult Edit(int id, ConferenceViewModel c, FormCollection formCollection)
        {
            Conferences conferences = db.conferencesList.Find(id);
            var dat = formCollection["Main.EventDate"];
            string img = common.UploadImages(c.ImageFile, null);
            string pdf = common.UploadImages(c.PdfFile, null);

            conferences.Name = c.Main.Name;
            conferences.Description = c.Main.Description;
            if (!string.IsNullOrEmpty(img))
            {
                conferences.ImageURL = img.Trim('~');
            }
            if (!string.IsNullOrEmpty(pdf))
            {
                conferences.DetailURL = pdf.Trim('~');
            }

            conferences.EventDate = DateTime.ParseExact(dat, "dd-MM-yyyy", null);
            conferences.Created_Date = DateTime.Now;
            try
            {
                conferences.Created_Date = DateTime.Now;
                db.Entry(conferences).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {

                return View(conferences);
            }


        }

        public ActionResult Delete(int id = 0)
        {
            Conferences conferences = db.conferencesList.Find(id);
            if (conferences == null)
            {
                return View();
            }
            return View(conferences);
        }
        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            Conferences conferences = db.conferencesList.Find(id);
            db.conferencesList.Remove(conferences);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
