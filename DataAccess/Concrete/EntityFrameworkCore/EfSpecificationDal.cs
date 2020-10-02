using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfSpecificationDal<TContext> : EfEntityRepository<Specification, TContext>, ISpecificationDal
        where TContext : DbContext, new()
    {
        public async Task<IEnumerable<int>> AddOrUpdateMultiple(List<Specification> entities)
        {
            var existingIds = new List<int>();
            var newItemCount = 0;

            using var context = new TContext();
            var specifications = context.Set<Specification>().AsQueryable();

            foreach (var entity in entities)
            {
                var specification = specifications.FirstOrDefault(i => i.SpecificationName == entity.SpecificationName && i.SpecificationValue == entity.SpecificationValue);

                if (specification != null)
                {
                    existingIds.Add(specification.Id);
                }
                else
                {
                    context.Set<Specification>().Add(new Specification { SpecificationName = entity.SpecificationName, SpecificationValue = entity.SpecificationValue });
                    newItemCount++;

                    await context.SaveChangesAsync();

                    existingIds.AddRange(specifications.OrderByDescending(i => i.Id).Take(newItemCount).Select(i => i.Id));
                }
            }

            return existingIds;
        }

        public async Task RemoveSpecification(int productId, int specId)
        {
            using (var context = new TContext())
            {
                var rowToDelete = await context.Set<ProductSpecification>().FirstOrDefaultAsync(i => i.ProductId == productId && i.SpecificationId == specId);
                context.Set<ProductSpecification>().Remove(rowToDelete);
                await context.SaveChangesAsync();
            }
        }
    }
}
