using FastMember;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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

        public static IQueryable<T> Paging<T>(this IQueryable<T> source, int pageIndex, int pageSize, out int pageCount)
        {
            pageCount = (int)Math.Ceiling(source.Count() / (double)pageSize);
            return source.Skip((pageIndex - 1) * pageSize).Take(pageSize);
        }
    }
}
