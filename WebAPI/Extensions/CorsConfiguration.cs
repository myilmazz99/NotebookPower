using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Extensions
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(i => i.AddPolicy("notebookpower", conf => conf.WithOrigins("https://wonderful-dune-027900103.azurestaticapps.net").AllowAnyMethod().AllowAnyHeader().AllowCredentials()));
        }

        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("notebookpower");
        }
    }
}
