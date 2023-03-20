using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class NewUser
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(200)]
        public string Company { get; set; }
        [Required]
        [StringLength(100)]
        public string Designation { get; set; }
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string Country { get; set; }
        [StringLength(50)]
        public string City { get; set; }
        public string ZIP { get; set; }
        [Required]
        public string Telephone { get; set; }
        public string Fax { get; set; }
        [Required]
        public string Email { get; set; }
        public string Purpose { get; set; }
    }
}
