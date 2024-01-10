using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Queries.GetMark
{
    public class GetMarkQuery:IRequest<IEnumerable<MarkDto>>
    {
        public int Id { get; set; } = default!;
    }
}
