using System;

#nullable disable

namespace OrderManagementSystem.Domain.Entities
{
    public partial class Cart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public DateTime? CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
