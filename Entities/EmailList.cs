using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class EmailList : IEntity
    {
        public string Email { get; set; }
    }
}
