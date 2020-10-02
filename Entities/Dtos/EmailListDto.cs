using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class EmailListDto : IDto
    {
        public string Email { get; set; }
    }
}
