using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Mark.Commands
{
    public class AddMarkCommandValidator:AbstractValidator<AddMarkCommand>
    {
        public AddMarkCommandValidator()
        {
            RuleFor(s => s.Value)
               .NotEmpty().WithMessage("The Value field is required.")
               .GreaterThanOrEqualTo(1).WithMessage("The Value must be greater than or equal to 1.")
               .LessThanOrEqualTo(6).WithMessage("The Value must be less than or equal to 6.");

        }
    }
}
