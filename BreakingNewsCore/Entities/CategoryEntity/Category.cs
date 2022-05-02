using System.Collections.Generic;
using BreakingNewsCore.Entities.NewsToCategoryEntity;

namespace BreakingNewsCore.Entities.CategoryEntity
{
    public class Category
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<NewsToCategory> News { get; set; }
    }
}