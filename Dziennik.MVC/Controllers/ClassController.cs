using Dziennik.Application.Class.Queries.GetAllClasses;
using Dziennik.Application.Subject.Commands.CreateSubject;
using Dziennik.Application.Subject.Commands.DeleteSubject;
using Dziennik.Application.Subject.Queries.GetAllSubjects;
using Dziennik.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Dziennik.MVC.Controllers
{
    public class ClassController : Controller
    {
        private readonly IMediator _mediator;

        public ClassController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllClassesQuery();
            var classes = await _mediator.Send(query);

            return View(classes);
        }

    }
}
