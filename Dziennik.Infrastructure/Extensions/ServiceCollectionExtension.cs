using Dziennik.Domain.Interfaces;
using Dziennik.Infrastructure.Presistence;
using Dziennik.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dziennik.Infrastructure.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuraiton)
        {
            services.AddDbContext<SchoolDbContext>(options => options.UseSqlServer(
                configuraiton.GetConnectionString("School")));

            services.AddScoped<IStudentRepository,StudentRepository>();
            
        }
        
    }
}
