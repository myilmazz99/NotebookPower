using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Feedback : IEntity
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FeedbackText { get; set; }
        public string Name { get; set; }
    }
}
