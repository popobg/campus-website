using System.ComponentModel.DataAnnotations;

namespace CampusApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(@"^[\w\-\s]+$", ErrorMessage = "Course's name can only contains letters, digits and dash.")]
        public string Name { get; set; } = string.Empty;
    }
}