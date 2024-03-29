﻿using AutoMapper;
using Dziennik.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Queries.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IClassRepository _classRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IStudentRepository studentRepository, IClassRepository classRepository, IMapper mapper)
        {
            _studentRepository=studentRepository;
            _classRepository = classRepository;
            _mapper = mapper;
        }
        public async Task<StudentDto> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var student= await _studentRepository.GetById(request.StudentId);
            var className = await _classRepository.GetClassNameById(student.ClassId);
            var studentDto = _mapper.Map<StudentDto>(student);
            studentDto.ClassName = className;
            return studentDto;

        }
    }
}
