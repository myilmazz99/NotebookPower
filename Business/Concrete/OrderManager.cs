using AutoMapper;
using Business.Abstract;
using Business.Services.PaymentService.Iyzico;
using Core.Utilities;
using DataAccess.Abstract;
using Entities;
using Entities.Dtos;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<OrderDto> ConfirmOrder(int orderId)
        {
            return _mapper.Map<OrderDto>(await _orderDal.ConfirmOrder(orderId));
        }

        public async Task Delete(int orderId)
        {
            await _orderDal.DeleteAsync(orderId);
        }

        public async Task FulfillOrder(OrderDto dto)
        {
            //Validation

            dto.OrderItems = dto.CartItems.Select(i => new OrderItemDto
            {
                ProductName = i.Product.ProductName,
                ProductPrice = i.Product.NewPrice,
                ProductQuantity = i.ProductQuantity
            }).ToList();

            Payment payment = new HandlePayment().CreatePayment(dto);

            if (payment.Status != "success")
                throw new PaymentException(payment.ErrorMessage);

            dto.OrderDate = DateTime.Now;
            dto.Status = OrderStatus.Onay_Bekliyor;

            await _orderDal.AddAsync(_mapper.Map<Order>(dto));
        }

        public async Task<List<OrderDto>> GetAll()
        {
            var entities = await _orderDal.GetAll();
            return _mapper.Map<List<OrderDto>>(entities);
        }

        public async Task<OrderDto> GetById(int orderId)
        {
            var entity = await _orderDal.GetById(orderId);
            return _mapper.Map<OrderDto>(entity);
        }

        public async Task<List<OrderDto>> GetPastOrders(string userId)
        {
            return _mapper.Map<List<OrderDto>>(await _orderDal.GetPastOrders(userId));
        }
    }
}
