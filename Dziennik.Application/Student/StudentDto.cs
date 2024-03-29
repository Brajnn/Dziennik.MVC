﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = default!;

        public string LastName { get; set; }= default!;
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
        public int ClassId { get; set; }
        public string? ClassName { get; set; }
    }
}
