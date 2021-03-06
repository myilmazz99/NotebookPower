﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductSpecification : IEntity
    {
        public int ProductId { get; set; }
        public int SpecificationId { get; set; }
        public Product Product { get; set; }
        public Specification Specification { get; set; }
    }
}
