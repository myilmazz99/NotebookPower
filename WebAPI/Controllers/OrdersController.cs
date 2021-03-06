﻿using System;
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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> FulfillOrder(OrderDto dto)
        {
            await _orderService.FulfillOrder(dto);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _orderService.GetById(id));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _orderService.Delete(id);
            return Ok();
        }

        [HttpGet("{id}/orders")]
        public async Task<IActionResult> GetPastOrders(string id)
        {
            return Ok(await _orderService.GetPastOrders(id));
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> ConfirmOrder(int orderId)
        {
            return Ok(await _orderService.ConfirmOrder(orderId));
        }
    }
}
