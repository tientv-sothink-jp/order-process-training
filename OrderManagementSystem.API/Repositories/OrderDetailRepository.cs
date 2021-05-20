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
    public interface IOrderDetailRepository
    {
        List<OrderDetail> Get();
        void Add(List<OrderDetail> orderdetailItems);
    }
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public OrderDetailRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public void Add(List<OrderDetail> orderdetailItems)
        {
            string[] columnNames = { "Id", "OrderId", "ProductId", "ProductPrice", "Quantity", "CreatedTime", "UpdatedTime" };

            var parameter = new SqlParameter("@OrderDetail", SqlDbType.Structured);
            parameter.Value = orderdetailItems.ToDataTable(columnNames);
            parameter.TypeName = "dbo.OrderDetailType";

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[AddOrderDetail]", CommandType.StoredProcedure, new SqlParameter[] { parameter }).ExecuteNonQuery();
            conn.Close();
        }

        public List<OrderDetail> Get()
        {
            return _orderManagementSystemContext.OrderDetails.ToList();
        }
    }
}
