using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities;
using DataAccess.Concrete.EntityFrameworkCore;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ISpecificationService _specificationService;

        public ProductsController(IProductService productService, ISpecificationService specificationService)
        {
            _productService = productService;
            _specificationService = specificationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _productService.GetById(id);
            return Ok(data);
        }

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] ProductDto productDto)
        {
            var specIds = await _specificationService.Create(productDto.Specifications);

            return Ok(await _productService.Add(productDto, specIds));
        }

        [HttpPost("addImages")]
        public async Task<IActionResult> AddImages([FromForm] List<IFormFile> productImages, [FromForm] int productId)
        {
            if (productImages == null) throw new Exception("Fotoğraflar boş!");

            var images = new List<ProductImageDto>();

            try
            {
                foreach (var file in productImages)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads", uniqueFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await stream.CopyToAsync(stream);
                    }

                    images.Add(new ProductImageDto { FileName = uniqueFileName, ImageUrl = path, ProductId = productId });
                }

                await _productService.AddImages(images);

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Fotoğraflar yüklenirken bir hata oluştu.");
            }


        }
    }
}