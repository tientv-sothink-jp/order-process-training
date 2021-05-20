using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Core.Controllers
{
    public class BaseApiController : ControllerBase
    {
        public DataReponse DataReponse = new DataReponse
        {
            ErrorCode = 200
        };
    }
}
