using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem.API.Helpers
{
    public class PageList<T>: List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPage;

        public PageList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            AddRange(items);
        }

        public static PageList<T> ToPageList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            int count = source.Count();
            var items = source.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToList<T>();
            return new PageList<T>(items, count, pageNumber, pageSize);
        }
    }
}
