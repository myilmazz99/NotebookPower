﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public class CommentDto
    {
        public int Id { get; set; }
        public string CommentText { get; set; }
        public byte Rating { get; set; }
    }
}
