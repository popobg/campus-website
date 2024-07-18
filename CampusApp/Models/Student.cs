using System.ComponentModel.DataAnnotations;

namespace CampusApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        // string.Empty = initialize the property when no value is given;
        // the property can't be null
        public string Name { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public DateTime Birthdate { get; set; }

        public string Email { get; set; } = string.Empty;

        public bool IsEnrolled { get; set; }
    }
}
