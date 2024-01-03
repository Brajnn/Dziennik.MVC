using AutoMapper;
using Dziennik.Application.Student;
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Services
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository, IMapper mapper)
        {
            _mapper = mapper;
            _studentRepository = studentRepository;
        }
        public async Task Create(StudentDto studentDto)
        {
            var student = _mapper.Map<Domain.Entities.Student>(studentDto);
            await _studentRepository.Create(student);
        }
    }
}
