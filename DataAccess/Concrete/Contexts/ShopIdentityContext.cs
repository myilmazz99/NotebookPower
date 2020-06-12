using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;

namespace DataAccess.Concrete.Contexts
{
    public class ShopIdentityContext : IdentityDbContext<ApplicationUser>
    {
        public ShopIdentityContext(DbContextOptions<ShopIdentityContext> options) : base(options)
        {

        }
    }
}
