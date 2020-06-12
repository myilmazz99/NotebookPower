using AutoMapper;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Abstract;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _orderDal;
        private readonly IMapper _mapper;

        public OrderManager(IOrderDal orderDal, IMapper mapper)
        {
            _orderDal = orderDal;
            _mapper = mapper;
        }

        public async Task Delete(int orderId)
        {
            await ExceptionHandler.HandleException(() => _orderDal.DeleteAsync(orderId));
        }

        public async Task<List<OrderDto>> GetAll()
        {
            return await ExceptionHandler.HandleExceptionWithData<List<OrderDto>>(async () =>
            {
                var entities = await _orderDal.GetAll();
                return _mapper.Map<List<OrderDto>>(entities);
            });
        }

        public async Task<OrderDto> GetById(int orderId)
        {
            return await ExceptionHandler.HandleExceptionWithData<OrderDto>(async () =>
            {
                var entity = await _orderDal.GetById(orderId);
                return _mapper.Map<OrderDto>(entity);
            });
        }
    }
}
