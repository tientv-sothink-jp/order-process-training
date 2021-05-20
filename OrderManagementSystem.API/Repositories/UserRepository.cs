using OrderManagementSystem.API.Models;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderManagementSystem.API.Repositories
{
    public interface IUserRepository
    {
        User Get(string userName);
        User Get(Guid userId);
    }

    public class UserRepository: IUserRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public UserRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        } 

        public User Get(string userName)
        {
            return _orderManagementSystemContext.Users.Where(item => item.UserName == userName).SingleOrDefault();
        }

        public User Get(Guid userId)
        {
            return _orderManagementSystemContext.Users.Where(item => item.Id == userId).SingleOrDefault();
        }
    }
}
