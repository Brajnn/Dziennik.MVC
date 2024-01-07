
using Dziennik.Application.Student;
using Dziennik.Application.Student.Commands.CreateStudent;
using Dziennik.Application.Student.Queries.GetAllStudents;
using Dziennik.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik.MVC.Controllers
{
    public class StudentController:Controller
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<ActionResult> Index() //main student page
        {
            var students = await _mediator.Send(new GatAllStudentsQuery());
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            if(!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index)); //TODO: refactor
        }
    }
}
