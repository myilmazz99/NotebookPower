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
using Microsoft.Data.SqlClient;
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

            services.AddCors();

            var emailConfiguration = Configuration.GetSection("EmailConfiguration").Get<EmailConfiguration>();
            services.AddSingleton(emailConfiguration);

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<JWTTokenOptions>();
            services.ConfigureJwt(tokenOptions);

            services.AddDbContext<ShopIdentityContext>(opt => opt.UseSqlServer(new SqlConnectionStringBuilder
            {
                UserID = "sqlserver",
                Password = "Notebookpoweradmin1",
                DataSource = "34.65.36.167",
                InitialCatalog = "NotebookPowerDB",
            }.ConnectionString));
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerService logger, UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.ConfigureExceptionHandler(logger);
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors(conf => conf.SetIsOriginAllowed(x => _ = true).WithOrigins("https://myilmazz99.github.io").AllowAnyMethod().AllowAnyHeader().AllowCredentials());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            IdentitySeed.Seed(userManager, cartService).Wait();
        }
    }
}
