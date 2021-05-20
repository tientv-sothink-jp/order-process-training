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
    public class OrderDetailsController: BaseApiController
    {
        private IOrderDetailService _orderdetailservice;

        public OrderDetailsController(IOrderDetailService orderdetailservice)
        {
            _orderdetailservice = orderdetailservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DataReponse.Description = "Lấy danh sách OrderDetail thành công";
            DataReponse.Result = _orderdetailservice.Get();
            return Ok(DataReponse);
        }

        [HttpPost]
        public void Post([FromBody] List<OrderDetail> orderDetailItems)
        {
            _orderdetailservice.Add(orderDetailItems);
        }
    }
}
