using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class UserResumes
    {
        [Key]
        public int ResumeId { get; set; }

        [StringLength(50)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(50)]
        [Required]
        public string DOB { get; set; }

        [StringLength(15)]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string ContactNo { get; set; }

        [StringLength(300)]
        [Required]
        public string Education { get; set; }

        [StringLength(300)]
        [Required]
        public string Experience { get; set; }
        public string ResumeUrl { get; set; }
        public DateTime CreateDate { get; set; }


    }
}
