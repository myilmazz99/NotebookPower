using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Cart : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public List<CartItem> CartItems { get; set; }
    }
}
