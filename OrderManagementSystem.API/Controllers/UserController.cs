using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    class UserController: ControllerBase
    {
        public UserController()
        {

        }

        [HttpPost]
        public IActionResult Login()
        {
            return Ok();
        }
    }
}
