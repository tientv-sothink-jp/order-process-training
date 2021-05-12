using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManagementSystem.API.Models
{
    public class DataReponse<T>
    {
        public DataReponse(int errorCode, string description, T result)
        {
            this.ErrorCode = errorCode;
            this.Description = description;
            this.Result = result;
        }

        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public T Result { get; set; }
    }
}
