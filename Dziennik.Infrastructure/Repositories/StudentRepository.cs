
using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using Dziennik.Infrastructure.Presistence;
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
        public async Task Create(Student student)
        {
            _dbContext.Add(student);
            await _dbContext.SaveChangesAsync();
        }
    }
}
