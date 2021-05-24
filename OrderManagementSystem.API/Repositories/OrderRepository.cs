using Microsoft.Data.SqlClient;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace OrderManagementSystem.API.Repositories
{
    public interface IOrderRepository
    {
        List<Order> Get();
        Guid Add(List<Order> orderItems);
        Guid Add(Order item);
        void Edit(Guid id, List<Order> orderItems);
    }
    public class OrderRepository: IOrderRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public OrderRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public Guid Add(List<Order> orderItems)
        {
            var parameter = new SqlParameter()
            {
                ParameterName = "@Order",
                SqlDbType = SqlDbType.Structured,
                Value = orderItems.ToDataTable("Id", "DateDelivered", "Discount", "OrderStatusId" ),
                TypeName = "dbo.OrderType"
            };

            SqlConnection conn = _orderManagementSystemContext.DbConnection;
            var result = conn.Prepare("[dbo].[AddOrder]", CommandType.StoredProcedure, new SqlParameter[] { parameter }).ExecuteScalar();
            
            return Guid.Parse(result.ToString());
        }

        public Guid Add(Order item)
        {
            return this.Add(new List<Order> {
                item
            });
        }

        public void Edit(Guid id, List<Order> orderItems)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Id", id),
                new SqlParameter()
                {
                    ParameterName = "@Order",
                    SqlDbType = SqlDbType.Structured,
                    Value = orderItems.ToDataTable("Id", "DateDelivered", "Discount", "OrderStatusId"),
                    TypeName = "dbo.OrderType"
                }
            };

            SqlConnection conn = _orderManagementSystemContext.DbConnection;
            conn.Prepare("[dbo].[EditOrder]", CommandType.StoredProcedure, sqlParameters).ExecuteNonQuery();
        }

        public List<Order> Get()
        {
            return _orderManagementSystemContext.Orders.ToList();
        }
    }
}
