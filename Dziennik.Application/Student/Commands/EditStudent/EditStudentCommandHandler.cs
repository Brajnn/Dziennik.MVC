using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Commands.EditStudent
{
    public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand>
    {
        private IStudentRepository _repository;

        public EditStudentCommandHandler(IStudentRepository repository)
        {
            _repository = repository;
        }
        public async Task<Unit> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            
            var student = await _repository.GetById(request.StudentId);
            student.StudentId = request.StudentId;
            student.FirstName = request.FirstName;
            student.LastName = request.LastName; 
            student.Email = request.Email;
            student.PhoneNumber = request.PhoneNumber;
            student.City = request.City;
            student.Street = request.Street;
            student.PostalCode = request.PostalCode;
            await _repository.Commit();
            return Unit.Value;
        }
    }
}
