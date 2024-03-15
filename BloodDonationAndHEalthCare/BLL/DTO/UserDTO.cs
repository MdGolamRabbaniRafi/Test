using Class_task1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        [StringLength(50, ErrorMessage = "FirstName must not exceed 50 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "DateOfBirth is required")]
        //[DataType(DataType.Date, ErrorMessage = "Invalid DateOfBirth")]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[AgeValidator(ErrorMessage = "Age must be 18+")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Password is required")]
        //[MinLength(8, ErrorMessage = "Password must be at least 8 characters long")]
       // [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[^A-Za-z\d]).{8,}$", ErrorMessage = "Password must have at least one uppercase letter, one lowercase letter, one digit, and one special character")]
        public string Password { get; set; }

        //public string FileName { get; set; }
        //public string FileContent { get; set; }
        [Required(ErrorMessage = "Password is required")]


        //[RegularExpression(@"^(A|B|AB|O)[+-]?$", ErrorMessage = "Invalid BloodGroup")]
        public string BloodGroup { get; set; }
        [Required(ErrorMessage = "Type is required")]

        public string UserType { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "AdminId must be a positive integer")]
        public int? AdminId { get; set; }
    }
}
