using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace OrderManagementSystem.API.Core.Services
{
    public interface IIdentityService
    {
        public ClaimsPrincipal User { get; set; }
        public string Name { get; }
        public Guid UserId { get; }
    }

    public class IdentityService : IIdentityService
    {
        public ClaimsPrincipal User { get; set; }

        public string Name => User.Identity.Name;

        public Guid UserId => User.Claims
            .Where(x => x.Type.Equals(ClaimTypes.NameIdentifier))
            .Select(x => Guid.Parse(x.Value))
            .FirstOrDefault();
    }
}
