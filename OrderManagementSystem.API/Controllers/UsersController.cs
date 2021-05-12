using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private UserService _userService;
        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Login 111111
        /// </summary>
        /// <param name="loginRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            DataReponse<LoginResponse> dataReponse;
            if (loginRequest == null)
            {
                return BadRequest("Invalid client request");
            }

            loginRequest.Password = StringCiplerHelper.MD5Hash(loginRequest.Password);
            LoginResponse loginResponse = _userService.Login(loginRequest);

            if (loginResponse != null)
            {
                dataReponse = new DataReponse<LoginResponse>(200, "Đăng nhập thành công.", loginResponse);
            }
            else
            {
                dataReponse = new DataReponse<LoginResponse>(401, "Đăng nhập thất bại", null);
            }    
            return Ok(dataReponse);
        }
    }
}
