using System;

#nullable disable

namespace OrderManagementSystem.Domain.Entities
{
    public partial class UserRole
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
