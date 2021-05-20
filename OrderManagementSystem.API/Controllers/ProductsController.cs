using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
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
    public class ProductsController : BaseApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Product> products = _productService.GetProducts();

            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = products;

            return Ok(DataReponse);
        }

        [HttpGet("Paging")]
        public IActionResult Get([FromQuery] int PageNumber, int MaxPageSize)
        {
            //DataReponse<List<Product>> dataReponse;
            ////List<Product> products = _productService.GetProductList(paging);
            //dataReponse = new DataReponse<List<Product>>
            //{
            //    ErrorCode = 200,
            //    Description = "Lấy dữ liệu danh sách sản phẩm thành công",
            //};
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            List<Product> products = _productService.GetProducts(id.Split(",").Select(x => Guid.Parse(x)).ToList());

            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = products;
            return Ok(DataReponse);
        }
    }
}