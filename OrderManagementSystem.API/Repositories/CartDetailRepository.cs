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
    public interface ICartDetailRepository
    {
        List<CartDetail> Get();
        List<CartDetail> GetByCartId(Guid cartId);
        CartDetail Get(Guid id);
        void Add(List<CartDetail> cartDetailItems);
        void Edit(Guid id, List<CartDetail> cartDetailItems);
        void Delete(Guid id);
    }
    public class CartDetailRepository : ICartDetailRepository
    {
        private readonly OrderManagementSystemContext _orderManagementSystemContext;

        public CartDetailRepository(OrderManagementSystemContext orderManagementSystemContext)
        {
            _orderManagementSystemContext = orderManagementSystemContext;
        }

        public void Add(List<CartDetail> cartDetailItems)
        {
            string[] columnNames = { "Id", "CartId", "ProductId", "ProductPrice", "Quantity", "CreatedTime", "UpdatedTime" };

            var cartDetailTable = new SqlParameter("@CartDetail", SqlDbType.Structured);
            cartDetailTable.Value = cartDetailItems.ToDataTable(columnNames);
            cartDetailTable.TypeName = "dbo.CartDetailType";

            SqlConnection conn = _orderManagementSystemContext.DbConnection;

            conn.Prepare("[dbo].[AddCartDetail]", CommandType.StoredProcedure, new SqlParameter[] { cartDetailTable }).ExecuteNonQuery();
            conn.Close();
        }

        public void Delete(Guid id)
        {
            CartDetail cartDetail = _orderManagementSystemContext.CartDetails.Find(id);
            _orderManagementSystemContext.CartDetails.Remove(cartDetail);
            _orderManagementSystemContext.SaveChanges();
        }

        public void Edit(Guid id, List<CartDetail> cartDetailItems)
        {
            string[] columnNames = { "Id", "CartId", "ProductId", "ProductPrice", "Quantity", "CreatedTime", "UpdatedTime" };
            var cartDetailTable = new SqlParameter("@CartDetail", SqlDbType.Structured);
            cartDetailTable.Value = cartDetailItems.ToDataTable(columnNames);
            cartDetailTable.TypeName = "dbo.CartDetailType";

            SqlParameter[] sqlParameters = new SqlParameter[2];
            sqlParameters[0] = new SqlParameter("Id", id);
            sqlParameters[1] = cartDetailTable;

            SqlConnection conn = _orderManagementSystemContext.DbConnection;
            conn.Prepare("[dbo].[EditCartDetail]", CommandType.StoredProcedure, sqlParameters).ExecuteNonQuery();
            conn.Close();
        }

        public List<CartDetail> Get()
        {
            return _orderManagementSystemContext.CartDetails.ToList();
        }

        public CartDetail Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<CartDetail> GetByCartId(Guid cartId)
        {
            return _orderManagementSystemContext.CartDetails.Where(x => x.CartId == cartId).ToList();
        }
    }
}
