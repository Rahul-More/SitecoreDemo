using Microsoft.AspNetCore.Hosting;
using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class Gallery
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [StringLength(250)]
        public string SmallImageUrl { get; set; }
        [StringLength(250)]
        public string LargeImageUrl { get; set; }
        public bool IsEnabled { get; set; }
        public int PreferenceNo { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
    }
    public class GalleryMethods
    {
        public string SaveLargeImage(IFormFile ProfileImage)
        {
            string[] allowedExtention = new string[] { ".jpg", ".png", ".JPEG", ".jpeg" };
            string finaleImageUrl = string.Empty;
            string imageExtention = Path.GetExtension(ProfileImage.FileName);
            if (!string.IsNullOrEmpty(ProfileImage.FileName))
            {
                if (allowedExtention.Contains(imageExtention))
                {
                    if (!Directory.Exists("~/Images/Gallery/LargeImages/"))
                    {
                        Directory.CreateDirectory("~/Images/Gallery/LargeImages/");
                    }
                    string uploadsFolder = Path.Combine("~/Images/Gallery/LargeImages/");
                    finaleImageUrl = Guid.NewGuid().ToString() + "_" +ProfileImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, finaleImageUrl);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }

                }

            }

            return finaleImageUrl;
        }
        public string SaveSmallImage(IFormFile ProfileImage)
        {
            string[] allowedExtention = new string[] { ".jpg", ".png", ".JPEG", ".jpeg" };
            string finaleImageUrl = string.Empty;
            string imageExtention = Path.GetExtension(ProfileImage.FileName);
            if (!string.IsNullOrEmpty(ProfileImage.FileName))
            {
                if (allowedExtention.Contains(imageExtention))
                {
                    if (!Directory.Exists("~/Images/Gallery/SmallImages/"))
                    {
                        Directory.CreateDirectory("~/Images/Gallery/SmallImages/");
                    }
                    string uploadsFolder = Path.Combine("~/Images/Gallery/SmallImages/");
                    finaleImageUrl = Guid.NewGuid().ToString() + "_" +ProfileImage.FileName;
                    string filePath = Path.Combine(uploadsFolder, finaleImageUrl);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        ProfileImage.CopyTo(fileStream);
                    }

                }

            }

            return finaleImageUrl;
        }

    }

}
