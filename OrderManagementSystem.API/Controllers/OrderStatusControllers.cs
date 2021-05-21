using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Core.Controllers;
using OrderManagementSystem.API.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Controllers
{
    [Authorize(Roles = "Admin, Guest")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController: BaseApiController
    {
        private IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            DataReponse.Description = "Lấy dữ liệu OrderStatus thành công";
            DataReponse.Result = _orderStatusService.Get();
            return Ok(DataReponse);
        }
    }
}
