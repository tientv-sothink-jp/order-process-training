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
        void Add(List<Order> orderItems);
        void Edit(Guid id, List<Order> orderItems);
    }
    public class OrderRepository: IOrderRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public OrderRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public void Add(List<Order> orderItems)
        {
            string[] columnNames = { "Id", "DateDelivered", "Discount", "OrderStatusId", "CreatedTime", "UpdatedTime" };

            var parameter = new SqlParameter("@Order", SqlDbType.Structured);
            parameter.Value = orderItems.ToDataTable(columnNames);
            parameter.TypeName = "dbo.OrderType";

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[AddOrder]", CommandType.StoredProcedure, new SqlParameter[] { parameter }).ExecuteNonQuery();
            conn.Close();
        }

        public void Edit(Guid id, List<Order> orderItems)
        {
            string[] columnNames = { "Id", "DateDelivered", "Discount", "OrderStatusId", "CreatedTime", "UpdatedTime" };

            SqlParameter[] sqlParameters = new SqlParameter[2];

            var orderTableParameter = new SqlParameter("@Order", SqlDbType.Structured);
            orderTableParameter.Value = orderItems.ToDataTable(columnNames);
            orderTableParameter.TypeName = "dbo.OrderType";

            sqlParameters[0] = new SqlParameter("Id", id);
            sqlParameters[1] = orderTableParameter;

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[EditOrder]", CommandType.StoredProcedure, sqlParameters).ExecuteNonQuery();
            conn.Close();
        }

        public List<Order> Get()
        {
            return _orderManagementSystemContext.Orders.ToList();
        }
    }
}
