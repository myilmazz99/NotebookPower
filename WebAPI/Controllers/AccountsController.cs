using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Security;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserDto user)
        {
            await _accountService.Register(user);
            return Ok("Kullanıcı oluşturuldu.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserDto dto)
        {
            var token = await _accountService.Login(dto);
            return Ok(token);
        }
    }
}
