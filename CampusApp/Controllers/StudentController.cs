using CampusApp.Models;
using CampusApp.Models.ViewModels;
using CampusApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CampusApp.Controllers
{
    public class StudentController : Controller
    {
        // IActionResult = interface implementing all the web objects returned
        // in .NET Core (very generic)
        [HttpGet]
        public IActionResult List()
        {
            return View(StudentRepository.GetStudents());
        }

        [HttpGet]
        public IActionResult Details(int StudentId)
        {
            return View(StudentRepository.GetStudentById(StudentId));
        }

        [HttpGet]
        public IActionResult Edit(int StudentId)
        {
            var student = StudentRepository.GetStudentById(StudentId);

            if (student is null) return RedirectToAction(actionName: "List", controllerName: "Student");
            // same as: if (student is null) return View("List", StudentRepository.GetStudents());

            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(int studentId, Student student)
        {
            if (studentId != student.Id) return BadRequest();

            var studentToUpdate = new Student()
            {
                Id = student.Id,
                Name = student.Name,
                LastName = student.LastName,
                Birthdate = student.Birthdate,
                Email = student.Email,
                IsEnrolled = student.IsEnrolled
            };

            StudentRepository.UpdateStudent(studentToUpdate);

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
        public IActionResult Add(AddStudent studentAdded)
        {
            // if invalid, returns in the View, into the asp-validation field
            if (!ModelState.IsValid) return View(studentAdded);

            StudentRepository.AddStudent(studentAdded);

            return RedirectToAction("List", "Student");
        }

        [HttpGet]
        public IActionResult Delete(int StudentId, Student student)
        {
            StudentRepository.DeleteStudent(StudentId);

            return RedirectToAction("List", "Student");
        }

        [HttpDelete]
        public IActionResult Delete(int StudentId)
        {
            if (StudentRepository.DeleteStudent(StudentId)) return Ok();

            return NotFound();
        }
    }
}
