using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<int> Add(ProductDto entity, IEnumerable<int> specIds);
        Task<ProductDto> GetById(int id);
        Task AddImages(List<ProductImageDto> images);
    }
}
