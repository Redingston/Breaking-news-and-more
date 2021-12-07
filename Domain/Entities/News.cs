using System;
using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class News
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }

        public ICollection<Comment> Comments { get; set; }
        public ICollection<NewsToCategory> Categories { get; set; }
        public ICollection<NewsToReaction> Reactions { get; set; }
        public ICollection<NewsToTag> Tags { get; set; }
        public ICollection<NewsToUser> Users { get; set; }

    }
}
