using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class AdminLogin
    {
        [Key]
        public int AdminId { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
