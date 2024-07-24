using CampusApp.Interface;
using CampusApp.Models;

namespace CampusApp.Repositories
{
    public class CourseLocalRepository : ICourseRepository
    {
        private static List<Course> _courses = new List<Course>()
        {
            new Course()
            {
                Id = 1,
                Name = "History"
            },
            new Course()
            {
                Id = 2,
                Name = "Math"
            },
            new Course()
            {
                Id = 3,
                Name = "War"
            }
        };

        private int GetUniqueId() => _courses.Count > 0 ? _courses.Max(x => x.Id) + 1 : 1;

        /// <summary>
        /// Get all Courses
        /// </summary>
        /// <returns>Task list of Course</returns>
        public Task<List<Course>> GetCoursesAsync() => Task.FromResult(_courses);

        /// <summary>
        /// Get one specific Course with his id
        /// </summary>
        /// <param name="idCourse"></param>
        /// <returns>Task Course</returns>
        public Task<Course?> GetCourseByIdAsync(int courseId) => Task.FromResult(_courses.Find(x => x.Id == courseId));

        public Task EditCourseAsync(Course courseToUpdate)
        {
            var course = _courses.Find(x => x.Id == courseToUpdate.Id);

            if (course != null)
            {
                course.Name = courseToUpdate.Name;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Add one Course to the list, auto generate the id
        /// </summary>
        /// <param name="name"></param>
        // no void for an async function, task
        public Task AddCourseAsync(string name)
        {
            var idNewCourse = GetUniqueId();
            var newCourse = new Course()
            {
                Id = idNewCourse,
                Name = name,
            };
            _courses.Add(newCourse);
            return Task.CompletedTask;
        }

        public Task<bool> DeleteCourseAsync(int courseId)
        {
            var course = _courses.Find(x => x.Id == courseId);

            if (course is null) return Task.FromResult(false);

            _courses.Remove(course);
            return Task.FromResult(true);
        }
    }
}
