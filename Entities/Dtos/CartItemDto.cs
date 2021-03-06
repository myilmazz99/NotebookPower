﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CartItemDto : IDto
    {
        public int Id { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductId { get; set; }
        public ProductDto Product { get; set; }
    }
}
