using Entities.Dtos;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IAccountDal
    {
        Task Add(UserDto user);
        Task Update(UserDto user);
        Task Delete(string userId);
        Task<IdentityUser> GetById(string userId);
        Task<List<IdentityUser>> GetAll();
    }
}
