using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class UserQuery
    {
        [Key]
        public int QueryId { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public string Company { get; set; }
        [StringLength(200)]
        public string Address { get; set; }
        [StringLength(20)]
        [Required]
        public string Country { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        public string Postal { get; set; }
        [StringLength(15)]
        [Required]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid Phone number")]
        public string Telephone { get; set; }
        public string Fax { get; set; }
        [StringLength(100)]
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }
        public string Description { get; set; }
        public string Questions { get; set; }

    }
}
