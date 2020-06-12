using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Business.Concrete;
using Business.Utilities;
using Core.Entities.Concrete;
using Core.Security;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using DataAccess.Concrete.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Extensions;

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

            services.AddCors(i => i.AddPolicy("notebookpower", conf => conf.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

            services.AddSingleton<IProductDal, EfProductDal<ShopContext>>();
            services.AddSingleton<IProductService, ProductManager>();

            services.AddSingleton<ICategoryDal, EfCategoryDal>();
            services.AddSingleton<ICategoryService, CategoryManager>();

            services.AddSingleton<ISpecificationDal, EfSpecificationDal<ShopContext>>();
            services.AddSingleton<ISpecificationService, SpecificationManager>();

            services.AddSingleton<IOrderDal, EfOrderDal<ShopContext>>();
            services.AddSingleton<IOrderService, OrderManager>();

            services.AddSingleton<ICartDal, EfCartDal<ShopContext>>();
            services.AddSingleton<ICartService, CartManager>();

            services.AddTransient<IAccountService, AccountManager>();
            services.AddSingleton<JwtHelper>();

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<JWTTokenOptions>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuer = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddDbContext<ShopIdentityContext>(opt => opt.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB; Database=NotebookPowerDB; integrated security=true"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ShopIdentityContext>().AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.SignIn.RequireConfirmedEmail = true;
                opt.Lockout.MaxFailedAccessAttempts = 3;
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(30);
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
            }

            app.ConfigureExceptionHandler();

            app.UseCors("notebookpower");

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
