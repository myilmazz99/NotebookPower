using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
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

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductDto productDto)
        {
            var specIds = await _specificationService.Create(productDto.Specifications);
            return Ok(await _productService.Update(productDto, specIds));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(int.Parse(id));
            return NoContent();
        }

        [HttpPost("addImages")]
        public async Task<IActionResult> AddImages([FromForm] List<IFormFile> productImages, [FromForm] int productId)
        {
            if (productImages.Count == 0) return NoContent();

            var images = new List<ProductImageDto>();

            try
            {
                foreach (var file in productImages)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await stream.CopyToAsync(stream);
                    }

                    images.Add(new ProductImageDto { FileName = uniqueFileName, ImageUrl = path, ProductId = productId });
                }

                await _productService.AddImages(images);

                return Ok();
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllWithIncludes());
        }

        [HttpGet("dailydeals")]
        public async Task<IActionResult> GetDailyDeals()
        {
            var deneme = HttpContext.User;
            var deneme2 = User;
            return Ok(await _productService.GetDailyDeals());
        }

        [HttpGet("bestseller")]
        public async Task<IActionResult> GetBestSeller()
        {
            return Ok(await _productService.GetBestSeller());
        }

        [HttpGet("similiar/{categoryId}")]
        public async Task<IActionResult> GetSimiliar(int categoryId)
        {
            return Ok(await _productService.GetSimiliar(categoryId));
        }

        [HttpGet("specifications")]
        public async Task<IActionResult> GetSpecifications()
        {
            return Ok(await _specificationService.GetAll());
        }

        [HttpDelete("{productId}/{specId}")]
        public async Task<IActionResult> RemoveSpecification(string productId, string specId)
        {
            await _specificationService.RemoveSpecification(int.Parse(productId), int.Parse(specId));
            return Ok(int.Parse(specId));
        }
    }
}