﻿namespace OrderManagementSystem.API.Models
{
    public class DataReponse
    {
        //public DataReponse(int errorCode, string description, T result)
        //{
        //    this.ErrorCode = errorCode;
        //    this.Description = description;
        //    this.Result = result;
        //}

        public int ErrorCode { get; set; }
        public string Description { get; set; }
        public object Result { get; set; }
    }
}
