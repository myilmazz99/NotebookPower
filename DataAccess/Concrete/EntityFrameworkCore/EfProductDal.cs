using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Contexts;
using Entities;
using Entities.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFrameworkCore
{
    public class EfProductDal<TContext> : EfEntityRepository<Product, ShopContext>, IProductDal
        where TContext : DbContext, new()
    {
        public async Task<int> Create(Product entity, IEnumerable<int> specIds)
        {
            using (var context = new TContext())
            {
                entity.ProductSpecifications = specIds.Select(i => new ProductSpecification { ProductId = entity.Id, SpecificationId = i }).ToList();
                await context.Set<Product>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity.Id;
            }
        }

        public async Task AddImages(List<ProductImage> images)
        {
            using (var context = new TContext())
            {
                await context.Set<ProductImage>().AddRangeAsync(images);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> Get10BestSeller()
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .OrderByDescending(i => i.OrderCount).Take(10)
                    .Include(i => i.Comments)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Product>> Get10Latest()
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .OrderByDescending(i => i.DateAdded).Take(10)
                    .Include(i => i.Comments)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<Product> GetById(int id)
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .Where(i => i.Id == id).Include(i => i.Comments)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .AsNoTracking().FirstOrDefaultAsync();
            }
        }
    }
}
