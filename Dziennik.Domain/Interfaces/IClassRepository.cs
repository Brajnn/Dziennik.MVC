using Dziennik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Domain.Interfaces
{
    public interface IClassRepository
    {
        Task<IEnumerable<Class>> GetAll();
        Task<Class> GetById(int Id);
        Task<string> GetClassNameById(int classId);
    }
}
