using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class ProductImageDto : IDto
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        public string FileName { get; set; }
        public int ProductId { get; set; }
    }
}
