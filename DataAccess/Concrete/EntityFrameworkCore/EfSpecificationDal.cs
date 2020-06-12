using Core.DataAccess.Concrete;
using DataAccess.Abstract;
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
        public async Task<IEnumerable<int>> AddMultiple(List<Specification> entities)
        {
            using (var context = new TContext())
            {
                await context.Set<Specification>().AddRangeAsync(entities);
                await context.SaveChangesAsync();

                var specIds =  entities.Select(i=> i.Id ) ;

                return specIds;
            }
        }
    }
}
