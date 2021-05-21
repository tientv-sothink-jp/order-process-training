using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class ListExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, string[] ColumnNames)
        {    
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create<T>(list, ColumnNames))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
