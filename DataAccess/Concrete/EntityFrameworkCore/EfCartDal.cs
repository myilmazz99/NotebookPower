using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfCartDal<TContext> : EfEntityRepository<Cart, TContext>, ICartDal
        where TContext : DbContext, new()
    {
        public async Task<Cart> GetById(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<Cart>().Include(i=>i.CartItems).FirstOrDefaultAsync(i => i.Id == id);
            }
        }
    }
}
