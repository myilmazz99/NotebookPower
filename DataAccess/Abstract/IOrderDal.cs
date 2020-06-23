using Core.DataAccess.Abstract;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        Task<Order> GetById(int id);
        Task<List<Order>> GetAll();
        Task<List<Order>> GetPastOrders(string userId);
    }
}
