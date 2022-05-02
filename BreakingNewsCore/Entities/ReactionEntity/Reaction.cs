using System.Collections.Generic;
using BreakingNewsCore.Entities.NewsToReactionEntity;

namespace BreakingNewsCore.Entities.ReactionEntity
{
    public class Reaction
    {
        public string Id { get; set; }
        public uint AgreeCount { get; set; }
        public uint DisagreeCount { get; set; }

        public List<NewsToReaction> BreakingNews { get; set; }
    }
}