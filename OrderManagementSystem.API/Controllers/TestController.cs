using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[Controller]")]
    public class TestController: ControllerBase
    {
        private readonly IConfiguration _configuration;
        public TestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Name = _configuration.GetSection("AppSettings:Secret")
            });
        }
    }
}
