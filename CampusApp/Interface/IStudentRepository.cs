using CampusApp.Models;
using CampusApp.Models.ViewModels;

namespace CampusApp.Interface
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetStudentsAsync();
        Task<Student?> GetStudentByIdAsync(int studentId);
        Task EditStudentAsync(Student student);
        Task AddStudentAsync(AddStudent addStudent);
        Task<bool> DeleteStudentAsync(int studentId);
    }
}
