using Dziennik.Application.Teacher.Queries.GetAllTeachers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik.MVC.Controllers
{
    public class TeacherController:Controller
    {
        private readonly IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllTeachersQuery ();
            var teachers = await _mediator.Send(query);

            return View(teachers);
        }

    }
}
