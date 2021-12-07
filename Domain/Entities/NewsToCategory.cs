namespace Domain.Entities
{
    public class NewsToCategory
    {
        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public string NewsId { get; set; }
        public News News { get; set; }
    }
}