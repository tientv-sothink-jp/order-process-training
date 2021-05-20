﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartDetailController : BaseApiController
    {
        private ICartDetailService _cartDetailService;
        public CartDetailController(ICartDetailService cartDetailService)
        {
            _cartDetailService = cartDetailService;
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("GetByCartId/{cartId}")]
        public IActionResult Get(Guid cartId)
        {
            DataReponse.Description = "Lấy dữ liệu CartDetail thành công";
            DataReponse.Result = _cartDetailService.GetByCartId(cartId);
            return Ok(DataReponse);
        }

        [HttpPost("")]
        public void Post(List<CartDetail> cartDetailItems)
        {
            _cartDetailService.Add(cartDetailItems);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, List<CartDetail> cartDetailItems)
        {
            _cartDetailService.Edit(id, cartDetailItems);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _cartDetailService.Delete(id);
        }
    }
}