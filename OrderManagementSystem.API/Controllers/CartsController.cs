using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CartsController: ControllerBase
    {
        private ICartService _cartService;

        public CartsController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            List<Cart> carts = _cartService.Get(userId);
            DataReponse<List<Cart>> dataresponse = new DataReponse<List<Cart>>
            {
                ErrorCode = 200,
                Description = "Lấy danh sách giỏ hàng thành công",
                Result = carts
            };
            return Ok(dataresponse);
        }

        [HttpPost]
        public void Post([FromBody] List<Cart> cartItems)
        {
            _cartService.Add(cartItems);
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
    }
}
