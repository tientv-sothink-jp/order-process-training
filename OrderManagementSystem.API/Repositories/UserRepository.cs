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
            User user;
            try
            {
                user = _orderManagementSystemContext.Users.Where(item => item.UserName == userName).SingleOrDefault();
            }
            catch (Exception)
            {
                user = null;
            }
            return user;
        }
    }
}
