using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager)
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

                await userManager.CreateAsync(newUser, "Notebookpoweradmin1");
            }
        }
    }
}