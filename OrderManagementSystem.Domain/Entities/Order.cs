using System;
using System.Collections.Generic;

#nullable disable

namespace OrderManagementSystem.Domain.Entities
{
    public partial class Order
    {
        public Order()
        {
            CreatedTime = DateTime.Now;
        }
        public Guid Id { get; set; }
        public DateTime? DateDelivered { get; set; }
        public decimal Discount { get; set; }
        public int OrderStatusId { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
