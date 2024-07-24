using CampusApp.Interface;
using CampusApp.Models;
using CampusApp.Models.ViewModels;
using CampusApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CampusApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudentRepository _repo;

        public StudentController(IStudentRepository repo)
        {
            _repo = repo;
        }

        // IActionResult = interface implementing all the web objects returned
        // in .NET Core (very generic)
        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await _repo.GetStudentsAsync();

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int StudentId)
        {
            var student = await _repo.GetStudentByIdAsync(StudentId);

            return View(student);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int StudentId)
        {
            var student = await _repo.GetStudentByIdAsync(StudentId);

            if (student is null) return RedirectToAction(actionName: "List", controllerName: "Student");
            // same as: if (student is null) return View("List", StudentRepository.GetStudents());

            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int studentId, Student student)
        {
            if (!ModelState.IsValid) return View(student);

            await _repo.EditStudentAsync(student);

            return RedirectToAction("List", "Student");
        }

        // The type of HTTP method is get by default,
        // so normally we don't have to specify it.
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        // We create a new Model for the info about a new student,
        // because it is different from our original Model Student
        [HttpPost]
        public async Task<IActionResult> Add(AddStudent studentAdded)
        {
            // if invalid, returns in the View, into the asp-validation field
            if (!ModelState.IsValid) return View(studentAdded);

            await _repo.AddStudentAsync(studentAdded);

            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int StudentId)
        {
            if (await _repo.DeleteStudentAsync(StudentId)) return RedirectToAction("List", "Student");

            return NotFound();
        }
    }
}
