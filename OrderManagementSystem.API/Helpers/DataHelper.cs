using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class DataHelper
    {
        public static DataTable ConvertListToDataTable<T>(List<T> data, string[] ColumnNames)
        {
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create(data, ColumnNames))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
