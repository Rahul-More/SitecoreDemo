using System.ComponentModel.DataAnnotations;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class VisitedUsers
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string IpAddress { get; set; }
        [StringLength(50)]
        [Required]
        public string VisitedPage { get; set; }
        [StringLength(20)]
        [Required]
        public string Country { get; set; }
        [StringLength(30)]
        public string City { get; set; }
        [Required]
        public DateTime EntryTime { get; set; }
        [Required]
        public DateTime ISTTime { get; set; }
    }
    public class UniqueUsers
    {
        public string IpAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }

    }

    public class UniqueCountryWithIpsList
    {
        public List<UniqueCountryWithIps> uniqueIpsList { get; set; }
        public int pageCounter { get; set; }
    }

    public class UniqueCountryWithIps
    {
        public string Country { get; set; }
        public int NoOfIps { get; set; }

    }

    public class UniqueIpsForCountry
    {
        public string ipAddress { get; set; }
        public int NoOf_VisitedPage { get; set; }
        public bool? blockingStatus { get; set; }

    }
}
