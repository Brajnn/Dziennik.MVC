using Dziennik.Application.Student;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Queries.GetAllSubjects
{
    public class GetAllSubjectsQuery: IRequest<IEnumerable<SubjectDto>>
    {
    }
}
