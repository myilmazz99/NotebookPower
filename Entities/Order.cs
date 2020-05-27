using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Order : IEntity
    {
        public int Id { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public int UserAddressId { get; set; }
        public UserAddress UserAddress { get; set; }

        //Payment API
    }
}
