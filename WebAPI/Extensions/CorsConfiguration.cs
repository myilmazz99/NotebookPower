using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Extensions
{
    public static class CorsConfiguration
    {
        public static void AddCorsConfig(this IServiceCollection services)
        {
            services.AddCors(i => i.AddPolicy("notebookpower", conf => conf.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));
        }

        public static void UseCorsConfig(this IApplicationBuilder app)
        {
            app.UseCors("notebookpower");
        }
    }
}
