using Microsoft.EntityFrameworkCore;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class SitecoredbContext: DbContext
    {
        public SitecoredbContext() : base() { }

        //tables mapping
        public DbSet<Job> jobList { get; set; }
        public DbSet<UserQuery> userQueryList { get; set; }
        public DbSet<UserResumes> userResumeList { get; set; }
        public DbSet<VisitedUsers> vistedUsersList { get; set; }
        public DbSet<AdminLogin> adminDetails { get; set; }
        public DbSet<BlockedIp> blockedIpList { get; set; }
        public DbSet<PagesData> pageDataList { get; set; }
        public DbSet<NewUser> userList { get; set; }
        public DbSet<Gallery> galleryList { get; set; }
        public DbSet<Conferences> conferencesList { get; set; }
    }
}
