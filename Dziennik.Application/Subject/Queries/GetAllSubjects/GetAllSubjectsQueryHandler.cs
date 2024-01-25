using AutoMapper;
using Dziennik.Application.Student.Queries.GetAllStudents;
using Dziennik.Application.Student;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Queries.GetAllSubjects
{
    public class GetAllSubjectQueryHandler : IRequestHandler<GetAllSubjectsQuery, IEnumerable<SubjectDto>>
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMapper _mapper;

        public GetAllSubjectQueryHandler(ISubjectRepository subjectRepository, IMapper mapper)
        {
            _subjectRepository = subjectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubjectDto>> Handle(GetAllSubjectsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Subject> subjects = await _subjectRepository.GetAll();

            var dtos = _mapper.Map<IEnumerable<SubjectDto>>(subjects);
            return dtos;
        }
    }
}
