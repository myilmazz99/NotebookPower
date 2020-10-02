using Core.Entities.Concrete;
using Core.Security;
using Entities;
using Entities.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public interface IAccountService
    {
        Task<UserDto> GetUserCredentials(string userId);
        Task<List<FavoriteDto>> GetFavoriteProducts(string userId);
        Task<AccessToken> Login(LoginDto user);
        Task<AccessToken> Register(UserDto user);
        Task ConfirmEmail(string id, string token);
        Task<FavoriteDto> AddToFavorite(string userId, int productId);
        Task RemoveFromFavorite(string userId, int productId);
    }
}