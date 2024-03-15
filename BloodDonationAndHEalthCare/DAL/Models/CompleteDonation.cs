using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CompleteDonation
    {
        [Key]
        public int Id { get; set; }
        public int DonerId { get; set; }
        public string Phone { get; set; }
        public string Location { get; set; }
        public string Problems { get; set; }
        public DateTime DonationTime { get; set; }
        public DateTime NextDonationTime { get; set; }
        public int ReceverId { get; set; }
    }
}