using AutoMapper;
using Dziennik.Application.Student;
using Dziennik.Application.Student.Queries.GetAllStudents;
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Class.Queries.GetAllClasses
{
    public class GetAllClassesQueryHandler : IRequestHandler<GetAllClassesQuery, IEnumerable<ClassDto>>
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public GetAllClassesQueryHandler(IClassRepository classRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ClassDto>> Handle(GetAllClassesQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Class> classes;

            classes = await _classRepository.GetAll();
            
            var dtos = _mapper.Map<IEnumerable<ClassDto>>(classes);
            return dtos;
        }
    }
}
