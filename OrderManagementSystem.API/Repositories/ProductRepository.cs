using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderManagementSystem.API.Models;

namespace OrderManagementSystem.API.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get(PagingModel paging);
        List<Product> Get();
    }

    public class ProductRepository: IProductRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public ProductRepository(OrderManagementSystemContext orderManagementSystem)
        {
            _orderManagementSystemContext = orderManagementSystem;
        }

        public List<Product> Get(PagingModel paging)
        {
            return _orderManagementSystemContext.Products
                .Skip((paging.PageNumber -1) * paging.PageSize)
                .Take(paging.PageSize)
                .ToList<Product>();
        }

        public List<Product> Get()
        {
            return _orderManagementSystemContext.Products.ToList<Product>();
        }
    }
}
