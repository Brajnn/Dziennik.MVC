using Dziennik.Application.Services;
using Dziennik.Application.Student;
using Dziennik.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik.MVC.Controllers
{
    public class StudentController:Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService=studentService;
        }

        public async Task<ActionResult> Index() //main student page
        {
            var students = await _studentService.GetAll();
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(StudentDto student)
        {
            if(!ModelState.IsValid)
            {
                return View();
            }

            await _studentService.Create(student);
            return RedirectToAction(nameof(Create)); //TODO: refactor
        }
    }
}
