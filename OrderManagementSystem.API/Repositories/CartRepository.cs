using FastMember;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
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
    public interface ICartRepository
    {
        Cart Get(Guid userId);
 
        Guid Add(List<Cart> cartItems);
        void Edit(Guid id, List<Cart> cartItem);
        void Delete(Guid id);
    }

    public class CartRepository: ICartRepository
    {
        private OrderManagementSystemContext _orderManagementSystemContext;

        public CartRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public void Delete(Guid id)
        {
            Cart cart = _orderManagementSystemContext.Carts.Find(id);
            _orderManagementSystemContext.Carts.Remove(cart);
            _orderManagementSystemContext.SaveChanges();
        }

        public Cart Get(Guid userId)
        {
            return _orderManagementSystemContext.Carts.Where(item => item.UserId == userId).SingleOrDefault();
        }

        public Guid Add(List<Cart> cartItems)
        {
            string[] columnNames = { "Id", "UserId", "CreatedTime", "UpdatedTime" };

            var parameter = new SqlParameter("@Cart", SqlDbType.Structured);
            parameter.Value = cartItems.ToDataTable(columnNames);
            parameter.TypeName = "dbo.CartType";

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            var result = conn.Prepare("[dbo].[AddCart]", CommandType.StoredProcedure, new SqlParameter[] { parameter}).ExecuteScalar();
            return Guid.Parse(result.ToString());
        }

        public void Edit(Guid id, List<Cart> cartItems)
        {
            string[] columnNames = { "Id", "UserId", "CreatedTime", "UpdatedTime" };

            SqlParameter[] sqlParameters = new SqlParameter[2];

            var cartTableParameter = new SqlParameter("@Cart", SqlDbType.Structured);
            cartTableParameter.Value = cartItems.ToDataTable(columnNames);
            cartTableParameter.TypeName = "dbo.CartType";

            sqlParameters[0] = new SqlParameter("Id", id);
            sqlParameters[1] = cartTableParameter;

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[EditCart]", CommandType.StoredProcedure, sqlParameters).ExecuteNonQuery();
            conn.Close();
        }
    }
}
