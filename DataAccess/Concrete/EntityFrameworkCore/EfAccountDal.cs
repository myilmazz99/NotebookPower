using DataAccess.Abstract;
using DataAccess.Identity;
using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfAccountDal : IAccountDal
    {
        private UserManager<IdentityUser> userManager;

        public EfAccountDal(UserManager<IdentityUser> _userManager)
        {
            userManager = _userManager;
        }

        public async Task Add(UserDto user)
        {
            //await userManager.CreateAsync(new ApplicationUser { FullName = user.FullName, Email = user.Email }, user.Password);
            throw new Exception("Eklenmedi");
        }

        public async Task Delete(string userId)
        {
            await userManager.DeleteAsync(await GetById(userId));
        }

        public async Task<IdentityUser> GetById(string userId)
        {
            return await userManager.FindByIdAsync(userId);
        }

        public async Task<List<IdentityUser>> GetAll()
        {
            return await userManager.Users.ToListAsync();
        }

        public Task Update(UserDto user)
        {
            throw new NotImplementedException();
        }
    }
}
