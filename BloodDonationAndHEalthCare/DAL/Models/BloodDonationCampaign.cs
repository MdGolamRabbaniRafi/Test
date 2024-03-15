using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class BloodDonationCampaign
    {
        public int ID { get; set; }
        public string CampaignName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int TotalMembersJoined { get; set; }
        public virtual ICollection<User> JoinedUsers { get; set; }
    }
}

