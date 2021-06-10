using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : BaseApiController
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] UserLoginRequest request)
        {
            if (request == null)
            {
                return BadRequest("Invalid client request");
            }

            User user = _userService.Login(request.UserName, request.Password);

            if (user != null)
            {
                DataReponse.Description = "Đăng nhập thành công";
                DataReponse.Result = user;
            }
            else
            {
                DataReponse.ErrorCode = 401;
                DataReponse.Description = "Đăng nhập thất bại";
                DataReponse.Result = null;
                return Unauthorized(DataReponse);
            }
            return Ok(DataReponse);
        }

        [Authorize]
        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            DataReponse.Description = "Lấy thông tin user thành công";
            DataReponse.Result = _userService.Get(userId);
            return Ok(DataReponse);
        }
    }
}
