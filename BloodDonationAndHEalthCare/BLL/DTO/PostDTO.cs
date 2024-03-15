using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PostDTO
    {
        public int PostId { get; set; }
        public string Name { get; set; }
        public string BloodGroup { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Problems { get; set; }
        
        public int UserId { get; set; }
    }
}
