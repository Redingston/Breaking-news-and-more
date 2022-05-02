using System.Collections.Generic;
using BreakingNewsCore.Entities.NewsToTagEntity;

namespace BreakingNewsCore.Entities.TagEntity
{
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public List<NewsToTag> BreakingNews { get; set; }
    }
}