using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Queries.GetAllStudents
{
    public class GatAllStudentsQuery : IRequest<IEnumerable<StudentDto>>
    {

    }
}
