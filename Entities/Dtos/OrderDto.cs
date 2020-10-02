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
        public string ShortDate { get; set; }
        public List<OrderItemDto> OrderItems { get; set; }
        public List<CartItemDto> CartItems { get; set; }
        public double TotalPrice { get; set; }
        public string UserId { get; set; }
        //Address
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string AddressHeader { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string AddressDescription { get; set; }
        //Credit Card
        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string ExpireMonth { get; set; }
        public string ExpireYear { get; set; }
        public string SecurityNumber { get; set; }
    }
}
