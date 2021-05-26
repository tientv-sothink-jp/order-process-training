using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem.API.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get(List<Guid> id);
        List<Product> Get();
        List<Product> GetPagination(string searchText, int pageIndex, int pageSize, out int pageCount);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public ProductRepository(OrderManagementSystemContext orderManagementSystem)
        {
            _orderManagementSystemContext = orderManagementSystem;
        }

        public List<Product> Get()
        {
            return _orderManagementSystemContext.Products.ToList();
        }

        public List<Product> Get(List<Guid> id)
        {
            return _orderManagementSystemContext.Products.Where(x => id.Contains(x.Id)).ToList();
        }

        public List<Product> GetPagination(string searchText, int pageIndex, int pageSize, out int pageCount)
        {
            return _orderManagementSystemContext.Products
                .AsQueryable()
                .Where(x => string.IsNullOrEmpty(searchText) || (
                    x.Name.Contains(searchText) ||
                    x.Sku.Contains(searchText) ||
                    x.Origin.Contains(searchText)
                ))
                .Paging(pageIndex, pageSize, out pageCount)
                .ToList();
        }
    }
}
