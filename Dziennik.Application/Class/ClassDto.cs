using Dziennik.Application.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Class
{
    public class ClassDto
    {
        public int ClassId { get; set; }
        public string ClassName { get; set; } = default!;
        public List<StudentDto> Students { get; set; }
    }
}
