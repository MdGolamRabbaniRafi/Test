using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Password { get; set; }
        //public string FileName { get; set; } 
        //public string FileContent { get; set; } 
        public string BloodGroup { get; set; } // Nullable string

        public string UserType { get; set; } // Nullable string

        [ForeignKey("UserAdmin")]

 


        public int? AdminId { get; set; } // Nullable int
        public virtual UserAdmin UserAdmin { get; set; } // Nullable UserAdmin


        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<HelpPost> HelpPosts { get; set; }
        public virtual ICollection<Donation> Donations { get; set; }
        public virtual ICollection<BloodDonationCampaign> Campaigns { get; set; }
        public virtual ICollection<BloodDonationCampaign> JoinedCampaigns { get; set; }

        public User()
        {
            Posts = new List<Post>();
            HelpPosts = new List<HelpPost>();
            Donations = new List<Donation>();
        }
       

        //public User()
        //{
        //    HelpPosts = new List<HelpPost>();
        //}

    }
}
