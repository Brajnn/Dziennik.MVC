using AutoMapper;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Queries.GetAllStudents
{
    
    public class GatAllStudentsQueryHandler : IRequestHandler<GatAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GatAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository=studentRepository;
            _mapper=mapper;
        }
        public async Task<IEnumerable<StudentDto>> Handle(GatAllStudentsQuery request, CancellationToken cancellationToken)
        {
            var students = await _studentRepository.GetAll();
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return dtos;
        }
    }
}
