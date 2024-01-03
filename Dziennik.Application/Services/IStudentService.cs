using Dziennik.Application.Student;
using Dziennik.Domain.Entities;

namespace Dziennik.Application.Services
{
    public interface IStudentService
    {
        Task Create(StudentDto student);
    }
}