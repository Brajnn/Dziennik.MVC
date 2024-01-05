using FluentValidation;
using FluentValidation.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Student
{
    public class StudentDtoValidator:AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(c=> c.FirstName)
                .NotEmpty()
                .WithMessage("The field cannot be empty")
                .MinimumLength(2)
                .WithMessage("First name should have atleast 2 characters")
                .MaximumLength(40)
                .WithMessage("First name should have maximum 40 characters");
            RuleFor(c => c.LastName)
                .NotEmpty()
                .WithMessage("The field cannot be empty")
                .MinimumLength(2)
                .WithMessage("Last name should have atleast 2 characters")
                .MaximumLength(50)
                .WithMessage("Last name should have maximum 40 characters");
            RuleFor(c => c.PhoneNumber)
                .Matches(@"^\+\d{2} \d{3}-\d{3}-\d{3}$")
                .WithMessage("Invalid phone number format. Use +XX XXX-XXX-XXX format.");
            RuleFor(c => c.PostalCode)
                .MaximumLength(6)
                .WithMessage("Postal code should have maximum 6 characters"); ;

        }
    }
}
