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
    public class ClassRepository:IClassRepository
    {
        private readonly SchoolDbContext _dbContext;

        public ClassRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Class>> GetAll()
        {
            return await _dbContext.Classes.ToListAsync();
        }

        public async Task<Class> GetById(int Id) =>
         await _dbContext.Classes.FirstOrDefaultAsync(c=> c.ClassId == Id);
        public async Task<string> GetClassNameById(int classId)
        {
            var className = await _dbContext.Classes
            .Where(c => c.ClassId == classId)
            .Select(c => c.ClassName)
            .FirstOrDefaultAsync();

            return className;
        }

    }
}
