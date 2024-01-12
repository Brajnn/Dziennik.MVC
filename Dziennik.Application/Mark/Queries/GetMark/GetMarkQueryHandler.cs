using AutoMapper;
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Queries.GetMark
{
    public class GetMarkQueryHandler : IRequestHandler<GetMarkQuery, IEnumerable<MarkDto>>
    {
        private readonly IMapper _mapper;
        private readonly IMarkRepository _markRepository;
        private readonly ISubjectRepository _subjectRepository;

        public GetMarkQueryHandler(IMarkRepository markRepository, IMapper mapper, ISubjectRepository subjectRepository)
        {
            _mapper=mapper;
            _markRepository = markRepository;
            _subjectRepository = subjectRepository;
        }
        public async Task<IEnumerable<MarkDto>> Handle(GetMarkQuery request, CancellationToken cancellationToken)
        {
            var marks =await  _markRepository.GetAllById(request.Id);
            var subjectIds = marks.Select(mark => mark.SubjectId).Distinct();
            var subjects = await _subjectRepository.GetSubjectsByIds(subjectIds);

            var dtos = marks.Select(mark =>
            {
                var subject = subjects.FirstOrDefault(s => s.SubjectId == mark.SubjectId);
                return new MarkDto
                {
                    SubjectId = mark.SubjectId,
                    SubjectName = subject?.Name ?? "Unknown Subject",
                    Value = mark.Value
                };
            });

            return dtos;
            //var dtos = _mapper.Map<IEnumerable<MarkDto>>(result);

            //return dtos;
        }
    }
}
