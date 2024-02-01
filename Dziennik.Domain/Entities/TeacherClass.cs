using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Domain.Entities
{
    public class TeacherClass
    {
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }
    }
}
