using Mechsoft_Project.Application.Interfaces.Repositories;
using Mechsoft_Project.Persistence.Contexts;
using Mechsoft_Project.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Persistence
{
    public static class ServiceRegistration
    {
        // Burası bizim IoC konteynırımızdır.
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MeetingDbContext>(conf =>
            {
                var connStr = configuration.GetConnectionString("SqlConnection");
                conf.UseSqlServer(connStr, opt =>
                {
                    opt.EnableRetryOnFailure();
                });
            });

            services.AddScoped<IMeetingRepository, MeetingRepository>();
        }
    }
}
