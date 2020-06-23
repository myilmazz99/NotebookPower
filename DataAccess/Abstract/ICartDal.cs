using Core.DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        Task<Cart> GetByUserId(string userId);
        Task<CartItem> Update(AddToCartDto dto);
        Task RemoveFromCart(RemoveFromCartDto dto);
    }
}
