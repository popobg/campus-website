using CampusApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace CampusApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s\p{M}\p{L}\-]+$", ErrorMessage = "The name only takes letter")]
        // string.Empty = initialize the property when no value is given;
        // the property can't be null
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[a-zA-Z\s\p{M}\p{L}\-]+$", ErrorMessage = "The name only takes letter")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Date)]
        // error message not displayed
        [CustomValidation(typeof(AddStudent), nameof(ValidateBirthdate), ErrorMessage = "The date must be in DD/MM/YYYY format")]
        public DateTime Birthdate { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public bool IsEnrolled { get; set; }

        public static ValidationResult? ValidateBirthdate(DateTime birthdate, ValidationContext context)
        {
            var age = DateTime.Today.Year - birthdate.Year;

            // in case this year's birthday has not come yet
            if (birthdate > DateTime.Today.AddYears(-age)) age--;

            if (age < 14 || age > 99)
            {
                return new ValidationResult("Age must be between 14 and 99");
            }

            return ValidationResult.Success;
        }
    }
}
