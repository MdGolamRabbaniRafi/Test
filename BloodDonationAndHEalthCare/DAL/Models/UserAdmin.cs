using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class UserAdmin
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string BloodGroup { get; set; }

        public DateTime DOB { get; set; }
        public string Password { get; set; }

        public virtual ICollection<User> Users { get; set; }
        public UserAdmin()
        {
            Users = new List<User>();

        }
    }
}
