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
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword")]
        public string ConfirmPassword { get; set; }

    }
}
