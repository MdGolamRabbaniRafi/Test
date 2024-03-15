using System.ComponentModel.DataAnnotations;
using System;
using Class_task1.Models;

namespace BLL.DTOs
{
    public class UserAdminDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage = "Name must contain only letters and spaces.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Age is Required")]
        [AgeValidator(ErrorMessage = "Age must be 18+")]
        public DateTime DOB { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [MinLength(4, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Blood group is Required")]
        public string BloodGroup { get; set; }

    }
}
