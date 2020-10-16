using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace GroupSoftware.Domain.DependencyInjection
{
    public static class SwaggerSupport
    {
        public static void AddSwaggerSupport(this IServiceCollection services) 
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ECommerce",
                        Version = "1.0.0",
                        Description = "API de vendas para o e-commerce da Big Corp S/A.",
                        
                    });
            });
        }

        public static void UseSwaggerSupport(this IApplicationBuilder app)
        {
            app.UseSwagger(c =>
            {
                c.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(options => options
               .SwaggerEndpoint("/swagger/v1/swagger.json", "ECommerce API v1"));
        }
    }
}
