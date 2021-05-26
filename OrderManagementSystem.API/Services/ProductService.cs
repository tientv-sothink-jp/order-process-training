using OrderManagementSystem.API.Core.Services;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.API.Services
{
    public interface IProductService
    {
        List<Product> Get();
        List<Product> GetProductPaging(string searchText, int paginIndex, int pageSize, out int pageCount);
        List<Product> Get(string id);
        List<Product> Searching(string keyword);
    }

    public class ProductService : BaseService, IProductService
    {
        private IProductRepository _productrepository;

        public ProductService(IProductRepository productrepository, IIdentityService identityService) : base(identityService)
        {
            _productrepository = productrepository;
        }

        public List<Product> GetProductPaging(string searchText, int paginIndex, int pageSize, out int pageCount)
        {
            return _productrepository.GetPagination(searchText, paginIndex, pageSize, out pageCount);
        }

        public List<Product> Get()
        {
            return _productrepository.Get();
        }

        public List<Product> Get(string id)
        {
            List<Guid> ids = id.Split(",").Select(x => Guid.Parse(x)).ToList();
            return _productrepository.Get(ids);
        }

        public List<Product> Searching(string keyword)
        {
            keyword = keyword.RemoveVietnameseTones();

            var products = _productrepository.Get();
            
            if(!String.IsNullOrEmpty(keyword))
            {
                products = products.Where(s => s.Name.RemoveVietnameseTones().Contains(keyword) ||
                s.Sku.RemoveVietnameseTones().Contains(keyword) ||
                s.Origin.RemoveVietnameseTones().Contains(keyword))
                .ToList();
            }
            return products;
        }
    }
}
