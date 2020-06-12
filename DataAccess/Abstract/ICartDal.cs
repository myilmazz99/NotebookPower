using Core.DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICartDal : IEntityRepository<Cart>
    {
        Task<Cart> GetById(int id);
    }
}
