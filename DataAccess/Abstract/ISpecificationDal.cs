using Core.DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ISpecificationDal : IEntityRepository<Specification>
    {
        Task<IEnumerable<int>> AddOrUpdateMultiple(List<Specification> entities);
        Task RemoveSpecification(int productId, int specId);
    }
}
