﻿using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UserAddress : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }

    }
}
