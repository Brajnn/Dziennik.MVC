using Dziennik.Domain.Entities;

namespace Dziennik.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int Id);
        Task<IEnumerable<Student>> GetStudentsBySearchPhrase(string searchPhrase);
        Task Delete(int id);
        Task Commit();
    }
}
