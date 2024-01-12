
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using Dziennik.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _dbContext;

        public StudentRepository(SchoolDbContext dbContext)
        {
            _dbContext=dbContext;
        }

        public async Task Commit()
        =>await _dbContext.SaveChangesAsync();

        public async Task Create(Student student)
        {
            _dbContext.Add(student);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAll()
        => await _dbContext.Students.ToListAsync();

        public async Task<Student> GetById(int Id) =>
            await _dbContext.Students.FirstOrDefaultAsync(c => c.StudentId == Id);

        public async Task<IEnumerable<Student>> GetStudentsBySearchPhrase(string searchPhrase)
        {          
            return await _dbContext.Students
                .Where(student => student.FirstName.ToLower().Contains(searchPhrase.ToLower()) 
                                || student.LastName.ToLower().Contains(searchPhrase.ToLower()))
                .ToListAsync();
        }
    }
}
