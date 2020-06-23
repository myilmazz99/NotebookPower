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

        public AuthException(IEnumerable<string> messages)
        {
            Messages = messages;
        }

        public IEnumerable<string> Messages { get; set; }
    }
}
