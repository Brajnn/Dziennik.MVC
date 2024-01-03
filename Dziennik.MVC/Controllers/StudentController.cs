using Dziennik.Application.Services;
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
        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _studentService.Create(student);
            return RedirectToAction(nameof(Create)); //TODO: refactor
        }
    }
}
