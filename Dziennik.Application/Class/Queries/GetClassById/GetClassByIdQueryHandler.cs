using AutoMapper;
using Dziennik.Application.Class.Queries.GetAllClasses;
using Dziennik.Application.Student;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Class.Queries.GetClassById
{
    public class GetClassByIdQueryHandler:IRequestHandler<GetClassByIdQuery, ClassDto>
    {
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;
        private readonly IStudentRepository _studentRepository;

        public GetClassByIdQueryHandler(IClassRepository classRepository, IStudentRepository studentRepository, IMapper mapper)
        {
            _classRepository = classRepository;
            _mapper = mapper;
            _studentRepository = studentRepository;
        }

        public async Task<ClassDto> Handle(GetClassByIdQuery request, CancellationToken cancellationToken)
        {
            var classEntity= await _classRepository.GetById(request.ClassId);
            var students= await _studentRepository.GetStudentsByClassId(request.ClassId);

            var classDto = _mapper.Map<ClassDto>(classEntity);
            classDto.Students = _mapper.Map<List<StudentDto>>(students);
            return classDto;
        }
    }
}
