using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OrderManagementSystem.API.Services
{
    public interface ICartDetailService
    {
        List<CartDetail> Get();
        List<CartDetail> GetByCartId(Guid cartId);
        CartDetail Get(Guid id);
        void Add(List<CartDetail> cartDetailItems);
        void Edit(Guid id, List<CartDetail> cartDetailItems);
        void Delete(Guid id);
    }
    public class CartDetailService : ICartDetailService
    {
        private ICartDetailRepository _cartDetailRepository;

        public CartDetailService(ICartDetailRepository cartDetailRepository)
        {
            _cartDetailRepository = cartDetailRepository;
        }

        public void Add(List<CartDetail> cartDetailItems)
        {
            _cartDetailRepository.Add(cartDetailItems);
        }

        public void Delete(Guid id)
        {
            _cartDetailRepository.Delete(id);
        }

        public void Edit(Guid id, List<CartDetail> cartDetailItems)
        {
            _cartDetailRepository.Edit(id, cartDetailItems);
        }

        public List<CartDetail> Get()
        {
            throw new NotImplementedException();
        }

        public CartDetail Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CartDetail> GetByCartId(Guid cartId)
        {
            return _cartDetailRepository.GetByCartId(cartId);
        }
    }
}
