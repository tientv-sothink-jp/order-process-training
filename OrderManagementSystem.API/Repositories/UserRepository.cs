using OrderManagementSystem.API.Models;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagementSystem.API.Repositories
{
    public class UserRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public UserRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        } 

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse loginResponse;
            try
            {
                loginResponse = _orderManagementSystemContext.UserRoles
                .Join(
                    _orderManagementSystemContext.Users,
                   userRole => userRole.UserId,
                   user => user.Id,
                   (userRoleData, userData) => new { userRoleData, userData }
                )
                .Join(
                    _orderManagementSystemContext.RoleMasters,
                    userRole => userRole.userRoleData.RoleId,
                    role => role.Id,
                    (userRoleData, roleData) => new { userRoleData, roleData }
                )
                .Where(x => x.userRoleData.userData.UserName == request.UserName && x.userRoleData.userData.Password == request.Password)
                .Select(joinDataResponse => new LoginResponse()
                {
                    Id = joinDataResponse.userRoleData.userData.Id,
                    UserName = joinDataResponse.userRoleData.userData.UserName,
                    Password = joinDataResponse.userRoleData.userData.Password,
                    Name = joinDataResponse.userRoleData.userData.Name,
                    Phone = joinDataResponse.userRoleData.userData.Phone,
                    Email = joinDataResponse.userRoleData.userData.Email,
                    Address = joinDataResponse.userRoleData.userData.Address,
                    IsActive = joinDataResponse.userRoleData.userData.IsActive,
                    RoleId = joinDataResponse.roleData.Id,
                    RoleName = joinDataResponse.roleData.Name
                }).SingleOrDefault();
            }
            catch (Exception)
            {
                loginResponse = null;
            }
            return loginResponse;
        }
    }
}
