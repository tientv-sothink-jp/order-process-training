using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OrderManagementSystem.API.Helpers
{
    public static class ListExtension
    {
        public static DataTable ToDataTable<T>(this IEnumerable<T> list, params string[] columnNames)
        {    
            DataTable table = new DataTable();
            using (var reader = ObjectReader.Create<T>(list, columnNames))
            {
                table.Load(reader);
            }
            return table;
        }
    }
}
