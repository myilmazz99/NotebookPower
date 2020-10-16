using System.Threading.Tasks;
using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager, ICartService cartService)
        {
            var user = await userManager.FindByNameAsync("admin@notebookpower.com");

            if (user == null)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    UserName = "admin@notebookpower.com",
                    Email = "admin@notebookpower.com",
                    EmailConfirmed = true,
                    FullName = "Admin",
                    RoleName = "admin"
                };

                var result = await userManager.CreateAsync(newUser, "Notebookpoweradmin1");
                if (result.Succeeded)
                {
                    var admin = await userManager.FindByEmailAsync("admin@notebookpower.com");
                    await cartService.Create(admin.Id);
                }
            }
        }
    }
}