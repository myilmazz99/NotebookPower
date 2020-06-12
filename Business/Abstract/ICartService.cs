using Entities;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICartService
    {
        Task<CartDto> Get(int id);
        Task Create(int userId);
        Task Update(CartDto entity);
        //Task Delete(int id);
    }
}
