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
    public class SubjectRepository:ISubjectRepository
    {
        private readonly SchoolDbContext _dbContext;

        public SubjectRepository(SchoolDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Subject>> GetAll()
        {
            return await _dbContext.Subjects.ToListAsync();
        }

        public async Task<IEnumerable<Subject>> GetSubjectsByIds(IEnumerable<int> subjectIds)
        {
            return await _dbContext.Subjects.Where(subject => subjectIds.Contains(subject.SubjectId)).ToListAsync();
        }
    }
}
