using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace GroupSoftware.Domain.DependencyInjection
{
    public static class CorsSupport
    {
        private const string POLICY_NAME = "CorsPolicy";

        public static void AddCorsSupport(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(POLICY_NAME,
                   builder => builder.SetIsOriginAllowed(_ => true)
                   .AllowAnyMethod()
                   .AllowAnyHeader()
                   .AllowCredentials());
            });
        }

        public static void UseCorsSupport(this IApplicationBuilder app)
        {
            app.UseCors(POLICY_NAME);
        }
    }
}
