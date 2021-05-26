using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem.API.Repositories
{
    public interface IOrderStatusRepository
    {
        List<OrderStatusMaster> Get();
    }
    public class OrderStatusRepository : IOrderStatusRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public OrderStatusRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public List<OrderStatusMaster> Get()
        {
            return _orderManagementSystemContext.OrderStatusMasters.ToList();
        }
    }
}
