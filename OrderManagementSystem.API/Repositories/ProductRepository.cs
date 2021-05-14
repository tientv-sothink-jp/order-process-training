using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OrderManagementSystem.API.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get();
    }

    public class ProductRepository: IProductRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public ProductRepository(OrderManagementSystemContext orderManagementSystem)
        {
            _orderManagementSystemContext = orderManagementSystem;
        }

        public List<Product> Get()
        {
            return _orderManagementSystemContext.Products.ToList<Product>();
        }
    }
}
