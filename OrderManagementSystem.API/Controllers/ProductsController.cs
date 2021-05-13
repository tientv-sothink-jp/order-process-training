using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController: ControllerBase
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
            List<Product> products = _productService.GetProductList();
            dataReponse = new DataReponse<List<Product>>
            {
                ErrorCode = 200,
                Description = "Lấy dữ liệu danh sách sản phẩm thành công",
                Result = products
            };
            return Ok(dataReponse);
        }
    }
}
