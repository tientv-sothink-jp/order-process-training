using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Helpers;

namespace OrderManagementSystem.API.Repositories
{
    public interface IProductRepository
    {
        List<Product> Get(List<Guid> id);
        List<Product> Get();
        List<Product> Pagination(string searchText, int pageIndex, int pageSize, out int pageCount);
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
            return _orderManagementSystemContext.Products.ToList();
        }

        public List<Product> Get(List<Guid> id)
        {
            return _orderManagementSystemContext.Products.Where(x => id.Contains(x.Id)).ToList();
        }

        public void Pagination(int pageIndex, int pageSize, out int pageCount)
        {
            var query = _orderManagementSystemContext.Products.AsQueryable();

            pageCount = query.Count();

            // Paganation -- todo;

            // reutnr
        }

        List<Product> IProductRepository.Pagination(string searchText, int pageIndex, int pageSize, out int pageCount)
        {
            return _orderManagementSystemContext.Products
                .AsQueryable()
                .Where(x => string.IsNullOrEmpty(searchText) || (
                    x.Name.Contains(searchText) ||
                    x.Sku.Contains(searchText) ||
                    x.Origin.Contains(searchText)
                )) //search here
                .Paging(pageIndex, pageSize, out pageCount)
                .ToList();
        }

        //public List<Product> Searching(string keyword)
        //{
        //    keyword = keyword.RemoveVietnameseTones();
        //    var products = _orderManagementSystemContext.Products.ToList();

        //    if (!String.IsNullOrEmpty(keyword))
        //    {
        //        products = products.Where(s => s.Name.RemoveVietnameseTones().Contains(keyword) || 
        //        s.Sku.RemoveVietnameseTones().Contains(keyword) || 
        //        s.Origin.RemoveVietnameseTones().Contains(keyword))
        //        .ToList();
        //    }
        //    return products;
        //}
    }
}
