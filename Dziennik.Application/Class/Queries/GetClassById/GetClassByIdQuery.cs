using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Class.Queries.GetClassById
{
    public class GetClassByIdQuery:IRequest<ClassDto>
    {
        public int ClassId { get; set; }
        public GetClassByIdQuery(int id)
        {
            ClassId= id;
        }
    }
}
