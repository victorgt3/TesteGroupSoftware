using GroupSoftware.Repository.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GroupSoftware.Repository.DependencyInjection
{
    public static class DependencyInjectionSupport
    {
        public static void AddApplicationDbContext(this IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(GetConnectionStrig());
            });

            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        }

        public static string GetConnectionStrig()
        {
            return Environment.GetEnvironmentVariable("CONNECTION_STRING");
        }

        public static void ConfigureOptionsBuilder(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-VB31P81;Initial Catalog=groupdb;Trusted_Connection=True;");
            }
        }
    }
}
