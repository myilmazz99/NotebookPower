using System.Threading.Tasks;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;

namespace WebAPI.Seeds
{
    public static class IdentitySeed
    {
        public static async Task Seed(UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync("admin");

            if (user == null)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    UserName = "mfyilmaz95@gmail.com",
                    Email = "mfyilmaz95@gmail.com",
                    EmailConfirmed = true,
                    FullName = "Admin",
                    RoleName = "admin"
                };

                await userManager.CreateAsync(newUser, "Notebookpoweradmin1");
            }
        }
    }
}