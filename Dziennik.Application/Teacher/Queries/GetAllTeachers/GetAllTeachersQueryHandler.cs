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

namespace Dziennik.Application.Teacher.Queries.GetAllTeachers
{
    public class GetAllTeachersQueryHandler : IRequestHandler<GetAllTeachersQuery, IEnumerable<TeacherDto>>
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public GetAllTeachersQueryHandler(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TeacherDto>> Handle(GetAllTeachersQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Entities.Teacher> teachers;

            teachers = await _teacherRepository.GetAll();
            
            var dtos = _mapper.Map<IEnumerable<TeacherDto>>(teachers);
            return dtos;
        }
    }
}
