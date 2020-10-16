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
    public class EfFavoriteDal<TContext> : EfEntityRepository<Favorite, TContext>, IFavoriteDal
        where TContext : DbContext, new()
    {
        public async Task<Favorite> AddAsync(string userId, int productId)
        {
            using (var context = new TContext())
            {
                var fav = new Favorite { ProductId = productId, UserId = userId };
                await context.Set<Favorite>().AddAsync(fav);
                await context.SaveChangesAsync();
                return await context.Set<Favorite>().Include(i => i.Product).ThenInclude(i => i.ProductImages).FirstOrDefaultAsync(i => i.Id == fav.Id);

            }
        }

        public async Task<List<Favorite>> GetAllWithProducts(Expression<Func<Favorite, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return await context.Set<Favorite>().Where(filter).Include(i => i.Product).ThenInclude(i => i.ProductImages).ToListAsync();
            }
        }
    }
}
