using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTOs
{
    public class DonationDTO
    {
        public int Id { get; set; }

        [Required]
       

     
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required]
        public string Description { get; set; }

        public bool IsApproved { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public bool IsPaid { get; set; }
        public int UserId { get; set; }

    }
}