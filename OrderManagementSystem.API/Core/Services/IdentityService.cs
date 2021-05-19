using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace OrderManagementSystem.API.Core.Services
{
    public interface IIdentityService
    {
        public IPrincipal User { get; set; }
        public string Name { get; }
    }

    public class IdentityService : IIdentityService
    {
        public IPrincipal User { get; set; }

        public string Name => User.Identity.Name;
    }
}
