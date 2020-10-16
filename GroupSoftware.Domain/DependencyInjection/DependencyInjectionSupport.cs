using GroupSoftware.Domain.DependencyInjection.Configuration.ErroHandler;
using GroupSoftware.Repository.DependencyInjection;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GroupSoftware.Domain.DependencyInjection
{
    public static class DependencyInjectionSupport
    {
        public static void AddDomainDependencyInjectionSupport(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDbContext();
            services.AddCorsSupport();
            services.AddSwaggerSupport();
            services.AddHttpContextAccessor();
            services.AddMediatR(Assembly.GetExecutingAssembly());

        }

        public static void UseDomainDependencyInjectionSupport(this IApplicationBuilder app)
        {
            app.UseCorsSupport();
            app.UseSwaggerSupport();
            app.UseMiddleware(typeof(ErroHandlerSupport));
        }
    }
}
