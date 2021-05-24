using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Linq;

namespace OrderManagementSystem.API.Repositories
{
    public interface IUserRoleRepository
    {
        UserRole Get(Guid userId);
    }

    public class UserRoleRepository: IUserRoleRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public UserRoleRepository(OrderManagementSystemContext orderManagementSystem)
        {
            _orderManagementSystemContext = orderManagementSystem;
        }

        public UserRole Get(Guid userId) => _orderManagementSystemContext.UserRoles.Where(item => item.UserId == userId).SingleOrDefault();
    }
}
