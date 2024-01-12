﻿
using AutoMapper;
using Dziennik.Application.Mark.Commands;
using Dziennik.Application.Mark.Queries.GetMark;
using Dziennik.Application.Student;
using Dziennik.Application.Student.Commands.CreateStudent;
using Dziennik.Application.Student.Commands.EditStudent;
using Dziennik.Application.Student.Queries.GetAllStudents;
using Dziennik.Application.Student.Queries.GetStudentById;
using Dziennik.Domain.Entities;
using Dziennik.MVC.Extensions;
using Dziennik.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Dziennik.MVC.Controllers
{
    public class StudentController:Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapepr;

        public StudentController(IMediator mediator, IMapper mapepr)
        {
            _mediator = mediator;
            _mapepr=mapepr;
        }

        public async Task<ActionResult> Index(string searchPhrase) //main student page
        {
            var students = await _mediator.Send(new GetAllStudentsQuery { SearchPhrase=searchPhrase});
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
            this.SetNotification("success", $"Created student: {command.FirstName} {command.LastName}");


           return RedirectToAction(nameof(Index));
        }

        [Route("Student/{id}/Details")]
        public async Task<IActionResult> Details(int id)
        { 
            var dto =await _mediator.Send(new GetStudentByIdQuery(id));   
            return View(dto);
        }

        [Route("Student/{id}/Edit")]
        public async Task<IActionResult> Edit(int id)
        {
            var dto = await _mediator.Send(new GetStudentByIdQuery(id));
           
            EditStudentCommand model =_mapepr.Map<EditStudentCommand>(dto);
            
            return View(model);
        }
        [HttpPost]
        [Route("Student/{id}/Edit")]
        public async Task<IActionResult> Edit(int id,EditStudentCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Route("Student/Mark")]
        public async Task<IActionResult> AddMark(AddMarkCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _mediator.Send(command);
            return Ok();
        }
        [HttpGet]
        [Route("Student/{id}/Mark")]
        public async Task<IActionResult> GetMarks(int id)
        {
            var data = await _mediator.Send(new GetMarkQuery { Id = id });
            
            return Ok(data);
        }
    }
}
