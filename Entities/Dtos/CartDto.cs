using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CartDto : IDto
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public List<CartItemDto> CartItems { get; set; }
    }
}
