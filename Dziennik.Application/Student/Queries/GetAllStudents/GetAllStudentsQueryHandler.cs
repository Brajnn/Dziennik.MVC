using AutoMapper;
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Queries.GetAllStudents
{
    
    public class GetAllStudentsQueryHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<StudentDto>>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public GetAllStudentsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository=studentRepository;
            _mapper=mapper;
        }
        public async Task<IEnumerable<StudentDto>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Student> students;
            if (!string.IsNullOrEmpty(request.SearchPhrase))
            {
                students = await _studentRepository.GetStudentsBySearchPhrase(request.SearchPhrase);
            }
            else
            {
                students = await _studentRepository.GetAll();
            }
            var dtos = _mapper.Map<IEnumerable<StudentDto>>(students);
            return dtos;
        }
    }
}
