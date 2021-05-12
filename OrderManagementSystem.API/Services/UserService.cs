using Microsoft.Extensions.Configuration;
using OrderManagementSystem.API.Models;
using OrderManagementSystem.API.Repositories;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Services
{
    public class UserService
    {
        private AuthenticationService _authenticationService;
        private UserRepository _userrepository;
        public UserService(IConfiguration configuration, OrderManagementSystemContext orderManagementSystemContext)
        {
            _authenticationService = new AuthenticationService(configuration);
            _userrepository = new UserRepository(orderManagementSystemContext);
        }

        public LoginResponse Login(LoginRequest request)
        {
            LoginResponse loginResponse = _userrepository.Login(request);
            if(loginResponse != null)
            {
                loginResponse.Token = _authenticationService.GenerateToken(loginResponse);
                loginResponse.RefreshToken = _authenticationService.GenerateRefreshToken();
            }
            else
            {
                return null;
            }
            return loginResponse;
        }
    }
}
