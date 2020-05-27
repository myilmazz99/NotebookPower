using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class OrderItem : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public double ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
