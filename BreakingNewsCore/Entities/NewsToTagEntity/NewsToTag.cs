using BreakingNewsCore.Entities.NewsEntity;
using BreakingNewsCore.Entities.TagEntity;

namespace BreakingNewsCore.Entities.NewsToTagEntity
{
    public class NewsToTag
    {
        public string TagId { get; set; }
        public Tag Tag { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}