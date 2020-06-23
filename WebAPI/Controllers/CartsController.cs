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
        public async Task<IActionResult> Create(string userId)
        {
            await _cartService.Create(userId);
            return Ok();
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> Get(string userId)
        {
            return Ok(await _cartService.Get(userId));
        }

        [HttpPut]
        public async Task<IActionResult> Update(AddToCartDto dto)
        {
            return Ok(await _cartService.Update(dto));
        }

        [HttpDelete("{cartId}/{cartItemId}")]
        public async Task<IActionResult> Delete([FromRoute] RemoveFromCartDto dto)
        {
            await _cartService.RemoveFromCart(dto);
            return Ok();
        }
    }
}
