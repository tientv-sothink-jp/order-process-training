using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DataReponse<List<Product>> dataReponse;
            List<Product> products = _productService.GetProducts();
            dataReponse = new DataReponse<List<Product>>
            {
                ErrorCode = 200,
                Description = "Lấy dữ liệu danh sách sản phẩm thành công",
                Result = products
            };

            return Ok(dataReponse);
        }

        [HttpGet("Paging")]
        public IActionResult Get([FromQuery] int PageNumber, int MaxPageSize)
        {
            DataReponse<List<Product>> dataReponse;
            //List<Product> products = _productService.GetProductList(paging);
            dataReponse = new DataReponse<List<Product>>
            {
                ErrorCode = 200,
                Description = "Lấy dữ liệu danh sách sản phẩm thành công",
            };
            return Ok(dataReponse);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            List<Product> products = _productService.GetProducts(id.Split(",").Select(x => Guid.Parse(x)).ToList());
            return Ok(new DataReponse<List<Product>>
            {
                ErrorCode = 200,
                Description = "Lấy dữ liệu danh sách sản phẩm thành công",
                Result = products
            });
        }
    }
}