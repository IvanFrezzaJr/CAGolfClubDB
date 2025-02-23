namespace CAGolfClubDB.Validators;

using System;
using System.ComponentModel.DataAnnotations;


public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value is DateTime date)
        {
            if (date.Date < DateTime.Today)
            {
                return new ValidationResult("The date must be today or in the future.");
            }
        }
        return ValidationResult.Success;
    }
}


