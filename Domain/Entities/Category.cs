using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Category
    {
        public Category()
        {
            News = new HashSet<NewsToCategory>();
        }

        public string Id { get; set; }
        public string Name { get; set; }

        public ICollection<NewsToCategory> News { get; set; }
    }
}