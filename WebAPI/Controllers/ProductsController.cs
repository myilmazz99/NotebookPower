using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
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
        public async Task<IActionResult> Add([FromForm] ProductDto productDto, [FromForm] List<IFormFile> productImages, [FromForm] string specifications)
        {
            productDto.Specifications = JsonSerializer.Deserialize<List<SpecificationDto>>(specifications, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

            if (productImages.Count != 0){

                productDto.ProductImages = productDto.ProductImages ?? new List<ProductImageDto>();

                foreach (var file in productImages)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);
                    var publicPath = Path.Combine(Path.DirectorySeparatorChar.ToString(), "uploads", uniqueFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    productDto.ProductImages.Add(new ProductImageDto { FileName = uniqueFileName, ImageUrl = publicPath});
                }
            }

            return Ok(await _productService.Add(productDto));
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromForm] ProductDto productDto, [FromForm] List<IFormFile> productImages, [FromForm] string specifications)
        {
            productDto.Specifications = JsonSerializer.Deserialize<List<SpecificationDto>>(specifications, new JsonSerializerOptions{PropertyNameCaseInsensitive = true});

            if (productImages.Count != 0){

                productDto.ProductImages = productDto.ProductImages ?? new List<ProductImageDto>();

                foreach (var file in productImages)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", uniqueFileName);
                    var publicPath = Path.Combine(Path.DirectorySeparatorChar.ToString(), "uploads", uniqueFileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    productDto.ProductImages.Add(new ProductImageDto { FileName = uniqueFileName, ImageUrl = publicPath});
                }
            }

            var specIds = await _specificationService.Create(productDto.Specifications);
            return Ok(await _productService.Update(productDto, specIds));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _productService.Delete(int.Parse(id));
            return NoContent();
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