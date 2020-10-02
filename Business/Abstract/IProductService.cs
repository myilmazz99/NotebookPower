using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProductService
    {
        Task<ProductDto> Add(ProductDto entity, IEnumerable<int> specIds);
        Task<ProductDto> GetById(int id);
        Task AddImages(List<ProductImageDto> images);
        Task<List<ProductDto>> GetAllWithIncludes();
        Task<List<ProductDto>> GetBestSeller();
        Task<List<ProductDto>> GetDailyDeals();
        Task<List<ProductDto>> GetSimiliar(int categoryId);
        Task<ProductDto> Update(ProductDto dto, IEnumerable<int> specIds);
        Task Delete(int id);
    }
}
