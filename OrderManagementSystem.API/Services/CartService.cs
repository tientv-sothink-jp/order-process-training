using OrderManagementSystem.API.Core.Services;
using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface ICartService
    {
        Cart Get(Guid userId);
        Guid Add(List<Cart> cartItems);
        void Edit(Guid id, List<Cart> cartItem);
        void Delete(Guid id);
        void Order(string cartDetailIds);
    }
    public class CartService : BaseService, ICartService
    {
        private ICartRepository _cartRepository;
        private ICartDetailRepository _cartDetailRepository;
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        public CartService(ICartRepository cartRepository, ICartDetailRepository cartDetailRepository,
            IOrderRepository orderRepository, IIdentityService identityService,
            IOrderDetailRepository orderDetailRepository)
            : base(identityService)
        {
            _cartRepository = cartRepository;
            _cartDetailRepository = cartDetailRepository;
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
        }

        public void Delete(Guid id)
        {
            _cartRepository.Delete(id);
        }

        public Cart Get(Guid userId)
        {
            return _cartRepository.Get(userId);
        }

        public Guid Add(List<Cart> cartItems)
        {
            return _cartRepository.Add(cartItems);
        }

        public void Edit(Guid id, List<Cart> cartItems)
        {
            _cartRepository.Edit(id, cartItems);
        }

        public void Order(string cartDetailIds)
        {
            var orderId = _orderRepository.Add(new Order
            {
                DateDelivered = null,
                Discount = 0,
                OrderStatusId = 1
            });

            var orderDetails = _cartDetailRepository
                .Get(cartDetailIds.Split(",").ToList())
                .Select((x) => new OrderDetail
                {
                    OrderId = orderId,
                    ProductId = x.ProductId,
                    ProductPrice = x.ProductPrice,
                    Quantity = x.Quantity
                })
                .ToList();

            _orderDetailRepository.Add(orderDetails);
            _cartDetailRepository.RemoveById(cartDetailIds);
        }
    }
}
