﻿using AutoMapper;
using Dziennik.Application.Class;
using Dziennik.Application.Mark;
using Dziennik.Application.Student;
using Dziennik.Application.Student.Commands.EditStudent;
using Dziennik.Application.Subject;
using Dziennik.Application.Teacher;


namespace Dziennik.Application.Mappings
{
    public class StudentMappingProfile :Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentDto, Dziennik.Domain.Entities.Student>();

            CreateMap<Dziennik.Domain.Entities.Student,StudentDto > ();
            CreateMap<StudentDto, EditStudentCommand>();
            CreateMap<MarkDto, Domain.Entities.Mark>()
                .ReverseMap();
            CreateMap<SubjectDto, Domain.Entities.Subject>()
                .ReverseMap();
            CreateMap<ClassDto, Domain.Entities.Class>()
                .ForMember(dest => dest.Students, opt => opt.MapFrom(src => src.Students))
                 .ReverseMap();
            CreateMap<TeacherDto, Domain.Entities.Teacher>().ReverseMap();
        }
    }
}
