using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IOrderDetailService
    {
        List<OrderDetail> Get(Guid orderId);
        void Add(List<OrderDetail> orderDetailItems);
    }
    public class OrderDetailService : IOrderDetailService
    {
        private IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public void Add(List<OrderDetail> orderDetailItems)
        {
            _orderDetailRepository.Add(orderDetailItems);
        }

        public List<OrderDetail> Get(Guid orderId)
        {
            return _orderDetailRepository.Get(orderId);
        }
    }
}
