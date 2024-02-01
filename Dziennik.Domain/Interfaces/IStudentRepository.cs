using Dziennik.Domain.Entities;

namespace Dziennik.Domain.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Student student);
        Task<IEnumerable<Student>> GetAll();
        Task<Student> GetById(int Id);
        Task<IEnumerable<Student>> GetStudentsBySearchPhrase(string searchPhrase);
        Task<List<Student>> GetStudentsByClassId(int classId);
        Task Delete(int id);
        Task Commit();
    }
}
