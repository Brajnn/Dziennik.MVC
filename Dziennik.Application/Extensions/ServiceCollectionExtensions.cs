using Dziennik.Application.Mappings;
using Dziennik.Application.Student.Commands.CreateStudent;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(CreateStudentCommand));
            services.AddAutoMapper(typeof(StudentMappingProfile));

            services.AddValidatorsFromAssemblyContaining<CreateStudentCommandValidator>()
                .AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();
        }
    }

}
