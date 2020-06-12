using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Concrete
{
    public class EfEntityRepository<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity
        where TContext : DbContext, new()
    {
        public virtual async Task AddAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
               await context.Set<TEntity>().AddAsync(entity);
               await context.SaveChangesAsync();
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            using (var context = new TContext())
            {
                var entity = await context.Set<TEntity>().FindAsync(id);
                context.Set<TEntity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return await context.Set<TEntity>().FirstOrDefaultAsync(filter);
            }
        }

        public virtual async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null ? 
                    await context.Set<TEntity>().ToListAsync() 
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            using (var context = new TContext())
            {
                context.Set<TEntity>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
