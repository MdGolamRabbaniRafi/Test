using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Class_task1.Models
{
    public class AgeValidator : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            if (value is DateTime dateOfBirth)
            {
                int age = DateTime.Now.Year - dateOfBirth.Year;

                if (age >= 18)
                {
                    return true;
                }

            }

            return false;
        }
    }
}