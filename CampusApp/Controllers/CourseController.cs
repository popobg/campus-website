using CampusApp.Interface;
using CampusApp.Models;
using CampusApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CampusApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ICourseRepository _repo;

        public CourseController(ICourseRepository repo)
        {
            _repo = repo;
        }

        public async Task<IActionResult> List()
        {
            var courses = await _repo.GetCoursesAsync();
            return View(courses);
        }

        public async Task<IActionResult> Edit(int CourseId)
        {
            var course = await _repo.GetCourseByIdAsync(CourseId);

            if (course is null) return RedirectToAction(actionName: "List", controllerName: "Course");

            ViewBag.Action = nameof(Edit);
            return View(course);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = nameof(Edit);
                return View(course);
            }

            await _repo.EditCourseAsync(course);
            return RedirectToAction("List", "Course");
        }

        public IActionResult Add()
        {
            ViewBag.Action = nameof(Add);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(Course course)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Action = nameof(Add);
                return View(course);
            }

            await _repo.AddCourseAsync(course.Name);
            return RedirectToAction(actionName: "List", controllerName: "Course");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int CourseId)
        {
            await _repo.DeleteCourseAsync(CourseId);
            return RedirectToAction("List", "Course");
        }
    }
}
