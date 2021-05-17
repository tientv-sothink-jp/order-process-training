using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Models
{
    public class UserLoginRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
