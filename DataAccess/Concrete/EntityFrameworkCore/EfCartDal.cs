﻿using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCartDal<TContext> : EfEntityRepository<Cart, TContext>, ICartDal
        where TContext : DbContext, new()
    {
        public async Task<Cart> GetByUserId(string userId)
        {
            using (var context = new TContext())
            {
                return await context.Set<Cart>().Include(i=>i.CartItems).ThenInclude(i=>i.Product).FirstOrDefaultAsync(i => i.UserId == userId);
            }
        }

        public async Task<CartItem> Update(AddToCartDto dto)
        {
            using (var context = new TContext())
            {
                var cartToUpdate = await context.Set<Cart>().FirstOrDefaultAsync(i => i.Id == dto.Id);
                var cartItem = new CartItem { ProductId = dto.ProductId, ProductQuantity = dto.Quantity };
                cartToUpdate.CartItems.Add(cartItem);
                await context.SaveChangesAsync();
                return await context.Set<CartItem>().Include(i=>i.Product).FirstOrDefaultAsync(i=>i.Id == cartItem.Id);
            }
        }

        public async Task RemoveFromCart(RemoveFromCartDto dto)
        {
            using (var context = new TContext())
            {
                var cartToRemoveFrom = await context.Set<Cart>().Include(i=>i.CartItems).FirstOrDefaultAsync(i => i.Id == dto.CartId);
                cartToRemoveFrom.CartItems = cartToRemoveFrom.CartItems.Where(i => i.Id != dto.CartItemId).ToList();
                await context.SaveChangesAsync();
            }
        }
    }
}
