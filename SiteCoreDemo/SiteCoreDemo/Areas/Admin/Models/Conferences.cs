using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class Conferences
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        public string ImageURL { get; set; }
        public string DetailURL { get; set; }
        public string Description { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
    }
}
