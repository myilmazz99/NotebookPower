using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(int id)
        {
            await _cartService.Create(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            await _cartService.Get(id);
            return Ok();
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update(CartDto cart)
        {
            await _cartService.Update(cart);
            return Ok();
        }
    }
}
