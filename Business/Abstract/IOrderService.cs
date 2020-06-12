﻿using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Task<OrderDto> GetById(int orderId);
        Task<List<OrderDto>> GetAll();
        Task Delete(int orderId);
    }
}
