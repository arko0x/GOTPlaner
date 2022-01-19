using System;
using System.ComponentModel.DataAnnotations;

namespace GOTPlaner.Models
{
    public class CustomDateValidator : ValidationAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return "You have to be at leasst 7 years old to register";
        }

        protected override ValidationResult IsValid(object objValue, ValidationContext validationContext)
        {
            var dateValue = objValue as DateTime? ?? new DateTime();

            //alter this as needed. I am doing the date comparison if the value is not null

            if (dateValue.Date > DateTime.Now.Date.AddYears(-7))
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
            return ValidationResult.Success;
        }
    }
}
