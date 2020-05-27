using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result
    {
        public DataResult(string message, bool success, T data) : base(message, success)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
