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
        List<OrderDetail> Get(Guid orderId);
        void Add(List<OrderDetail> orderdetailItems);
    }
    public class OrderDetailRepository: IOrderDetailRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;

        public OrderDetailRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public void Add(List<OrderDetail> orderdetailItems)
        {
            var addOrderDetailParameter =
                new SqlParameter[]
                {
                    new SqlParameter()
                    {
                        ParameterName = "@OrderDetail",
                        SqlDbType = SqlDbType.Structured,
                        Value = orderdetailItems.ToDataTable("Id", "OrderId", "ProductId", "ProductPrice", "Quantity"),
                        TypeName = "dbo.OrderDetailType"
                    }
                };
            

            SqlConnection conn = _orderManagementSystemContext.DbConnection;
            SqlTransaction transaction = conn.BeginTransaction();
            try
            {
                conn.Prepare("[dbo].[AddOrderDetail]", CommandType.StoredProcedure, addOrderDetailParameter , transaction).ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        //public void Add(Guid cartID, List<OrderDetail> orderdetailItems)
        //{
        //    string[] columnNames = { "Id", "OrderId", "ProductId", "ProductPrice", "Quantity" };

            //    var addOrderDetailParameter = new SqlParameter("@OrderDetail", SqlDbType.Structured)
            //    {
            //        Value = orderdetailItems.ToDataTable(columnNames),
            //        TypeName = "dbo.OrderDetailType"
            //    };

            //    SqlParameter deleteCartDetailByCartIdParameter = new SqlParameter("@CartId", cartID);

            //    SqlConnection conn = _orderManagementSystemContext.DbConnection;
            //    SqlTransaction transaction = conn.BeginTransaction();
            //    try
            //    {
            //        conn.Prepare("[dbo].[AddOrderDetail]", CommandType.StoredProcedure, new SqlParameter[] { addOrderDetailParameter }, transaction).ExecuteNonQuery();
            //        conn.Prepare("[dbo].[DeleteCartDetailByCartId]", CommandType.StoredProcedure, new SqlParameter[] { deleteCartDetailByCartIdParameter }, transaction).ExecuteNonQuery();
            //        transaction.Commit();
            //    }
            //    catch (Exception)
            //    {
            //        transaction.Rollback();
            //    }
            //}

            public List<OrderDetail> Get(Guid orderId)
        {
            return _orderManagementSystemContext.OrderDetails.Where(x => x.OrderId == orderId).ToList();
        }
    }
}
