using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IOrderStatusService
    {
        List<OrderStatusMaster> Get();
    }
    public class OrderStatusService: IOrderStatusService
    {
        private IOrderStatusRepository _orderStatusRepository;

        public OrderStatusService(IOrderStatusRepository orderStatusRepository)
        {
            _orderStatusRepository = orderStatusRepository;
        }

        public List<OrderStatusMaster> Get()
        {
            return _orderStatusRepository.Get();
        }
    }
}
