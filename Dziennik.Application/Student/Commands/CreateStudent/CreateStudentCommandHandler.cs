using AutoMapper;
using Dziennik.Domain.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Commands.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand>
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository=studentRepository;
        }

        public async Task<Unit> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = _mapper.Map<Domain.Entities.Student>(request);
            await _studentRepository.Create(student);

            return Unit.Value;
        }
    }
}
