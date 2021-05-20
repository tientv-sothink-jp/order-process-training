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
    [Authorize]
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
        public void Post([FromBody] List<Order> orderItems)
        {
            _orderService.Add(orderItems);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody] List<Order> orderItems)
        {
            _orderService.Edit(id, orderItems);
        }
    }
}
