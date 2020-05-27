using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class UserAddress : IEntity
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Header { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }

    }
}
