using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IOrderService
    {
        List<Order> Get();
        Guid Add(List<Order> orderItems);
        void Edit(Guid id, List<Order> orderItems);
    }
    public class OrderService : IOrderService
    {
        private IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Guid Add(List<Order> orderItems)
        {
            return _orderRepository.Add(orderItems);
        }

        public void Edit(Guid id, List<Order> orderItems)
        {
            _orderRepository.Edit(id, orderItems);
        }

        public List<Order> Get()
        {
            return _orderRepository.Get();
        }
    }
}
