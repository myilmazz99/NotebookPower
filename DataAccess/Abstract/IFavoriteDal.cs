using Core.DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFavoriteDal : IEntityRepository<Favorite>
    {
        Task<List<Favorite>> GetAllWithProducts(Expression<Func<Favorite, bool>> filter = null);
        Task<Favorite> AddAsync(string userId, int productId);
    }
}
