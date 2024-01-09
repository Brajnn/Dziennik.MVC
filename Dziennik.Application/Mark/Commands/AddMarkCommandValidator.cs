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
            RuleFor(s => s.Value).NotEmpty().NotNull();
            RuleFor(s => s.SubjectId).NotEmpty().NotNull();
        }
    }
}
