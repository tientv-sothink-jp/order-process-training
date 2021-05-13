using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IProductService
    {
        List<Product> GetProductList();
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public List<Product> GetProductList()
        {
            return _productrepository.Get();
        }
    }
}
