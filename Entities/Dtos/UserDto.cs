using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDto
    {
        public string Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
