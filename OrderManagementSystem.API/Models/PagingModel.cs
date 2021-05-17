using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Models
{
    public class PagingModel
    {
        public int MaxPageSize { get; set; } = 50;
        public int PageNumber { get; set; } = 1;

        private int _PageSize = 10;
        public int PageSize
        {
            get
            {
                return _PageSize;
            }
            set
            {
                _PageSize = (value > MaxPageSize) ? MaxPageSize : value;
            }
        }
    }
}
