using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Services;
using Business.Utilities;
using Business.Utilities.Nlog;
using Core.Entities.Concrete;
using Core.Security;
using Core.Security.Constants;
using DataAccess.Concrete.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebAPI.Extensions;
using WebAPI.Seeds;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddCorsConfig();

            var emailConfiguration = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfiguration);

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<JWTTokenOptions>();
            services.ConfigureJwt(tokenOptions);

            services.AddDbContext<ShopIdentityContext>(opt => opt.UseSqlServer(@"Server=tcp:notebookpower.database.windows.net,1433;Initial Catalog=notebookpower;Persist Security Info=False;User ID=admin_notebookpower;Password=Notmusti230395;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ShopIdentityContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = false;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
                opt.Password.RequireNonAlphanumeric = false;
            });

            services.AddAuthorization(opt =>
            {
                opt.AddPolicy(PolicyConstants.ADMIN, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
                opt.AddPolicy(PolicyConstants.USER, policy =>
                {
                    policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
                    policy.RequireClaim(ClaimTypes.Role, "user", "admin");
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService logger, UserManager<ApplicationUser> userManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.ConfigureExceptionHandler(logger);

            app.UseCorsConfig();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            IdentitySeed.Seed(userManager).Wait();
        }
    }
}
