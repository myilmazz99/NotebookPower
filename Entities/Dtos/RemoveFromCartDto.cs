using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class RemoveFromCartDto : IDto
    {
        public int CartId { get; set; }
        public int CartItemId { get; set; }
    }
}
