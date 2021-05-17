using OrderManagementSystem.API.Models;
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
        List<Product> GetProductList(PagingModel paging);
    }

    public class ProductService : IProductService
    {
        private IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository)
        {
            _productrepository = productrepository;
        }

        public List<Product> GetProductList(PagingModel paging)
        {
            return _productrepository.Get(paging);
        }

        public List<Product> GetProductList()
        {
            return _productrepository.Get();
        }
    }
}
