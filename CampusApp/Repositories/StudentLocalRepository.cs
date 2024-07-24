using CampusApp.Interface;
using CampusApp.Models;
using CampusApp.Models.ViewModels;

namespace CampusApp.Repositories
{
    public class StudentLocalRepository : IStudentRepository
    {
        // replaces the database
        private static List<Student> _students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Ragnar",
                LastName = "The Red",
                Birthdate = new DateTime(1950, 12, 12),
                Email = "ragnartheboss@gmail.com",
                IsEnrolled = false
            },
            new Student()
            {
                Id = 2,
                Name = "Mjoll",
                LastName = "The Lioness",
                Birthdate = new DateTime(1995, 07, 13),
                Email = "TheLioness78@gmail.com",
                IsEnrolled = true
            },
            new Student()
            {
                Id = 3,
                Name = "Delphine",
                LastName = "The Blade",
                Birthdate = new DateTime(1975, 01, 05),
                Email = "SecretBlade@yahoo.com",
                IsEnrolled = false
            }
        };

        public int GetUniqueId() => _students.Count > 0 ? _students.Max(x => x.Id) + 1 : 1;

        /// <summary>
        /// Return a list containing all the students
        /// registered in the campus app.
        /// </summary>
        /// <returns>List of Student</returns>
        public Task<List<Student>> GetStudentsAsync() => Task.FromResult(_students);

        /// <summary>
        /// Return one specific student matching the given ID.
        /// </summary>
        /// <param name="StudentId">an integer representing an ID</param>
        /// <returns>an object Student</returns>
        public Task<Student?> GetStudentByIdAsync(int StudentId)
        {
            var student = _students.Find(student => student.Id == StudentId);

            // student can be null if nothing is find in the list
            return Task.FromResult(student);
        }

        /// <summary>
        /// Modify the information about a student (except its ID)
        /// </summary>
        /// <param name="studentToUpdate">the object Student the user wants to modify</param>
        public Task EditStudentAsync(Student studentToUpdate)
        {
            Student? student = _students.Find(student => student.Id == studentToUpdate.Id);

            if (student != null)
            {
                student.Name = studentToUpdate.Name;
                student.LastName = studentToUpdate.LastName;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Add one student to the list, auto generate the ID.
        /// </summary>
        /// <param name="name">a string for the name of the student</param>
        /// <param name="lastName">a string for the last name of the student</param>
        /// <param name="birthdate">a DateTime object for the birth date of the student</param>
        /// <param name="email">a string for the email of the student</param>
        /// <param name="isEnrolled">a bool</param>
        public void AddStudent(string name, string lastName, DateTime birthdate, string email, bool isEnrolled)
        {
            int idNewStudent = GetUniqueId();

            var newStudent = new Student()
            {
                Id = idNewStudent,
                Name = name,
                LastName = lastName,
                Birthdate = birthdate,
                Email = email,
                IsEnrolled = isEnrolled
            };

            _students.Add(newStudent);
        }

        /// <summary>
        /// Add one student to the list, auto generate the ID.
        /// </summary>
        /// <param name="student">the object AddStudent with all the user's information except the ID</param>
        public Task AddStudentAsync(AddStudent student)
        {
            int idNewStudent = _students.Max(student => student.Id) + 1;

            var newStudent = new Student()
            {
                Id = idNewStudent,
                Name = student.Name,
                LastName = student.LastName,
                Birthdate = student.Birthdate,
                Email = student.Email,
                IsEnrolled = student.IsEnrolled
            };

            _students.Add(newStudent);

            return Task.CompletedTask;
        }

        /// <summary>
        /// Delete a Student from the campus list, based on its ID.
        /// </summary>
        /// <param name="StudentId">an integer representing an ID</param>
        public Task<bool> DeleteStudentAsync(int StudentId)
        {
            Student? student = _students.Find(student => student.Id == StudentId);

            if (student is null) return Task.FromResult(false);

            _students.Remove(student);
            return Task.FromResult(true);
        }
    }
}
