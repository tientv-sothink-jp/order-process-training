using Microsoft.Data.SqlClient;
using OrderManagementSystem.API.Helpers;
using OrderManagementSystem.Domain.EF;
using OrderManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace OrderManagementSystem.API.Repositories
{
    public interface ICartRepository
    {
        Cart Get(Guid userId);

        Guid Add(List<Cart> cartItems);
        void Edit(Guid id, List<Cart> cartItem);
        void Delete(Guid id);
    }

    public class CartRepository : ICartRepository
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
            var cart = _orderManagementSystemContext.Carts.Where(item => item.UserId == userId).SingleOrDefault();
            if (cart == null)
            {
                cart = new Cart
                {
                    UserId = userId
                };
                _orderManagementSystemContext.Carts.Add(cart);
                _orderManagementSystemContext.SaveChanges();
            }
            return cart;
        }

        public Guid Add(List<Cart> cartItems)
        {
            var parameter = new SqlParameter()
            {
                ParameterName = "@Cart",
                SqlDbType = SqlDbType.Structured,
                Value = cartItems.ToDataTable("Id", "UserId"),
                TypeName = "dbo.CartType"
            };

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            var result = conn.Prepare("[dbo].[AddCart]", CommandType.StoredProcedure, new SqlParameter[] { parameter }).ExecuteScalar();
            return Guid.Parse(result.ToString());
        }

        public void Edit(Guid id, List<Cart> cartItems)
        {
            SqlParameter[] sqlParameters = new SqlParameter[]
            {
                new SqlParameter("Id", id),
                new SqlParameter()
                {
                    ParameterName = "@Cart",
                    SqlDbType = SqlDbType.Structured,
                    Value = cartItems.ToDataTable("Id", "UserId"),
                    TypeName = "dbo.CartType"
                }
            };

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[EditCart]", CommandType.StoredProcedure, sqlParameters).ExecuteNonQuery();
        }
    }
}
