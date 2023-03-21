using SiteCoreDemo.Areas.Admin.Models;

namespace SiteCoreDemo.Models
{
    public class HomePageModel
    {
        public PagesData pageData { get; set; }
        public List<Gallery> Slider { get; set; }
    }
}
