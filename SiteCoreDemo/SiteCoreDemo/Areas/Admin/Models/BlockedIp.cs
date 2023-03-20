using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class BlockedIp
    {
        [Key]
        public int Id { get; set; }
        public string IpAddress { get; set; }
        public bool IsBlocked { get; set; }
        public DateTime BlockingDate { get; set; }
    }
}
