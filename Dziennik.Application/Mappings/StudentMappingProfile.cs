using AutoMapper;
using Dziennik.Application.Student;
using Dziennik.Application.Student.Commands.EditStudent;


namespace Dziennik.Application.Mappings
{
    public class StudentMappingProfile :Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentDto, Dziennik.Domain.Entities.Student>();

            CreateMap<Dziennik.Domain.Entities.Student,StudentDto > ();
            CreateMap<StudentDto, EditStudentCommand>();
        }
    }
}
