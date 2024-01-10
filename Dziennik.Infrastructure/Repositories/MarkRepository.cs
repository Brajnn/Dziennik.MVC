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
    public class MarkRepository:IMarkRepository
    {
        private readonly SchoolDbContext _dbContext;

        public MarkRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task Add(Mark mark)
        {
            _dbContext.Marks.Add(mark);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mark>> GetAllById(int id) =>
           await _dbContext.Marks.Where(s => s.StudentId == id).ToListAsync();

    }
}
