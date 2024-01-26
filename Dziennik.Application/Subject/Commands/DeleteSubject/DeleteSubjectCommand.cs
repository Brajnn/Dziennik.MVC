using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Commands.DeleteSubject
{
    public class DeleteSubjectCommand:IRequest
    {
        public int SubjectId { get; set; }
    }
}
