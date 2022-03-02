using System;
using CRUDMVCEFV1.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CRUDMVCEFV1.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserContext>(o => o.UseSqlServer(configuration.GetConnectionString("UserContext")));
            return services;
        }

    }
}
