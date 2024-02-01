using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Teacher.Queries.GetAllTeachers
{
    public class GetAllTeachersQuery:IRequest<IEnumerable<TeacherDto>>
    {
    }
}
