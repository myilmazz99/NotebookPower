using Core.DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {
        Task<int> Create(Product entity);
        Task<Product> GetById(int id);
        Task<List<Product>> GetBestSeller();
        Task<List<Product>> GetDailyDeals();
        Task AddImages(List<ProductImage> images);
        Task<List<Product>> GetAllWithIncludes();
        Task<List<Product>> GetSimiliar(int categoryId);
        Task Update(Product product, IEnumerable<int> specIds);
    }
}
