using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfOrderDal<TContext> : EfEntityRepository<Order, TContext>, IOrderDal
        where TContext : DbContext, new()
    {
        public async Task<Order> GetById(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<Order>().Include(i => i.OrderItems).FirstOrDefaultAsync(i=>i.Id == id);
            }
        }

        public async Task<List<Order>> GetAll()
        {
            using (var context = new TContext())
            {
                return await context.Set<Order>().Include(i => i.OrderItems).Include(i=>i.UserAddress).ToListAsync();
            }
        }

        public async Task<List<Order>> GetPastOrders(string userId)
        {
            using (var context = new TContext())
            {
                return await context.Set<Order>().Include(i => i.OrderItems).Where(i => i.UserId == userId).ToListAsync();
            }
        }
    }
}
