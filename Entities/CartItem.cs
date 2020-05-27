using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CartItem : IEntity
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
