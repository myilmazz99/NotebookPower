using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Security.Constants;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = PolicyConstants.ADMIN)]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpPost("email")]
        [AllowAnonymous]
        public async Task<IActionResult> AddEmail(EmailListDto email)
        {
            await _adminService.AddEmail(email);
            return NoContent();
        }

        [HttpGet("emails")]
        public async Task<IActionResult> GetEmails()
        {
            return Ok(await _adminService.GetAllEmails());
        }

        [HttpPost("feedback")]
        [AllowAnonymous]
        public async Task<IActionResult> PostFeedback(FeedbackDto dto)
        {
            await _adminService.AddFeedback(dto);
            return Ok();
        }

        [HttpGet("feedbacks")]
        public async Task<IActionResult> GetFeedbacks()
        {
            return Ok(await _adminService.GetAllFeedbacks());
        }
    }
}
