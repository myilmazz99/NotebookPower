using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        Task<CartDto> Get(string userId);
        Task<CartDto> Create(string userId);
        Task<CartItemDto> Update(AddToCartDto dto);
        Task RemoveFromCart(RemoveFromCartDto dto);
        Task Empty(int id);
    }
}
