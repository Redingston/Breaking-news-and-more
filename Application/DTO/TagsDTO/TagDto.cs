using System.Collections.Generic;
using Domain.Entities;

namespace Application.DTO.TagsDTO
{
    public class TagDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }

       // public ICollection<NewsToTag> News { get; set; }
    }
}