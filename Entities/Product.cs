using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Stock { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Comment> Comments { get; set; }
        public List<ProductImage> ProductImages { get; set; }
        public List<ProductSpecification> ProductSpecifications { get; set; }
    }
}
