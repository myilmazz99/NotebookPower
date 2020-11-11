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
        public async Task<int> Create(Product entity)
        {
            using (var context = new TContext())
                using (var transaction = await context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        await context.Set<Product>().AddAsync(entity);
                        await context.SaveChangesAsync();
                        
                        await transaction.CommitAsync();

                        return entity.Id;
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        throw ex;
                    }
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

        public async Task<List<Product>> GetBestSeller()
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .OrderByDescending(i => i.OrderCount).Take(5)
                    .Include(i => i.Category)
                    .Include(i => i.Comments)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Product>> GetDailyDeals()
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .OrderByDescending(i => i.OldPrice - i.NewPrice).Take(5)
                    .Include(i => i.Category)
                    .Include(i => i.Comments)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .AsNoTracking().ToListAsync();
            }
        }

        public async Task<List<Product>> GetSimiliar(int categoryId)
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>()
                    .Where(i => i.CategoryId == categoryId).Take(5)
                    .Include(i => i.Category)
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
                    .Include(i => i.Comments)
                    .AsNoTracking().FirstOrDefaultAsync();
            }
        }

        public async Task<List<Product>> GetAllWithIncludes()
        {
            using (var context = new TContext())
            {
                return await context.Set<Product>().Include(i => i.Category)
                    .Include(i => i.ProductImages)
                    .Include(i => i.ProductSpecifications)
                    .ThenInclude(i => i.Specification)
                    .Include(i=>i.Comments).ToListAsync();
            }
        }

        public async Task Update(Product product, IEnumerable<int> specIds)
        {
            using (var context = new TContext())
            {
                var entity = await context.Set<Product>().Include(i => i.ProductSpecifications).FirstOrDefaultAsync(i => i.Id == product.Id);

                if (entity != null)
                {
                    foreach (var id in specIds)
                    {
                        if (entity.ProductSpecifications.Find(i => i.ProductId == product.Id && i.SpecificationId == id) == null)
                            entity.ProductSpecifications.Add(new ProductSpecification { ProductId = product.Id, SpecificationId = id });
                    }

                    entity.CategoryId = product.CategoryId;
                    entity.NewPrice = product.NewPrice;
                    entity.OldPrice = product.OldPrice;
                    entity.ProductDescription = product.ProductDescription;
                    entity.ProductName = product.ProductName;
                    entity.Stock = product.Stock;

                    await context.SaveChangesAsync();
                }

            }
        }
    }
}
