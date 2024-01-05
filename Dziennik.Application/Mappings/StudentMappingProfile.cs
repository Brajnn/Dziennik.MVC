using AutoMapper;
using Dziennik.Application.Student;


namespace Dziennik.Application.Mappings
{
    public class StudentMappingProfile :Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<StudentDto, Dziennik.Domain.Entities.Student>();

            CreateMap<Dziennik.Domain.Entities.Student,StudentDto > ();

        }
    }
}
