using System.Collections;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Tag
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

        public ICollection<NewsToTag> News { get; set; }
    }
}