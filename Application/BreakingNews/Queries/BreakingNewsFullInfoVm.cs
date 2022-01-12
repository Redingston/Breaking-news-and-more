using System.Collections.Generic;
using Domain.Entities;

namespace Application.BreakingNews.Queries
{
    public class BreakingNewsFullInfoVm 
    {
        public string Id { get; set; }
        public string Topic { get; set; }
        public string Text { get; set; }
        public string TimeCreated { get; set; }
        public string LastTimeUpdated { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<NewsToCategory> Categories { get; set; }
        public ICollection<NewsToReaction> Reactions { get; set; }
        public ICollection<NewsToTag> Tags { get; set; }
        public ICollection<NewsToUser> Users { get; set; }
    }
}