using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class SqlConnectionExtension
    {
        public static SqlCommand Prepare(this SqlConnection source, string commandText, CommandType commandType, SqlParameter[] sqlParameter, SqlTransaction sqlTransaction = null)
        {
            SqlCommand cmd = new SqlCommand
            {
                Connection = source,
                CommandText = commandText,
                CommandType = commandType
            };
            if (sqlParameter != null && sqlParameter.Length > 0)
                cmd.Parameters.AddRange(sqlParameter);
            if (sqlTransaction != null)
                cmd.Transaction = sqlTransaction;
            return cmd;
        }
    }
}
