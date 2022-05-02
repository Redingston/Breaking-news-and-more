using System;
using System.Collections;
using System.Collections.Generic;
using BreakingNewsCore.Entities.CommentEntity;
using BreakingNewsCore.Entities.NewsToCategoryEntity;
using BreakingNewsCore.Entities.NewsToReactionEntity;
using BreakingNewsCore.Entities.NewsToTagEntity;
using BreakingNewsCore.Entities.NewsToUserEntity;

namespace BreakingNewsCore.Entities.NewsEntity
{
    public class News
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string TimeCreated { get; set; }
        public string LastTimeUpdated { get; set; }

        public List<Comment> Comments { get; set; }
        public List<NewsToCategory> Categories { get; set; }
        public List<NewsToReaction> Reactions { get; set; }
        public List<NewsToTag> Tags { get; set; }
        public List<NewsToUser> Users { get; set; }
    }
}
