using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : BaseApiController
    {
        private ICartDetailService _cartDetailService;
        public CartDetailController(ICartDetailService cartDetailService)
        {
            _cartDetailService = cartDetailService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [Authorize(Roles = "Admin, Guest")]
        [HttpGet("GetByCartId/{cartId}")]
        public IActionResult Get(Guid cartId)
        {
            DataReponse.Description = "Lấy dữ liệu CartDetail thành công";
            DataReponse.Result = _cartDetailService.GetByCartId(cartId);
            return Ok(DataReponse);
        }

        [Authorize(Roles = "Admin, Guest")]
        [HttpPost]
        public void Post(List<CartDetail> cartDetailItems)
        {
            _cartDetailService.Add(cartDetailItems);
        }

        [Authorize(Roles = "Admin, Guest")]
        [HttpPut("{id}")]
        public void Put(Guid id, List<CartDetail> cartDetailItems)
        {
            _cartDetailService.Edit(id, cartDetailItems);
        }

        [Authorize(Roles = "Admin, Guest")]
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _cartDetailService.Delete(id);
        }
    }
}