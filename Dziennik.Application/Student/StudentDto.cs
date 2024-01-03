using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student
{
    public class StudentDto
    {
        [Required]
        [StringLength(50,MinimumLength =2)]
        public string FirstName { get; set; } = default!;
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }= default!;
        public string? Email { get; set; }
        [StringLength(12, MinimumLength = 8)]
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
    }
}
