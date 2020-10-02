using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities
{
    public class PaymentException : Exception
    {
        public PaymentException(string message) : base(message)
        {

        }
    }
}
