using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IOrderDetailService
    {
        List<OrderDetail> Get();
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

        public List<OrderDetail> Get()
        {
            return _orderDetailRepository.Get();
        }
    }
}
