using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class AuthException : Exception
    {
        public AuthException(string message) : base(message)
        {

        }
        public AuthException(IEnumerable<string> message) : base(JsonConvert.SerializeObject(message))
        {

        }
    }
}
