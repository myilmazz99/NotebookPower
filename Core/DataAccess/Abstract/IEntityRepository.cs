using Core.Business.Results;
using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.Abstract
{
    public interface IEntityRepository<T> where T : IEntity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> Get(Expression<Func<T, bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
