using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Subject.Commands.CreateSubject
{
    public class CreateSubjectCommand:SubjectDto,IRequest
    {
    }
}
