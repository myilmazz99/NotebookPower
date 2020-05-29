using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using DataAccess.Concrete.EntityFrameworkCore;
using DataAccess.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IAccountService _accountService;

        public ProductsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("get")]
        public IActionResult Get()
        {
            _accountService.Add(new Entities.Dtos.UserDto { Email = "lale", FullName = "Hello Worldd" });

            return Ok();
        }
    }
}