﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string RoleName { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }

    }
}
