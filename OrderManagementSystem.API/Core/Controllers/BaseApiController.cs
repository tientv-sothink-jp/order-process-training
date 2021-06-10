using Microsoft.AspNetCore.Mvc;
using OrderManagementSystem.API.Models;

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
