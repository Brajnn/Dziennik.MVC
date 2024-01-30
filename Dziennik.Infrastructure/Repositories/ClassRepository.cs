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
    }
}
