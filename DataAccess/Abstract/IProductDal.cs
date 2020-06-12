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
        Task<int> Create(Product entity, IEnumerable<int> specIds);
        Task<Product> GetById(int id);
        Task<List<Product>> Get10BestSeller();
        Task<List<Product>> Get10Latest();
        Task AddImages(List<ProductImage> images);
    }
}
