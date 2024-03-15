using DAL.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    internal class DBContext : DbContext
    {
        public DbSet<UserAdmin> UserAdmins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Token> Tokens { get; set; }

        public DbSet<Post>Posts { get; set; }

       
        public DbSet<HelpPost> HelpPosts { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<ProvideHelp> ProvideHelps { get; set; }
        

        public DbSet<BloodDonationCampaign> BloodDonationsCampaigns { get; set; }
        public DbSet<CompleteDonation> CompleteDonations { get; set; }



    }
}
