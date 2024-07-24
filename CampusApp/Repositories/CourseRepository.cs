using CampusApp.Data;
using CampusApp.Interface;
using CampusApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CampusApp.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CampusDbContext _context;

        public CourseRepository(CampusDbContext context)
        {
            _context = context;
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            List<Course> courses = await _context.Courses.ToListAsync();
            return courses;
        }

        public async Task<Course?> GetCourseByIdAsync(int courseId)
        {
            Course? course = await _context.Courses.FindAsync(courseId);
            return course;
        }

        public async Task EditCourseAsync(Course course)
        {
            if (await _context.Courses.FindAsync(course.Id) is Course found
                && found != null)
            {
                found.Name = course.Name;

                await _context.SaveChangesAsync();
            }
        }

        public async Task AddCourseAsync(string name)
        {
            Course newCourse = new Course() { Name = name };

            await _context.Courses.AddAsync(newCourse);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteCourseAsync(int courseId)
        {
            if (await _context.Courses.FindAsync(courseId) is Course found)
            {
                _context.Courses.Remove(found);

                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
