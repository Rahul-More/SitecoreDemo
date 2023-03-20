using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class PagesData
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string PageUrl { get; set; }
        [Required]
        [StringLength(100)]
        public string Captions { get; set; }
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string Keywords { get; set; }
        [Required]
        public string Descriptions { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string PageContent { get; set; }

    }

    public class PageDataMethods
    {
        public PagesData getPageInfo(string url)
        {
            using (SitecoredbContext db = new SitecoredbContext())
            {
                var data = db.pageDataList.Where(i => i.PageUrl == url).SingleOrDefault();
                return data;
            }
           
        }
    }
}
