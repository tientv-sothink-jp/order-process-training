using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Models
{
    public class LoginResponse
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public Guid RoleId { get; set; }
        public string RoleName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool? IsActive { get; set; }
    }
}
