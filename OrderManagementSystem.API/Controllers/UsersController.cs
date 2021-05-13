﻿using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            DataReponse<User> dataReponse;
            if (loginRequest == null)
            {
                return BadRequest("Invalid client request");
            }

            User user = _userService.Login(loginRequest);

            if (user != null)
            {
                dataReponse = new DataReponse<User>
                {
                    ErrorCode = 200,
                    Description = "Đăng nhập thành công",
                    Result = user
                };
            }
            else
            {
                dataReponse = new DataReponse<User>
                {
                    ErrorCode = 401,
                    Description = "Đăng nhập thất bại",
                    Result = null
                };
                return Unauthorized(dataReponse);
            }    
            return Ok(dataReponse);
        }
    }
}