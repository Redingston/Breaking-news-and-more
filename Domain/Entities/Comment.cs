﻿using System;

namespace Domain.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
    }
}
