using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCoreDemo.Areas.Admin.Models;

namespace SiteCoreDemo.Areas.Admin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {

        private SitecoredbContext db = new SitecoredbContext();
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();

        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(AdminLogin data)
        {
            if (ModelState.IsValid)
            {

                bool admindata = db.adminDetails.Any(i => i.Name == data.Name && i.Password == data.Password);
                if (admindata)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Credentials");
                }

            }


            return View();

        }
        public ActionResult LogOut()
        {

            return RedirectToAction("Login", "Home");
        }

        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword adminDetails)
        {
            if (ModelState.IsValid)
            {
                var checkIfAdminExist = (from admin in db.adminDetails
                                         where admin.Password == adminDetails.OldPassword
                                         select admin).SingleOrDefault();
                if (checkIfAdminExist != null)
                {
                    checkIfAdminExist.Password = adminDetails.NewPassword;
                    db.Entry(checkIfAdminExist).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("LogOut", "Home");
                }

                else
                {
                    ModelState.AddModelError("", "Old password is not valid.");
                }
            }

            return View();
        }

    }

}
