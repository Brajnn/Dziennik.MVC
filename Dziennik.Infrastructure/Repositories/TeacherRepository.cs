using Dziennik.Domain.Entities;
using Dziennik.Domain.Interfaces;
using Dziennik.Infrastructure.Presistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Infrastructure.Repositories
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly SchoolDbContext _dbContext;

        public TeacherRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Teacher>> GetAll()
        {
            return await _dbContext.Teachers.ToListAsync();
        }

      
    }
}
