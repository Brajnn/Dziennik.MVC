using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student.Queries.GetStudentById
{
    public class GetStudentByIdQuery: IRequest<StudentDto>
    {
        public int StudentId { get; set; }
        public GetStudentByIdQuery(int id)
        {
            StudentId = id;
        }
    }
}
