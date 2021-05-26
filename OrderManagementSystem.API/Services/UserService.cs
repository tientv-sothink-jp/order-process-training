using Microsoft.Extensions.Configuration;
using OrderManagementSystem.API.Core;
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
        private ICartRepository _cartRepository;
        public UserService(IUserRepository userRepository, IUserRoleRepository userRoleRepository, 
            IRoleMasterRepository roleMasterRepository, IConfiguration configuration,
            ICartRepository cartRepository) : base(configuration)
        {
            _userrepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _roleMasterRepository = roleMasterRepository;
            _cartRepository = cartRepository;
        }

        public User Get(Guid userId)
        {
            return _userrepository.Get(userId);
        }

        public User Login(string username, string password)
        {
            User user = _userrepository.Get(username);
            if (user == null || user.Password != password.ToMD5Hash())
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

            var cartId = _cartRepository.Get(user.Id).Id;

            var claims = new List<Claim>()
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.Name.ToString()),
                            new Claim(ClaimTypes.Role, roleMaster.Name),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(CustomClaimTypes.Cart, cartId.ToString()),
                        };
            user.Token = this.GenerateToken(claims);
            user.RefreshToken = this.GenerateRefreshToken();
            return user;
        }
    }
}
