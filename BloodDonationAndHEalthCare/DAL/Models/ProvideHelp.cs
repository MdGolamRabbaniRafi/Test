using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProvideHelp
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime HelpDate { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
    }
}

