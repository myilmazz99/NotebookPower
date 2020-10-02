using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Security;
using Core.Security.Constants;
using Entities.Dtos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = PolicyConstants.USER)]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDto dto)
        {
            var token = await _accountService.Register(dto);
            return Ok(token);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _accountService.Login(dto);
            return Ok(token);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var data = await _accountService.GetUserCredentials(id);
            return Ok(data);
        }

        [HttpGet("{id}/favorites")]
        public async Task<IActionResult> GetFavorites(string id)
        {
            var favs = await _accountService.GetFavoriteProducts(id);
            return Ok(favs);
        }

        [HttpGet("confirmemail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery]string userId, string token)
        {
            await _accountService.ConfirmEmail(userId, token);
            return Ok("Mailiniz başarıyla onaylandı.");
        }

        [HttpPost("addtofav")]
        public async Task<IActionResult> AddToFavorites(FavoriteDto dto)
        {
            return Ok(await _accountService.AddToFavorite(dto.UserId, dto.ProductId));
        }

        [HttpDelete("{userId}/removefromfav/{productId}")]
        public async Task<IActionResult> RemoveFromFavorite(string userId, int productId)
        {
            await _accountService.RemoveFromFavorite(userId, productId);
            return Ok("Favorilerden çıkarıldı.");
        }
    }
}
