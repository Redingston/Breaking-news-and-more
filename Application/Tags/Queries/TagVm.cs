using System.Collections.Generic;
using Domain.Entities;

namespace Application.Tags.Queries
{
    public class TagVm
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

       // public ICollection<NewsToTag> News { get; set; }
    }
}