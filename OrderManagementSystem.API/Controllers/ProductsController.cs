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
using System.Threading.Tasks;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin, Guest")]
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Lấy dữ liệu product
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = _productService.Get();

            return Ok(DataReponse);
        }

        [HttpGet("Paging")]
        public IActionResult Get([FromQuery] string keyword, int pageIndex, int pageSize)
        {
            var data = _productService.GetProductPaging(keyword, pageIndex, pageSize, out int pageCount);

            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = new
            {
                Source = data,
                TotalPage = pageCount
            };
            return Ok(DataReponse);
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = _productService.Get();
            return Ok(DataReponse);
        }
        
        [HttpGet("Search/{keyword}")]
        public IActionResult Search(string keyword)
        {
            DataReponse.Description = "Lấy dữ liệu danh sách sản phẩm thành công";
            DataReponse.Result = _productService.Searching(keyword);
            return Ok(DataReponse);
        }
    }
}