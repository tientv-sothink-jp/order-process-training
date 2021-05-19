using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Core.Services
{
    public class BaseService
    {
        protected IIdentityService IdentityService;

        public BaseService(IIdentityService identityService)
        {
            this.IdentityService = identityService;
        }
    }
}
