using AutoMapper;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Commands.CreateSubject
{
    public class CreateSubjectCommandHandler:IRequestHandler<CreateSubjectCommand>
    {
        private readonly IMapper _mapper;
        private readonly ISubjectRepository _subjectRepository;

        public CreateSubjectCommandHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _mapper = mapper;
            _subjectRepository = subjectRepository;
        }

        public async Task<Unit> Handle(CreateSubjectCommand request, CancellationToken cancellationToken)
        {
            var subject = _mapper.Map<Domain.Entities.Subject>(request);
            await _subjectRepository.Create(subject);

            return Unit.Value;
        }
    }
}
