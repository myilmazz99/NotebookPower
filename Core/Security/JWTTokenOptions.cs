using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Security
{
    public class JWTTokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int ExpirationInDays { get; set; }
        public string SecurityKey { get; set; }
    }
}
