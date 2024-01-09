using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Commands
{
    public class AddMarkCommand:MarkDto,IRequest
    {
        public int StudentId { get; set; } = default!;
    }
}
