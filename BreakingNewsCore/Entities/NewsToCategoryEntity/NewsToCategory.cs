using BreakingNewsCore.Entities.CategoryEntity;
using BreakingNewsCore.Entities.NewsEntity;

namespace BreakingNewsCore.Entities.NewsToCategoryEntity
{
    public class NewsToCategory
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}