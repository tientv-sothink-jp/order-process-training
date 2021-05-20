using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface ICartService
    {
        Cart Get(Guid userId);
        void Add(List<Cart> cartItems);
        void Edit(Guid id, List<Cart> cartItem);
        void Delete(Guid id);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="products"></param>
        /// <returns>Order ID</returns>
        Guid Order(Guid cartId, List<Guid> products);
    }
    public class CartService : ICartService
    {
        private ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public void Delete(Guid id)
        {
            _cartRepository.Delete(id);
        }

        public Cart Get(Guid userId)
        {
            return _cartRepository.Get(userId);
        }

        public void Add(List<Cart> cartItems)
        {
            _cartRepository.Add(cartItems);
        }

        public void Edit(Guid id, List<Cart> cartItems)
        {
            _cartRepository.Edit(id, cartItems);
        }

        public Guid Order(Guid cartId, List<Guid> products)
        {
            throw new NotImplementedException();
        }
    }
}
