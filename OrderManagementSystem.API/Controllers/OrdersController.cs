using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Services;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize(Roles ="Admin, Guest")]
    [Route("api/[controller]")]
    public class OrdersController: BaseApiController
    {
        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DataReponse.Description = "Lấy danh sách order thành công";
            DataReponse.Result = _orderService.Get();
            return Ok(DataReponse);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<Order> orderItems)
        {
            DataReponse.Description = "Thêm mới Order thành công";
            DataReponse.Result = new
            {
                Id = _orderService.Add(orderItems)
            };
            return Ok(DataReponse);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] List<Order> orderItems)
        {
            _orderService.Edit(id, orderItems);
            return Ok(DataReponse);
        }
    }
}
