using System;

#nullable disable

namespace OrderManagementSystem.Domain.Entities
{
    public partial class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
