using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Comment : IEntity
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public byte Rating { get; set; }
        public string UserId { get; set; }
        public string Username { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
