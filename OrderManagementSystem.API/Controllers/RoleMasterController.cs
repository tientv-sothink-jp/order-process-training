using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;

namespace OrderManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    public class RoleMasterController: ControllerBase
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public RoleMasterController(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        [HttpPost]
        public IActionResult Add()
        {
            RoleMaster roleMaster = new RoleMaster()
            {
                Name = "Administrator"
            };
            _orderManagementSystemContext.Add<RoleMaster>(roleMaster);
            _orderManagementSystemContext.SaveChanges();
            return Ok();
        }
    }
}
