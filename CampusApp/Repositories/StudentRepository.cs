using CampusApp.Data;
using CampusApp.Interface;
using CampusApp.Models;
using CampusApp.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace CampusApp.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly CampusDbContext _context;

        public StudentRepository(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            List<Student> students = await _context.Students.ToListAsync();
            return students;
        }

        public async Task<Student?> GetStudentByIdAsync(int studentId)
        {
            Student? student = await _context.Students.FindAsync(studentId);
            return student;
        }

        public async Task EditStudentAsync(Student student)
        {
            if (await _context.Students.FindAsync(student.Id) is Student found
                && found != null)
            {
                _context.Entry(found).CurrentValues.SetValues(student);

                await _context.SaveChangesAsync();
            }
        }

        public async Task AddStudentAsync(AddStudent studentAdded)
        {
            // the ID generation is managed by the DB
            Student newStudent = new Student()
            {
                Name = studentAdded.Name,
                LastName = studentAdded.LastName,
                Birthdate = studentAdded.Birthdate,
                Email = studentAdded.Email,
                IsEnrolled = studentAdded.IsEnrolled
            };

            await _context.Students.AddAsync(newStudent);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteStudentAsync(int studentId)
        {
            if (await _context.Students.FindAsync(studentId) is Student found)
            {
                _context.Students.Remove(found);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
