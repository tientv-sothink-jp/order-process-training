using Microsoft.Extensions.Configuration;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public interface IUserService
    {
        User Login(string username, string password);
        User Get(Guid userId);
    }

    public class UserService : CustomAuthenticationService, IUserService
    {
        private IUserRepository _userrepository;
        private IUserRoleRepository _userRoleRepository;
        private IRoleMasterRepository _roleMasterRepository;
        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, IRoleMasterRepository roleMasterRepository, IConfiguration configuration) : base(configuration)
        {
            _userrepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleMasterRepository = roleMasterRepository;
        }

        public User Get(Guid userId)
        {
            return _userrepository.Get(userId);
        }

        public User Login(string username, string password)
        {
            User user = _userrepository.Get(username);
            if (user == null || user.Password != StringCiplerHelper.MD5Hash(password))
            {
                return null;
            }

            UserRole userRole = _userRoleRepository.Get(user.Id);
            if (userRole == null)
            {
                return null;
            }

            RoleMaster roleMaster = _roleMasterRepository.Get(userRole.RoleId);
            if (roleMaster == null)
            {
                return null;
            }
            
            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.UserName),
                            new Claim(ClaimTypes.Name, user.Name),
                            new Claim(ClaimTypes.Role, roleMaster.Name),
                            new Claim(ClaimTypes.Email, user.Email)
                        };
            user.Token = this.GenerateToken(claims);
            user.RefreshToken = this.GenerateRefreshToken();
            return user;
        }
    }
}
