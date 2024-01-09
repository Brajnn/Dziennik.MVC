using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Commands
{
    public class AddMarkCommandHandler : IRequestHandler<AddMarkCommand>
    {
        private readonly IStudentRepository _studentReopsitory;
        private readonly IMarkRepository _markRepository;

        public AddMarkCommandHandler(IStudentRepository studentReopsitory, IMarkRepository markRepository)
        {
            _studentReopsitory = studentReopsitory;
            _markRepository= markRepository;
        }
        public async Task<Unit> Handle(AddMarkCommand request, CancellationToken cancellationToken)
        {
            var student = await _studentReopsitory.GetById(request.StudentId);
            
            var mark = new Domain.Entities.Mark()
            {
                Value = request.Value,
                SubjectId= request.SubjectId,
                StudentId= request.StudentId,
                
            };
            await _markRepository.Add(mark);

            return Unit.Value;
            
        }
        
    }
}
