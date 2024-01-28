using Dziennik.Application.Student.Commands.CreateStudent;
using Dziennik.Application.Student.Commands.DeleteStudent;
using Dziennik.Application.Subject.Commands.CreateSubject;
using Dziennik.Application.Subject.Commands.DeleteSubject;
using Dziennik.Application.Subject.Queries.GetAllSubjects;
using Dziennik.MVC.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Dziennik.MVC.Controllers
{
    public class SubjectController:Controller
    {
        private readonly IMediator _mediator;

        public SubjectController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var query = new GetAllSubjectsQuery();
            var subjects = await _mediator.Send(query);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
            {
                return Json(subjects);
            }

            ViewBag.SubjectsList = subjects;
            return View(subjects);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {

            var command = new DeleteSubjectCommand { SubjectId = id };
            await _mediator.Send(command);

            return RedirectToAction(nameof(Index));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSubjectCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            this.SetNotification("success", $"Created Subject: {command.Name}");


            return RedirectToAction(nameof(Index));
        }
    }
}
