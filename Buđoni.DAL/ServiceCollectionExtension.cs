using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Budjoni.DAL
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDAL(this IServiceCollection services,string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(connectionString,
                    b => b.MigrationsAssembly("Budjoni"));
                options.UseLazyLoadingProxies();
            });

            services.AddTransient<ModelObuceService>();

            return services;
        }
    }
}
