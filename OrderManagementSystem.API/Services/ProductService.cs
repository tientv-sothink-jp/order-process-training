using OrderManagementSystem.API.Core.Services;
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
        List<Product> GetProducts();
        List<Product> GetProductPaging(PagingModel paging);
        List<Product> GetProducts(List<Guid> id);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="product"></param>
        /// <param name="quantity"></param>
        /// <returns>Cart Id</returns>
        Guid AddToCart(Product product, int quantity);
    }

    public class ProductService : BaseService, IProductService
    {
        private IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository, IIdentityService identityService) : base(identityService)
        {
            _productrepository = productrepository;
        }

        public Guid AddToCart(Product product, int quantity)
        {
            var x = IdentityService.User;
            var y = IdentityService.Name;

            return Guid.NewGuid();
        }

        public List<Product> GetProductPaging(PagingModel paging)
        {
            return _productrepository.Get(paging);
        }

        public List<Product> GetProducts()
        {
            return _productrepository.Get();
        }

        public List<Product> GetProducts(List<Guid> id)
        {
            return _productrepository.Get(id);
        }
    }
}
