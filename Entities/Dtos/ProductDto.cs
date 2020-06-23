using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Stock { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<ProductImageDto> ProductImages { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<SpecificationDto> Specifications { get; set; }
    }
}
