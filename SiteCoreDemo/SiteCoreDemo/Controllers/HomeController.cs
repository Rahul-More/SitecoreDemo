using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiteCoreDemo.Areas.Admin.Models;
using SiteCoreDemo.Models;

namespace SiteCoreDemo.Controllers
{
    public class HomeController : Controller
    {
        private SitecoredbContext dbRecords = new SitecoredbContext();
        private AdditionalMethods additionalMethods = new AdditionalMethods();
        public IActionResult Index()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            HomePageModel imagesList = new HomePageModel();

            imagesList.Slider = dbRecords.galleryList.Where(i => i.Category == "Slider").OrderByDescending(c => c.Created_Date).ToList();
            PageDataMethods getData = new PageDataMethods();
            imagesList.pageData = getData.getPageInfo(url);


            return View(imagesList);
        }
        public ActionResult About()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var aboutusData = getData.getPageInfo(url);
            return View(aboutusData);
        }
		public ActionResult Objective()
		{
			var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
			string url = location.AbsoluteUri;
			PageDataMethods getData = new PageDataMethods();
			var PageData = getData.getPageInfo(url);
			return View(PageData);
		}
        public ActionResult Faculty()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var PageData = getData.getPageInfo(url);
            return View(PageData);
        }
        public ActionResult Members()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var PageData = getData.getPageInfo(url);
            return View(PageData);
        }
        public ActionResult Conferences()
        {

            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            var PageData = new PageDataMethods().getPageInfo(url);
            ConferencesViewModel view = new ConferencesViewModel();
            view.Page = PageData;
            view.list = dbRecords.conferencesList.ToList();
            return View(view);
        }
        public ActionResult Guidelines()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var PageData = getData.getPageInfo(url);
            return View(PageData);
        }
        public ActionResult Workshops()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var PageData = getData.getPageInfo(url);
            return View(PageData);
        }
        public ActionResult Contact()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var pageData = getData.getPageInfo(url);
            return View(pageData);
        }
        public ActionResult Faq()
        {
            var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
            string url = location.AbsoluteUri;
            PageDataMethods getData = new PageDataMethods();
            var faqData = getData.getPageInfo(url);
            return View(faqData);
        }
		public ActionResult Privacy()
		{
			var location = new Uri($"{Request.Scheme}://{Request.Host}{Request.Path}{Request.QueryString}");
			string url = location.AbsoluteUri;
			PageDataMethods getData = new PageDataMethods();
			var privacyData = getData.getPageInfo(url);
			return View(privacyData);
		}
	}
}
