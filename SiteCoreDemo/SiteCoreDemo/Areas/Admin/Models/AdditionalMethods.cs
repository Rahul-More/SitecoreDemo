using Microsoft.EntityFrameworkCore;

namespace SiteCoreDemo.Areas.Admin.Models
{
    public class AdditionalMethods
    {

        public int GetIndexes(int pageSize, int totalRecords)
        {
            if (pageSize > totalRecords)
            {
                return 1;

            }
            else
            {
                if (totalRecords % pageSize == 0)
                {
                    return totalRecords / pageSize;
                }
                else
                {
                    return totalRecords / pageSize + 1;
                }

            }
        }

        //method for checking weather ip is valid to visit or not.
        public bool CheckIpStatus(string ipAddress)
        {
            using (SitecoredbContext db = new SitecoredbContext())
            {
                bool status = db.blockedIpList.Any(i => i.IpAddress == ipAddress && i.IsBlocked == true);
                return status;
            }
        }
    }
}
