using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string ErrorType { get; set; }
        public string ErrorMessage { get; set; }
    }
}
