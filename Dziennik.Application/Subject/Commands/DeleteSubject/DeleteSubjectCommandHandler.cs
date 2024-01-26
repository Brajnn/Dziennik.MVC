using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Commands.DeleteSubject
{
    public class DeleteSubjectCommandHandler:IRequestHandler<DeleteSubjectCommand>
    {
        private readonly ISubjectRepository _subjectRepository;

        public DeleteSubjectCommandHandler(ISubjectRepository subjectRepository)
        {

            _subjectRepository = subjectRepository;
        }

        public async Task<Unit> Handle(DeleteSubjectCommand request, CancellationToken cancellationToken)
        {
            await _subjectRepository.Delete(request.SubjectId);
            return Unit.Value;
        }
    }
}
