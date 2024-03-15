using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace DAL.Models
{
    public class Donation
    {
        public int Id { get; set; }
    
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public bool IsPaid { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}

