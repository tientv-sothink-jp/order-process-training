using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Repositories
{
    public interface IRoleMasterRepository
    {
        RoleMaster Get(Guid roleId);
    }

    public class RoleMasterRepository: IRoleMasterRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;
        public RoleMasterRepository(OrderManagementSystemContext orderManagementSystem)
        {
            _orderManagementSystemContext = orderManagementSystem;
        }

        public RoleMaster Get(Guid roleId)
        {
            RoleMaster roleMaster;
            try
            {
                roleMaster = _orderManagementSystemContext.RoleMasters.Where(item => item.Id == roleId).SingleOrDefault();
            }
            catch (Exception)
            {
                roleMaster = null;
            }
            return roleMaster;
        }
    }
}
