using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class OrderDto : IDto
    {
        public int Id { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public UserAddress UserAddress { get; set; }
    }
}
