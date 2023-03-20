namespace SiteCoreDemo.Areas.Admin.Models
{
    public class ConferenceViewModel
    {
        public Conferences Main { get; set; }
        public IFormFile ImageFile { get; set; }
        public IFormFile PdfFile { get; set; }
    }
}
