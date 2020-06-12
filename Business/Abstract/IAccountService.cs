using Core.Entities.Concrete;
using Core.Security;
using Entities.Dtos;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public interface IAccountService
    {
        Task<UserDto> GetUserCredentials(string userId);
        Task<AccessToken> Login(UserDto user);
        Task Register(UserDto user);
    }
}