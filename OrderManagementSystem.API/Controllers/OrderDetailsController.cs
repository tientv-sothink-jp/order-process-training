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
    [Authorize(Roles = "Admin, Guest")]
    [Route("api/[controller]")]
    public class OrderDetailsController: BaseApiController
    {
        private readonly IOrderDetailService _orderdetailservice;

        public OrderDetailsController(IOrderDetailService orderdetailservice)
        {
            _orderdetailservice = orderdetailservice;
        }

        [HttpGet("{orderId}")]
        public IActionResult Get(Guid orderId)
        {
            DataReponse.Description = "Lấy danh sách OrderDetail thành công";
            DataReponse.Result = _orderdetailservice.Get(orderId);
            return Ok(DataReponse);
        }

        [HttpPost]
        public IActionResult Post([FromBody] List<OrderDetail> orderDetailItems)
        {
            _orderdetailservice.Add(orderDetailItems);
            return Ok(DataReponse);
        }
    }
}
