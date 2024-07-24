using CampusApp.Models;
using CampusApp.Models.ViewModels;

namespace CampusApp.Interface
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetCoursesAsync();
        Task<Course?> GetCourseByIdAsync(int courseId);
        Task EditCourseAsync(Course course);
        Task AddCourseAsync(string name);
        Task<bool> DeleteCourseAsync(int courseId);
    }
}
