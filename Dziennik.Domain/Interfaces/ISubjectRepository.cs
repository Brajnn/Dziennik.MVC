﻿using Dziennik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Domain.Interfaces
{
    public interface ISubjectRepository
    {
        Task<IEnumerable<Subject>> GetAll();
        Task<IEnumerable<Subject>> GetSubjectsByIds(IEnumerable<int> subjectIds);
        Task<Subject> GetByName(string subjectName);
        Task Delete(int id);
        Task Create(Subject subject);
    }
}
