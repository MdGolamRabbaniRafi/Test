using System;
using System.ComponentModel.DataAnnotations;

namespace BLL.DTO
{
    public class BloodDonationCampaignDTO
    {
        [Key]
        public int ID { get; set; }


        [Required(ErrorMessage = "Campaign Name is required")]
        [StringLength(100, ErrorMessage = "Campaign Name must not exceed 100 characters")]
        public string CampaignName { get; set; }

        [Required(ErrorMessage = "Start Date is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid Start Date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "End Date is required")]
        [DataType(DataType.DateTime, ErrorMessage = "Invalid End Date")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "Location is required")]
        [StringLength(200, ErrorMessage = "Location must not exceed 200 characters")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
    }
}