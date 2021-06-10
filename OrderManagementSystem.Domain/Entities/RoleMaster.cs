using System;

#nullable disable

namespace OrderManagementSystem.Domain.Entities
{
    public partial class RoleMaster
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
