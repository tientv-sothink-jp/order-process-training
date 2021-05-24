using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize(Roles = "Guest")]
    [Route("api/[controller]")]
    public class CartsController: BaseApiController
    {
        private ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            Cart carts = _cartService.Get(userId);
            DataReponse.Description = "Lấy danh sách giỏ hàng thành công";
            DataReponse.Result = carts;
            return Ok(DataReponse);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Cart> cartItems)
        {
            Guid guid = _cartService.Add(cartItems);

            DataReponse.Description = "Thêm mới cart thành công";
            DataReponse.Result = new
            {
                Id = guid
            };
            return Ok(DataReponse);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] List<Cart> cartItems)
        {
            _cartService.Edit(id, cartItems);
        }
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _cartService.Delete(id);
        }
        [HttpPost("Order/{stringCartDetailId}")]
        public IActionResult Post(string stringCartDetailId)
        {
            _cartService.Order(stringCartDetailId);
            DataReponse.Description = "Order thành công";
            DataReponse.Result = new ArrayList();
            return Ok(DataReponse);
        }
    }
}
