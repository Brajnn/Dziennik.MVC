﻿using Dziennik.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Domain.Interfaces
{
    public interface IMarkRepository
    {
        Task Add(Mark mark);
        Task<IEnumerable<Mark>> GetAllById(int id);
    }
}
