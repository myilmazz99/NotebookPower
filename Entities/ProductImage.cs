using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class ProductImage : IEntity
    {
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
