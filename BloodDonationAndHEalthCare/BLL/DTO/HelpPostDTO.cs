using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class HelpPostDTO
    {
        public int HelpPostId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Problems { get; set; }
        public string Amount { get; set; }
        public int UserId { get; set; }
    }
}
