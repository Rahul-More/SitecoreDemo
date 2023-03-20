using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        [StringLength(100)]
        [Required]
        public string Designation { get; set; }
        [Required]
        public string JobDescription { get; set; }
        public bool IsEnabled { get; set; }
    }
}
